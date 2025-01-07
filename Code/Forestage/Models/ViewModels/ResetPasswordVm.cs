using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class ResetPasswordVm
    {
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
