using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("PhieuKhamBenh")]
public partial class PhieuKhamBenh
{
    [Key]
    [Column("MaPK")]
    [StringLength(50)]
    public string MaPk { get; set; } = null!;  
    [StringLength(100)]
    public string? TrieuChung { get; set; }

    public DateOnly? NgayKham { get; set; }

    [StringLength(50)]
    public string? NguoiKham { get; set; }

    [StringLength(50)]
    public string? Bacsi { get; set; }

    public int? MaSoKham { get; set; } 

    [ForeignKey("Bacsi")]
    [InverseProperty("PhieuKhamBenhs")]
    public virtual BacSi? BacsiNavigation { get; set; }

    [ForeignKey("NguoiKham")]
    [InverseProperty("PhieuKhamBenhs")]
    public virtual BenhNhan? NguoiKhamNavigation { get; set; }

    [ForeignKey("MaSoKham")]
    [InverseProperty("PhieuKhamBenhs")]
    public virtual SoKhamBenh? MaSoKhamNavigation { get; set; }
    public virtual ToaThuoc? ToaThuoc { get; set; }
}
