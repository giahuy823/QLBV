using System.ComponentModel.DataAnnotations;

namespace QLBV.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} character")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = ("Doesnt match !"))]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập sdt.")]
        public string Sdt { get; set; }

        [Required(ErrorMessage = "Phòng ban nào ?")]
        public string PhongBan { get; set; }
    }
}
