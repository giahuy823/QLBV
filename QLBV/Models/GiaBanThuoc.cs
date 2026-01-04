using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[PrimaryKey("MaThuoc", "NgayApDung")]
[Table("GiaBanThuoc")]
public partial class GiaBanThuoc
{
    [Key]
    [StringLength(50)]
    
    public string MaThuoc { get; set; } = null!;

    [Key]
    public DateOnly NgayApDung { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? GiaBan { get; set; }

    [ForeignKey("MaThuoc")]
    [InverseProperty("GiaBanThuocs")]
    public virtual Thuoc MaThuocNavigation { get; set; } = null!;
}
