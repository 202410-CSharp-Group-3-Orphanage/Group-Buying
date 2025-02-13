﻿namespace Forestage.Models.ViewModels.Carts
{
    public class CartInfoVm
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImagePath { get; set; }
        public string ProductLink { get; set; }
        public int Quantity { get; set; }
        public int GroupBuyingPrice { get; set; }
        public int SubTotal { get { return Quantity * GroupBuyingPrice; } }
    }
}
