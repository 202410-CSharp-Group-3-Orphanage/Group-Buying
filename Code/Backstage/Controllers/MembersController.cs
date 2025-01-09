using Backstage.Models.Dtos;
using Backstage.Models.Dtos.Members;
using Backstage.Models.Services;
using Backstage.Models.ViewModels;
using Backstage.Models.ViewModels.Members;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class MembersController : Controller
    {
        private readonly MemberService _service;

        public MembersController(MemberService service)
        {
            _service = service;
        }
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVm model, string returnUrl = null)
        {
            if (!ModelState.IsValid) { return View(model); }

            try
            {
                VaildateLogin(model);

                ProcessLogin(model.Account);
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
        private void ProcessLogin(string account)
        {
            // 創建驗證票證
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, // 版本
                account, // 用戶名
                DateTime.Now, // 發行時間
                DateTime.Now.AddHours(2), // 過期時間
                false, // 是否記住我
                "", // 用戶數據
                FormsAuthentication.FormsCookiePath // Cookie路徑
            );

            // 加密票證
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            // 創建 Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true; // 防止 XSS
            cookie.Secure = true;   // 只通過 HTTPS 傳送

            // 加入 Cookie
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private void VaildateLogin(LoginVm model)
        {
            LoginDTO dto = new LoginDTO
            {
                Account = model.Account,
                Password = model.Password,
            };
            _service.Login(dto);
        }

        
        public ActionResult Register()
        {            
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(RegisterVm model) // TODO 未完成新增檢視
        {
            if (!ModelState.IsValid) { return View(model); }

            try
            {
                VaildateRegister(model);
                return RedirectToAction("Login", "Members");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        private void VaildateRegister(RegisterVm model)
        {
            string imagePath = null;
            if (model.Image != null)
            {
                var fileName = Path.GetFileName(model.Image.FileName);
                var filePath = Path.Combine(Server.MapPath("~/ShopImages"), fileName);
                model.Image.SaveAs(filePath);
                imagePath = $"/ShopImages/{fileName}";
            }
            RegisterDTO dto = new RegisterDTO
            {
                Account = model.Account,
                Password = model.Password,                
                Name = model.Name,
                IdentityCard = model.IdentityCard,
                Address = model.Address,
                Image = model.Image
            };

            _service.Register(dto);
        }

        // 登出
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // 登出並清除 cookie
            return RedirectToAction("Index", "Home");
        }
    }
}