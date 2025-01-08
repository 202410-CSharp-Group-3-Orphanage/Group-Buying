using Forestage.Models.EFModels;
using Forestage.Models.Services;
using Forestage.Models.ViewModels;
using Forestage.Models.ViewModels.Paging;
using Forestage.Models.ViewModels.Products;
using Forestage.Models.ViewModels.Shops;
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

        [HttpGet]
        public IActionResult Details(int id, int pageNumber = 1, string ColumnName = "CreatedAt", string Direction = "Asc")
        {
            if (id <= 0)
            {
                return BadRequest("無效的商家 ID");
            }

            var shopInfoDto = _shopService.GetShopInfo(id);

            if(shopInfoDto == null)
            {
                return NotFound("找不到該商家");
            }

            var model = new ShopInfoVm
            {
                Name = shopInfoDto.Name,
                Avatar = shopInfoDto.Avatar,
                Address = shopInfoDto.Address,
                ProductCount = shopInfoDto.ProductCount
            };

            int pageSize = 9;
            pageNumber = string.IsNullOrEmpty(Request.Query["page"]) ? 1 : int.Parse(Request.Query["page"]);

            var productQuery = _shopService.GetProductsByShopId(id);
            int totalCount = productQuery.Count();

            PaginationInfo paginationInfo = new PaginationInfo(totalCount, pageSize, pageNumber);

            productQuery = model.SortInfo.ApplySort(productQuery);

            var pagedProductQuery = productQuery.Skip((paginationInfo.PageNumber - 1) * paginationInfo.PageSize)
                .Take(paginationInfo.PageSize);

            List<ProductBlockVm> productList = pagedProductQuery.Select(p => new ProductBlockVm
            {
                Id = p.Id,
                ProductName = p.Name,
                ProductPrice = p.Price,
                CreatedAt = p.CreatedAt
            }).ToList();

            PagedList<ProductBlockVm> pagedList = new PagedList<ProductBlockVm>(productList, paginationInfo.PageNumber, 
                paginationInfo.PageSize, totalCount, model.SortInfo.ColumnName, model.SortInfo.Direction);

            ViewBag.PaginationInfo = paginationInfo;

            return View(pagedList);
        }
    }
}
