using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models;

[Keyless]
[Table("ChiTietToaThuoc")]
public partial class ChiTietToaThuoc
{
    [StringLength(50)]
    
    public string? MaToaThuoc { get; set; }

    [StringLength(50)]
    
    public string? MaThuoc { get; set; }

    [StringLength(50)]
    
    public string? SoLuong { get; set; }

    [StringLength(100)]
    
    public string? LieuDung { get; set; }

    [ForeignKey("MaThuoc")]
    public virtual Thuoc? MaThuocNavigation { get; set; }

    [ForeignKey("MaToaThuoc")]
    public virtual ToaThuoc? MaToaThuocNavigation { get; set; }
}
