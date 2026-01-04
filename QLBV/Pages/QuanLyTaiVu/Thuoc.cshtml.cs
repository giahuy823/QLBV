using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.ViewModel;

namespace QLBV.Pages.QuanLyTaiVu
{
    [Authorize(Roles = "QuanLyTaiVu")]
    public class ThuocModel : PageModel
    {
        private readonly QLBVContext _context;
        public ThuocModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ThuocVaGiaThuoc Thuoc { get; set; } = new();

        [BindProperty]
        public DateOnly NgayApDung { get; set; } 

        public async Task<IActionResult> OnGetAsync(string maThuoc)
        {
            if (string.IsNullOrEmpty(maThuoc))
                return NotFound();

            var thuoc = await _context.Thuocs
                .Include(t => t.GiaBanThuocs)
                .FirstOrDefaultAsync(t => t.MaThuoc == maThuoc);

            if (thuoc == null)
                return NotFound();

            Thuoc = new ThuocVaGiaThuoc
            {
                MaThuoc = thuoc.MaThuoc,
                TenThuoc = thuoc.TenThuoc,
                DonVi = thuoc.DonVi,
                GiaGanNhat = thuoc.GiaBanThuocs
                    .OrderByDescending(g => g.NgayApDung)
                    .Select(g => new GiaBanDTO
                    {
                        Gia = g.GiaBan ?? 0,
                        NgayApDung = g.NgayApDung
                    })
                    .FirstOrDefault()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Thuoc.MaThuoc");
            ModelState.Remove("Thuoc.GiaGanNhat.NgayApDung");

            if (!ModelState.IsValid)
                return Page();

            try
            {
                var thuoc = await _context.Thuocs
                    .Include(t => t.GiaBanThuocs)
                    .FirstOrDefaultAsync(t => t.MaThuoc == Thuoc.MaThuoc);

                if (thuoc == null)
                    return NotFound();

                thuoc.TenThuoc = Thuoc.TenThuoc;
                thuoc.DonVi = Thuoc.DonVi;

                if (Thuoc.GiaGanNhat != null && Thuoc.GiaGanNhat.Gia > 0)
                {
                    var giaMoi = Thuoc.GiaGanNhat.Gia;
                    var ngayMoi = Thuoc.GiaGanNhat.NgayApDung;

                   
                    var giaTheoNgay = thuoc.GiaBanThuocs.FirstOrDefault(g => g.NgayApDung == ngayMoi);

                    if (giaTheoNgay != null)
                    {
                        
                        giaTheoNgay.GiaBan = giaMoi;
                    }
                    else
                    {
                       
                        thuoc.GiaBanThuocs.Add(new GiaBanThuoc
                        {
                            MaThuoc = thuoc.MaThuoc,
                            NgayApDung = ngayMoi,
                            GiaBan = giaMoi
                        });
                    }
                }

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Cập nhật thông tin thuốc thành công";
                return RedirectToPage(); 
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Lỗi khi lưu thông tin thuốc. Vui lòng thử lại.");
                return Page();
            }
        }
    }
}