using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("BenhNhan_Archive")]
public partial class BenhNhanArchive
{
    [Column("MaBN")]
    [StringLength(50)]
    
    public string? MaBn { get; set; }

    [Column("HoTenBN")]
    [StringLength(100)]
    
    public string? HoTenBn { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(100)]
    
    public string? DiaChi { get; set; }

    [Column("SDT")]
    [StringLength(20)]
    
    public string? Sdt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]
    
    public string? ActionType { get; set; }
}
