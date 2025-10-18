using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarK64.Helpers;
using SolarK64.Services;
using System.Security.Claims;

namespace SolarK64.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISolarServices _solarServices;
        public AccountController(ISolarServices solarServices)
        {
            _solarServices = solarServices;
        }

        [Route("/login")]
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return Redirect("/admin/dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> LoginToSystem(string username, string password)
        {
            try
            {
                var account = _solarServices.Login(username, password);
                if (account != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, account.HoVaTen));
                    claims.Add(new Claim(ClaimTypes.Email, account.Email));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, account.TenDangNhap));
                    claims.Add(new Claim(ClaimTypes.Role, account.VaiTro));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return Json(new { status = WebConstants.SUCCESS });
                }
                else
                {
                    return Json(new { status = WebConstants.ERROR, message = "Tài khoản hoặc mật khẩu không chính xác." });
                }
            }
            catch(Exception ex)
            {
                return Json(new { status = WebConstants.ERROR, message = "Lỗi đăng nhập", error = ex.ToString() });
            }
        }
    }
}
