using Microsoft.AspNetCore.Mvc.Rendering;

namespace QLBV.Models.InterfaceRepository
{
    public interface InterfaceBenhVien
    {
        public Task<List<SelectListItem>> LayDanhSachPhongBanSelectListAsync();
        public Task<List<SelectListItem>> LayDanhSachBoPhan();
        public Task<List<SelectListItem>> LayDanhSachNhanVienChon();
        public Task ThemNv(string maNV, string hoTen, string ngaySinh, string gioiTinh, string? diachi, string sdt, string mapb);
        public Task<BacSi> LayNhanVien(string id);
        public Task ThemBacSi(string maNv, string trinhdo);
        public Task<List<BenhNhan>> LayBenhNhanGanNhat();
        public Task<BenhNhan> LayBenhNhanTheoId(string id);
        public Task<List<BacSi>> LayDanhSachBacSi();
        public Task<List<SelectListItem>> LayDanhSachBacSiChon();
        public Task<int?> LayMaSoKhamHienTai(string maBenhNhan);
        public Task<int> TaoSoKhamBenhMoi(string maBenhNhan);
    }
}
