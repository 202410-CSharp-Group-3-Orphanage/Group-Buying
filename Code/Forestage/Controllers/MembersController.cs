using Forestage.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Forestage.Models.Dtos.Members;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Members;
using Forestage.Models.Services.Interfaces;



namespace Forestage.Controllers
{
	public class MembersController : Controller
	{
		private readonly MemberService _service;
        private readonly EmailService _emailService;


        public MembersController(MemberService service, EmailService emailService)
		{
			_service = service;
			_emailService = emailService;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login(string returnUrl = "/")
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginVm model, string returnUrl = "/")
		{
			// 如果 Login 錯誤，returnUrl 會被放回去
			ViewBag.ReturnUrl = returnUrl;
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

		private void VaildateLogin(LoginVm model)
		{
			LoginDTO dto = new LoginDTO
			{
				Account = model.Account,
				Password = model.Password,
			};
			_service.Login(dto);
		}
		public async Task<IActionResult> Logout()
		{
			// 登出並清除 Cookie
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Register(RegisterVm model) // TODO email confirm
		{
			if (!ModelState.IsValid) { return View(model); }

			try
			{
				VaildateRegister(model);
				
				return RedirectToAction("RegisterConfirm");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
		}
        public IActionResult RegisterConfirm()
        {
            return View();
        }
        public IActionResult VaildateEmail(int id, string confirmCode)
        {
            try
            {
                VaildateEmailByIdAndConfirmCode(id, confirmCode);
				UpdateMembersConfirmCode(id, confirmCode);
				TempData["EmailVaildatation"] = "Email驗證成功";
                return RedirectToAction("Login", "Members");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public IActionResult ResetPasswordFromEmail(int id, string confirmCode)
        {
            try
            {
                VaildateEmailByIdAndConfirmCode(id, confirmCode);
                UpdateMembersConfirmCodeAndPassword(id, confirmCode);
                return RedirectToAction("ResetPasswordFromEmailWithoutLogin", "Members", new { id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        
        public IActionResult ResetPasswordFromEmailWithoutLogin()
		{
			return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPasswordFromEmailWithoutLogin(int id, ResetPasswordVm model)
		{
            try
            {
                ChangePasswordDTO dto = new ChangePasswordDTO
                {
                    Id = id,
                    NewPassword = model.Password,
                };
                _service.ResetPasswordFromEmailWithoutLogin(dto);
                TempData["EmailVaildatation"] = "已成功修改密碼";
                return RedirectToAction("Login", "Members");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        private void UpdateMembersConfirmCodeAndPassword(int id, string confirmCode)
        {
            RegisterDTO dto = new RegisterDTO
            {
                Id = id,
                ConfirmCode = confirmCode,
            };
            _service.UpdateMembersConfirmCode(dto);
        }

        private void UpdateMembersConfirmCode(int id, string confirmCode)
        {
            RegisterDTO dto = new RegisterDTO
            {
                Id = id,
                ConfirmCode = confirmCode,
            };
            _service.UpdateMembersConfirmCode(dto);
        }

        private void VaildateEmailByIdAndConfirmCode(int id, string confirmCode)
        {
            RegisterDTO dto = new RegisterDTO
            {
                Id = id,
                ConfirmCode = confirmCode,
            };
            _service.VaildateEmailByIdAndConfirmCode(dto);
        }

        private void VaildateRegister(RegisterVm model)
		{
			string confirmCode = Guid.NewGuid().ToString("N");

            RegisterDTO dto = new RegisterDTO
			{
				Account = model.Account,
				Password = model.Password,
				Email = model.Email,
				Name = model.Name,
				Phone = model.Phone,
				Birthday = model.Birthday,
				Gender = model.Gender,
                ConfirmCode = confirmCode,
            };
			_service.Register(dto);
		}

		public IActionResult ForgetPassword()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ForgetPassword(ForgetPasswordVm model) // TODO email confirm
		{
			try
			{
				VaildateEmail(model);

				return RedirectToAction("ForgetPasswordConfirm"); 
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
		}

		public IActionResult ForgetPasswordConfirm()
        {
            return View();
        }


        private void VaildateEmail(ForgetPasswordVm model)
		{
            string confirmCode = Guid.NewGuid().ToString("N");
            ForgetPasswordDTO dto = new ForgetPasswordDTO
			{
				Email = model.Email,
                ConfirmCode = confirmCode,
            };
			_service.ForgetPassword(dto);
		}

		//public IActionResult ResetPassword(string email, string confirmCode, ResetPasswordVm model)  // TODO email confirm
		//{
		//	try
		//	{
		//		VaildateEmailAndConfirmCode(email, confirmCode);
		//		ResetPasswordFromEmail(model);
		//		return RedirectToAction("Login", "Members");
		//	}
		//	catch (Exception ex)
		//	{
		//		ModelState.AddModelError("", ex.Message);
		//		return View();
		//	}
		//}

		private void ResetPasswordFromEmail(int id , string confirmCode,ResetPasswordVm model)
		{
			ForgetPasswordDTO dto = new ForgetPasswordDTO
			{
				Id = id,
				Password = model.Password,
			};
			_service.ResetPasswordFromEmail(dto);
		}

		private void VaildateEmailAndConfirmCode(string email, string confirmCode)
		{
			ForgetPasswordDTO dto = new ForgetPasswordDTO
			{
				Email = email,
				ConfirmCode = confirmCode,
			};
			_service.ResetPassword(dto);
		}

		[Authorize]
		public IActionResult ChangePassword()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ChangePassword(ChangePasswordVm model)
		{
			if (!ModelState.IsValid) { return View(model); }

			try
			{
				VaildateChangePassword(model);
                TempData["EmailVaildatation"] = "密碼已修改！";
                return RedirectToAction("Index", "Members");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
		}

		private void VaildateChangePassword(ChangePasswordVm model)
		{
			var account = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

			ChangePasswordDTO dto = new ChangePasswordDTO
			{
				Account = account,
				OldPassword = model.OldPassword,
				NewPassword = model.NewPassword,
			};
			_service.ChangeMemberPassword(dto);
		}

		[Authorize]
		public IActionResult ModifyPersonalInformation()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ModifyPersonalInformation(ModifyPersonalInformationVm model)
		{
			if (!ModelState.IsValid) { return View(model); }

			try
			{
				VaildateModifyPersonalInformation(model);
                TempData["EmailVaildatation"] = "個人資料已修改！";
                return RedirectToAction("Index", "Members");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
		}

		private void VaildateModifyPersonalInformation(ModifyPersonalInformationVm model)
		{
			var account = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
			ModifyPersonalInformationDTO dto = new ModifyPersonalInformationDTO
			{
				Account = account,
				Name = model.Name,
				Phone = model.Phone,
				Birthday = model.Birthday
			};
			_service.ModifyPersonalInformation(dto);
		}

		public class GroupbuyingSearchParams
		{
			public string? ProductName { get; set; }
			public decimal? GroupBuyingPriceMin { get; set; }
			public decimal? GroupBuyingPriceMax { get; set; }
			public DateTime? EndDate { get; set; }
			public int? Status { get; set; }
		}

		[Authorize]
		public IActionResult SearchGroupbuyingProgress(
		string? productName,
		decimal? groupBuyingPriceMin,
		decimal? groupBuyingPriceMax,
		DateTime? endDate)
		{
			var account = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
			if (string.IsNullOrEmpty(account)) return RedirectToAction("Login");

			int id = _service.GetIdByAccount(account);
			var searchParams = new GroupbuyingSearchParams
			{
				ProductName = productName,
				GroupBuyingPriceMin = groupBuyingPriceMin,
				GroupBuyingPriceMax = groupBuyingPriceMax,
				EndDate = endDate
			};

			var vm = _service.GetGroupbuyingProgress(id, searchParams);
			return View(vm);
		}

		[Authorize]
		[HttpPost]
		public IActionResult CancelGroupbuyingOrder(int groupBuyingId)
		{

			try
			{
				var account = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
				if (string.IsNullOrEmpty(account)) return RedirectToAction("Login");

				int memberId = _service.GetIdByAccount(account);
				Console.WriteLine($"groupBuyingId: {groupBuyingId}");
				Console.WriteLine($"memberId: {memberId}");
				_service.CancelGroupbuyingOrder(groupBuyingId, memberId);

				// 保持當前的查詢參數
				return RedirectToAction("SearchGroupbuyingProgress",
					new
					{
						productName = Request.Query["productName"],
						groupBuyingPriceMin = Request.Query["groupBuyingPriceMin"],
						groupBuyingPriceMax = Request.Query["groupBuyingPriceMax"],
						endDate = Request.Query["endDate"],
					});
			}
			catch (Exception ex)
			{
				TempData["Error"] = "取消參團失敗：" + ex.Message;
				return RedirectToAction("SearchGroupbuyingProgress");
			}
		}

		[Authorize]
		public IActionResult SearchGroupbuyingOrder(
		string? productName,
		decimal? groupBuyingPriceMin,
		decimal? groupBuyingPriceMax,
		int? status
		)
		{
			var account = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
			if (string.IsNullOrEmpty(account)) return RedirectToAction("Login");

			int id = _service.GetIdByAccount(account);
			var searchParams = new GroupbuyingSearchParams
			{
				ProductName = productName,
				GroupBuyingPriceMin = groupBuyingPriceMin,
				GroupBuyingPriceMax = groupBuyingPriceMax,
				Status = status
			};

			var vm = _service.GetGroupbuyingOrders(id, searchParams);
			return View(vm);
		}
	}
}
