using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;

namespace QLBV.Pages.Admin
{
    [Authorize(Roles = "QuanLyNhanSu, Admin")]
    public class QuanLyNhanVienModel : PageModel
    {
        private readonly InterfaceNhanVien _nhanVienRepo;
        private readonly ILogger<QuanLyNhanVienModel> _logger;

        public QuanLyNhanVienModel(
            InterfaceNhanVien nhanVienRepo,
            ILogger<QuanLyNhanVienModel> logger)
        {
            _nhanVienRepo = nhanVienRepo;
            _logger = logger;
        }

        public List<QLBV.Models.NhanVien> NhanViens { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                NhanViens = await _nhanVienRepo.LayNhanVien();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tải danh sách nhân viên");
                ModelState.AddModelError("", "Lỗi khi tải dữ liệu");
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            try
            {
                var nv = await _nhanVienRepo.LayNhanVienById(id);
                if (nv != null)
                {
                   
                    // await _nhanVienRepo.DeleteNhanVienAsync(id);
                    TempData["Message"] = $"Đã xóa nhân viên {id}";
                }
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa nhân viên");
                ModelState.AddModelError("", "Lỗi khi xóa nhân viên");
                return Page();
            }
        }
    }
}