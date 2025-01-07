namespace Forestage.Models.Dtos.Members
{
    public class ForgetPasswordDTO
    {
        public string Email { get; set; }
        public string ConfirmCode { get; set; }
        public string Password { get; set; }
    }
}
