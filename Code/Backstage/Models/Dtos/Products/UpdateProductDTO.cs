using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.Dtos.Products
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<string> ImagePaths { get; set; } // 圖片路徑列表
    }

}