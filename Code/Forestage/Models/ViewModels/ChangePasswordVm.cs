using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class ChangePasswordVm
    {
        
        [Display(Name = "舊密碼")]
        [Required]        
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Display(Name = "新密碼")]
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "{0} 長度必須介於 {2} ~ {1}")]
        [DataType(DataType.Password)]
        
        public string NewPassword { get; set; }
        [Display(Name = "再次輸入新密碼")]
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "{0} 長度必須介於 {2} ~ {1}")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
