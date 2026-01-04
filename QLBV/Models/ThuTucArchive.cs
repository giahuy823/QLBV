using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("ThuTuc_Archive")]
public partial class ThuTucArchive
{
    [StringLength(50)]
    
    public string? MaThuTuc { get; set; }

    [StringLength(100)]
    
    public string? TenTuc { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? DonGia { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
