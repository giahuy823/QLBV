using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("PhieuKhamBenh_Archive")]
public partial class PhieuKhamBenhArchive
{
    [Column("MaPK")]
    [StringLength(50)]
    
    public string? MaPk { get; set; }

    [StringLength(100)]
    
    public string? TrieuChung { get; set; }

    public DateOnly? NgayKham { get; set; }

    [StringLength(50)]
    
    public string? NguoiKham { get; set; }

    [StringLength(50)]
    
    public string? Bacsi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
