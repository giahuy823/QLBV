using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.TiepTan
{
    public class ChiTietPhieuKhamModel : PageModel
    {
        private readonly QLBVContext _context;

        public ChiTietPhieuKhamModel(QLBVContext context)
        {
            _context = context;
        }

        public PhieuKhamBenh PhieuKham { get; set; }

        public List<ChiTietPhieuKham> ChiTietList { get; set; } = new();
        //[BindProperty(SupportsGet = true)]
        //public string id { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            PhieuKham = await _context.PhieuKhamBenhs
                .Include(p => p.NguoiKhamNavigation)
                .Include(p => p.BacsiNavigation)
                .FirstOrDefaultAsync(p => p.MaPk == id);

            if (PhieuKham == null)
            {
                return NotFound();
            }

            ChiTietList = await _context.ChiTietPhieuKhams
                .Include(c => c.MaTtNavigation)
                .Where(c => c.MaPk == id)
                .ToListAsync();

            TempData["success"] = $"Đang xem chi tiết phiếu khám {id}";
            return Page();
        }
    }
}
