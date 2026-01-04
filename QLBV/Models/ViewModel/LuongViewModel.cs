using System.ComponentModel.DataAnnotations;

namespace QLBV.Models.ViewModel
{
    public class LuongViewModel
    {
        [Required]
        [StringLength(50)]
        public string MaLuong { get; set; }

        [Required]
        [Display(Name = "Mã Nhân Viên")]
        public string MaNV { get; set; }

        [Range(1, 12)]
        public int Thang { get; set; }

        public int Nam { get; set; }

        [Required]
        [Display(Name = "Lương Cơ Bản")]
        public string LuongCoBan { get; set; } 

        [Display(Name = "Phụ Cấp")]
        public decimal PhuCap { get; set; }

        [Display(Name = "Ngày Công")]
        public int NgayCong { get; set; }

        [Display(Name = "Tổng Lương")]
        public decimal TongLuong { get; set; }
    }
}
