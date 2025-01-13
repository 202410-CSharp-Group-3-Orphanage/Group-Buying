using Forestage.Models.Dtos.Carts;
using Forestage.Models.EFModels;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using MT.Utilities.Mapper;

namespace Forestage.Models.Repositories
{
    public class CartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IEnumerable<CartInfoDto> GetCartInfo(int memberId)
        {
            var cartInfoDto = _context.Carts
                .Include(c => c.GroupBuying)
                .ThenInclude(g => g.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(c => c.MemberId == memberId)
                .Select(c => new CartInfoDto
                {
                    Id = c.Id,
                    ProductName = c.GroupBuying.Product.Name,
                    ProductImagePath = c.GroupBuying.Product.ProductImages.First().Path,
                    ProductLink = $"/Products/Details/{c.GroupBuying.Product.Id}",
                    Quantity = c.Quantity,
                    GroupBuyingPrice = c.GroupBuying.Price,
                })
                .ToList();
            if (cartInfoDto == null) return null;

            return cartInfoDto;

        }

        public void UpdateItem(int memberId, int cartId, int newQty)
        {
            var cart = _context.Carts.Single(c => c.Id == cartId);

            if (newQty == 0)
            {
                _context.Carts.Remove(cart);
            }
            else
            {
                cart.Quantity = newQty;
            }

            _context.SaveChanges();
        }
    }
}
