using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QLBV.Pages.TaiVu
{
    [Authorize(Roles ="TaiVu")]
    public class ChiTietPhieuKhamModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
