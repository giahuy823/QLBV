using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;

namespace QLBV.Pages.Admin
{
    [Authorize(Roles = "QuanLyNhanSu, Admin")]
    public class QuanLyPhongBanModel : PageModel
    {
        private InterfaceNhanVien repoNv;
        private readonly QLBVContext _context;
        public QuanLyPhongBanModel(QLBVContext context, InterfaceNhanVien _repoNv)
        {
            _context = context;
            repoNv = _repoNv;
        }
        public List<PhongBan> DanhSachCacPhongBan { get; set; } = new List<PhongBan>();
        public async Task<IActionResult> OnGet()
        {
            DanhSachCacPhongBan = await repoNv.LayPhongBan();
            return Page();
        }
        public async Task<IActionResult> OnPostXoa(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                // Gọi stored procedure
                await _context.Database.ExecuteSqlRawAsync("EXEC Delete_PhongBan @MaPB = {0}", id);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                ModelState.AddModelError(string.Empty, "Lỗi khi xóa phòng ban: " + ex.Message);
                return Page();
            }
            return RedirectToPage();
        }
    }
}
