using Backstage.Common;
using MT.Utilities.UploadFile.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backstage.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilePathHelper _fileHelper = new FilePathHelper();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult UploadTest(HttpPostedFileBase file1)
        {
            if (file1 != null && file1.ContentLength > 0)
            {
                string uploadPath = _fileHelper.GetWritePath("Products");
                string fileName = Path.GetFileName(file1.FileName);
                string fullPath = Path.Combine(uploadPath, fileName);

                file1.SaveAs(fullPath);

                // 取得可存取的 URL
                string fileUrl = _fileHelper.GetReadPath("Products", fileName);
                return Json(new { success = true, fileUrl });
            }
            return Json(new { success = false });
        }
    }
}