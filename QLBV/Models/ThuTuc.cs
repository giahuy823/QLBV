using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Table("ThuTuc")]
public partial class ThuTuc
{
    [Key]
    [StringLength(50)]
    
    public string MaThuTuc { get; set; } = null!;

    [StringLength(100)]
    
    public string? TenTuc { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? DonGia { get; set; }
}
