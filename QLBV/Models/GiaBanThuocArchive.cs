using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("GiaBanThuoc_Archive")]
public partial class GiaBanThuocArchive
{
    [StringLength(50)]
    
    public string? MaThuoc { get; set; }

    public DateOnly? NgayApDung { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? GiaBan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
