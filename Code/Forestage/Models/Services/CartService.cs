
using Forestage.Models.Dtos.Carts;
using Forestage.Models.Repositories;

namespace Forestage.Models.Services
{
    public class CartService
    {
        private readonly MemberEFRepository _memberRepo;
        private readonly CartRepository _cartRepo;

        public CartService(MemberEFRepository memberEFRepository, CartRepository cartRepository)
        {
            _memberRepo = memberEFRepository;
            _cartRepo = cartRepository;
        }
        public IEnumerable<CartInfoDto> GetCartInfo(string? account)
        {
            int memberId = _memberRepo.GetMemberId(account);

            IEnumerable<CartInfoDto> cartInfoDtos = _cartRepo.GetCartInfo(memberId);
            return cartInfoDtos;

        }

        public void UpdateItem(string? name, int cartId, int newQty)
        {
            int memberId = _memberRepo.GetMemberId(name);
            _cartRepo.UpdateItem(memberId, cartId, newQty);
        }
    }
}
