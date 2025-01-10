using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.Dtos.Products
{
    public class StartGroupBuyingDTO
    {
        public int ProductId { get; set; }
        public int MinimumGroupSize { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Account { get; set; }
    }

}