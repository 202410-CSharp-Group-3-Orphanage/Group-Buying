using Forestage.Common;
using Forestage.Models.Dtos.Products;
using Forestage.Models.Enums;
using Forestage.Models.Infra;
using Forestage.Models.Repositories;
using MT.Extensions;

namespace Forestage.Models.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;
        private readonly FilePathHelper _filePathHelper;

        public ProductService(ProductRepository productRepository, FilePathHelper filePathHelper)
        {
            _productRepo = productRepository;
            _filePathHelper = filePathHelper;
        }
        public IEnumerable<ProductBlockDto> GetBestProducts()
        {
            int limit = 5;
            int imgLimit = 1;
            IEnumerable<ProductBlockDto> productIndexDtos = _productRepo.GetBestProducts();
            productIndexDtos = productIndexDtos
                .Select(x =>
                {
                    x.ImagePaths = x.ImagePaths.Take(imgLimit).ToList();
                    x.Info = x.Info.Truncate(20, true);
                    return x;
                });
            productIndexDtos = productIndexDtos.Take(limit);
            return productIndexDtos;
        }

        public IEnumerable<ProductBlockDto> GetNewProducts()
        {
            int limit = 6;
            int imgLimit = 1;
            IEnumerable<ProductBlockDto> productIndexDtos = _productRepo.GetNewProducts();
            productIndexDtos = productIndexDtos
                .Select(x =>
                {
                    x.ImagePaths = x.ImagePaths.Take(imgLimit).ToList();
                    x.Info = x.Info.Truncate(20, true);
                    return x;
                });
            productIndexDtos = productIndexDtos.Take(limit);
            return productIndexDtos;
        }
        public IEnumerable<ProductBlockDto> GetUpcomingProducts()
        {
            int limit = 10;
            int imgLimit = 2;
            IEnumerable<ProductBlockDto> productIndexDtos = _productRepo.GetUpcomingProducts();
            productIndexDtos = productIndexDtos
                .Select(x =>
                {
                    x.ImagePaths = x.ImagePaths.Take(imgLimit).ToList();
                    x.Info = x.Info.Truncate(20, true);
                    return x;
                });
            productIndexDtos = productIndexDtos.Take(limit);
            return productIndexDtos;
        }
        public ProductInfoDto Get(int id)
        {
            try
            {
                ProductInfoDto productInfoDto = _productRepo.Get(id);

                // 商品資訊
                productInfoDto.ImagePaths = productInfoDto.ProductImages
                    .Select(x => _filePathHelper.GetReadPath("Products", x.Path))
                    .ToList();

                // 商家資訊
                productInfoDto.ShopName = productInfoDto.Shop.Name;
                productInfoDto.ShopAvatar = _filePathHelper.GetReadPath("Shops", productInfoDto.Shop.Avatar);
                productInfoDto.ShopLink = $"/Shops/Details/{productInfoDto.Shop.Id}";


                // 先取得有效的團購
                var groupBuyings = productInfoDto.GroupBuyings.LastOrDefault(g => g.Enabled);
                if (groupBuyings != null)
                {
                    productInfoDto.Participants = groupBuyings.Orders
                        .Where(o => o.Status == (int)OrderStatus.Participating)
                        .Sum(o => o.Quantity);
                    productInfoDto.MinimumGroupSize = groupBuyings.MinimumGroupSize;
                    productInfoDto.EndDate = groupBuyings.EndDate;
                    productInfoDto.GroupBuyingPrice = groupBuyings.Price;
                    productInfoDto.Description = groupBuyings.Description;
                }

                return productInfoDto;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public ProductSearchDto GetSearchProducts(int pageNumber, SortInfo<ProductBlockDto> sortInfo, Criteria criteria)
        {
            int pageSize = 9;
            var productBlockDto = _productRepo.GetSearchProducts().ToList();

            var categoriesDto = _productRepo.GetCategories().ToList();

            productBlockDto = criteria.ApplyCriteria(productBlockDto.AsQueryable()).ToList();

            int totalCount = productBlockDto.Count();

            productBlockDto = sortInfo.ApplySort(productBlockDto.AsQueryable()).ToList();

            foreach (var product in productBlockDto)
            {
                product.ImagePaths = product.ImagePaths
                    .Select(x => _filePathHelper.GetReadPath("Products", x))
                    .ToList();
                product.ProductLink = $"/Products/Details/{product.Id}";
            }

            var paginationInfo = new PaginationInfo(totalCount, pageSize, pageNumber);

            var pagedProducts = paginationInfo.GetPagedData(productBlockDto);

            var productList = pagedProducts.ToList();

            PagedList<ProductBlockDto, SortInfo<ProductBlockDto>> pagedList =
                new PagedList<ProductBlockDto, SortInfo<ProductBlockDto>>(productList, pageNumber, pageSize,
                totalCount, sortInfo);

            return new ProductSearchDto
            {
                CategoryId = criteria.CategoryId,
                ProductCount = totalCount,
                MinPrice = criteria.MinPrice,
                MaxPrice = criteria.MaxPrice,
                SearchKeyword = criteria.SearchKeyword,
                categories = categoriesDto,
                SearchProducts = pagedList
            };

        }
    }
}