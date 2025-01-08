namespace Backstage.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int GroupBuyingId { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public short ShippingMethod { get; set; }

        [StringLength(150)]
        public string ShippingAddress { get; set; }

        public short Status { get; set; }

        public short PaymentStatus { get; set; }

        public short DeliveryStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual GroupBuying GroupBuying { get; set; }

        public virtual Member Member { get; set; }
    }
}
