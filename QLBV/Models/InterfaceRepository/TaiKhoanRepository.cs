using Microsoft.EntityFrameworkCore;

namespace QLBV.Models.InterfaceRepository
{
    public class TaiKhoanRepository : InterfaceTaiKhoan
    {
        private readonly QLBVContext _context;
        public TaiKhoanRepository(QLBVContext context)
        {
            _context = context;
        }
        public async Task TaoTk(string maTk, string maNv, string tenDn, string matKhau, string? loaiTk)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC TaoTaiKhoan_MaHoa @MaTK = {0}, @MaNV = {1}, @TenDN = {2}, @MatKhau = {3}, @LoaiTK = {4}",
                maTk, maNv, tenDn, matKhau, loaiTk);
        }
    }
}
