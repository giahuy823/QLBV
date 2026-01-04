using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("Audit_Log")]
public partial class AuditLog
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string? TableName { get; set; }

    [StringLength(10)]
    public string? ActionType { get; set; }

    [Column("RecordID")]
    [StringLength(50)]
    public string? RecordId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActionTime { get; set; }

    [StringLength(100)]
    public string? PerformedBy { get; set; }
}
