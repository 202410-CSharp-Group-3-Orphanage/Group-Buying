using Forestage.Models.Dtos.Members;
using Forestage.Models.EFModels;
using Forestage.Models.Repositories;
using Forestage.Models.ViewModels;
using Forestage.Models.ViewModels.Members;
using MT.Security.Hashing;
using NuGet.Protocol.Core.Types;
using static Forestage.Controllers.MembersController;

namespace Forestage.Models.Services
{
    public class MemberService
    {
        private MemberEFRepository _repo;

        public MemberService(MemberEFRepository repo)
        {
            _repo = repo;
        }
        public void Login(LoginDTO dto)
        {
            if (!_repo.VaildateAccountExist(dto.Account)) throw new Exception("帳號或密碼錯誤");
            if (!_repo.VaildateLoginPassword(dto.Account, dto.Password)) throw new Exception("帳號或密碼錯誤");
            if (!_repo.VaildateLoginIsConfirm(dto.Account, dto.Password)) throw new Exception("帳號尚未開通");
        }

        public void Register(RegisterDTO dto)
        {
            if (_repo.VaildateRegisterAccount(dto)) throw new Exception("此帳號已存在");
            if (_repo.VaildateRegisterEmail(dto)) throw new Exception("此Email已存在");
            if (_repo.VaildateRegisterPhone(dto)) throw new Exception("此手機號碼已存在");

            _repo.CreateMember(dto);
        }

        public void ChangeMemberPassword(ChangePasswordDTO dto)
        {
            if (!_repo.VaildateLoginPassword(dto.Account, dto.OldPassword)) throw new Exception("舊密碼錯誤");
            if (_repo.VaildateOldPasswordWithNewPassword(dto.Account, dto.NewPassword)) throw new Exception("新密碼不可與舊密碼相同");

            _repo.UpdateMemberPassword(dto);
        }

        public void ForgetPassword(ForgetPasswordDTO dto)
        {
            if (!_repo.VaildateEmailExist(dto.Email))
            {
                throw new Exception("查無此Email");
            }
            else
            {
                _repo.SendConfirmMail(dto.Email);
            }
        }


        public void ModifyPersonalInformation(ModifyPersonalInformationDTO dto)
        {
            if (_repo.ValidatePhoneExistExceptSelf(dto.Account, dto.Phone))
            {
                throw new Exception("此手機號碼已被其他用戶使用");
            }

            _repo.UpdatePersonalInformation(dto);
        }

        public void ResetPassword(ForgetPasswordDTO dto)
        {
            if (!_repo.VaildateEmailExist(dto.Email))
            {
                throw new Exception("查無此Email");
            }
            if (!_repo.VaildateConfirmCodeExist(dto.ConfirmCode))
            {
                throw new Exception("驗證碼錯誤");
            }
        }

        public void ResetPasswordFromEmail(ForgetPasswordDTO dto)
        {
            _repo.UpdatePasswordFromEmail(dto);
        }

        public List<GroupbuyingProgressVm> GetGroupbuyingProgress(int memberId, GroupbuyingSearchParams searchParams)
        {
            return _repo.GetGroupbuyingProgressById(memberId, searchParams);
        }

        public int GetIdByAccount(string loggedInUserAccount)
        {
            return _repo.GetIdByAccount(loggedInUserAccount);
        }

        public void CancelGroupbuyingOrder(int groupBuyingId, int memberId)
        {
            _repo.CancelGroupbuyingOrder(groupBuyingId, memberId);
        }

        public List<PersonalGroupBuyingOrdersVm> GetGroupbuyingOrders(int memberId, GroupbuyingSearchParams searchParams)
        {
            return _repo.GetGroupbuyingOrderById(memberId, searchParams);
        }

    }
}
