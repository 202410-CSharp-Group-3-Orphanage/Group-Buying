using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.ViewModels
{
    public class ShopProductListVm
    {
        public string category { get; set; }
        public string name { get; set; }
        public string info { get; set; }
        public int price { get; set; }
    }
}