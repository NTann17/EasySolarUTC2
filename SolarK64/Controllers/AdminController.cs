using Microsoft.AspNetCore.Mvc;
using SolarK64.Services;

namespace SolarK64.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISolarServices _solarServices;
        public AdminController(ISolarServices solarServices)
        {
            _solarServices = solarServices;
        }

        [Route("/admin/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
