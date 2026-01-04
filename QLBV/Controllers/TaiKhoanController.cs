using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;
using QLBV.Models.User_Model;
using QLBV.Models.ViewModel;
namespace QLBV.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly QLBVContext context;
        private InterfaceTaiKhoan tkrepo;
        private InterfaceBenhVien bvrepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public TaiKhoanController(
                QLBVContext context,
                InterfaceTaiKhoan tkrepo,
                InterfaceBenhVien bvrepo,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager)
        {
            this.context = context;
            this.tkrepo = tkrepo;
            this.bvrepo = bvrepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var dspb = await bvrepo.LayDanhSachPhongBanSelectListAsync();
            ViewBag.dspb = dspb;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
         
                var existingUser = await _userManager.FindByNameAsync(model.Fullname);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Fullname", "Tên đăng nhập đã tồn tại, vui lòng chọn tên khác.");
                    ViewBag.dspb = await bvrepo.LayDanhSachPhongBanSelectListAsync();
                    return View(model);
                }

                var lastNhanVien = await context.NhanViens
                    .OrderByDescending(nv => nv.MaNv)
                    .FirstOrDefaultAsync();
                var lastTK = await context.TaiKhoans
                    .OrderByDescending(tk => tk.MaTk)
                    .FirstOrDefaultAsync();

                string role = await context.PhongBans
                    .Where(pb => pb.MaPb == model.PhongBan)
                    .Select(pb => pb.TenPhongBan)
                    .FirstOrDefaultAsync();

                role = role switch
                {
                    "Phòng quản lý tài nguyên nhân sự" => "QuanLyNhanSu",
                    "Phòng quản lý tài vụ" => "QuanLyTaiVu",
                    "Phòng quản lý chuyên môn" => "QuanLyChuyenMon",
                    "Phòng tiếp tân và điều phối" => "TiepTan",
                    "Phòng khoa nội" or "Phòng khoa ngoại" or "Phòng khoa nhi" => "BacSi",
                    "Phòng tài vụ" => "TaiVu",
                    "Phòng kế toán" => "KeToan",
                    "Phòng bán thuốc" => "BanThuoc",
                    _ => "NhanVien"
                };

                string newMaNhanVien = GenerateCode.GenerateNextCode(lastNhanVien?.MaNv, "NV");
                string newMaTaiKhoan = GenerateCode.GenerateNextCode(lastTK?.MaTk, "TK");

                await bvrepo.ThemNv(newMaNhanVien, model.Fullname, null, model.Sex, role, model.Sdt, model.PhongBan);

                if (role == "BacSi")
                {
                    await bvrepo.ThemBacSi(newMaNhanVien, "Bác sĩ chuyên khoa");
                }

                await tkrepo.TaoTk(newMaTaiKhoan, newMaNhanVien, model.Fullname, model.Password, role);

                return await CreateUserAndRole(model, role, newMaNhanVien); 
            }

            ViewBag.dspb = await bvrepo.LayDanhSachPhongBanSelectListAsync();
            return View(model);
        }

        private async Task<IActionResult> CreateUserAndRole(RegisterViewModel model, string role, string maNhanVien = null)
        {
            
            var existingUser = await _userManager.FindByNameAsync(model.Fullname);
            if (existingUser != null)
            {
                ModelState.AddModelError("Fullname", "Tên đăng nhập đã tồn tại, vui lòng chọn tên khác.");
                ViewBag.dspb = await bvrepo.LayDanhSachPhongBanSelectListAsync();
                return View("Register", model);
            }

            var user = new ApplicationUser()
            {
                UserName = model.Fullname,
                Email = model.Email,
                MaNv = maNhanVien,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (role == "QuanLyNhanSu" || role == "QuanLyTaiVu" || role == "QuanLyChuyenMon")
                {
                    await _userManager.AddToRoleAsync(user, "BoPhanQuanLy");
                    await _userManager.AddToRoleAsync(user, role);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                await _userManager.AddToRoleAsync(user, role);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ViewBag.dspb = await bvrepo.LayDanhSachPhongBanSelectListAsync();
            return View (model);
        }

    }
}
