using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Entities;

[Table("order_details")]
public partial class OrderDetail
{
    [Key]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string OrderId { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string ItemId { get; set; } = null!;

    public int Price { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("OrderDetails")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order Order { get; set; } = null!;
}
