using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("BoPhan_Archive")]
public partial class BoPhanArchive
{
    [Column("MaBP")]
    [StringLength(50)]
    
    public string? MaBp { get; set; }

    [StringLength(100)]
    
    public string? TenBoPhan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
