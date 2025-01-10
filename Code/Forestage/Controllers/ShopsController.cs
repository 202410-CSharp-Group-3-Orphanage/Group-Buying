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

        public IActionResult Details(int id, int pageNumber = 1, string SortOption = "")
        {
            if (id <= 0)
            {
                return BadRequest("無效的商家 ID");
            }

            string columnName = "CreatedAt"; 
            string direction = "Desc";      

            if (!string.IsNullOrEmpty(SortOption))
            {
                string[] parts = SortOption.Split('-');
                if (parts.Length == 2)
                {
                    columnName = parts[0];
                    direction = parts[1];
                }
            }

            ViewBag.SortOption = SortOption;

            var sortInfo = new SortInfo<ProductBlockDto>(columnName, direction);

            var shopInfoDto = _shopService.GetShopInfoWithProducts(id, pageNumber, sortInfo);

            if(shopInfoDto == null)
            {
                return NotFound("找不到該商家");
            }

            var productVms = shopInfoDto.Products.Items.Select(p => new ProductBlockVm 
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                ImagePaths = p.ImagePaths,
                ProductLink = p.ProductLink,
                CreatedAt = p.CreatedAt
            }).ToList();

            var model = new ShopInfoVm
            {
                Name = shopInfoDto.Name,
                Avatar = shopInfoDto.Avatar,
                Address = shopInfoDto.Address,
                ProductCount = shopInfoDto.ProductCount,
                Products = new PagedList<ProductBlockVm, SortInfo<ProductBlockDto>>(productVms, pageNumber, shopInfoDto.Products.PageSize, shopInfoDto.Products.TotalCount, sortInfo),
                PageNumber = pageNumber,
                TotalPages = shopInfoDto.Products.TotalPages,
            };

            return View(model);
        }
    }
}
