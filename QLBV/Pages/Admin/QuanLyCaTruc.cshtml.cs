using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;

namespace QLBV.Pages.Admin
{
    [Authorize(Roles = "QuanLyNhanSu, Admin")]
    public class QuanLyCaTrucModel : PageModel
    {
        private readonly QLBVContext _context;
        private InterfaceBenhVien repoBv;
        
        public QuanLyCaTrucModel(QLBVContext context, InterfaceBenhVien _repoBv)
        {
            _context = context;
            repoBv = _repoBv;
        }
        public List<SelectListItem> Dsnv { get; set; } = new List<SelectListItem>();

        public List<CaTruc> DanhSachCaTruc { get; set; }

        public async Task OnGetAsync()
        {
             Dsnv = await repoBv.LayDanhSachNhanVienChon();
             DanhSachCaTruc = await _context.CaTrucs.Include(ct=>ct.NvtrucNavigation)
             .OrderByDescending(ct => ct.ThoiGianBt)
            .ToListAsync();
        }
    }
}
