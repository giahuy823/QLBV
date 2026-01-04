using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("ChiTietPhieuNhap_Archive")]
public partial class ChiTietPhieuNhapArchive
{
    [StringLength(50)]
    
    public string? MaPhieuNhap { get; set; }

    [StringLength(50)]
    
    public string? MaThuoc { get; set; }

    public int? SoLuong { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? GiaNhap { get; set; }

    public DateOnly? HanSuDung { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
