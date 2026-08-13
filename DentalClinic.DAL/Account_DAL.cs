using DentalClinic.MODEL;
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
                return context.Accounts.ToList();
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
    }
}
