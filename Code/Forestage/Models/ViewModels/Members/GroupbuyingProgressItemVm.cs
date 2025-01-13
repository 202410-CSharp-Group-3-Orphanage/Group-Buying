namespace Forestage.Models.ViewModels.Members
{
    public class GroupbuyingProgressItemVm
    {
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal GroupPrice { get; set; }
        public int OrderQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string GroupProgress { get; set; }  
        public DateTime EndTime { get; set; }
    }
}
