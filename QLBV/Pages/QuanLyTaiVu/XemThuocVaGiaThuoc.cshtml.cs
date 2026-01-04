using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLBV.Models.ViewModel;
using QLBV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace QLBV.Pages.QuanLyTaiVu
{
    [Authorize(Roles = "QuanLyTaiVu")]
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
        //public async Task<IActionResult> OnPostDeleteAsync(string maThuoc)
        //{
        //    if (string.IsNullOrEmpty(maThuoc))
        //        return NotFound();

           
        //    var thuoc = await _context.Thuocs.FirstOrDefaultAsync(t => t.MaThuoc == maThuoc);
        //    if (thuoc == null)
        //        return NotFound();

           
        //    await _context.Database.ExecuteSqlRawAsync(
        //        "EXEC Delete_Thuoc @MaThuoc = {0}", maThuoc);

        //    return RedirectToPage();
        //}
    }
}

