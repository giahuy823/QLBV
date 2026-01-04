namespace QLBV.Models.InterfaceRepository
{
    public interface InterfaceNhanVien
    {
        Task UpdateNhanVien(NhanVien nhanVien);
        Task<NhanVien> LayNhanVienById(string maNV);
        Task<List<NhanVien>> LayNhanVien();
        Task<List<PhongBan>> LayPhongBan();
    }
}