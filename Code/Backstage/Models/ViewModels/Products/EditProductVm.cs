using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.ViewModels.Products
{
    public class EditProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<HttpPostedFileBase> Images { get; set; } // 上傳新圖片
        public List<string> ImageUrls { get; set; } // 現有圖片 URL
    }



}