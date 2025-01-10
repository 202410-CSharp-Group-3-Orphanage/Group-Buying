using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class LoginVm
    {

        [Display(Name = "請輸入帳號")]
        [Required(ErrorMessage ="帳號必填")]
        public string Account { get; set; }

        [Display(Name = "請輸入密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
