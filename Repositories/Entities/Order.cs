using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repositories.Enums;

namespace Repositories.Entities;

[Table("orders")]
public partial class Order
{
    [Key]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    public int TotalPrice { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public OrderPaymentMethod? PaymentMethod { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? VoucherId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public OrderStatus? Status { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("VoucherId")]
    [InverseProperty("Orders")]
    public virtual Voucher? Voucher { get; set; }
}
