using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.User_Model;

namespace QLBV.Pages.BacSi
{
    [Authorize(Roles = "BacSi")]
    public class DanhSachPhieuKhamModel : PageModel
    {
     
        private readonly QLBVContext _context;
        public DanhSachPhieuKhamModel(QLBVContext context)
        {
            _context = context;
        }
        public IList<PhieuKhamBenh> PhieuKhamBenhs { get; set; } = new List<PhieuKhamBenh>();
        [BindProperty]
        public string MaPk { get; set; }

      
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

        public async Task OnGetAsync()
        {

            var maBS = LayMa();
            PhieuKhamBenhs = await _context.PhieuKhamBenhs
                .Include(p => p.NguoiKhamNavigation)
                .Include(p => p.BacsiNavigation)
                .Where(p => p.Bacsi == maBS && p.NgayKham == DateOnly.FromDateTime(DateTime.Now))
                .ToListAsync();
            
        }
        public async Task<IActionResult> OnPostTimKiem()
        {
            var maBacSi = LayMa();
            var ngayHienTai = DateOnly.FromDateTime(DateTime.Now);

            var query = _context.PhieuKhamBenhs
                .Include(p => p.NguoiKhamNavigation)
                .Include(p => p.BacsiNavigation)
                .Where(p => p.Bacsi == maBacSi && p.NgayKham == ngayHienTai);

            if (!string.IsNullOrWhiteSpace(MaPk))
            {
                query = query.Where(p => p.MaPk.Contains(MaPk));
            }

            PhieuKhamBenhs = await query.ToListAsync();

            return Page();
        }

    }
}
