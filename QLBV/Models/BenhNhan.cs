using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("BenhNhan")]
public partial class BenhNhan
{
    [Key]
    [Column("MaBN")]
    [StringLength(50)]
    
    public string MaBn { get; set; } = null!;

    [Column("HoTenBN")]
    [StringLength(100)]
    
    public string? HoTenBn { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(100)]
    
    public string? DiaChi { get; set; }

    [Column("SDT")]
    [StringLength(20)]
    
    public string? Sdt { get; set; }

    [InverseProperty("NguoiKhamNavigation")]
    public virtual ICollection<PhieuKhamBenh> PhieuKhamBenhs { get; set; } = new List<PhieuKhamBenh>();
    [InverseProperty("MaBnNavigation")]
    public virtual ICollection<SoKhamBenh> SoKhamBenhs { get; set; } = new List<SoKhamBenh>();
}
