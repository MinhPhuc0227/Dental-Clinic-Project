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
        private readonly AppDbContext _context;

        public Account_DAL(AppDbContext context)
        {
            _context = context;
        }

        // GetAll
        public List<Account> GetAll(string keyword = "", AccountRole? role = null, AccountStatus? status = null)
        {
            var query = _context.Accounts
                .Include(a => a.Doctor)
                .Include(a => a.Receptionist)
                .AsQueryable();

            // Tìm kiếm
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();

                query = query.Where(a =>
                    a.UserName.Contains(keyword) ||
                    (a.Doctor != null && a.Doctor.FullName.Contains(keyword)) ||
                    (a.Receptionist != null && a.Receptionist.FullName.Contains(keyword)));
            }

            // Lọc vai trò
            if (role.HasValue)
            {
                query = query.Where(a => a.Role == role.Value);
            }

            // Lọc trạng thái
            if (status.HasValue)
            {
                query = query.Where(a => a.Status == status.Value);
            }

            return query.ToList();
        }

        // GetById
        public Account? GetById(int accountId)
        {
            return _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
        }

        // GetByUserName (dùng cho login)
        public Account? GetByUserName(string userName)
        {
            return _context.Accounts
                .Include(a => a.Doctor)
                .Include(a => a.Receptionist)
                .FirstOrDefault(a => a.UserName == userName);
        }

        // Kiểm tra tên người dùng đã tồn tại chưa (không kiểm tra tài khoản đang được cập nhật)
        public bool IsUserNameExists(string userName, int excludeAccountId = 0)
        {
            return _context.Accounts.Any(a => a.UserName.ToLower() == userName.ToLower()
                                          && a.AccountId != excludeAccountId);
        }

        // Tương tự, kiểm tra số điện thoại đã tồn tại chưa
        public bool IsPatientPhoneExists(string phone)
        {
            return _context.Patients.Any(
                p => p.Phone == phone);
        }

        // CREATE
        public bool Create(Account entity)
        {
            _context.Accounts.Add(entity);
            return _context.SaveChanges() > 0;
        }

        // UPDATE
        public bool Update(Account entity, bool updatePassword)
        {
                var existing = _context.Accounts.FirstOrDefault(a => a.AccountId == entity.AccountId);
                if (existing == null) return false;

                existing.UserName = entity.UserName;
                existing.Role = entity.Role;
                existing.Status = entity.Status;

                if (updatePassword)
                {
                    existing.Password = entity.Password;
                }

                return _context.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int accountId)
        {
                var existing = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                if (existing == null) return false;

                _context.Accounts.Remove(existing);
                return _context.SaveChanges() > 0;
        }
    }
}
