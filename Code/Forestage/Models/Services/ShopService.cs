using Forestage.Models.Dtos.Shops;
using Forestage.Models.EFModels;
using Forestage.Models.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Forestage.Models.Services
{
    public interface IShopService
    {
        IQueryable<Product> GetProductsByShopId(int id);
    }
    public class ShopService : IShopService
    {
        private readonly ShopRepository _shopRepository;
        private readonly IProductRepository _productRepository;

        public ShopService(ShopRepository shopRepository, IProductRepository productRepository)
        {
           _shopRepository = shopRepository;
           _productRepository = productRepository;
        }

        public IQueryable<Product> GetProductsByShopId(int id)
        {
            return _productRepository.GetProductsByShopId(id);
        }

        public ShopInfoDto GetShopInfo(int id)
        {
            var shop = _shopRepository.GetShopById(id);

            if(shop == null)
            {
                return null;
            }

            var ProductCount = _shopRepository.GetProductCountByShopId(id);

            return new ShopInfoDto
            {
                Name = shop.Name,
                Avatar = shop.Avatar,
                Address = shop.Address,
                ProductCount = ProductCount
            };
        }
    }

    public class SortInfo
    {
        public IQueryable<Product> ApplySort(IQueryable<Product> data)
        {
            switch (this.ColumnName)
            {
                case EnumColumn.CreatedAt:
                    return (this.Direction == EnumDirection.Asc)
                        ? data.OrderBy(t => t.UpdatedAt) : data.OrderByDescending(t => t.CreatedAt);

                case EnumColumn.Price:
                    return (this.Direction == EnumDirection.Asc)
                        ? data.OrderBy(t => t.Price) : data.OrderBy(t => t.Price);
            }

            return data;
        }

        public SortInfo(string columnName, string direction)
        {   
            this.ColumnName = Enum.TryParse(columnName, out EnumColumn colValue) ? colValue : EnumColumn.CreatedAt;

            this.Direction = Enum.TryParse(direction, out EnumDirection directionValue)
                ? directionValue
                : EnumDirection.Asc;
        }


        public string UrlTemplate { get; set; }

        public string GetQueryString()
        {
            string template = "ColumnName={0}&Direction={1}";
            return string.Format(template, this.ColumnName, this.Direction);
        }

        public EnumColumn ColumnName { get; set; }
        public EnumDirection Direction { get; set; }

        public enum EnumColumn
        {
            CreatedAt, Price
        }

        public enum EnumDirection
        {
            Asc, Desc
        }
    }
}
