using Forestage.Models.Dtos.Products;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using MT.Utilities.Mapper;
using MT.Utilities.UploadFile;
using MT.Utilities.UploadFile.Implementations;

namespace Forestage.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ProductService _productService;
		private readonly IWebHostEnvironment _env;

		public ProductsController(ProductService productService, IWebHostEnvironment env)
		{
			_productService = productService;
			_env = env;
		}

		public IActionResult Details(int? id)
		{
			if (id == null) return NotFound();

			try
			{
				ProductInfoDto productInfoDto = _productService.Get(id.Value);
				ProductInfoVm productInfoVm = ObjectMapper.Map<ProductInfoDto, ProductInfoVm>(productInfoDto);
				ViewData["ProductUrl"] = Url.Action("ProductsApi", "api", new { id = productInfoVm.Id });
				Console.WriteLine(ViewData["ProductUrl"]);
				return View(productInfoVm);
			}
			catch (ArgumentException ex)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult UploadTest(IFormFile file)
		{
			CoreFile mVC5File = new CoreFile(file);
			UploadFileHelper uploadFileHelper = new UploadFileHelper();
			string relativePath = Path.Combine(_env.ContentRootPath, "..", "FileServer", "Files", "Products");
			var newFileName = uploadFileHelper.SaveAs(relativePath, mVC5File);
			Console.WriteLine(newFileName);
			return NoContent();
		}
	}
}
