using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.ChuyenMon
{
    public class DanhSachPhieuKhamModel : PageModel
    {
        private readonly QLBVContext _context;

        public DanhSachPhieuKhamModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string mabs { get; set; }

        public List<PhieuKhamBenh> DanhSachPhieuKham { get; set; } = new List<PhieuKhamBenh>();

        public async Task<IActionResult> OnGetAsync()
        {
            var query = _context.PhieuKhamBenhs
                .Include(p => p.NguoiKhamNavigation)
                .Include(p => p.BacsiNavigation)
                .AsQueryable();

            if (!string.IsNullOrEmpty(mabs))
            {
                query = query.Where(p => p.Bacsi == mabs);
            }

            DanhSachPhieuKham = await query.ToListAsync();
            return Page();
        }
    }
}
