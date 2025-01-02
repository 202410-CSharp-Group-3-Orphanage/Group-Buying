﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Forestage.Models.EFModels;

public partial class Product
{
    public int Id { get; set; }

    public int ShopId { get; set; }

    public int CategoryId { get; set; }

    /// <summary>
    /// 商品名稱
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 原價
    /// </summary>
    public int Price { get; set; }

    /// <summary>
    /// 商品資訊
    /// </summary>
    public string Info { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<GroupBuying> GroupBuyings { get; set; } = new List<GroupBuying>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual Shop Shop { get; set; }

    public virtual ICollection<Wish> Wishes { get; set; } = new List<Wish>();
}