using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repositories.Enums;

namespace Repositories.Entities;

[Table("vouchers")]
public partial class Voucher
{
    [Key]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public int? Discount { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public VoucherStatus? Status { get; set; }

    [InverseProperty("Voucher")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
