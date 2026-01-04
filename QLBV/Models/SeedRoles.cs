using Microsoft.AspNetCore.Identity;

namespace QLBV.Models
{
    public class SeedRoles
    {
        public static class IdentityDataInitializer
        {
            public static async Task SeedRoles(IServiceProvider serviceProvider)
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roles = new[]
                       {
                        "BoPhanQuanLy",
                        "QuanLyNhanSu",     // PBQLNS
                        "QuanLyTaiVu",      // PBQLTV
                        "QuanLyChuyenMon",  // PBQLCM
                        "TiepTan",          // PBTTDP
                        "BacSi",            // PBKN, PBKG, PBKNHI
                        "TaiVu",            // PBTTV
                        "KeToan",           // PBKT
                        "BanThuoc",         // PBBT
                        "NhanVien",
                        "Admin"
                    };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
        }
    }
}