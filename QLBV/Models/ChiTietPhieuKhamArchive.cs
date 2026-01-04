using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("ChiTietPhieuKham_Archive")]
public partial class ChiTietPhieuKhamArchive
{
    [Column("MaPK")]
    [StringLength(50)]
    
    public string? MaPk { get; set; }

    [Column("MaTT")]
    [StringLength(50)]
    
    public string? MaTt { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SoTien { get; set; }

    [Column("TTThanhToan")]
    [StringLength(100)]
    
    public string? TtthanhToan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
