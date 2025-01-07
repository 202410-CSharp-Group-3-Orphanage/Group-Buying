using Forestage.Models.EFModels;
using Forestage.Models.Services;
using Forestage.Models.ViewModels;
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

        public IActionResult Index()
        {
            var dto = _shopService.GetShopInfo(3);
            var model = new ShopInfoVm
            {
                Name = dto.Name,
                Avatar = dto.Avatar,
                Address = dto.Address,
                qty = dto.qty
            };
            return View(model);
        }
    }
}
