using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;

namespace QLBV.Models.InterfaceRepository
{
    public class NhanVienRepository : InterfaceNhanVien
    {
        private readonly QLBVContext _context;

        public NhanVienRepository(QLBVContext context)
        {
            _context = context;
        }

        public async Task UpdateNhanVien(NhanVien nhanVien)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateNhanVien @MaNV, @HoTenNV, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaPB",
                new SqlParameter("@MaNV", nhanVien.MaNv),
                new SqlParameter("@HoTenNV", nhanVien.HoTenNv),
                new SqlParameter("@NgaySinh", nhanVien.NgaySinh),
                new SqlParameter("@GioiTinh", nhanVien.GioiTinh),
                new SqlParameter("@DiaChi", nhanVien.DiaChi),
                new SqlParameter("@SDT", nhanVien.Sdt),
                new SqlParameter("@MaPB", nhanVien.MaPb)
            );
        }

        public async Task<NhanVien> LayNhanVienById(string maNV)
        {
            return await _context.NhanViens
                .Include(nv => nv.MaPbNavigation)
                .FirstOrDefaultAsync(nv => nv.MaNv == maNV);
        }

        public async Task<List<NhanVien>> LayNhanVien()
        {
            return await _context.NhanViens
                .Include(nv => nv.MaPbNavigation)
                .ToListAsync();
        }

        public async Task<List<PhongBan>> LayPhongBan()
        {
            return await _context.PhongBans.ToListAsync();
        }
    }
}