using Forestage.Common;
using Forestage.Models.Dtos.Products;
using Forestage.Models.Dtos.Shops;
using Forestage.Models.Infra;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Products;
using Forestage.Models.ViewModels.Shops;
using Microsoft.AspNetCore.Mvc;
using MT.Utilities.Mapper;
using MT.Utilities.UploadFile;
using MT.Utilities.UploadFile.Implementations;
using MT.Utilities.UploadFile.Vaildators;

namespace Forestage.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly FilePathHelper _filePathHelper;

        public ProductsController(ProductService productService, FilePathHelper filePathHelper)
        {
            _productService = productService;
            _filePathHelper = filePathHelper;
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
            if (file == null)
            {
                return Json(new { success = false, message = "檔案為空" });
            }

            // 把檔案放到 兩種 不同類型的物件
            CoreFile mVC5File = new CoreFile(file);

            // 建立檔案上傳助手
            UploadFileHelper uploadFileHelper = new UploadFileHelper();

            // 加入驗證方式
            // 驗證檔案必填
            uploadFileHelper.AddValidator(new RequiredValidator());
            // 驗證是否為圖片類型
            uploadFileHelper.AddValidator(new ImageFileValidator());
            // 驗證檔案大小，檔案大小須小於 10 MB
            uploadFileHelper.AddValidator(new FileSizeValidator(10 * 1024));

            // 執行驗證
            var result = uploadFileHelper.Validate(mVC5File);

            // 判斷驗證結果
            if (result == false)
            {
                return Json(new { success = false, message = uploadFileHelper.ErrorMessage });
            }


            // 以上通過驗證後，可以進行檔案上傳
            // 檔案上傳
            string relativePath = _filePathHelper.GetWritePath("Products");
            var newFileName = uploadFileHelper.SaveAs(relativePath, mVC5File);
            Console.WriteLine(newFileName);

            // 讀取檔案網址
            string url = _filePathHelper.GetReadPath("Products", newFileName);
            Console.WriteLine(url);

            return NoContent();
        }

        public IActionResult Search(ProductSearchVm SearchModel, string SortOption = "", int pageNumber = 1)
        {
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
            ViewBag.SearchModel = SearchModel;

            var criteria = new Criteria(SearchModel.CategoryId, SearchModel.MinPrice, SearchModel.MaxPrice, SearchModel.SearchKeyword);

            var sortInfo = new SortInfo<ProductBlockDto>(columnName, direction);

            var productSearchDto = _productService.GetSearchProducts(pageNumber, sortInfo, criteria);

            var productVms = productSearchDto.SearchProducts.Items.Select(p => new ProductBlockVm
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                ImagePaths = p.ImagePaths,
                ProductLink = p.ProductLink,
                CreatedAt = p.CreatedAt
            }).ToList();

            var model = new ProductResultVm
            {
                SearchVm = SearchModel,
                categories = productSearchDto.categories,
                SearchProducts = new PagedList<ProductBlockVm, SortInfo<ProductBlockDto>>(productVms, pageNumber, productSearchDto.SearchProducts.PageSize, productSearchDto.SearchProducts.TotalCount, sortInfo)
            };

            return View(model);
        }
    }
}
