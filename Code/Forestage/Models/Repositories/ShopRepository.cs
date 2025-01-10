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
        public Shop GetShopById(int id)
        {
            return _context.Shops.Find(id);
        }
    }
}
