using DentalClinic.DTO;
using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Account_DAL
    {
        // GetAll
        public List<Account> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Accounts
                    .Include(a => a.Doctor)
                    .Include(a => a.Receptionist)
                    .ToList();
            }
        }

        // GetById
        public Account? GetById(int accountId)
        {
            using (var context = new AppDbContext())
            {
                return context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            }
        }

        // Check if username exists, excluding a specific account ID - for Updating
        public bool IsUserNameExists(string userName, int excludeAccountId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.Accounts.Any(a => a.UserName.ToLower() == userName.ToLower()
                                              && a.AccountId != excludeAccountId);
            }
        }

        // CREATE
        public bool Create(Account entity)
        {
            using (var context = new AppDbContext())
            {
                context.Accounts.Add(entity);
                return context.SaveChanges() > 0;
            }
        }

        // UPDATE
        public bool Update(Account entity, bool updatePassword)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Accounts.FirstOrDefault(a => a.AccountId == entity.AccountId);
                if (existing == null) return false;

                existing.UserName = entity.UserName;
                existing.Role = entity.Role;
                existing.Status = entity.Status;

                if (updatePassword)
                {
                    existing.Password = entity.Password;
                }

                return context.SaveChanges() > 0;
            }
        }

        // DELETE
        public bool Delete(int accountId)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                if (existing == null) return false;

                context.Accounts.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }

        // GetByUserName (for Login)
        public Account? GetByUserName(string userName)
        {
            using (var context = new AppDbContext())
            {
                return context.Accounts.FirstOrDefault(a => a.UserName == userName);
            }
        }

        // HÀM CŨ KHI CHƯA DÙNG BCRYPT BĂM PASSWORD

        //public LoginResponseDto CheckLogin(string username, string password)
        //{
        //    using (var context = new AppDbContext())
        //    {
        //        // Tìm tài khoản khớp Username và Password
        //        // Dùng Include để lấy luôn thông tin Bác sĩ/Lễ tân gắn với tài khoản này
        //        var account = context.Accounts
        //            .Include(a => a.Doctor)
        //            .Include(a => a.Receptionist)
        //            .FirstOrDefault(a => a.UserName == username && a.Password == password);

        //        if (account == null)
        //        {
        //            return new LoginResponseDto { IsSuccess = false, Message = "Sai tài khoản hoặc mật khẩu!" };
        //        }

        //        // Nếu là Bác sĩ
        //        if (account.Role == AccountRole.Doctor && account.Doctor != null)
        //        {
        //            return new LoginResponseDto
        //            {
        //                IsSuccess = true,
        //                Role = "Doctor",
        //                UserId = account.Doctor.DoctorId,
        //                FullName = account.Doctor.FullName
        //            };
        //        }

        //        // Nếu là Lễ tân
        //        if (account.Role == AccountRole.Receptionist && account.Receptionist != null)
        //        {
        //            return new LoginResponseDto
        //            {
        //                IsSuccess = true,
        //                Role = "Receptionist",
        //                UserId = account.Receptionist.ReceptionistId,
        //                FullName = account.Receptionist.FullName
        //            };
        //        }

        //        return new LoginResponseDto { IsSuccess = false, Message = "Tài khoản chưa được phân quyền hợp lệ!" };
        //    }
        //}
    }
}
