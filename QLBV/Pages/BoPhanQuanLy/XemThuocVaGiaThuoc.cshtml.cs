using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models.ViewModel;
using QLBV.Models;
using Microsoft.AspNetCore.Authorization;


namespace QLBV.Pages.BoPhanQuanLy
{
    [Authorize(Roles = "BoPhanQuanLy")]
    public class XemThuocVaGiaThuocModel : PageModel
    {
        private readonly QLBVContext _context;
        public XemThuocVaGiaThuocModel(QLBVContext context)
        {
            _context = context;
        }

        public List<ThuocVaGiaThuoc> DanhSachThuoc { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            DanhSachThuoc = await _context.Thuocs
                .Select(t => new ThuocVaGiaThuoc
                {
                    MaThuoc = t.MaThuoc,
                    TenThuoc = t.TenThuoc,
                    DonVi = t.DonVi,
                    GiaGanNhat = t.GiaBanThuocs
                        .OrderByDescending(g => g.NgayApDung)
                        .Select(g => new GiaBanDTO
                        {
                            Gia = g.GiaBan ?? 0,
                            NgayApDung = g.NgayApDung
                        })
                        .FirstOrDefault()
                })
                .ToListAsync();

            return Page();
        }
    }
}
