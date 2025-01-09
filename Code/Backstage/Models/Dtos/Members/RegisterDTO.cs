using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backstage.Models.Dtos.Members
{
    public class RegisterDTO
    {
        public string Account { get; set; }
        
        public string Password { get; set; }
        

        public string ConfirmPassword { get; set; }
        
        public string IdentityCard { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
                
        public HttpPostedFileBase Image { get; set; }
    }
}