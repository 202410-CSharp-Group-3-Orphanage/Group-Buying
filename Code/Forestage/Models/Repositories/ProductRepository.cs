using Dapper;
using Forestage.Models.Dtos.GroupBuyings;
using Forestage.Models.Dtos.Orders;
using Forestage.Models.Dtos.Products;
using Forestage.Models.EFModels;
using Forestage.Models.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MT.SQL;
using MT.Utilities.Mapper;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Forestage.Models.Repositories
{
	public class ProductRepository
	{
		private readonly AppDbContext _context;
		private readonly SqlConnection _sqlConnection;

		public ProductRepository(AppDbContext context, SqlConnection sqlConnection)
		{
			_context = context;
			_sqlConnection = sqlConnection;
		}
		public IEnumerable<Product> GetProducts()
		{
			return _context.Products;
		}

		public ProductInfoDto Get(int id)
		{
			var product = _context.Products
				.AsNoTracking()
				.Include(p => p.Category)
				.Include(p => p.Shop)
				.Include(p => p.ProductImages)
				.Include(p => p.GroupBuyings)
				.ThenInclude(g => g.Orders)
				.FirstOrDefault(p => p.Id == id);
			if (product == null)
			{
				throw new ArgumentException("找不到商品");
			}
			var productInfoDto = ObjectMapper.Map<Product, ProductInfoDto>(product);
			return productInfoDto;

			//ProductInfoDto productInfoDto = new ProductInfoDto
			//{
			//    Id = product.Id,
			//    Name = product.Name,
			//    Price = product.Price,
			//    Info = product.Info
			//};

			//product.GroupBuyings = product.GroupBuyings.Where(gb => gb.Enabled).ToList();
			//if (product.GroupBuyings.SingleOrDefault(g => g.Enabled) != null)
			//{
			//    var groupBuying = product.GroupBuyings.SingleOrDefault(g => g.Enabled);
			//    productInfoDto.GroupBuyings = new GroupBuyingInfoDto
			//    {

			//        //Price = product.GroupBuyings.First(gb => gb.Enabled)?.Price ?? null,
			//        //MinimumGroupSize = product.GroupBuyings.SingleOrDefault(gb => gb.Enabled)?.MinimumGroupSize ?? null
			//        Price = groupBuying.Price,
			//        MinimumGroupSize = groupBuying.MinimumGroupSize,
			//        Description = groupBuying.Description,
			//        StartDate = groupBuying.StartDate,
			//        EndDate = groupBuying.EndDate,
			//        Orders = groupBuying.Orders.Select(o => new OrderInfoDto { Quantity = o.Quantity }).ToList()
			//    };
			//}

			//return productInfoDto;
		}

		public IEnumerable<ProductBlockDto> GetBestProducts()
		{
			//SELECT p.Id,
			//       MAX(p.Name) AS ProductName,
			//       MAX(c.Name) AS CategoryName,
			//       SUM(o.Quantity) AS total
			//FROM Products p
			//    JOIN Categories c ON p.CategoryId = c.Id
			//    JOIN GroupBuyings gb ON gb.ProductId = p.Id
			//        AND gb.Enabled = 1
			//    JOIN Orders o ON o.GroupBuyingId = gb.Id
			//        AND o.Status = 5
			//GROUP BY p.Id
			//ORDER BY total DESC;

			int numOfBestProducts = 5;
			var sql = $@"
SELECT p.Id,
       p.Name AS ProductName,
       c.Name AS CategoryName,
       p.Info,
       p.Price AS ProductPrice,
       g.Price AS GroupBuyingPrice,
       pImg.Path AS ImagePath
FROM Products p
JOIN Categories c ON p.CategoryId = c.Id
JOIN GroupBuyings g ON p.Id = g.ProductId
LEFT OUTER JOIN ProductImages pImg ON p.Id = pImg.ProductId
JOIN
    (SELECT top({numOfBestProducts}) p.Id,
            SUM(o.Quantity) AS total
     FROM Products p
     JOIN Categories c ON p.CategoryId = c.Id
     JOIN GroupBuyings gb ON gb.ProductId = p.Id
     AND gb.Enabled = 1
     JOIN Orders o ON o.GroupBuyingId = gb.Id
     AND o.Status = {(int)OrderStatus.PickedUp}
     AND o.CreatedAt >= DATEADD(MONTH, -1, GETDATE())
     GROUP BY p.Id
     ORDER BY total DESC) t ON p.Id = t.Id
            ";
			var productDict = new Dictionary<int, ProductBlockDto>();

			var result = _sqlConnection.Query<ProductBlockDto,
				string, ProductBlockDto>(
					sql,
					(product, imagePath) =>
					{
						if (!productDict.TryGetValue(product.Id, out
								var productDto))
						{
							productDto = product;
							productDto.ImagePaths = new List<string>();
							productDict[product.Id] = productDto;
						}

						if (!string.IsNullOrEmpty(imagePath))
						{
							productDto.ImagePaths.Add(imagePath);
						}

						return productDto;
					},
					splitOn: "ImagePath"
				);

			return productDict.Values.ToList();
		}

		public IEnumerable<ProductBlockDto> GetNewProducts()
		{
			//SELECT*
			//FROM Products p
			//JOIN GroupBuyings gb ON gb.ProductId = p.Id and gb.Enabled = 1
			//order by p.CreatedAt desc
			var query = _context.Products
				.AsNoTracking()
				.Include(p => p.GroupBuyings)
				.Include(p => p.ProductImages)
				.Include(p => p.Category)
				.Where(p => p.GroupBuyings.Any(gb => gb.Enabled))
				.OrderByDescending(p => p.CreatedAt)
				.ToList();

			var result = query.Select(p => new ProductBlockDto
			{
				Id = p.Id,
				ProductName = p.Name,
				CategoryName = p.Category.Name,
				Info = p.Info,
				ProductPrice = p.Price,
				GroupBuyingPrice = p.GroupBuyings.FirstOrDefault()?.Price ?? null,
				ImagePaths = p.ProductImages.Select(pi => pi.Path).ToList()
			});

			return result;
		}

		public IEnumerable<ProductBlockDto> GetUpcomingProducts()
		{
			//SELECT *,
			//       CAST(o.Quantity AS FLOAT) / CAST(gb.MinimumGroupSize AS FLOAT) AS CurrentParticipants
			//FROM Products p
			//JOIN GroupBuyings gb ON p.Id = gb.ProductId
			//JOIN Orders o ON gb.Id = o.GroupBuyingId
			//AND gb.Enabled = 1
			//AND o.Status = 1
			//WHERE DATEDIFF(DAY, GETDATE(), gb.EndDate) BETWEEN 0 AND 3
			//ORDER BY CurrentParticipants DESC,
			//         gb.EndDate;
			var today = DateTime.Now;
			var query = _context.Products
				.AsNoTracking()
				.Include(p => p.ProductImages)
				.Include(p => p.Category)
				.Join(
					_context.GroupBuyings.Where(gb => gb.Enabled),
					p => p.Id,
					gb => gb.ProductId,
					(p, gb) => new { p, gb }
				)
				.Join(
					_context.Orders.Where(o => o.Status == (int)OrderStatus.Participating),
					pg => pg.gb.Id,
					o => o.GroupBuyingId,
					(pg, o) => new
					{
						pg.p,
						pg.gb,
						o,
						CurrentParticipants = (float)o.Quantity / pg.gb.MinimumGroupSize
					}
				)
				.Where(x => EF.Functions.DateDiffDay(today, x.gb.EndDate) >= 0
						 && EF.Functions.DateDiffDay(today, x.gb.EndDate) <= 3)
				.OrderByDescending(x => x.CurrentParticipants)
				.ThenBy(x => x.gb.EndDate)
				.ToList();

			var result = query.Select(x => new ProductBlockDto
			{
				Id = x.p.Id,
				ProductName = x.p.Name,
				CategoryName = x.p.Category.Name,
				Info = x.p.Info,
				ProductPrice = x.p.Price,
				GroupBuyingPrice = x.gb.Price,
				ImagePaths = x.p.ProductImages.Select(pi => pi.Path).ToList()
			});

			return result;
		}

		public IEnumerable<ProductBlockDto> GetProductsByShopId(int shopId)
		{
			var query = _context.Products
				.AsNoTracking()
				.Include(p => p.ProductImages)
				.Where(p => p.ShopId == shopId).ToList();

			var result = query.Select(x => new ProductBlockDto
			{
				Id = x.Id,
				ProductName = x.Name,
				ProductPrice = x.Price,
				ImagePaths = x.ProductImages.Select(i => i.Path).ToList(),
				CreatedAt = x.CreatedAt
			});

            return result;
        }
        public IEnumerable<ProductBlockDto> GetSearchProducts()
        {
            var query = _context.Products
                .AsNoTracking()
                .Include(p => p.ProductImages)
                .Include(p => p.Category).ToList();

            var result = query.Select(x => new ProductBlockDto
            {
                Id = x.Id,
                ProductName = x.Name,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                ProductPrice = x.Price,
                ImagePaths = x.ProductImages.Select(i => i.Path).ToList(),
                CreatedAt = x.CreatedAt
            });

            return result;
        }
        public IEnumerable<CategoryDto> GetCategories()
        {
            var query = _context.Products
                .Join( 
                    _context.Categories,
                    p => p.CategoryId,
                    c => c.Id, 
                    (p, c) => new { p.CategoryId, c.Name } 
                )
                .GroupBy(pc => new { pc.CategoryId, pc.Name }) 
                .Select(g => new 
                {
                    g.Key.CategoryId,
                    CategoryName = g.Key.Name,
                    ProductCount = g.Count()
                })
                .ToList();

            return query.Select(x => new CategoryDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                ProductCount = x.ProductCount
            });
        }
    }

}