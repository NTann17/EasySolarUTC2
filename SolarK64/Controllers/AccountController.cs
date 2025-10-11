using Microsoft.AspNetCore.Mvc;

namespace SolarK64.Controllers
{
    public class AccountController : Controller
    {
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
