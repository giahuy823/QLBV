using Microsoft.AspNetCore.Identity;

namespace QLBV.Models.User_Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? MaNv { get; set; }
        public NhanVien? NhanVien { get; set; }
    }
}
