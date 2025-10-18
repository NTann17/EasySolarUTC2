using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarK64.Models;
using SolarK64.Models.EF;
using SolarK64.Services;
using System.Diagnostics;

namespace SolarK64.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISolarServices _solarServices;
        public HomeController(ILogger<HomeController> logger, ISolarServices solarServices)
        {
            _logger = logger;
            _solarServices = solarServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrangChu()
        {
            var lstPhanHoi = _solarServices.GetListPhanHoi("HeaderFeedback");
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
