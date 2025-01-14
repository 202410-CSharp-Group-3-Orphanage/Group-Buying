using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MT.Utilities.Mapper;
using PlatformManagement.Models;
using PlatformManagement.Models.EFModels;
using PlatformManagement.Models.ViewModels;
using System.Diagnostics;

namespace PlatformManagement.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly AppDbContext _context;

		public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
		{
			_logger = logger;
			_context = appDbContext;
		}

		[Authorize]
		public IActionResult Index()
		{
			var shops = _context.Shops.AsNoTracking().ToList();
			IEnumerable<ShopStatusVm> shopVm = ObjectMapper.MapCollection<Shop, ShopStatusVm>(shops);
			return View(shopVm);
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
