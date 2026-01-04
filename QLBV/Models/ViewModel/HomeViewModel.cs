namespace QLBV.Models.ViewModel
{
    public class HomeViewModel
    {
        public string Introduction { get; set; }
        public List<BacSi> Doctors { get; set; }
        public List<BoPhan> Departments { get; set; }
        public List<ThuTuc> Procedures { get; set; }
    }
}
