using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.ViewModels.Products
{
    public class GroupBuyingStatusViewModel
    {
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int CurrentGroupSize { get; set; }
        public int MinimumGroupSize { get; set; }
        public DateTime EndDate { get; set; }
    }

}