using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backstage.Models.ViewModels
{
    public class CreateProductVm
    {
        [Required(ErrorMessage = "商品名稱為必填項目")]
        public string Name { get; set; }
        [Required(ErrorMessage = "商品價格為必填項目")]
        [Range(1, int.MaxValue, ErrorMessage = "價格必須大於 0")]
        public int Price { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "商品類別為必填項目")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "商品圖片為必填項目")]
        public List<HttpPostedFileBase> Images { get; set; } // 支持多圖上傳
    }
}