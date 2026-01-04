using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.User_Model;
using QLBV.Models.ViewModel;

namespace QLBV.Pages.BoPhanQuanLy
{
    [Authorize(Roles = "BoPhanQuanLy")]
    public class XemLuongModel : PageModel
    {
        private readonly QLBVContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public XemLuongModel(QLBVContext context, UserManager<ApplicationUser> _userManager)
        {
            this._context = context;
            this._userManager = _userManager;
        }
        public List<LuongViewModel> DsLuong { get; set; } = new List<LuongViewModel>();
        public async Task<IActionResult> OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null || string.IsNullOrEmpty(currentUser.MaNv))
            {
                return Unauthorized();
            }

            string maNvHienTai = currentUser.MaNv;
            var danhSachTam = new List<LuongViewModel>();

            // Lương giải mã Mã NV 
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "XemLuong_GiaiMa";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var param = command.CreateParameter();
                param.ParameterName = "@MaNV";
                param.Value = maNvHienTai;
                command.Parameters.Add(param);

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        danhSachTam.Add(new LuongViewModel
                        {
                            MaLuong = reader["MaLuong"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            Thang = Convert.ToInt32(reader["Thang"]),
                            Nam = Convert.ToInt32(reader["Nam"]),
                            LuongCoBan = reader["LuongCoBan"].ToString(),
                            PhuCap = reader["PhuCap"] != DBNull.Value ? Convert.ToDecimal(reader["PhuCap"]) : 0,
                            NgayCong = reader["NgayCong"] != DBNull.Value ? Convert.ToInt32(reader["NgayCong"]) : 0,
                            TongLuong = reader["TongLuong"] != DBNull.Value ? Convert.ToDecimal(reader["TongLuong"]) : 0
                        });
                    }
                }
            }

           //Lương người khác
            var luongKhac = await _context.Luongs
                .Include(l => l.MaNvNavigation)
                .Where(l => l.MaNv != maNvHienTai)
                .Select(l => new LuongViewModel
                {
                    MaLuong = l.MaLuong,
                    MaNV = l.MaNv,
                    Thang = l.Thang ?? 0,
                    Nam = l.Nam ?? 0,
                    LuongCoBan = "[Đã mã hóa]",
                    PhuCap = l.PhuCap ?? 0,
                    NgayCong = l.NgayCong ?? 0,
                    TongLuong = l.TongLuong ?? 0
                })
                .ToListAsync();

            // Gộp và ưu tiên lương của người dùng hiện tại lên đầu
            DsLuong = danhSachTam.Concat(luongKhac).ToList();

            return Page();
        }

    }
}
