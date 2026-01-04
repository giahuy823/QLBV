using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("CaTruc_Archive")]
public partial class CaTrucArchive
{
    [Column("MaCT")]
    [StringLength(50)]
    
    public string? MaCt { get; set; }

    [Column("ThoiGianBT", TypeName = "datetime")]
    public DateTime? ThoiGianBt { get; set; }

    [Column("ThoiGianKT", TypeName = "datetime")]
    public DateTime? ThoiGianKt { get; set; }

    [Column("NVtruc")]
    [StringLength(50)]
    
    public string? Nvtruc { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
