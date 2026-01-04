using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.InterfaceRepository;
using System;
using System.Threading.Tasks;

namespace QLBV.Pages.TiepTan
{
    [Authorize(Roles ="TiepTan")]
    public class DieuPhoiModel : PageModel
    {
        private readonly QLBVContext _context;
        private readonly InterfaceBenhVien _repoBv;

        public DieuPhoiModel(QLBVContext context, InterfaceBenhVien repoBv)
        {
            _context = context;
            _repoBv = repoBv;
        }

        [BindProperty(SupportsGet = true)]
        public string? Id { get; set; }

        [BindProperty]
        public BenhNhan BenhNhan { get; set; } = new BenhNhan();

        [BindProperty]
        public PhieuKhamBenh PhieuKhamMoi { get; set; } = new PhieuKhamBenh();

        public List<SelectListItem> Dsbs { get; set; } = new List<SelectListItem>();
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                await LoadDanhSachBacSi();

                if (!string.IsNullOrEmpty(Id))
                {
                    BenhNhan = await _repoBv.LayBenhNhanTheoId(Id);
                    if (BenhNhan == null)
                    {
                        ErrorMessage = "Không tìm thấy bệnh nhân với mã này";
                    }
                    else
                    {
                        PhieuKhamMoi.NguoiKham = BenhNhan.MaBn;
                        PhieuKhamMoi.NgayKham = DateOnly.FromDateTime(DateTime.Now);
                        
                        SuccessMessage = "Đã tìm thấy bệnh nhân với id " + Id;
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Đã xảy ra lỗi: {ex.Message}";
                return Page();
            }
        }
      
        public async Task<IActionResult> OnPostTaoPhieuKham()
        {
           
                ModelState.Remove("PhieuKhamMoi.MaPk");
                PhieuKhamMoi.MaPk = $"PK-{DateTime.Now:yyyyMMddHHmmss}";
                await LoadDanhSachBacSi();

                if (!ModelState.IsValid)
                {
                    ErrorMessage = "Có vấn đề khi tạo phiếu khám";
                    return Page();
                }

                var benhNhan = await _repoBv.LayBenhNhanTheoId(PhieuKhamMoi.NguoiKham);
                if (benhNhan == null)
                {
                    ErrorMessage = "Bệnh nhân không tồn tại";
                    return Page();
                }

                var maSoKham = await _repoBv.TaoSoKhamBenhMoi(PhieuKhamMoi.NguoiKham);
                if (maSoKham == null)
                {
                    ErrorMessage = "Không tạo được mã sổ khám";
                    return Page();
                }

                PhieuKhamMoi.MaSoKham = maSoKham;

                
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [dbo].[Sp_AddPhieuKham] @MaPK, @TrieuChung, @NgayKham, @NguoiKham, @BacSi, @MaSoKham",
                    new SqlParameter("@MaPK", PhieuKhamMoi.MaPk),
                    new SqlParameter("@TrieuChung", PhieuKhamMoi.TrieuChung ?? ""),
                    new SqlParameter("@NgayKham", PhieuKhamMoi.NgayKham),
                    new SqlParameter("@NguoiKham", PhieuKhamMoi.NguoiKham),
                    new SqlParameter("@BacSi", PhieuKhamMoi.Bacsi),
                    new SqlParameter("@MaSoKham", PhieuKhamMoi.MaSoKham)
                );

                
                var soKham = await _context.SoKhamBenhs
                    .FirstOrDefaultAsync(s => s.MaSoKham == maSoKham);

                if (soKham != null)
                {
                    
                    soKham.MaPk = PhieuKhamMoi.MaPk;

                    
                    await _context.SaveChangesAsync();
                }

                SuccessMessage = "Đã tạo phiếu khám thành công";
                return Page();
         }
            
            


        private async Task LoadDanhSachBacSi()
        {
            Dsbs = await _repoBv.LayDanhSachBacSiChon();
        }
    }
}