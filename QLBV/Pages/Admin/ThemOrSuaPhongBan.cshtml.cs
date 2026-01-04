using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace QLBV.Pages.Admin
{
    [Authorize(Roles = "QuanLyNhanSu, Admin")]
    public class ThemOrSuaPhongBanModel : PageModel
    {
        private readonly QLBVContext _context;
        private readonly InterfaceBenhVien _repoBv;

        public ThemOrSuaPhongBanModel(QLBVContext context, InterfaceBenhVien repoBv)
        {
            _context = context;
            _repoBv = repoBv;
        }

        [BindProperty]
        public PhongBan PhongBan { get; set; }

        public List<SelectListItem> DanhSachBoPhan { get; set; }
        public bool IsEdit { get; private set; }
        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
            {
                await InitializePageAsync(id);
                return Page();
            }
            catch (System.Exception ex)
            {
                ErrorMessage = "Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await LoadDanhSachBoPhan();
                    return Page();
                }

                if (string.IsNullOrEmpty(PhongBan.MaPb))
                {
                    ModelState.AddModelError("PhongBan.MaPb", "Mã phòng ban là bắt buộc");
                    await LoadDanhSachBoPhan();
                    return Page();
                }

                var existing = await _context.PhongBans.FindAsync(PhongBan.MaPb);

                if (existing == null)
                {
                    await _context.Database.ExecuteSqlRawAsync(
                   "EXEC Sp_AddPhongBan @MaPB, @MaBP, @TenPhongBan, @MoTa",
                   new SqlParameter("@MaPB", PhongBan.MaPb),
                   new SqlParameter("@MaBP", PhongBan.MaBp ?? (object)DBNull.Value),
                   new SqlParameter("@TenPhongBan", PhongBan.TenPhongBan),
                   new SqlParameter("@MoTa", (object?)PhongBan.MoTa ?? DBNull.Value)
               );
                }
                else
                {
                    existing.TenPhongBan = PhongBan.TenPhongBan;
                    existing.MoTa = PhongBan.MoTa;
                    existing.MaBp = PhongBan.MaBp;
                    _context.PhongBans.Update(existing);
                }

                await _context.SaveChangesAsync();
                return RedirectToPage("/Admin/QuanLyPhongBan");
            }
            catch (System.Exception ex)
            {
                ErrorMessage = "Đã xảy ra lỗi khi lưu dữ liệu: " + ex.Message;
                await LoadDanhSachBoPhan();
                return Page();
            }
        }

        private async Task InitializePageAsync(string id)
        {
            await LoadDanhSachBoPhan();

            if (!string.IsNullOrEmpty(id))
            {
                IsEdit = true;
                PhongBan = await _context.PhongBans.FindAsync(id) ?? throw new KeyNotFoundException("Không tìm thấy phòng ban");
            }
            else
            {
                IsEdit = false;
                PhongBan = new PhongBan();
            }
        }

        private async Task LoadDanhSachBoPhan()
        {
            DanhSachBoPhan = await _repoBv.LayDanhSachBoPhan();
        }
    }
}