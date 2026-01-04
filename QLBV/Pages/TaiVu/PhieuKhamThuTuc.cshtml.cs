using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.TaiVu
{
    [Authorize(Roles = "TaiVu")]
    public class PhieuKhamThuTucModel : PageModel
    {
        private readonly QLBVContext _context;

        public PhieuKhamThuTucModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string MaPhieuKham { get; set; } = string.Empty;

        public List<ChiTietPhieuKham> DanhSachChiTiet { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(MaPhieuKham))
                return NotFound("Không tìm thấy mã phiếu khám.");

            DanhSachChiTiet = await _context.ChiTietPhieuKhams
                .Include(c => c.MaTtNavigation)
                .Where(c => c.MaPk == MaPhieuKham)
                .ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostThanhToanAsync(string maPk, string maTt)
        {
            if (string.IsNullOrEmpty(maPk) || string.IsNullOrEmpty(maTt))
                return RedirectToPage();

            var chitiet = await _context.ChiTietPhieuKhams
                .FirstOrDefaultAsync(c => c.MaPk == maPk && c.MaTt == maTt);

            if (chitiet != null && chitiet.TtthanhToan != "Đã thanh toán")
            {
                chitiet.TtthanhToan = "Đã thanh toán";
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Thủ tục {maTt} đã được thanh toán.";
            }

            return RedirectToPage(new { MaPhieuKham = maPk });
        }
    }
}
