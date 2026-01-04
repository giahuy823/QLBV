namespace QLBV.Models.InterfaceRepository
{
    public interface InterfaceTaiKhoan
    {
        public Task TaoTk(string maTk, string maNv, string tenDn, string matKhau, string loaiTk);
    }
    
}
