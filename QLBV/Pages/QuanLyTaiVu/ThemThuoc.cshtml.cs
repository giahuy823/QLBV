using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using System.Data;
using System.Threading.Tasks;

namespace QLBV.Pages.QuanLyTaiVu
{
    [Authorize(Roles = "QuanLyTaiVu")]
    public class ThemThuocModel : PageModel
    {
        private readonly QLBVContext _context;

        public ThemThuocModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Thuoc Thuoc { get; set; } = new Thuoc();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.Sp_AddThuoc";
                    command.CommandType = CommandType.StoredProcedure;

                    var maThuocParam = new SqlParameter("@MaThuoc", Thuoc.MaThuoc);
                    var tenThuocParam = new SqlParameter("@TenThuoc", Thuoc.TenThuoc);
                    var donViParam = new SqlParameter("@DonVi", Thuoc.DonVi);

                    command.Parameters.Add(maThuocParam);
                    command.Parameters.Add(tenThuocParam);
                    command.Parameters.Add(donViParam);

                    await command.ExecuteNonQueryAsync();
                }

                TempData["SuccessMessage"] = "Thêm thuốc mới thành công";
                return RedirectToPage("XemThuocVaGiaThuoc");
            }
            catch (SqlException ex)
            {
                // Mã lỗi 50000 là của RAISERROR
                if (ex.Number == 50000)
                {
                    ModelState.AddModelError("Thuoc.MaThuoc", ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi cơ sở dữ liệu: " + ex.Message);
                }

                return Page();
            }
        }
    }
}
