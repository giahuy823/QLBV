using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("Thuoc")]
public partial class Thuoc
{
    [Key]
    [StringLength(50)]
    
    public string MaThuoc { get; set; } = null!;

    [StringLength(100)]
    
    public string? TenThuoc { get; set; }

    [StringLength(100)]
    
    public string? DonVi { get; set; }

    [InverseProperty("MaThuocNavigation")]
    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    [InverseProperty("MaThuocNavigation")]
    public virtual ICollection<GiaBanThuoc> GiaBanThuocs { get; set; } = new List<GiaBanThuoc>();
}
