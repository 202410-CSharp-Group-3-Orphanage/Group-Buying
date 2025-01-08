using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backstage.Models.ViewModels
{
    public class LoginVm
    {
        public LoginVm() { }
        [Required(ErrorMessage = "帳號必填")]
        public string Account { get; set; }
        [Required(ErrorMessage = "密碼必填")]
        public string Password { get; set; }
    }
}