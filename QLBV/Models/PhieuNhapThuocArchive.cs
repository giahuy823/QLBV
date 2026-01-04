using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("PhieuNhapThuoc_Archive")]
public partial class PhieuNhapThuocArchive
{
    [StringLength(50)]
    
    public string? MaPhieuNhap { get; set; }

    public DateOnly? NgayNhap { get; set; }

    [StringLength(100)]
    public string? NhaCungCap { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
