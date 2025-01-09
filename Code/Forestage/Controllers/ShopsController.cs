using System.Drawing.Printing;
using Forestage.Models.Dtos.Products;
using Forestage.Models.EFModels;
using Forestage.Models.Services;
using Forestage.Models.ViewModels;
using Forestage.Models.ViewModels.Paging;
using Forestage.Models.ViewModels.Products;
using Forestage.Models.ViewModels.Shops;
using Forestage.Models.ViewModels.Sort;
using Microsoft.AspNetCore.Mvc;

namespace Forestage.Controllers
{
    public class ShopsController : Controller
    {
        private readonly ShopService _shopService;

        public ShopsController(ShopService shopService)
        {
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id, int pageNumber = 1, string ColumnName = "CreatedAt", string Direction = "Asc")
        {
            if (id <= 0)
            {
                return BadRequest("無效的商家 ID");
            }

            var sortInfo = new SortInfo<ProductBlockDto>(ColumnName, Direction);

            var shopInfoDto = _shopService.GetShopInfoWithProducts(id, pageNumber, sortInfo);

            if(shopInfoDto == null)
            {
                return NotFound("找不到該商家");
            }

            var model = new ShopInfoVm
            {
                Name = shopInfoDto.Name,
                Avatar = shopInfoDto.Avatar,
                Address = shopInfoDto.Address,
                ProductCount = shopInfoDto.ProductCount,
                //Products = shopInfoDto.Products
            };

            return View(model);
        }
    }
}
