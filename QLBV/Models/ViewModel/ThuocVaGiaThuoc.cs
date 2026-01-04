namespace QLBV.Models.ViewModel
{
    public class ThuocVaGiaThuoc
    {
        public string MaThuoc { get; set; }
        public string? TenThuoc { get; set; }
        public string? DonVi { get; set; }
        public GiaBanDTO? GiaGanNhat { get; set; }
    }

    public class GiaBanDTO
    {
        public decimal Gia { get; set; }
        public DateOnly NgayApDung { get; set; }
    }
}
