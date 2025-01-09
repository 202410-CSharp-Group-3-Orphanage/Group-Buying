using Azure.Core;
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

        public ShopService(ShopRepository shopRepository, ProductRepository productRepository)
        {
            _shopRepository = shopRepository;
            _productRepository = productRepository;
        }

        public ShopInfoDto GetShopInfoWithProducts(int id, int pageNumber, SortInfo<ProductBlockDto> sortInfo)
        {
            int pageSize = 9;
            var products = _productRepository.GetProductsByShopId(id);
            int totalCount = products.Count();

            products = sortInfo.ApplySort(products.AsQueryable());

            var paginationInfo = new PaginationInfo(totalCount, pageSize, pageNumber);

            //var pagedProductQuery = productQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var productList = products.ToList();

            PagedList<ProductBlockDto, SortInfo<ProductBlockDto>> pagedList = 
                new PagedList<ProductBlockDto, SortInfo<ProductBlockDto>>(productList, pageNumber, pageSize,
                totalCount, sortInfo);

            var shop = _shopRepository.GetShopById(id);

            return new ShopInfoDto
            {
                Name = shop.Name,
                Address = shop.Address,
                Avatar = shop.Avatar,
                ProductCount = totalCount,
                //Products = pagedList
            };
        }
    }
}
