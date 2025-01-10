using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class ForgetPasswordVm
    {
        [Display(Name = "請輸入Email")]
        [Required(ErrorMessage = "Email必填")]
        public string Email { get; set; }
      
        public string ConfirmCode { get; set; }
    }
}
