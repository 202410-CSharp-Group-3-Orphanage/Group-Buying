using Forestage.Models.Dtos.Products;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using MT.Utilities.Mapper;

namespace Forestage.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        //[Route("/Products/{id}")]
        //[HttpGet]
        //public IActionResult Details(int id)
        //{
        //    ProductBlockVm productBlockVm = ObjectMapper
        //        .Map<ProductBlockDto, ProductBlockVm>(_productService.Get(id));
        //    return View(productBlockVm);
        //}

        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();

            try
            {
                ProductInfoDto productInfoDto = _productService.Get(id.Value);
                ProductInfoVm productInfoVm = ObjectMapper.Map<ProductInfoDto, ProductInfoVm>(productInfoDto);
                ViewBag["ProductUrl"] = Url.Action("Index", "Products", new { id = productInfoVm.Id });
                return View(productInfoVm);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
        }
    }
}
