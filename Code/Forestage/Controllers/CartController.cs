using Forestage.Models.Dtos.Carts;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MT.Utilities.Mapper;

namespace Forestage.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var cartInfoDto = _cartService.GetCartInfo(User.Identity.Name);
            IEnumerable<CartInfoVm> cartInfoVms = ObjectMapper.MapCollection<CartInfoDto, CartInfoVm>(cartInfoDto);
            return View(cartInfoVms);
        }

        [Authorize]
        public IActionResult GetCartInfo()
        {
            var cartInfoDto = _cartService.GetCartInfo(User.Identity.Name);
            IEnumerable<CartInfoVm> cartInfoVms = ObjectMapper.MapCollection<CartInfoDto, CartInfoVm>(cartInfoDto);
            return Json(cartInfoVms);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateItem(int cartId, int newQty)
        {
            newQty = newQty < 0 ? 0 : newQty;
            _cartService.UpdateItem(User.Identity.Name, cartId, newQty);


            return Json(_cartService.GetCartInfo(User.Identity.Name));
        }
    }
}
