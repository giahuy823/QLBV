using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.QuanLyTaiVu
{
    [Authorize(Roles = "QuanLyTaiVu")]
    public class ThemThuTucModel : PageModel
    {
        private readonly QLBVContext _context;

        public ThemThuTucModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ThuTuc ThuTuc { get; set; } = new ThuTuc();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

       
            bool exists = await _context.ThuTucs.AnyAsync(t => t.MaThuTuc == ThuTuc.MaThuTuc);

            if (exists)
            {
                ModelState.AddModelError("ThuTuc.MaThuTuc", "Mã thủ tục đã tồn tại, vui lòng nhập mã khác.");
                return Page();
            }

            _context.ThuTucs.Add(ThuTuc);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Thêm thủ tục thành công";
            return RedirectToPage("ThuTuc");
        }
    }
}
