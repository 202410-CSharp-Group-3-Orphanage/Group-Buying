using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.Dtos.Members
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string ConfirmCode { get; set; }
        public string Account { get; set; }

        public string Password { get; set; }

        //public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public byte Gender { get; set; }
    }
}
