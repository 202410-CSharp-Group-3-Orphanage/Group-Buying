namespace Forestage.Models.ViewModels.Members
{
    public class PersonalGroupBuyingOrdersVm
    {
        
            public int? Status { get; set; }
            public int? ProductId { get; set; }
            public string ProductImage { get; set; }
            public string ProductName { get; set; }
            public int ProductPrice { get; set; }
            public int OrdersQuantity { get; set; }
            public int TotalPrice { get; set; }
            
    }
}
