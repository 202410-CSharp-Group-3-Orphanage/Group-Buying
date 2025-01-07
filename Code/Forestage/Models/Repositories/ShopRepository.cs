using Forestage.Models.Dtos.Shops;
using Forestage.Models.EFModels;

namespace Forestage.Models.Repositories
{
    public class ShopRepository
    {
        private readonly AppDbContext _context;
        public ShopRepository(AppDbContext context)
        {
            _context = context;
        }
        public ShopInfoDto GetById(int id)
        {
            var shop = _context.Shops.Find(id);
            var shopDto = new ShopInfoDto
            {
                Name = shop.Name,
                Avatar = shop.Avatar,
                Address = shop.Address,
                qty = _context.Products.Count(x => x.ShopId == shop.Id),
                Products = shop.Products
            };
            return shopDto;
        }
    }
}
