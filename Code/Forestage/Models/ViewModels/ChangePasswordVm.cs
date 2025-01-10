using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class ChangePasswordVm
    {
        
        [Display(Name = "舊密碼")]
        [Required(ErrorMessage = "舊密碼必填")]        
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Display(Name = "新密碼")]
        [Required(ErrorMessage = "新密碼必填")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "{0} 長度必須介於 {2} ~ {1}")]
        [DataType(DataType.Password)]
        
        public string NewPassword { get; set; }
        [Display(Name = "再次輸入新密碼")]
        [Required(ErrorMessage = "請再次輸入新密碼")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "{0} 長度必須介於 {2} ~ {1}")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
