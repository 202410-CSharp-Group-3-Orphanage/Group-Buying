using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backstage.Models.ViewModels.Members
{
    public class RegisterVm
    {
        [Required(ErrorMessage = "帳號必填")]
        public string Account { get; set; }
        [Required(ErrorMessage = "密碼必填")]
        public string Password { get; set; }
        [Required(ErrorMessage = "確認密碼必填")]
        [Compare("Password", ErrorMessage = "密碼不一致")]

        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "身分證字號必填")]
        [RegularExpression(@"^[A-Za-z][0-9]{9}$", ErrorMessage = "身分證字號格式不正確，須為1個英文字母加上9個數字")]
        public string IdentityCard { get; set; }
        [Required(ErrorMessage = "店家名稱必填")]
        public string Name { get; set; }
        [Required(ErrorMessage = "店家地址必填")]
        public string Address { get; set; }

        [Required(ErrorMessage = "請上傳商品圖片")]
        public HttpPostedFileBase Image { get; set; }
    }
}