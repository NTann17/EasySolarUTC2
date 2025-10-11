using Microsoft.AspNetCore.Mvc;

namespace SolarK64.Controllers
{
    public class AdminController : Controller
    {
        [Route("/admin/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
