using Backstage.Models.Dtos;
using Backstage.Models.EFModels;
using Backstage.Models.Services;
using Backstage.Models.ViewModels;
using MT.Utilities.UploadFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace Backstage.Controllers
{
    public class ProductsController : Controller
    {
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

            // 保存圖片到伺服器
            var imagePaths = new List<string>();
            UploadFileHelper uploadFileHelper = new UploadFileHelper();
            foreach (var image in model.Images)
            {
                // TODO: 要改相對路徑
                var filename = uploadFileHelper.SaveAs("C:\\Group-Buying\\Code\\FileServer\\Files\\Products", image);
                imagePaths.Add(filename);
            }
                
            //if (model.Images != null && model.Images.Count > 0)
            //{
            //    foreach (var image in model.Images)
            //    {
            //        if (image != null)
            //        {
            //            var fileName = Path.GetFileName(image.FileName);
            //            var filePath = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
            //            image.SaveAs(filePath);
            //            imagePaths.Add($"/ProductImages/{fileName}");
            //        }
            //    }
            //}


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
    }
}