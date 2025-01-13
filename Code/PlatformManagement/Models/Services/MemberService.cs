using PlatformManagement.Models.Dtos.Members;
using PlatformManagement.Models.Repositories;
using PlatformManagement.Models.ViewModels;

namespace PlatformManagement.Models.Service
{
    public class MemberService
    {
        private MemberRepository _repo;

        public MemberService(MemberRepository repo)
        {
            _repo = repo;
        }

        public void Login(LoginVm model)
        {
            LoginDTO dto = new LoginDTO
            {
                Account = model.Account,
                Password = model.Password,
            };
            if (!_repo.VaildateAccountIsExist(dto.Account)) throw new Exception("帳號錯誤");
            if (!_repo.ValidateLoginPasswordIsCorrect(dto.Account, dto.Password)) throw new Exception("密碼錯誤");            
        }
    }
}
