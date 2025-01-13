namespace Forestage.Models.Dtos.Carts
{
    public class CartInfoDto
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
