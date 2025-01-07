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
            return _shopRepository.GetById(id);
        }
    }
}
