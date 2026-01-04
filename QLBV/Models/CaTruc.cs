using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("CaTruc")]
public partial class CaTruc
{
    [Key]
    [Column("MaCT")]
    [StringLength(50)]
    
    public string MaCt { get; set; } = null!;

    [Column("ThoiGianBT", TypeName = "datetime")]
    public DateTime? ThoiGianBt { get; set; }

    [Column("ThoiGianKT", TypeName = "datetime")]
    public DateTime? ThoiGianKt { get; set; }

    [Column("NVtruc")]
    [StringLength(50)]
    
    public string? Nvtruc { get; set; }

    [ForeignKey("Nvtruc")]
    [InverseProperty("CaTrucs")]
    public virtual NhanVien? NvtrucNavigation { get; set; }
}
