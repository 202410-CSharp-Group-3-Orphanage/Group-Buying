﻿namespace Forestage.Models.ViewModels.Products
{
    public class ProductBlockVm
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Info { get; set; }
        public int ProductPrice { get; set; }
        public int? GroupBuyingPrice { get; set; }
        public List<string> ImagePaths { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProductLink { get; set; }
    }
}
