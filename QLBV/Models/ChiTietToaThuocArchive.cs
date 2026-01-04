using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("ChiTietToaThuoc_Archive")]
public partial class ChiTietToaThuocArchive
{
    [StringLength(50)]
    
    public string? MaToaThuoc { get; set; }

    [StringLength(50)]
    
    public string? MaThuoc { get; set; }

    [StringLength(50)]
    
    public string? SoLuong { get; set; }

    [StringLength(100)]
    
    public string? LieuDung { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
