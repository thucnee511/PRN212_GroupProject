using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repositories.Enums;

namespace Repositories.Entities;

[Table("items")]
public partial class Item
{
    [Key]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? CategoryId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int Price { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public ItemStatus? Status { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Items")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
