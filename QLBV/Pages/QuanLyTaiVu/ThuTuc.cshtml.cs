using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Pages.QuanLyTaiVu
{
    [Authorize(Roles = "QuanLyTaiVu")]
    public class ThuTucModel : PageModel
    {
        private readonly QLBVContext context;
        public ThuTucModel(QLBVContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public List<ThuTuc> thuTucs { get; set; } = new List<ThuTuc>();

        public async Task OnGet()
        {
            thuTucs = await context.ThuTucs.ToListAsync();
        }
        //public async Task<IActionResult> OnPostDeleteAsync(string id)
        //{
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        try
        //        {
        //            var affectedRows = await context.Database.ExecuteSqlRawAsync(
        //                "EXEC Delete_ThuTuc @MaThuTuc = {0}", id);

        //            if (affectedRows > 0)
        //            {
        //                TempData["SuccessMessage"] = "Xóa thủ tục thành công!";
        //            }
        //            else
        //            {
        //                TempData["ErrorMessage"] = "Không tìm thấy thủ tục cần xóa!";
        //            }
        //        }
        //        catch (DbUpdateException ex)
        //        {
        //            TempData["ErrorMessage"] = "Lỗi khi xóa thủ tục: " + ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Xóa không thành công! Mã thủ tục không hợp lệ.";
        //    }

        //    return RedirectToPage();
        //}
    }
}
