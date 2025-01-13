using Forestage.Models;
using Forestage.Models.Dtos;
using Forestage.Models.EFModels;
using Forestage.Models.ViewModels;
using Forestage.Models.Services;
using Forestage.Models.EFModels;
using Forestage.Models.Enums;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Homes;
using Forestage.Models.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;
using MT.Utilities.Mapper;
using Forestage.Models.Dtos.Products;

namespace Forestage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var bestProducts = _productService.GetBestProducts();
            var newProducts = _productService.GetNewProducts();
            var upcomingProducts = _productService.GetUpcomingProducts();
            var indexVm = new IndexVm
            {
                BestProducts = ObjectMapper.MapCollection<ProductBlockDto, ProductBlockVm>(bestProducts).ToList(),
                NewProducts = ObjectMapper.MapCollection<ProductBlockDto, ProductBlockVm>(newProducts).ToList(),
                UpcomingProducts = ObjectMapper.MapCollection<ProductBlockDto, ProductBlockVm>(upcomingProducts).ToList(),
            };

            return View(indexVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

        
    }
}
