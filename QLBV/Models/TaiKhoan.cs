using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("TaiKhoan")]
[Index("MaNv", Name = "UQ__TaiKhoan__2725D70B0150A028", IsUnique = true)]
public partial class TaiKhoan
{
    [Key]
    [Column("MaTK")]
    [StringLength(50)]
    
    public string MaTk { get; set; } = null!;

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

    [ForeignKey("MaNv")]
    [InverseProperty("TaiKhoan")]
    public virtual NhanVien? MaNvNavigation { get; set; }
}
