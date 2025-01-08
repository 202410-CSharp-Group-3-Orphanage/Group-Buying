using Backstage.Models.Dtos;
using Backstage.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace Backstage.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVm model)
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
            LoginDTO dto = new LoginDTO
            {
                Account = model.Account,
                Password = model.Password,
            };
        }

        // 登出
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // 登出並清除 cookie
            return RedirectToAction("Index", "Home");
        }
    }
}