using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class ResetPasswordVm
    {
        [Display(Name = "請輸入密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "請輸入密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "密碼不一致")]
        public string ConfirmPassword { get; set; }
    }
}
