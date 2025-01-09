namespace Backstage.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(500)]
        public string Path { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Product Product { get; set; }
    }
}
