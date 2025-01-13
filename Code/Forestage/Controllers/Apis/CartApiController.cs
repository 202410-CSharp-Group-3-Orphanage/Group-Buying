using Forestage.Models.Services;
using Forestage.Models.ViewModels.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forestage.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartApiController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("AddItem")]
        [Authorize]
        public IActionResult AddItem([FromBody] CartAddItemVm addItemVm)
        {
            int productId = addItemVm.ProductId;
            int quantity = addItemVm.Quantity;
            try
            {
                _cartService.AddToCart(User.Identity.Name, productId, quantity);
                return Ok(new { status = "success", message = "Item added to cart successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CheckOut")]
        [Authorize]
        public IActionResult CheckOut()
        {
            try
            {

                _cartService.CheckOut(User.Identity.Name);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
