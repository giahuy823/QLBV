using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Models.InterfaceRepository
{
    public class BenhVienRepository : InterfaceBenhVien
    {
        private readonly QLBVContext _context;
        public BenhVienRepository(QLBVContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> LayDanhSachPhongBanSelectListAsync()
        {
            
            return await _context.PhongBans
                .Select(p => new SelectListItem
                {
                    Value = p.MaPb,
                    Text = p.TenPhongBan
                })
                .ToListAsync();
        }
        public async Task<List<SelectListItem>> LayDanhSachBoPhan()
        {
            return await _context.BoPhans.Select(bp => new SelectListItem
            {
                Value = bp.MaBp,
                Text = bp.TenBoPhan
            })
                .ToListAsync();
        }
        public async Task<List<SelectListItem>> LayDanhSachNhanVienChon()
        {
            return await _context.NhanViens.Select(nv => new SelectListItem
            {
                Value = nv.MaNv,
                Text = nv.HoTenNv
            })
                .ToListAsync();
        }
        public async Task<List<BenhNhan>> LayBenhNhanGanNhat()
        {
            return await _context.BenhNhans.OrderByDescending(b=>b.MaBn).Take(5).ToListAsync();
        }
        public async Task ThemNv(string maNV, string hoTen, string ngaySinh, string gioiTinh, string? diachi, string sdt, string mapb)
        {
            var parameters = new[]
            {
                new SqlParameter("@MaNV", maNV ?? (object)DBNull.Value),
                new SqlParameter("@HoTenNV", hoTen ?? (object)DBNull.Value),
                new SqlParameter("@NgaySinh", ngaySinh ?? (object)DBNull.Value),
                new SqlParameter("@GioiTinh", gioiTinh ?? (object)DBNull.Value),
                new SqlParameter("@DiaChi", diachi ?? (object)DBNull.Value),
                new SqlParameter("@SDT", sdt ?? (object)DBNull.Value),
            
                new SqlParameter("@MaPB", mapb ?? (object)DBNull.Value),
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC Sp_AddNV @MaNV, @HoTenNV, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaPB", parameters);
        }
        public async Task<BacSi> LayNhanVien(string id)
        {
            return await _context.BacSis
           .Include(bs => bs.MaBsNavigation)
               .ThenInclude(nv => nv.MaPbNavigation)
           .FirstOrDefaultAsync(bs => bs.MaBs == id);
        }
        public async Task ThemBacSi(string manv, string trinhdo)
        {
            await _context.Database.ExecuteSqlRawAsync(
           "EXEC Sp_AddBacSi @MaBS = {0}, @TrinhDo = {1}",
           manv, trinhdo
            );
        }
        public async Task<BenhNhan> LayBenhNhanTheoId(string id)
        {
            return await _context.BenhNhans.FirstOrDefaultAsync(bn => bn.MaBn == id);
        }
        public async Task<List<BacSi>> LayDanhSachBacSi()
        {
            return await _context.BacSis
                .Include(bs => bs.MaBsNavigation) // Include thông tin Nhân viên
                    .ThenInclude(nv => nv.MaPbNavigation) // Include thông tin Phòng ban
                .ToListAsync();
        }
        public async Task<List<SelectListItem>> LayDanhSachBacSiChon()
        {
            var danhSachBacSi = await LayDanhSachBacSi();

            return danhSachBacSi.Select(bs => new SelectListItem
            {
                Value = bs.MaBs,
                Text = $"{bs.MaBsNavigation.HoTenNv} - {bs.MaBsNavigation.MaPbNavigation?.TenPhongBan}"
            }).ToList();
        }
        public async Task<int?> LayMaSoKhamHienTai(string maBenhNhan)
        {
            return await _context.SoKhamBenhs
                .Where(s => s.MaBn == maBenhNhan)
                .OrderByDescending(s => s.MaSoKham)
                .Select(s => (int?)s.MaSoKham)
                .FirstOrDefaultAsync();
        }

        public async Task<int> TaoSoKhamBenhMoi(string maBenhNhan)
        {
            
            var soKham = await _context.SoKhamBenhs
                .FirstOrDefaultAsync(s => s.MaBn == maBenhNhan);

            if (soKham != null)
            {
                
                return soKham.MaSoKham;
            }

            var soMoi = new SoKhamBenh
            {
                MaBn = maBenhNhan,
               
            };

            _context.SoKhamBenhs.Add(soMoi);
            await _context.SaveChangesAsync();

            return soMoi.MaSoKham;
        }

    }
}
