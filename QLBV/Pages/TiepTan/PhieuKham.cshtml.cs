using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.TiepTan
{
    [Authorize(Roles = "TiepTan")]
    public class PhieuKhamModel : PageModel
    {

        private readonly QLBVContext context;
        public PhieuKhamModel(QLBVContext context)
        {
            this.context = context;
        }
        public List<PhieuKhamBenh> PhieuKhamBenh { get; set; }
        public async Task OnGet(string id)
        {
            PhieuKhamBenh = await context.PhieuKhamBenhs.Include(p =>p.NguoiKhamNavigation).Where(p => p.NguoiKham == id).ToListAsync();
        }
    }
}
