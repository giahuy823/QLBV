using Microsoft.AspNetCore.Identity;

namespace QLBV.Models.User_Model;

public class SeedData
{
    public static async Task CreateUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = serviceProvider.GetRequiredService<QLBVContext>();

        var users = new List<(string UserName, string Password, string Role, string MaNV)>
            {
                ("PBQLNS12", "12345678", "QuanLyNhanSu", "NV001"),
                ("PBQLTV12", "12345678", "QuanLyTaiVu", "NV002"),
                ("PBQLCM12", "12345678", "QuanLyChuyenMon", "NV003"),
                ("PBTT1234", "12345678", "TiepTan", "NV004"),
                ("PBBS1234", "12345678", "BacSi", "BS001"),
                ("PBBS12345", "12345678", "BacSi", "BS002"),
                ("PBBS123456", "12345678", "BacSi", "BS003"),
                ("PBTV1234", "12345678", "TaiVu", "NV005"),
                ("PBKT1234", "12345678", "KeToan", "NV006"),
                ("PBBT1234", "12345678", "BanThuoc", "NV007"),
            };

        foreach (var (userName, password, role, maNV) in users)
        {
            var nhanVien = await dbContext.NhanViens.FindAsync(maNV);
            if (nhanVien == null)
            {
                Console.WriteLine($"Không tìm thấy nhân viên {maNV}!");
                continue;
            }

            var existingUser = await userManager.FindByNameAsync(userName);
            if (existingUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = $"{userName}@gmail.com", // cần Email nếu hệ thống yêu cầu
                    EmailConfirmed = true,
                    MaNv = maNV
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    // Gán role chính
                    await userManager.AddToRoleAsync(user, role);

                
                    if (role == "QuanLyNhanSu" || role == "QuanLyTaiVu" || role == "QuanLyChuyenMon")
                    {
                        await userManager.AddToRoleAsync(user, "BoPhanQuanLy");
                    }

                    Console.WriteLine($"User '{userName}' created with role '{role}'{(role.StartsWith("QuanLy") ? " + BoPhanQuanLy" : "")}.");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Failed to create user {userName}: {error.Description}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"User '{userName}' already exists.");
            }
        }
    }
}


