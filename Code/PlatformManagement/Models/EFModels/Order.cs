﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlatformManagement.Models.EFModels;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int GroupBuyingId { get; set; }

    /// <summary>
    /// 成交價格
    /// </summary>
    public int Price { get; set; }

    /// <summary>
    /// 數量
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// 運送方式(1:到店取)
    /// </summary>
    public short ShippingMethod { get; set; }

    /// <summary>
    /// 運送地址
    /// </summary>
    [StringLength(150)]
    public string ShippingAddress { get; set; }

    /// <summary>
    /// 訂單狀態(0: 取消, 1: 參與中, 2: 成立, 3: 運送中, 4: 到貨, 5: 已取貨, 6: 未取貨)
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// 付款狀態(0:未付款,1:已付款)
    /// </summary>
    public short PaymentStatus { get; set; }

    /// <summary>
    /// 運送狀態(0: 未出貨, 1: 已送達)
    /// </summary>
    public short DeliveryStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("GroupBuyingId")]
    [InverseProperty("Orders")]
    public virtual GroupBuying GroupBuying { get; set; }

    [ForeignKey("MemberId")]
    [InverseProperty("Orders")]
    public virtual Member Member { get; set; }
}