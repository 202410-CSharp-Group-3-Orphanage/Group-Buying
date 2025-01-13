﻿using Dapper;
using Forestage.Common;
using Forestage.Models.Dtos.Members;
using Forestage.Models.EFModels;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Members;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MT.Security.Hashing;
using static Forestage.Controllers.MembersController;

namespace Forestage.Models.Repositories
{
    public class MemberEFRepository
    {
        private readonly FilePathHelper _filePathHelper;
        private readonly EmailService _emailService;
        private readonly AppDbContext _context;        
        private readonly SqlConnection _sqlConnection;


        public MemberEFRepository(EmailService emailService, AppDbContext context, SqlConnection sqlConnection, FilePathHelper filePathHelper)
        {
            _emailService = emailService;
            _context = context;
            _sqlConnection = sqlConnection;
            _filePathHelper = filePathHelper;
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

        

        public int GetIdByAccount(string loggedInUserAccount)
        {
            var account_id = _context.Members
                .Where(m => m.Account == loggedInUserAccount)
                .Select(m => m.Id)
                .FirstOrDefault();
            return account_id;
        }

        public List<GroupbuyingProgressVm> GetGroupbuyingProgressById(int memberId, GroupbuyingSearchParams searchParams)
        {
            var sql = $@"
SELECT 
    (SELECT TOP 1 pi2.Path 
     FROM ProductImages pi2 
     WHERE pi2.ProductId = p.Id) ProductImage,
    p.Name ProductName,
    gb.Price ProductPrice,
    (SELECT SUM(CAST(o2.Quantity AS int))
     FROM Orders o2 
     WHERE o2.GroupBuyingId = gb.Id 
     AND o2.MemberId = @MemberId
     AND o2.Status = 1) OrdersQuantity,
    (SELECT SUM(CAST(o3.Quantity AS int))
     FROM Orders o3
     WHERE o3.GroupBuyingId = gb.Id 
     AND o3.Status = 1) CurrentGroupSize,
    gb.MinimumGroupSize MinimumGroupSize,
    gb.EndDate EndDate,
gb.Id AS GroupBuyingId,
gb.ProductId AS ProductId
FROM GroupBuyings gb
INNER JOIN Products p ON gb.ProductId = p.Id
INNER JOIN Orders o ON o.GroupBuyingId = gb.Id
WHERE gb.EndDate > @CurrentDate 
AND gb.Enabled = 1 
AND o.Status = 1
AND EXISTS (SELECT 1 FROM Orders o4 WHERE o4.GroupBuyingId = gb.Id AND o4.MemberId = @MemberId)
AND (@ProductName IS NULL OR p.Name LIKE '%' + @ProductName + '%')
AND (@PriceMin IS NULL OR gb.Price >= @PriceMin)
AND (@PriceMax IS NULL OR gb.Price <= @PriceMax)
AND (@EndDate IS NULL OR CAST(gb.EndDate AS DATE) <= CAST(@EndDate AS DATE))
ORDER BY EndDate
";

            var parameters = new
            {
                CurrentDate = DateTime.Now,
                MemberId = memberId,
                ProductName = searchParams.ProductName,
                PriceMin = searchParams.GroupBuyingPriceMin,
                PriceMax = searchParams.GroupBuyingPriceMax,
                EndDate = searchParams.EndDate
            };

            var results = _sqlConnection.Query<dynamic>(sql, parameters);

            return results.Select(p => new GroupbuyingProgressVm
            {
                ProductImage = p.ProductImage != null
                    ? _filePathHelper.GetReadPath("Products", p.ProductImage)
                    : null,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                OrdersQuantity = p.OrdersQuantity ?? 0,
                TotalPrice = p.ProductPrice * (p.OrdersQuantity ?? 0),
                CurrentGroupSize = p.CurrentGroupSize ?? 0,
                MinimumGroupSize = p.MinimumGroupSize,
                EndDate = p.EndDate,
                GroupBuyingId = p.GroupBuyingId ?? 0,
                ProductId = p.ProductId ?? 0
            }).ToList();
        }

        public void CancelGroupbuyingOrder(int groupBuyingId, int memberId)
        {
            var sql = @"
            UPDATE Orders 
            SET Status = 0, 
                UpdatedAt = @UpdateTime
            WHERE GroupBuyingId = @GroupBuyingId 
            AND MemberId = @MemberId 
            AND Status = 1";

            var result = _sqlConnection.Execute(sql, new
            {
                GroupBuyingId = groupBuyingId,
                MemberId = memberId,
                UpdateTime = DateTime.Now
            });

            if (result == 0)
            {
                throw new Exception($"No records updated. GroupBuyingId: {groupBuyingId}, MemberId: {memberId}");
            }
        }

        public List<PersonalGroupBuyingOrdersVm> GetGroupbuyingOrderById(int memberId, GroupbuyingSearchParams searchParams)
        {
            var sql = $@"
SELECT 
    (SELECT TOP 1 pi2.Path 
     FROM ProductImages pi2 
     WHERE pi2.ProductId = p.Id) ProductImage,
    p.Name ProductName,
    gb.Price ProductPrice,
    (SELECT SUM(CAST(o2.Quantity AS int))
     FROM Orders o2 
     WHERE o2.GroupBuyingId = gb.Id 
     AND o2.MemberId = @MemberId
     ) OrdersQuantity, 
gb.ProductId AS ProductId,
o.Status AS Status
FROM GroupBuyings gb
INNER JOIN Products p ON gb.ProductId = p.Id
INNER JOIN Orders o ON o.GroupBuyingId = gb.Id
AND o.MemberId = @MemberId
AND gb.Enabled = 1 
WHERE o.Status != 0
AND o.Status != 1

AND (@ProductName IS NULL OR p.Name LIKE '%' + @ProductName + '%')
AND (@PriceMin IS NULL OR gb.Price >= @PriceMin)
AND (@PriceMax IS NULL OR gb.Price <= @PriceMax)
AND (@Status IS NULL OR o.Status = @Status)
ORDER BY Status
";
            var parameters = new
            {
                MemberId = memberId,
                ProductName = searchParams.ProductName,
                PriceMin = searchParams.GroupBuyingPriceMin,
                PriceMax = searchParams.GroupBuyingPriceMax,
                Status = searchParams.Status
            };

            var results = _sqlConnection.Query<dynamic>(sql, parameters);

            return results.Select(p => new PersonalGroupBuyingOrdersVm
            {
                ProductImage = p.ProductImage != null
                    ? _filePathHelper.GetReadPath("Products", p.ProductImage)
                    : null,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                OrdersQuantity = p.OrdersQuantity ?? 0,
                TotalPrice = p.ProductPrice * (p.OrdersQuantity ?? 0),                
                ProductId = p.ProductId ?? 0,
                Status = p.Status
            }).ToList();
        }
    }
}
