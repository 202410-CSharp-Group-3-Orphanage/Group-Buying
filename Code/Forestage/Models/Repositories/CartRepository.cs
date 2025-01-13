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
            var cartInfoDtos = _context.Carts
                .Include(c => c.GroupBuying)
                .ThenInclude(g => g.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(c => c.MemberId == memberId)
                .Select(c => new CartInfoDto
                {
                    Id = c.Id,
                    ProductId = c.GroupBuying.ProductId,
                    ProductName = c.GroupBuying.Product.Name,
                    ProductImagePath = c.GroupBuying.Product.ProductImages.First().Path,
                    ProductLink = $"/Products/Details/{c.GroupBuying.Product.Id}",
                    Quantity = c.Quantity,
                    GroupBuyingPrice = c.GroupBuying.Price,
                })
                .ToList();
            if (cartInfoDtos == null) return null;

            return cartInfoDtos;

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

        public void AddToCart(int memberId, int groupBuyingId, int qty)
        {
            var cart = _context.Carts.SingleOrDefault(c => c.MemberId == memberId && c.GroupBuyingId == groupBuyingId);

            if (cart == null)
            {
                _context.Carts.Add(new Cart
                {
                    MemberId = memberId,
                    GroupBuyingId = groupBuyingId,
                    Quantity = qty,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            }
            else
            {
                cart.Quantity += qty;
            }

            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var cart = _context.Carts.Find(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
        }
    }
}
