using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("BoPhan")]
public partial class BoPhan
{
    [Key]
    [Column("MaBP")]
    [StringLength(50)]
    
    public string MaBp { get; set; } = null!;

    [StringLength(100)]
    
    public string? TenBoPhan { get; set; }

    [InverseProperty("MaBpNavigation")]
    public virtual ICollection<PhongBan> PhongBans { get; set; } = new List<PhongBan>();
}
