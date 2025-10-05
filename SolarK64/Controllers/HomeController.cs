using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarK64.Models;
using SolarK64.Models.EF;
using System.Diagnostics;

namespace SolarK64.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrangChu()
        {
            var lstPhanHoi = _context.PhanHoi.AsNoTracking().Where(t=>t.MaKieuPhanHoi== "HeaderFeedback").ToList();
            ViewData["lstPhanHoi"] = lstPhanHoi;
            return View();
        }

        public IActionResult TinTuc()
        {
            ViewBag.title = "Tin tức";
            return View();
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
