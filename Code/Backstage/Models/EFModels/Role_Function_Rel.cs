namespace Backstage.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role_Function_Rel
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int FunctionId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Function Function { get; set; }

        public virtual Role Role { get; set; }
    }
}
