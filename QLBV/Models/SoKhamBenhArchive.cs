using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("SoKhamBenh_Archive")]
public partial class SoKhamBenhArchive
{
    [Column("MaSoKham")]
    [StringLength(50)]
    [Key]
    public int MaSoKham { get; set; }

    [Column("MaBN")]
    [StringLength(50)]
    public string? MaBn { get; set; }

   
    [StringLength(50)]
    public string? MaPk { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchiveDate { get; set; }

    [StringLength(10)]

    public string? ActionType { get; set; }
}
