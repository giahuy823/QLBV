using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("BacSi")]
public partial class BacSi
{
    [Key]
    [Column("MaBS")]
    [StringLength(50)]
    
    public string MaBs { get; set; } = null!;

    [StringLength(100)]
    
    public string? TrinhDo { get; set; }

    [ForeignKey("MaBs")]
    [InverseProperty("BacSi")]
    public virtual NhanVien MaBsNavigation { get; set; } = null!;

    [InverseProperty("BacsiNavigation")]
    public virtual ICollection<PhieuKhamBenh> PhieuKhamBenhs { get; set; } = new List<PhieuKhamBenh>();

    [InverseProperty("MaBacSiNavigation")]
    public virtual ICollection<ToaThuoc> ToaThuocs { get; set; } = new List<ToaThuoc>();
}
