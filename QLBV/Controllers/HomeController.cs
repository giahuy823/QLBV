using Microsoft.AspNetCore.Mvc;
using QLBV.Models;
using System.Diagnostics;
using QLBV.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace QLBV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLBVContext _context;
        public HomeController(ILogger<HomeController> logger, QLBVContext context)
        {
            _logger = logger;
            _context = context;
        }
        private int soLuongBacSi = 4;

        public IActionResult Index()
        {
            var HomeView = new HomeViewModel()
            {
                Introduction = GetIntroductionString(),
                Doctors = _context.BacSis.Include(b => b.MaBsNavigation).Take(soLuongBacSi).ToList(),
                Departments = _context.BoPhans.Include(b => b.PhongBans).ToList(),
                Procedures = _context.ThuTucs.ToList()
            };
            return View(HomeView);
        }
        private string GetIntroductionString()
        {
            return @"Our hospital is a leading healthcare provider with state-of-the-art facilities 
                and a team of experienced professionals dedicated to your well-being. 
                We offer comprehensive medical services with a patient-centered approach.";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
