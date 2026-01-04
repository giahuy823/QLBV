using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLBV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace QLBV.Pages.BoPhanQuanLy
{
    [Authorize(Roles = "BoPhanQuanLy")]
    public class XemThuTucModel : PageModel
    {

        private QLBVContext context;
        public XemThuTucModel(QLBVContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public List<ThuTuc> thuTucs { get; set; } = new List<ThuTuc>();
        public async Task<IActionResult> OnGet()
        {
            thuTucs = await context.ThuTucs.ToListAsync();
            return Page();
        }
    }
}
