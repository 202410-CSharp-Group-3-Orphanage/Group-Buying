﻿namespace Forestage.Models.Dtos.Members
{
    public class ChangePasswordDTO
    {
        public string Account { get; set; }
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        //public string ConfirmPassword { get; set; }
    }
}
