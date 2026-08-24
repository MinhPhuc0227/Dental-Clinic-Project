using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Receptionist_DAL
    {
        // GetAll
        public List<Receptionist> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Receptionists.Include(r => r.Account).ToList();
            }
        }

        // GetById
        public Receptionist? GetById(int receptionistId)
        {
            using (var context = new AppDbContext())
            {
                return context.Receptionists.Include(r => r.Account).FirstOrDefault(r => r.ReceptionistId == receptionistId);
            }
        }

        public Receptionist? GetReceptionistByAccountId(int accountId)
        {
            using (var context = new AppDbContext())
            {
                return context.Receptionists.FirstOrDefault(d => d.AccountId == accountId);
            }
        }

        // Check if username exists (excludeAccountId) - for Updating
        public bool IsUserNameExists(string userName, int excludeAccountId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.Accounts.Any(a => a.UserName.ToLower() == userName.ToLower() && a.AccountId != excludeAccountId);
            }
        }

        // Check if phone exists (excludeReceptionistId, active account) - for Updating
        public bool IsPhoneExists(string phone, int excludeReceptionistId = 0)
        {
            using (var context = new AppDbContext())
            {
                bool isReceptionistPhoneExist = context.Receptionists.Any(d => d.Phone == phone && d.ReceptionistId != excludeReceptionistId);
                bool isDoctorPhoneExist = context.Doctors.Any(r => r.Phone == phone);
                return isReceptionistPhoneExist || isDoctorPhoneExist;
            }
        }

        // Add receptionist + account with transaction
        public bool AddWithAccount(Account accountEntity, Receptionist receptionistEntity)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Accounts.Add(accountEntity);
                        context.SaveChanges();

                        receptionistEntity.AccountId = accountEntity.AccountId;
                        context.Receptionists.Add(receptionistEntity);
                        context.SaveChanges();

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Update receptionist + account with transaction
        public bool UpdateWithAccount(Receptionist receptionistEntity, Account accountEntity, bool updatePassword)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var existingRec = context.Receptionists.FirstOrDefault(r => r.ReceptionistId == receptionistEntity.ReceptionistId);
                        var existingAcc = context.Accounts.FirstOrDefault(a => a.AccountId == accountEntity.AccountId);

                        if (existingRec == null || existingAcc == null) return false;

                        existingRec.FullName = receptionistEntity.FullName;
                        existingRec.Gender = receptionistEntity.Gender;
                        existingRec.DateOfBirth = receptionistEntity.DateOfBirth;
                        existingRec.Phone = receptionistEntity.Phone;
                        existingRec.Email = receptionistEntity.Email;
                        existingRec.Description = receptionistEntity.Description;

                        existingAcc.UserName = accountEntity.UserName;
                        existingAcc.Status = accountEntity.Status;
                        if (updatePassword)
                        {
                            existingAcc.Password = accountEntity.Password;
                        }

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Delete receptionist + account with transaction 
        public bool DeleteWithAccount(int receptionistId)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var receptionist = context.Receptionists.FirstOrDefault(r => r.ReceptionistId == receptionistId);
                        if (receptionist == null) return false;

                        var account = context.Accounts.FirstOrDefault(a => a.AccountId == receptionist.AccountId);

                        context.Receptionists.Remove(receptionist);
                        if (account != null) context.Accounts.Remove(account);

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
