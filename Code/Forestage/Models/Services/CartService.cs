
using Forestage.Common;
using Forestage.Models.Dtos.Carts;
using Forestage.Models.Dtos.Orders;
using Forestage.Models.Enums;
using Forestage.Models.Repositories;

namespace Forestage.Models.Services
{
	public class CartService
	{
		private readonly MemberEFRepository _memberRepo;
		private readonly CartRepository _cartRepo;
		private readonly GroupBuyingRepository _groupBuyingRepo;
		private readonly OrderRepository _orderRepo;
		private readonly FilePathHelper _filePathHelper;

		public CartService(
			MemberEFRepository memberEFRepository,
			CartRepository cartRepository,
			GroupBuyingRepository groupBuyingRepository,
			OrderRepository orderRepository,
			FilePathHelper filePathHelper
			)
		{
			_memberRepo = memberEFRepository;
			_cartRepo = cartRepository;
			_groupBuyingRepo = groupBuyingRepository;
			_orderRepo = orderRepository;
			_filePathHelper = filePathHelper;
		}
		public IEnumerable<CartInfoDto> GetCartInfo(string account)
		{
			int memberId = _memberRepo.GetMemberId(account);

			IEnumerable<CartInfoDto> cartInfoDtos = _cartRepo.GetCartInfo(memberId);
			//cartInfoDtos.Select(c => c.ProductImagePath = _filePathHelper.GetReadPath("Products", c.ProductImagePath));
			foreach (var cartInfoDto in cartInfoDtos)
			{
				cartInfoDto.ProductImagePath = _filePathHelper.GetReadPath("Products", cartInfoDto.ProductImagePath);
			}
			return cartInfoDtos;

		}

		public void UpdateItem(string? name, int cartId, int newQty)
		{
			int memberId = _memberRepo.GetMemberId(name);
			_cartRepo.UpdateItem(memberId, cartId, newQty);
		}

		public void AddToCart(string account, int productId, int qty)
		{
			int memberId = _memberRepo.GetMemberId(account);
			int activeGroupBuyingId = _groupBuyingRepo.GetActiveGroupBuyingId(productId);
			_cartRepo.AddToCart(memberId, activeGroupBuyingId, qty);
		}

		public void CheckOut(string account)
		{
			var memberId = _memberRepo.GetMemberId(account);
			var cartInfoDtos = _cartRepo.GetCartInfo(memberId);

			foreach (var cartInfoDto in cartInfoDtos)
			{
				OrderCreateDto orderCreateDto = new OrderCreateDto()
				{
					MemberId = memberId,
					GroupBuyingId = _groupBuyingRepo.GetActiveGroupBuyingId(cartInfoDto.ProductId),
					Price = cartInfoDto.GroupBuyingPrice,
					Quantity = cartInfoDto.Quantity,
					ShippingMethod = 1,
					Status = (int)OrderStatus.Participating,
					PaymentStatus = 0,
					DeliveryStatus = 0,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				};

				_orderRepo.CreateOrder(memberId, orderCreateDto);
				_cartRepo.DeleteItem(cartInfoDto.Id);
			}

		}
	}
}
