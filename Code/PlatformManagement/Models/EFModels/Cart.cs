﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlatformManagement.Models.EFModels;

public partial class Cart
{
    [Key]
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int GroupBuyingId { get; set; }

    /// <summary>
    /// 數量
    /// </summary>
    public int Quantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("GroupBuyingId")]
    [InverseProperty("Carts")]
    public virtual GroupBuying GroupBuying { get; set; }

    [ForeignKey("MemberId")]
    [InverseProperty("Carts")]
    public virtual Member Member { get; set; }
}