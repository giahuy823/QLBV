using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLBV.Models.ViewModel;
using QLBV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace QLBV.Pages.BanThuoc
{
    [Authorize(Roles ="BanThuoc")]
    public class CapPhatThuocModel : PageModel
    {
        private readonly QLBVContext _context;

        public CapPhatThuocModel(QLBVContext context)
        {
            _context = context;
        }

        public List<ThuocViewModel> DanhSachThuoc { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string? MaToaThuoc { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = from tt in _context.ToaThuocs
                        join ct in _context.ChiTietToaThuocs on tt.MaToaThuoc equals ct.MaToaThuoc
                        join th in _context.Thuocs on ct.MaThuoc equals th.MaThuoc
                        select new ThuocViewModel
                        {
                            MaToaThuoc = tt.MaToaThuoc,
                            NgayKe = tt.NgayKe,
                            MaThuoc = ct.MaThuoc,
                            TenThuoc = th.TenThuoc,
                            SoLuong = ct.SoLuong,
                            LieuDung = ct.LieuDung,
                            TongTien = tt.TongTien
                        };

            if (!string.IsNullOrEmpty(MaToaThuoc))
            {
                query = query.Where(x => x.MaToaThuoc.Contains(MaToaThuoc));
            }

            DanhSachThuoc = await query.ToListAsync();
            return Page();
        }
    }
}
