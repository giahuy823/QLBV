using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.BacSi
{
    [Authorize(Roles = "BacSi")]
    public class ThemToaThuocModel : PageModel
    {

        private readonly QLBVContext _context;

        public ThemToaThuocModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PhieuKhamBenh PhieuKham { get; set; }

        [BindProperty]
        public List<ChiTietToaThuoc> ThuocDuocKe { get; set; } = new();

        public SelectList ThuocList { get; set; }

        public async Task<IActionResult> OnGetAsync(string maPk)
        {
            if (string.IsNullOrEmpty(maPk)) return NotFound();

            PhieuKham = await _context.PhieuKhamBenhs
                .Include(p => p.BacsiNavigation)
                .Include(p => p.ToaThuoc) // Thêm include để kiểm tra toa thuốc
                .FirstOrDefaultAsync(p => p.MaPk == maPk);

            if (PhieuKham == null) return NotFound();

            
            if (PhieuKham.ToaThuoc != null)
            {
                return RedirectToPage("./PhieuKham", new { id = maPk });
            }

            ThuocList = new SelectList(await _context.Thuocs.ToListAsync(), "MaThuoc", "TenThuoc");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var phieu = await _context.PhieuKhamBenhs
                .Include(p => p.ToaThuoc) // Kiểm tra toa thuốc
                .FirstOrDefaultAsync(p => p.MaPk == PhieuKham.MaPk);

            if (phieu == null) return NotFound();

   
            if (phieu.ToaThuoc != null)
            {
                ModelState.AddModelError(string.Empty, "Phiếu khám này đã có toa thuốc.");
                ThuocList = new SelectList(await _context.Thuocs.ToListAsync(), "MaThuoc", "TenThuoc");
                return Page();
            }

            // Cập nhật triệu chứng
            phieu.TrieuChung = PhieuKham.TrieuChung;

            var maToa = $"TT{DateTime.Now:yyyyMMddHHmmss}";
            decimal tongTien = 0;

            var toa = new ToaThuoc
            {
                MaToaThuoc = maToa,
                MaPk = PhieuKham.MaPk,
                MaBacSi = phieu.Bacsi,
                NgayKe = DateOnly.FromDateTime(DateTime.Now),
                TongTien = 0 
            };

            
            _context.ToaThuocs.Add(toa);
            await _context.SaveChangesAsync();

            foreach (var chiTiet in ThuocDuocKe)
            {
                if (string.IsNullOrEmpty(chiTiet.MaThuoc)) continue;

                var thuoc = await _context.Thuocs.FirstOrDefaultAsync(t => t.MaThuoc == chiTiet.MaThuoc);
                if (thuoc == null) continue;

                var giaBan = await _context.GiaBanThuocs
                    .Where(g => g.MaThuoc == chiTiet.MaThuoc)
                    .OrderByDescending(g => g.NgayApDung)
                    .FirstOrDefaultAsync();

                if (giaBan != null)
                {
                    // Parse SoLuong to integer
                    int soLuong = int.Parse(chiTiet.SoLuong);
                    tongTien += giaBan.GiaBan.Value * soLuong;

                   
                    await _context.Database.ExecuteSqlRawAsync(
                        "EXEC Sp_AddChiTietToaThuoc @MaToaThuoc, @MaThuoc, @SoLuong, @LieuDung",
                        new SqlParameter("@MaToaThuoc", maToa),
                        new SqlParameter("@MaThuoc", chiTiet.MaThuoc),
                        new SqlParameter("@SoLuong", soLuong), 
                        new SqlParameter("@LieuDung", chiTiet.LieuDung ?? "")
                    );
                }
            }

            toa.TongTien = tongTien;
            await _context.SaveChangesAsync();

            return RedirectToPage("./PhieuKham", new { id = phieu.MaPk });
        }
    }
}
