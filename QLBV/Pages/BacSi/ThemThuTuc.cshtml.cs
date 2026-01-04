using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using QLBV.Models;
using QLBV.Models.User_Model;

namespace QLBV.Pages.BacSi
{
    [Authorize(Roles = "BacSi")]
    public class ThemThuTucModel : PageModel
    {
        private readonly QLBVContext _context;

        public ThemThuTucModel(QLBVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChiTietPhieuKham ChiTietPhieuKham { get; set; }

        [BindProperty]
        public string MaPK { get; set; }

        public List<SelectListItem> DanhSachThuTuc { get; set; }
        public string LayMa()
        {
            var userManager = HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>();
            var user = userManager.GetUserAsync(User).Result;

            if (user != null)
            {

                if (userManager.IsInRoleAsync(user, "BacSi").Result)
                {
                    return user.MaNv;
                }
                else if (userManager.IsInRoleAsync(user, "NhanVien").Result)
                {
                    return user.MaNv;
                }
            }
            return null;

        }
        public async Task<IActionResult> OnGetAsync(string maPK)
        {
            
            var maBS = LayMa();
            var phieuKham = await _context.PhieuKhamBenhs
                .FirstOrDefaultAsync(p => p.MaPk == maPK && p.Bacsi == maBS);

            if (phieuKham == null)
            {
                return NotFound();
            }

            MaPK = maPK;

            
            await LoadDanhSachThuTuc();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
       
                await LoadDanhSachThuTuc();
                return Page();
            }

           
            var thuTuc = await _context.ThuTucs.FindAsync(ChiTietPhieuKham.MaTt);
            if (thuTuc != null)
            {
               
                ChiTietPhieuKham.SoTien = thuTuc.DonGia;
            }

            ChiTietPhieuKham.TtthanhToan = "Chưa thanh toán";
            ChiTietPhieuKham.MaPk = MaPK;

            _context.ChiTietPhieuKhams.Add(ChiTietPhieuKham);
            await _context.SaveChangesAsync();

            return RedirectToPage("/BacSi/PhieuKham", new { id = MaPK });
        }
        public async Task LoadDanhSachThuTuc()
        {
            DanhSachThuTuc = await _context.ThuTucs
                 .Select(t => new SelectListItem
                 {
                     Value = t.MaThuTuc,
                     Text = $"{t.TenTuc} - {t.DonGia} VNĐ"
                 })
                 .ToListAsync();
        }

    }
}