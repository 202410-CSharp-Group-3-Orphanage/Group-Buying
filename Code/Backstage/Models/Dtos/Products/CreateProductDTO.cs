using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.Dtos
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<string> ImagePaths { get; set; } // 支持多圖上傳
        public string Account { get; set; }
    }
}