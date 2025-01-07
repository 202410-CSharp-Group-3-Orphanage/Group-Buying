namespace Forestage.Models.Dtos.Products
{
    public class ProductBlockDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Info { get; set; }
        public int ProductPrice { get; set; }
        public int? GroupBuyingPrice { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}
