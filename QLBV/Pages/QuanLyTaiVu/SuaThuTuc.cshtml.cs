using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.QuanLyTaiVu
{
    [Authorize(Roles ="QuanLyTaiVu")]
    public class SuaThuTucModel : PageModel
    {
        private readonly QLBVContext _context;

        public SuaThuTucModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ThuTuc ThuTuc { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            ThuTuc = await _context.ThuTucs.FindAsync(id);

            if (ThuTuc == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existing = await _context.ThuTucs.FindAsync(ThuTuc.MaThuTuc);
            if (existing == null)
                return NotFound();

            existing.TenTuc = ThuTuc.TenTuc;
            existing.DonGia = ThuTuc.DonGia;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Cập nhật thủ tục thành công.";
            return RedirectToPage("ThuTuc");
        }
    }
}
