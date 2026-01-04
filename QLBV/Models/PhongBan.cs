using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("PhongBan")]
public partial class PhongBan
{
    [Key]
    [Column("MaPB")]
    [StringLength(50)]
    
    public string MaPb { get; set; } = null!;

    [Column("MaBP")]
    [StringLength(50)]
    
    public string? MaBp { get; set; }

    [StringLength(100)]
    
    public string? TenPhongBan { get; set; }

    public string? MoTa { get; set; }

    [ForeignKey("MaBp")]
    [InverseProperty("PhongBans")]
    public virtual BoPhan? MaBpNavigation { get; set; }

    [InverseProperty("MaPbNavigation")]
    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
