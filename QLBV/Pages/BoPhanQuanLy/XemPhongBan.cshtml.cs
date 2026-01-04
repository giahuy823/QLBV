using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLBV.Models.InterfaceRepository;
using QLBV.Models;
using Microsoft.AspNetCore.Authorization;

namespace QLBV.Pages.BoPhanQuanLy
{
    [Authorize(Roles = "BoPhanQuanLy")]
    public class XemPhongBanModel : PageModel
    {
        private InterfaceNhanVien repoNv;
        private readonly QLBVContext _context;
        public XemPhongBanModel(QLBVContext context, InterfaceNhanVien _repoNv)
        {
            _context = context;
            repoNv = _repoNv;
        }
        public List<PhongBan> DanhSachCacPhongBan { get; set; } = new List<PhongBan>();
        public async Task<IActionResult> OnGet()
        {
            DanhSachCacPhongBan = await repoNv.LayPhongBan();
            return Page();
        }
    }
}
