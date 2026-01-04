using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QLBV.Models.User_Model;

namespace QLBV.Models;

[Table("NhanVien")]
public partial class NhanVien
{
    [Key]
    [Column("MaNV")]
    [StringLength(50)]
    
    public string MaNv { get; set; } = null!;

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

    [Column("MaPB")]
    [StringLength(50)]
    
    public string? MaPb { get; set; }

    [InverseProperty("MaBsNavigation")]
    public virtual BacSi? BacSi { get; set; }

    [InverseProperty("NvtrucNavigation")]
    public virtual ICollection<CaTruc> CaTrucs { get; set; } = new List<CaTruc>();

    [InverseProperty("MaNvNavigation")]
    public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();

    [ForeignKey("MaPb")]
    [InverseProperty("NhanViens")]
    public virtual PhongBan? MaPbNavigation { get; set; }

    [InverseProperty("MaNvNavigation")]
    public virtual TaiKhoan? TaiKhoan { get; set; }

    public ApplicationUser? User { get; set; }
}
