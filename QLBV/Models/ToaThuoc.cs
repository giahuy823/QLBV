using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("ToaThuoc")]
public partial class ToaThuoc
{
    [Key]
    [StringLength(50)]
    
    public string MaToaThuoc { get; set; } = null!;

    [StringLength(50)]
    
    public string? MaBacSi { get; set; }

    public DateOnly? NgayKe { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? TongTien { get; set; }

    [ForeignKey("MaBacSi")]
    [InverseProperty("ToaThuocs")]
    public virtual BacSi? MaBacSiNavigation { get; set; }
    [StringLength(50)]
    public string? MaPk { get; set; }

    //Them
    [ForeignKey("MaPk")]
    [InverseProperty("ToaThuoc")]
    public virtual PhieuKhamBenh? MaPkNavigation { get; set; }
}
