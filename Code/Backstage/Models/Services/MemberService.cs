using Backstage.Models.Dtos;
using Backstage.Models.Dtos.Members;
using Backstage.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.Services
{
    public class MemberService
    {
        private readonly MemberRepository _memberRepo;

        public MemberService(MemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public void Login(LoginDTO dto)
        {
            if (!_memberRepo.VaildateAccountExist(dto.Account)) throw new Exception("帳號錯誤");
            if (!_memberRepo.VaildateLoginPassword(dto.Account, dto.Password)) throw new Exception("密碼錯誤");
        }

        public void Register(RegisterDTO dto)
        {
            if (_memberRepo.VaildateAccountExist(dto.Account)) throw new Exception("帳號已存在");
            if (_memberRepo.VaildateNameExist(dto.Name)) throw new Exception("店家名稱已存在");
            if (_memberRepo.VaildateIdentityCardExist(dto.IdentityCard)) throw new Exception("身分證字號已存在");

            _memberRepo.CreateMember(dto);
        }
    }
}