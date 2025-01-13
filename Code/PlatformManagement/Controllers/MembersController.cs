using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PlatformManagement.Models.ViewModels;
using System.Security.Claims;
using PlatformManagement.Models.Service;

namespace PlatformManagement.Controllers
{
    public class MembersController : Controller
    {
        private readonly MemberService _service;

        public MembersController(MemberService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm model, string returnUrl = null)
        {
            if (!ModelState.IsValid) { return View(model); }


            try
            {
                VaildateLogin(model);

                await ProcessLogin(model.Account);
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        private void VaildateLogin(LoginVm model)
        {
            _service.Login(model);
        }

        private async Task ProcessLogin(string account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false,  // 設定為 Session Cookie
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2),  // 設定 2 小時後過期
                // 加入安全設定
                AllowRefresh = true,  // 允許在快過期時自動更新                
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
