using Forestage.Models.Dtos.Members;
using Forestage.Models.EFModels;
using Forestage.Models.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MT.Security.Hashing;

namespace Forestage.Models.Repositories
{
    public class MemberEFRepository
    {
        private readonly EmailService _emailService;
        private readonly AppDbContext _context;

        public MemberEFRepository(EmailService emailService, AppDbContext context)
        {
            _emailService = emailService;
            _context = context;
        }

        
        

        public bool VaildateAccountExist(string account)
        {
            var member = _context.Members.FirstOrDefault(m => m.Account == account);
            
            if (member == null) return false;
            return true;
        }
        public bool VaildateLoginPassword(string account, string password)
        {
            
            //var member = _context.Members.FirstOrDefault(m => m.Account == account);
            //if (password == member.EncryptedPassword) return true;
            //return false;

            var member = _context.Members.FirstOrDefault(m => m.Account == account);
            if (!Sha256Hasher.Verify(password, member.EncryptedPassword)) return false;
            return true;

        }
        public bool VaildateLoginIsConfirm(string account, string password)
        {
            
                var member = _context.Members.FirstOrDefault(m => m.Account == account);
                if (member.IsConfirmed == false) return false;
                return true;
            
        }

        public bool VaildateRegisterAccount(RegisterDTO dto)
        {
            
                var member = _context.Members.FirstOrDefault(m => m.Account == dto.Account);
                if (member == null) return false;
                return true;
            
        }

        public bool VaildateRegisterEmail(RegisterDTO dto)
        {
            
                var member = _context.Members.FirstOrDefault(m => m.Email == dto.Email);
                if (member == null) return false;
                return true;
            
        }

        public bool VaildateRegisterPhone(RegisterDTO dto)
        {
            
                var member = _context.Members.FirstOrDefault(m => m.Phone == dto.Phone);
                if (member == null) return false;
                return true;
            
        }
        public void CreateMember(RegisterDTO dto) // TODO
        {
            
                var member = new Member
                {
                    Account = dto.Account,
                    EncryptedPassword = Sha256Hasher.ComputeHash(dto.Password, Sha256Hasher.GetSalt()),
                    Name = dto.Name,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    Birthday = dto.Birthday,
                    Gender = dto.Gender,
                    IsConfirmed = false,
                    // todo Email驗證
                    ConfirmCode = Guid.NewGuid().ToString("N"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            _context.Members.Add(member);
            _context.SaveChanges();
            
        }

        public bool VaildateOldPasswordWithNewPassword(string account, string newPassword)
        {
            
                var member = _context.Members.FirstOrDefault(m => m.Account == account);
                if (!Sha256Hasher.Verify(newPassword, member.EncryptedPassword)) return false;
                return true;
            
        }

        public void UpdateMemberPassword(ChangePasswordDTO dto)
        {
            var member = _context.Members.FirstOrDefault(m => m.Account == dto.Account);
            member.EncryptedPassword = Sha256Hasher.ComputeHash(dto.NewPassword, Sha256Hasher.GetSalt());
            _context.SaveChanges();            
        }

        public bool VaildateEmailExist(string email)
        {            
            var member = _context.Members.FirstOrDefault(m => m.Email == email);
            if (member == null) return false;
            return true;
        }

        public void SendConfirmMail(string email) // TODO
        {
            var member = _context.Members.FirstOrDefault(m => m.Email == email);

            // 生成驗證碼
            var confirmCode = Guid.NewGuid().ToString("N");
            member.ConfirmCode = confirmCode;            
            _context.SaveChanges();

            // 生成驗證信 URL
            string resetPasswordUrl = $"https://localhost:7203/ResetPassword?email={email}&code={confirmCode}";

            // 發送郵件            
            string subject = "重設密碼驗證信";
            string body = $@"
        <p>您好，請點擊以下連結重設您的密碼：</p>
        <p><a href='{resetPasswordUrl}'>重設密碼</a></p>
        <p>此連結將於 10 分鐘後失效。</p>";
            _emailService.SendEmail(email, subject, body);
        }

        
        

        public bool VaildatePhoneExist(string phone)
        {            
            var member = _context.Members.FirstOrDefault(m => m.Phone == phone);
            if (member == null) return false;
            return true;
        }

        public void UpdatePersonalInformation(ModifyPersonalInformationDTO dto)
        {
            var member = _context.Members.FirstOrDefault(m => m.Account == dto.Account);
            member.Name = dto.Name;            
            member.Phone = dto.Phone;
            member.Birthday = dto.Birthday;
            _context.SaveChanges();            
        }
        public bool ValidatePhoneExistExceptSelf(string currentAccount, string phone)
        {
            return _context.Members.Any(m =>
                m.Phone == phone &&
                m.Account != currentAccount);
        }

        public bool ValidateEmailExistExceptSelf(string currentAccount, string email)
        {
            return _context.Members.Any(m =>
                m.Email == email &&
                m.Account != currentAccount);
        }

        public bool VaildateConfirmCodeExist(string confirmCode)
        {
            var member = _context.Members.FirstOrDefault(m => m.ConfirmCode == confirmCode);
            if (member == null) return false;
            return true;
        }

        public void UpdatePasswordFromEmail(ForgetPasswordDTO dto)
        {
            var member = _context.Members.FirstOrDefault(m => m.Email == dto.Email);
            member.EncryptedPassword = Sha256Hasher.ComputeHash(dto.Password, Sha256Hasher.GetSalt());
            _context.SaveChanges();
        }
    }
}
