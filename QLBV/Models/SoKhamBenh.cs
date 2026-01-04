using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("SoKhamBenh")]
public partial class SoKhamBenh
{
    [Key]
    public int MaSoKham { get; set; }

    [Column("MaBN")]
    [StringLength(50)]
    public string? MaBn { get; set; }

    [Column("MaPK")]
    [StringLength(50)]
    public string? MaPk { get; set; }

    [ForeignKey("MaBn")]
    [InverseProperty("SoKhamBenhs")]
    public virtual BenhNhan? MaBnNavigation { get; set; }

    [InverseProperty("MaSoKhamNavigation")]
    public virtual ICollection<PhieuKhamBenh> PhieuKhamBenhs { get; set; } = new List<PhieuKhamBenh>();
}
