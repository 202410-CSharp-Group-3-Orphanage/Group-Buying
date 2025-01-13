namespace Forestage.Models.Dtos.Members
{
    public class GroupbuyingProgressDTO
    {
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal GroupPrice { get; set; }
        public int OrderQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int CurrentQuantity { get; set; }
        public int TargetQuantity { get; set; }
        public DateTime EndTime { get; set; }
    }
}
