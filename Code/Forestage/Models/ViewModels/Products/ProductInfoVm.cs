﻿namespace Forestage.Models.ViewModels.Products
{
    public class ProductInfoVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }


        public List<string> ImagePaths { get; set; }
        public int Participants { get; set; }
        public int MinimumGroupSize { get; set; }
        public DateTime EndDate { get; set; }
        public string ShopName { get; set; }
        public string ShopLink { get; set; }
        public string ShopAvatar { get; set; }
        public int GroupBuyingPrice { get; set; }
        public string Description { get; set; }
    }
}
