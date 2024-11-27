using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repositories.Enums;

namespace Repositories.Entities;

[Table("categories")]
public partial class Category
{
    [Key]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public CategoryStatus? Status { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
