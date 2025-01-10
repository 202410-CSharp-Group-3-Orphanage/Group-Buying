using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.ViewModels.Products
{
    public class StartGroupBuyingVm
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int OriginalPrice { get; set; }
        public string CategoryName { get; set; }
        public List<string> ExistingImages { get; set; } // 商品圖片列表

        public string Account { get; set; }

        // 團購相關欄位
        public int MinimumGroupSize { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}