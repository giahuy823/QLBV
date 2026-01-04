using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("Luong")]
public partial class Luong
{
    [Key]
    [StringLength(50)]
    
    public string MaLuong { get; set; } = null!;

    [Column("MaNV")]
    [StringLength(50)]
    
    public string? MaNv { get; set; }

    public int? Thang { get; set; }

    public int? Nam { get; set; }

    [MaxLength(255)]
    public byte[]? LuongCoBan { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PhuCap { get; set; }

    public int? NgayCong { get; set; }

    [Column(TypeName = "decimal(20, 2)")]
    public decimal? TongLuong { get; set; }

    [ForeignKey("MaNv")]
    [InverseProperty("Luongs")]
    public virtual NhanVien? MaNvNavigation { get; set; }
}
