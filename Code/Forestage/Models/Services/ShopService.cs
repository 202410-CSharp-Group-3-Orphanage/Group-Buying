using Forestage.Models.Dtos.Shops;
using Forestage.Models.EFModels;
using Forestage.Models.Repositories;

namespace Forestage.Models.Services
{
    public class ShopService
    {
        private readonly ShopRepository _shopRepository;

        public ShopService(ShopRepository shopRepository)
        {
           _shopRepository = shopRepository;
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
}
