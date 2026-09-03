using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Receptionist_DAL
    {
        private readonly AppDbContext _context;

        public Receptionist_DAL(AppDbContext context)
        {
            _context = context;
        }

        // GetAll
        public List<Receptionist> GetAll()
        {
                return _context.Receptionists.Include(r => r.Account).ToList();
        }

        // GetById
        public Receptionist? GetById(int receptionistId)
        {
            return _context.Receptionists.Include(r => r.Account).FirstOrDefault(r => r.ReceptionistId == receptionistId);
        }

        public Receptionist? GetReceptionistByAccountId(int accountId)
        {
            return _context.Receptionists.FirstOrDefault(d => d.AccountId == accountId);
        }

        // Check if username exists (excludeAccountId) - for Updating
        public bool IsUserNameExists(string userName, int excludeAccountId = 0)
        {
                return _context.Accounts.Any(a => a.UserName.ToLower() == userName.ToLower() && a.AccountId != excludeAccountId);
        }

        // Check if phone exists (excludeReceptionistId, active account) - for Updating
        public bool IsPhoneExists(string phone, int excludeReceptionistId = 0)
        {
                bool isReceptionistPhoneExist = _context.Receptionists.Any(d => d.Phone == phone && d.ReceptionistId != excludeReceptionistId);
                bool isDoctorPhoneExist = _context.Doctors.Any(r => r.Phone == phone);
                return isReceptionistPhoneExist || isDoctorPhoneExist;
        }

        // Add receptionist + account with transaction
        public bool AddWithAccount(Account accountEntity, Receptionist receptionistEntity)
        {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Accounts.Add(accountEntity);
                        _context.SaveChanges();

                        receptionistEntity.AccountId = accountEntity.AccountId;
                        _context.Receptionists.Add(receptionistEntity);
                        _context.SaveChanges();

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

        // Update receptionist + account with transaction
        public bool UpdateWithAccount(Receptionist receptionistEntity, Account accountEntity, bool updatePassword)
        {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var existingRec = _context.Receptionists.FirstOrDefault(r => r.ReceptionistId == receptionistEntity.ReceptionistId);
                        var existingAcc = _context.Accounts.FirstOrDefault(a => a.AccountId == accountEntity.AccountId);

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

                        _context.SaveChanges();
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

        // Delete receptionist + account with transaction 
        public bool DeleteWithAccount(int receptionistId)
        {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var receptionist = _context.Receptionists.FirstOrDefault(r => r.ReceptionistId == receptionistId);
                        if (receptionist == null) return false;

                        var account = _context.Accounts.FirstOrDefault(a => a.AccountId == receptionist.AccountId);

                        _context.Receptionists.Remove(receptionist);
                        if (account != null) _context.Accounts.Remove(account);

                        _context.SaveChanges();
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
