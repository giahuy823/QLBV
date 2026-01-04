using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.ViewModel;
namespace QLBV.Pages.KeToan
{
    [Authorize(Roles = "KeToan")]
    public class ThemLuongModel : PageModel
    {
        private readonly QLBVContext context;
        [BindProperty]
        public LuongViewModel Luong { get; set; }
        public ThemLuongModel( QLBVContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost()
        {
            ModelState.Remove("Luong.MaLuong");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Luong.MaLuong = "L" + Luong.MaNV + DateOnly.FromDateTime(DateTime.Now).ToString("yyyyMMdd"); 
                decimal luongCB = decimal.Parse(Luong.LuongCoBan);
                Luong.TongLuong = luongCB * Luong.NgayCong *8 + Luong.PhuCap;

                var parameters = new[]
                {
                    new SqlParameter("@MaLuong", Luong.MaLuong),
                    new SqlParameter("@MaNV", Luong.MaNV),
                    new SqlParameter("@Thang", Luong.Thang),
                    new SqlParameter("@Nam", Luong.Nam),
                    new SqlParameter("@LuongCoBan", Luong.LuongCoBan),
                    new SqlParameter("@PhuCap", Luong.PhuCap),
                    new SqlParameter("@NgayCong", Luong.NgayCong),
                    new SqlParameter("@TongLuong", Luong.TongLuong),
                };

                await context.Database.ExecuteSqlRawAsync(
                    "EXEC ThemLuong_MaHoa @MaLuong, @MaNV, @Thang, @Nam, @LuongCoBan, @PhuCap, @NgayCong, @TongLuong",
                    parameters);

                return RedirectToPage("Index", new { MaNV = Luong.MaNV });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Lỗi: {ex.Message}");
                return Page();
            }
        }

    }
}
