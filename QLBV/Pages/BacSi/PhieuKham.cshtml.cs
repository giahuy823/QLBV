using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.BacSi
{
    [Authorize(Roles = "BacSi")]
    public class PhieuKhamModel : PageModel
    {
        private readonly QLBVContext _context;

        public PhieuKhamModel(QLBVContext context)
        {
            _context = context;
        }

        public PhieuKhamBenh PhieuKhamBenh { get; set; }
        public IList<ChiTietPhieuKham> DanhSachThuTuc { get; set; } = new List<ChiTietPhieuKham>();
        public ToaThuoc? ToaThuoc { get; set; }
        public IList<ChiTietToaThuoc> DanhSachThuoc { get; set; } = new List<ChiTietToaThuoc>();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            // Lấy phiếu khám bệnh
            PhieuKhamBenh = await _context.PhieuKhamBenhs
                .Include(p => p.NguoiKhamNavigation)
                .Include(p => p.BacsiNavigation)
                    .ThenInclude(bs => bs.MaBsNavigation)
                .FirstOrDefaultAsync(p => p.MaPk == id);

            if (PhieuKhamBenh == null)
                return NotFound();

            // Lấy danh sách thủ tục
            DanhSachThuTuc = await _context.ChiTietPhieuKhams
                .Include(c => c.MaTtNavigation)
                .Where(c => c.MaPk == id)
                .OrderBy(c => c.MaTtNavigation.TenTuc)
                .ToListAsync();

            // Lấy toa thuốc và chi tiết thuốc (nếu có)
            ToaThuoc = await _context.ToaThuocs
                .Include(t => t.MaPkNavigation)
                .FirstOrDefaultAsync(t => t.MaPk == id);

            if (ToaThuoc != null)
            {
                DanhSachThuoc = await _context.ChiTietToaThuocs
                    .Include(ct => ct.MaThuocNavigation)
                    .Where(ct => ct.MaToaThuoc == ToaThuoc.MaToaThuoc)
                    .ToListAsync();
            }

            return Page();
        }
    }
}
