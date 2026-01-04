using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("TaiKhoan_Archive")]
public partial class TaiKhoanArchive
{
    [Column("MaTK")]
    [StringLength(50)]
    
    public string? MaTk { get; set; }

    [Column("MaNV")]
    [StringLength(50)]
    
    public string? MaNv { get; set; }

    [Column("TenDN")]
    [StringLength(50)]
    
    public string? TenDn { get; set; }

    [Column("MK")]
    [MaxLength(255)]
    public byte[]? Mk { get; set; }

    [Column("LoaiTK")]
    [StringLength(50)]
    
    public string? LoaiTk { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
