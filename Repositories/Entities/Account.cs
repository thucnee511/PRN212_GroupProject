using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repositories.Enums;

namespace Repositories.Entities;

[Table("accounts")]
[Index("Username", Name = "UQ__accounts__536C85E43C7DD5E3", IsUnique = true)]
public partial class Account
{
    [Key]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    public AccountRole Role { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public AccountStatus? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
