﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlatformManagement.Models.EFModels;

public partial class Role
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 角色名稱
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<EmployeeRoleRel> EmployeeRoleRels { get; set; } = new List<EmployeeRoleRel>();

    [InverseProperty("IdNavigation")]
    public virtual RoleFunctionRel RoleFunctionRel { get; set; }
}