using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("PhieuNhapThuoc")]
public partial class PhieuNhapThuoc
{
    [Key]
    [StringLength(50)]
    
    public string MaPhieuNhap { get; set; } = null!;

    public DateOnly? NgayNhap { get; set; }

    [StringLength(100)]
    public string? NhaCungCap { get; set; }

    [InverseProperty("MaPhieuNhapNavigation")]
    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();
}
