using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;

namespace QLBV.Pages.TiepTan
{
    [Authorize(Roles = "TiepTan")]
    public class TiepNhanModel : PageModel
    {
        private readonly QLBVContext _context;
        private readonly InterfaceBenhVien repoBv;

        public TiepNhanModel(QLBVContext context, InterfaceBenhVien _repoBv)
        {
            _context = context;
            repoBv = _repoBv;
        }

        [BindProperty]
        public BenhNhan BenhNhanMoi { get; set; } = new();

        public List<BenhNhan> BenhNhan { get; set; } = new();
        [TempData]
        public string Message { get; set; }

        public async Task OnGet()
        {
            BenhNhan = await repoBv.LayBenhNhanGanNhat();
            BenhNhanMoi.MaBn = await TaoMaBenhNhanTuDong();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            BenhNhan = await repoBv.LayBenhNhanGanNhat();

            if (!ModelState.IsValid)
                return Page();

     
            if (string.IsNullOrEmpty(BenhNhanMoi.MaBn))
                BenhNhanMoi.MaBn = await TaoMaBenhNhanTuDong();

            var existing = await _context.BenhNhans.FindAsync(BenhNhanMoi.MaBn);
            if (existing != null)
            {
                ModelState.AddModelError("BenhNhanMoi.MaBn", "Mã bệnh nhân đã tồn tại.");
                return Page();
            }

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Sp_AddBenhNhan @MaBN, @HoTenBN, @NgaySinh, @DiaChi, @SDT",
                new SqlParameter("@MaBN", BenhNhanMoi.MaBn),
                new SqlParameter("@HoTenBN", BenhNhanMoi.HoTenBn),
                new SqlParameter("@NgaySinh", BenhNhanMoi.NgaySinh ?? (object)DBNull.Value),
                new SqlParameter("@DiaChi", BenhNhanMoi.DiaChi ?? ""),
                new SqlParameter("@SDT", BenhNhanMoi.Sdt ?? "")
            );

            Message = $"Đã tiếp nhận bệnh nhân mới: {BenhNhanMoi.MaBn}";
            return RedirectToPage();
        }

        private async Task<string> TaoMaBenhNhanTuDong()
        {
            var maCuoi = await _context.BenhNhans
                .OrderByDescending(b => b.MaBn)
                .Select(b => b.MaBn)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(maCuoi))
                return "BN0001";

            if (maCuoi.Length < 3 || !int.TryParse(maCuoi.Substring(2), out int so))
                return "BN0001";

            return $"BN{(so + 1):D4}";
        }
    }
}
