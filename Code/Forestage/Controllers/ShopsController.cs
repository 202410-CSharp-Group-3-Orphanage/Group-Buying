using System.Drawing.Printing;
using Forestage.Models.Dtos.Products;
using Forestage.Models.EFModels;
using Forestage.Models.Infra;
using Forestage.Models.Services;
using Forestage.Models.ViewModels;
using Forestage.Models.ViewModels.Products;
using Forestage.Models.ViewModels.Shops;
using Microsoft.AspNetCore.Mvc;

namespace Forestage.Controllers
{
	public class ShopsController : Controller
	{
		private readonly ShopService _shopService;
		private readonly AppDbContext _context;

		public ShopsController(ShopService shopService, AppDbContext context)
		{
			_shopService = shopService;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details(int id, int pageNumber = 1, string SortOption = "")
		{
			var shop = _context.Shops.SingleOrDefault(x => x.Id == id && x.Status == 1);

			if (id <= 0 || shop == null)
			{
				return View("NotFound");
			}

			string columnName = "CreatedAt";
			string direction = "Desc";

			if (!string.IsNullOrEmpty(SortOption))
			{
				string[] parts = SortOption.Split('-');
				if (parts.Length == 2)
				{
					columnName = parts[0];
					direction = parts[1];
				}
			}

			ViewBag.SortOption = SortOption;

			var sortInfo = new SortInfo<ProductBlockDto>(columnName, direction);

			var shopInfoDto = _shopService.GetShopInfoWithProducts(id, pageNumber, sortInfo);

			if (shopInfoDto == null)
			{
				return View("NotFound");
			}

			var productVms = shopInfoDto.Products.Items.Select(p => new ProductBlockVm
			{
				Id = p.Id,
				ProductName = p.ProductName,
				ProductPrice = p.ProductPrice,
				ImagePaths = p.ImagePaths,
				ProductLink = p.ProductLink,
				CreatedAt = p.CreatedAt
			}).ToList();

			var model = new ShopInfoVm
			{
				Name = shopInfoDto.Name,
				Avatar = shopInfoDto.Avatar,
				Address = shopInfoDto.Address,
				ProductCount = shopInfoDto.ProductCount,
				Products = new PagedList<ProductBlockVm, SortInfo<ProductBlockDto>>(productVms, pageNumber, shopInfoDto.Products.PageSize, shopInfoDto.Products.TotalCount, sortInfo),
				PageNumber = pageNumber,
				TotalPages = shopInfoDto.Products.TotalPages,
			};

			return View(model);
		}
	}
}
