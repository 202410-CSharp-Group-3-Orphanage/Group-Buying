﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlatformManagement.Models.EFModels;

[Table("Role_Function_Rel")]
public partial class RoleFunctionRel
{
    [Key]
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int FunctionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("FunctionId")]
    [InverseProperty("RoleFunctionRels")]
    public virtual Function Function { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("RoleFunctionRel")]
    public virtual Role IdNavigation { get; set; }
}