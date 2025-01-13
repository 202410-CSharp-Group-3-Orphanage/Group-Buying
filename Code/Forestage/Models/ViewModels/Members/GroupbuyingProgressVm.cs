namespace Forestage.Models.ViewModels.Members
{
    public class GroupbuyingProgressVm
    {
        public int? GroupBuyingId { get; set; }
        public int? ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int OrdersQuantity { get; set; }
        public int TotalPrice { get; set; }
        public int CurrentGroupSize { get; set; }
        public int MinimumGroupSize { get; set; }
        public DateTime EndDate { get; set; }
    }
}
