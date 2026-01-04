using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;
using QLBV.Models.User_Model;

namespace QLBV.Pages.Admin
{
    [Authorize(Roles = "QuanLyNhanSu, Admin")]
    public class SuaNhanVienModel : PageModel
    {
        private readonly InterfaceNhanVien _nhanVienRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SuaNhanVienModel(
            InterfaceNhanVien nhanVienRepo,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _nhanVienRepo = nhanVienRepo;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public QLBV.Models.NhanVien NhanVien { get; set; }
        public SelectList PhongBanList { get; set; }

        private Dictionary<string, string> PhongBanRoleMapping = new()
        {
            {"PBQLNS", "QuanLyNhanSu"},
            {"PBQLTV", "QuanLyTaiVu"},
            {"PBQLCM", "QuanLyChuyenMon"},
            {"PBTTDP", "TiepTan"},
            {"PBKN", "BacSi"},
            {"PBKG", "BacSi"},
            {"PBKNHI", "BacSi"},
            {"PBTTV", "TaiVu"},
            {"PBKT", "KeToan"},
            {"PBBT", "BanThuoc"}
        };

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            NhanVien = await _nhanVienRepo.LayNhanVienById(id);

            if (NhanVien == null)
                return NotFound();

            await LoadPhongBan();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadPhongBan();
                return Page();
            }

            try
            {
                // 1. Cập nhật thông tin nhân viên
                await _nhanVienRepo.UpdateNhanVien(NhanVien);

                // 2. Xử lý đồng bộ role
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.MaNv == NhanVien.MaNv);
                if (user == null)
                {
                    ModelState.AddModelError("", "Không tìm thấy tài khoản người dùng");
                    await LoadPhongBan();
                    return Page();
                }

                // 3. Xác định role mới
                if (!PhongBanRoleMapping.TryGetValue(NhanVien.MaPb, out var newRole))
                {
                    ModelState.AddModelError("", "Không tìm thấy ánh xạ role cho phòng ban này");
                    await LoadPhongBan();
                    return Page();
                }

                // 4. Đảm bảo role tồn tại
                if (!await _roleManager.RoleExistsAsync(newRole))
                {
                    await _roleManager.CreateAsync(new IdentityRole(newRole));
                }

                // 5. Xóa tất cả roles cũ
                var currentRoles = await _userManager.GetRolesAsync(user);
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                {
                    ModelState.AddModelError("", $"Lỗi khi xóa role cũ: {string.Join(", ", removeResult.Errors)}");
                    await LoadPhongBan();
                    return Page();
                }

                // 6. Thêm role mới
                var addResult = await _userManager.AddToRoleAsync(user, newRole);
                if (!addResult.Succeeded)
                {
                    ModelState.AddModelError("", $"Lỗi khi thêm role mới: {string.Join(", ", addResult.Errors)}");
                    await LoadPhongBan();
                    return Page();
                }

                // 7. Nếu role mới là 1 trong các role quản lý, thêm role BoPhanQuanLy
                if (newRole == "QuanLyNhanSu" || newRole == "QuanLyTaiVu" || newRole == "QuanLyChuyenMon")
                {
                    var boPhanQuanLyRole = "BoPhanQuanLy";

                    // Tạo role nếu chưa tồn tại
                    if (!await _roleManager.RoleExistsAsync(boPhanQuanLyRole))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(boPhanQuanLyRole));
                    }

                    // Thêm role BoPhanQuanLy nếu chưa có
                    if (!await _userManager.IsInRoleAsync(user, boPhanQuanLyRole))
                    {
                        await _userManager.AddToRoleAsync(user, boPhanQuanLyRole);
                    }
                }

                return RedirectToPage("./QuanLyNhanVien");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi hệ thống: {ex.Message}");
                await LoadPhongBan();
                return Page();
            }
        }

        private async Task LoadPhongBan()
        {
            var phongBans = await _nhanVienRepo.LayPhongBan();
            PhongBanList = new SelectList(phongBans, "MaPb", "TenPhongBan");
        }
    }
}