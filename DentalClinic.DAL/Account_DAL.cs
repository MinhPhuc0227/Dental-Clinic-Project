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
        public List<Account> GetAll()
        {   
                return _context.Accounts
                    .Include(a => a.Doctor)
                    .Include(a => a.Receptionist)
                    .ToList();
        }

        // GetById
        public Account? GetById(int accountId)
        {
            return _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
        }

        // Check if username exists, excluding a specific account ID - for Updating
        public bool IsUserNameExists(string userName, int excludeAccountId = 0)
        {
            return _context.Accounts.Any(a => a.UserName.ToLower() == userName.ToLower()
                                          && a.AccountId != excludeAccountId);
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

        // GetByUserName (for Login)
        public Account? GetByUserName(string userName)
        {
            return _context.Accounts.FirstOrDefault(a => a.UserName == userName);
        }
    }
}
