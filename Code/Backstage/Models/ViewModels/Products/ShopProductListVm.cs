using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.ViewModels
{
    public class ShopProductListVm
    {
        public int Id { get; set; } // 商品 ID

        public string Category { get; set; } // 商品分類

        public string ImageUrl { get; set; } // 商品預覽圖 URL

        public string Name { get; set; } // 商品名稱

        public string Description { get; set; } // 商品資訊

        public int OriginalPrice { get; set; } // 商品原價

        public bool IsGroupOpen { get; set; } // 開團狀況

        public string EditUrl { get; set; } // 修改連結

        public string GroupOpenUrl { get; set; } // 開團連結
    }
}