using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;
using System;
using System.Threading.Tasks;

namespace QLBV.Pages.Admin
{
    [Authorize(Roles = "QuanLyNhanSu, Admin")]
    public class ThemOrSuaCaTrucModel : PageModel
    {
        private readonly QLBVContext _context;
        private readonly InterfaceBenhVien _repo;

        public ThemOrSuaCaTrucModel(QLBVContext context, InterfaceBenhVien repo)
        {
            _context = context;
            _repo = repo;
        }

        [BindProperty] 
        public CaTruc CaTruc { get; set; }

        public List<SelectListItem> Dsnv { get; set; }
        [BindProperty]
        public bool IsEdit { get; private set; }
        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
            {
                
                await InitializePageAsync(id);
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Lỗi khi tải dữ liệu: {ex.Message}";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await LoadDanhSachNhanVien();
                    return Page();
                }

                if (string.IsNullOrEmpty(CaTruc.MaCt))
                {
                    ModelState.AddModelError("PhongBan.MaPb", "Mã phòng ban là bắt buộc");
                    await LoadDanhSachNhanVien();
                    return Page();
                }

                var existing = await _context.CaTrucs.FindAsync(CaTruc.MaCt);

                if (existing == null)
                {
                    await _context.Database.ExecuteSqlRawAsync(
                        "EXEC Sp_AddCaTruc @MaCT, @ThoiGianBT, @ThoiGianKT, @NVtruc",
                        new SqlParameter("@MaCT", CaTruc.MaCt),
                        new SqlParameter("@ThoiGianBT", CaTruc.ThoiGianBt),
                        new SqlParameter("@ThoiGianKT", CaTruc.ThoiGianKt),
                        new SqlParameter("@NVtruc", CaTruc.Nvtruc)
                    );
                }
                else
                {
                    existing.ThoiGianBt = CaTruc.ThoiGianBt;
                    existing.ThoiGianKt = CaTruc.ThoiGianKt;
                    existing.Nvtruc = CaTruc.Nvtruc;
                }

                await _context.SaveChangesAsync();
                return RedirectToPage("/Admin/QuanLyCaTruc");
            }
            catch (System.Exception ex)
            {
                ErrorMessage = "Đã xảy ra lỗi khi lưu dữ liệu: " + ex.Message;
                await LoadDanhSachNhanVien();
                return Page();
            }
        }
        private async Task InitializePageAsync(string id)
        {
            await LoadDanhSachNhanVien();

            if (!string.IsNullOrEmpty(id))
            {
                IsEdit = true;
                CaTruc = await _context.CaTrucs.FindAsync(id) ?? throw new KeyNotFoundException("Không tìm thấy phòng ban");
            }
            else
            {
                IsEdit = false;
                CaTruc = new CaTruc();
            }
        }

        private async Task LoadDanhSachNhanVien()
        {
            Dsnv = await _repo.LayDanhSachNhanVienChon();
        }
    }
}