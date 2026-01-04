using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLBV.Models.InterfaceRepository;
using QLBV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using QLBV.Models.User_Model;
using Microsoft.AspNetCore.Authorization;

namespace QLBV.Pages.BoPhanQuanLy
{
    [Authorize(Roles="BoPhanQuanLy")]
    public class XemCaTrucModel : PageModel
    {
        private readonly QLBVContext _context;
        private InterfaceBenhVien repoBv;
        private readonly UserManager<ApplicationUser> _userManager;
        public XemCaTrucModel(QLBVContext context, InterfaceBenhVien _repoBv, UserManager<ApplicationUser> _userManager)
        {
            _context = context;
            repoBv = _repoBv;
            this._userManager = _userManager;
        }
        public List<CaTruc> DanhSachCaTruc { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            DanhSachCaTruc = await _context.CaTrucs
            .Include(ct => ct.NvtrucNavigation)
            .OrderByDescending(ct => ct.Nvtruc == user.MaNv) 
            .ThenByDescending(ct => ct.ThoiGianBt)         
            .ToListAsync();
        }
    }
}
