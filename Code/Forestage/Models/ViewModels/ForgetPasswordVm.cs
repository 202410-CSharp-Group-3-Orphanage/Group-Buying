using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class ForgetPasswordVm
    {
        
        public string Email { get; set; }
      
        public string ConfirmCode { get; set; }
    }
}
