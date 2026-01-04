using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("Thuoc_Archive")]
public partial class ThuocArchive
{
    [StringLength(50)]
    
    public string? MaThuoc { get; set; }

    [StringLength(100)]
    
    public string? TenThuoc { get; set; }

    [StringLength(100)]
    
    public string? DonVi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
