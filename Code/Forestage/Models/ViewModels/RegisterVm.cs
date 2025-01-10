using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class RegisterVm
    {
        [Display(Name = "請輸入帳號")]
        [Required(ErrorMessage = "帳號必填")]
        public string Account { get; set; }
        [Display(Name = "請輸入密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "請輸入密碼")]
        [Required(ErrorMessage = "確認密碼必填")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "密碼不一致")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "請輸入Email")]
        [Required(ErrorMessage = "Email必填")]
        public string Email { get; set; }

        [Display(Name = "請輸入姓名")]
        [Required(ErrorMessage = "姓名必填")]
        public string Name { get; set; }

        [Display(Name = "請輸入手機號碼")]
        [Required(ErrorMessage = "手機號碼必填")]
        public string Phone { get; set; }

        [Display(Name = "請輸入生日")]
        public DateTime Birthday { get; set; }

        [Display(Name = "請選擇性別")]
        public byte Gender { get; set; }
    }
}
