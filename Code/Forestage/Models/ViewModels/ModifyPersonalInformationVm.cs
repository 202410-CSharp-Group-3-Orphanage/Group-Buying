﻿using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.ViewModels
{
    public class ModifyPersonalInformationVm
    {        
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        [StringLength(30, ErrorMessage = "{0} 長度不可超過 {1}")]
        public string Name { get; set; }

        [Display(Name = "手機")]
        [Required(ErrorMessage = "手機必填")]
        [StringLength(10, ErrorMessage = "{0} 長度不可超過 {1}")]
        public string Phone { get; set; }


        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }
    }
}
