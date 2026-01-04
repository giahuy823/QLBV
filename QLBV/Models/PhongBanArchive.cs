using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("PhongBan_Archive")]
public partial class PhongBanArchive
{
    [Column("MaPB")]
    [StringLength(50)]
    
    public string? MaPb { get; set; }

    [Column("MaBP")]
    [StringLength(50)]
    
    public string? MaBp { get; set; }

    [StringLength(100)]
    
    public string? TenPhongBan { get; set; }

 
    public string? MoTa { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
