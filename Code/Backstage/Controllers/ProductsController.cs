using Backstage.Common;
using Backstage.Models.Dtos;
using Backstage.Models.EFModels;
using Backstage.Models.Services;
using Backstage.Models.ViewModels;
using Backstage.Models.ViewModels.Products;
using MT.Utilities.UploadFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace Backstage.Controllers
{
    public class ProductsController : Controller
    {
        FilePathHelper _filePathHelper = new FilePathHelper();
        UploadFileHelper _uploadFileHelper = new UploadFileHelper();
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Categories = ShowCategories();
            return View(new CreateProductVm());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string account = ticket.Name;

            
            var imagePaths = new List<string>();
            
            foreach (var image in model.Images)
            {
                string relativePath = _filePathHelper.GetWritePath("Products");
                var newFileName = _uploadFileHelper.SaveAs(relativePath, (MT.Utilities.UploadFile.Interfaces.IMyFile)image);
                
                imagePaths.Add(newFileName);
            }

            var productDto = new CreateProductDTO
            {
                Account = account,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
                ImagePaths = imagePaths,
            };

            _service.CreateProduct(productDto);

            return RedirectToAction("ShopProductList", "Products");
        }

        private SelectList ShowCategories()
        {
            return _service.ShowCategories();            
        }

        [Authorize]
        public ActionResult ShopProductList()
        {            
            string currentMerchant = User.Identity.Name;

            var products = _service.ShowShopProductList(currentMerchant);
                        
            return View(products); 
        }

        [Authorize]
        // 編輯商品頁面
        public ActionResult EditProduct(int id)
        {
            // 根據商品 ID 查詢商品資料
            var product = _service.GetProductById(id);
            ViewBag.Categories = ShowCategories();

            if (product == null)
            {
                return HttpNotFound(); // 如果找不到商品，返回 404
            }

            // 將商品資料傳遞給視圖
            return View(product);
        }


        [Authorize]
        [HttpPost]
        public ActionResult EditProduct(int id, EditProductVm model)
        {
            if (ModelState.IsValid)
            {
                // 根據 ID 更新商品資料
                _service.UpdateProduct(id, model);
                return RedirectToAction("ShopProductList");
            }

            return View(model);
        }

        [Authorize]
        // 顯示開團頁面
        public ActionResult StartGroupBuying(int id)
        {
            string loggedInUserAccount = User.Identity.Name;
            try {
                var product = _service.GetProductByIdForGroupBuying(id, loggedInUserAccount);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product); // 將商品資訊傳遞到開團頁面

            } catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StartGroupBuying(int id,StartGroupBuyingVm model)
        {
            if (ModelState.IsValid)
            {
                model.ProductId = id;
                _service.StartGroupBuying(model);
                return RedirectToAction("ShopProductList");
            }

            return View(model); // 如果驗證失敗，返回頁面並顯示錯誤
        }

    }
}