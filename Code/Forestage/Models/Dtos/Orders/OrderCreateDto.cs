using Forestage.Models.Enums;

namespace Forestage.Models.Dtos.Orders
{
    public class OrderCreateDto
    {
        public int MemberId { get; set; }
        public int GroupBuyingId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int ShippingMethod { get; set; }
        public int Status { get; set; }
        public int PaymentStatus { get; set; }
        public int DeliveryStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
