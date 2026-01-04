using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;
using QLBV.Models.User_Model;

namespace QLBV.Pages.NhanVien
{
    public class ThongTinModel : PageModel
    {
        private readonly QLBVContext _context;
        private readonly InterfaceBenhVien repoBV;
        private readonly InterfaceNhanVien repoNv;
        private readonly UserManager<ApplicationUser> _userManager;

        public ThongTinModel(QLBVContext context, InterfaceBenhVien _repoBv, InterfaceNhanVien _repoNv, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            repoBV = _repoBv;
            repoNv = _repoNv;
            _userManager = userManager;
        }

        public Models.BacSi? NhanVienBacSi { get; set; }
        public Models.NhanVien? NhanVienKhac { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null || string.IsNullOrEmpty(user.MaNv))
                {
                    TempData["Error"] = "Không tìm thấy thông tin người dùng.";
                    return Page();
                }

                id = user.MaNv;
            }

         
            NhanVienBacSi = await repoBV.LayNhanVien(id);

            if (NhanVienBacSi == null)
            {
             
                NhanVienKhac = await repoNv.LayNhanVienById(id);

                if (NhanVienKhac == null)
                {
                    TempData["Error"] = $"Không tìm thấy nhân viên có mã: {id}";
                }
            }

            return Page();
        }
    }
}
