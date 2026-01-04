using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("Archive_NhanVien")]
public partial class ArchiveNhanVien
{
    [Key]
    [Column("ArchiveID")]
    public int ArchiveId { get; set; }

    [Column("MaNV")]
    [StringLength(50)]
    
    public string? MaNv { get; set; }

    [Column("HoTenNV")]
    [StringLength(100)]
    
    public string? HoTenNv { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(10)]
    
    public string? GioiTinh { get; set; }

    [StringLength(100)]
    
    public string? DiaChi { get; set; }

    [Column("SDT")]
    [StringLength(20)]
    
    public string? Sdt { get; set; }

    [StringLength(100)]
    
    public string? LoaiNhanVien { get; set; }

    [Column("MaPB")]
    [StringLength(50)]
    
    public string? MaPb { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchivedAt { get; set; }
}
