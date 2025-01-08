using Backstage.Models.Dtos.Members;
using Backstage.Models.EFModels;
using MT.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backstage.Models.Repositories
{
    public class MemberRepository
    {
        private readonly AppDbContext2 _context;

        public MemberRepository(AppDbContext2 db)
        {
            _context = db;
        }

        public bool VaildateAccountExist(string account)
        {
            var member = _context.Shops.FirstOrDefault(m => m.Account == account);
            if (member == null) return false;
            return true;
        }
        public bool VaildateLoginPassword(string account, string password)
        {
            var member = _context.Members.FirstOrDefault(m => m.Account == account);
            if (!Sha256Hasher.Verify(password, member.EncryptedPassword)) return false;
            return true;
        }

        public bool VaildateNameExist(string name)
        {
            var member = _context.Shops.FirstOrDefault(m => m.Name == name);
            if (member == null) return false;
            return true;
        }

        public bool VaildateIdentityCardExist(string identityCard)
        {
            var member = _context.Shops.FirstOrDefault(m => m.IdentityCard == identityCard);
            if (member == null) return false;
            return true;
        }

        public void CreateMember(RegisterDTO dto)
        {
            var shop = new Shop
            {
                Account = dto.Account,
                EncryptedPassword = Sha256Hasher.ComputeHash(dto.Password, Sha256Hasher.GetSalt()),
                Name = dto.Name,
                IdentityCard = dto.IdentityCard,
                Address = dto.Address,
                Avatar = dto.Image.FileName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Shops.Add(shop);
            _context.SaveChanges();
        }
    }
}