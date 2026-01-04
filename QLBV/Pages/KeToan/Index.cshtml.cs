using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.ViewModel;
using System.Text;

namespace QLBV.Pages.KeToan
{
    [Authorize(Roles ="KeToan")]
    public class IndexModel : PageModel
    {
        private readonly QLBVContext _context;

        public IndexModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string MaNv { get; set; }

        public List<LuongViewModel> DsLuong { get; set; } = new List<LuongViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            if (!string.IsNullOrEmpty(MaNv))
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "XemLuong_GiaiMa";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    var param = command.CreateParameter();
                    param.ParameterName = "@MaNV";
                    param.Value = MaNv;
                    command.Parameters.Add(param);

                    await _context.Database.OpenConnectionAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DsLuong.Add(new LuongViewModel
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
            }
            else
            {
                DsLuong = await _context.Luongs
                    .Include(l => l.MaNvNavigation)
                    .Select(l => new LuongViewModel
                    {
                        MaLuong = l.MaLuong,
                        MaNV = l.MaNv,
                       
                        Thang = l.Thang ?? 0,
                        Nam = l.Nam ?? 0,
                        LuongCoBan = "[Đã mã hóa]",
                        PhuCap = l.PhuCap ?? 0,
                        NgayCong = l.NgayCong ?? 0,
                        TongLuong = l.TongLuong ?? 0,
                     
                    }).ToListAsync();
            }

            return Page();
        }
    }
}