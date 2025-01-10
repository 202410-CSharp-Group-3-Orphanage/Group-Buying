using Azure.Core;
using Forestage.Common;
using Forestage.Models.Dtos.Products;
using Forestage.Models.Dtos.Shops;
using Forestage.Models.EFModels;
using Forestage.Models.Repositories;
using Forestage.Models.ViewModels.Paging;
using Forestage.Models.ViewModels.Products;
using Forestage.Models.ViewModels.Shops;
using Forestage.Models.ViewModels.Sort;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Forestage.Models.Services
{
    public class ShopService
    {
        private readonly ShopRepository _shopRepository;
        private readonly ProductRepository _productRepository;
        private readonly FilePathHelper _filePathHelper;

        public ShopService(ShopRepository shopRepository, ProductRepository productRepository, FilePathHelper filePathHelper)
        {
            _shopRepository = shopRepository;
            _productRepository = productRepository;
            _filePathHelper = filePathHelper;
        }

        public ShopInfoDto GetShopInfoWithProducts(int id, int pageNumber, SortInfo<ProductBlockDto> sortInfo)
        {
            int pageSize = 9;
            var productBlockDto = _productRepository.GetProductsByShopId(id).ToList();
            int totalCount = productBlockDto.Count();

            productBlockDto = sortInfo.ApplySort(productBlockDto.AsQueryable()).ToList();

            foreach (var product in productBlockDto)
            {
                product.ImagePaths = product.ImagePaths
                    .Select(x => _filePathHelper.GetReadPath("Products", x))
                    .ToList();
                product.ProductLink = $"/Products/Details/{product.Id}";
                Console.WriteLine($"Product ID: {product.Id}, ProductLink: {product.ProductLink}");
        }

            var paginationInfo = new PaginationInfo(totalCount, pageSize, pageNumber);

            var pagedProducts = paginationInfo.GetPagedData(productBlockDto);

            var productList = pagedProducts.ToList();

            PagedList<ProductBlockDto, SortInfo<ProductBlockDto>> pagedList =
                new PagedList<ProductBlockDto, SortInfo<ProductBlockDto>>(productList, pageNumber, pageSize,
                totalCount, sortInfo);

            var shop = _shopRepository.GetShopById(id);
            shop.Avatar = _filePathHelper.GetReadPath("Shops", shop.Avatar);

            return new ShopInfoDto
            {
                Name = shop.Name,
                Address = shop.Address,
                Avatar = shop.Avatar,
                ProductCount = totalCount,
                Products = pagedList
            };
        }
    }
}
