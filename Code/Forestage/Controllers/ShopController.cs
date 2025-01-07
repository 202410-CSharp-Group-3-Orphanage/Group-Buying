using Forestage.Models.EFModels;
using Forestage.Models.Services;
using Forestage.Models.ViewModels;
using Forestage.Models.ViewModels.Shops;
using Microsoft.AspNetCore.Mvc;

namespace Forestage.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [Route("Shop/Index/{id}")]
        public IActionResult Index(int id)
        {
            if(id <= 0)
            {
                return BadRequest("無效的商家 ID");
            }

            var dto = _shopService.GetShopInfo(id);

            if(dto == null)
            {
                return NotFound("找不到該商家");
            }

            var model = new ShopInfoVm
            {
                Name = dto.Name,
                Avatar = dto.Avatar,
                Address = dto.Address,
                ProductCount = dto.ProductCount
            };

            return View(model);
        }
    }
}
