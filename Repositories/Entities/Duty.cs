using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repositories.Enums;

namespace Repositories.Entities;

[Table("duties")]
public partial class Duty
{
    [Key]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string EmployeeId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndTime { get; set; }

    public double? SalaryRate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public DutyStatus? Status { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Duties")]
    public virtual Employee Employee { get; set; } = null!;
}
