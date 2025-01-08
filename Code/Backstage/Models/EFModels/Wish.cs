namespace Backstage.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Wish
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
