using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.DAL
{
    public class Doctor_DAL
    {
        private readonly AppDbContext _context;

        public Doctor_DAL(AppDbContext context)
        {
            _context = context;
        }

        // GetAll
        public List<Doctor> GetAll()
        {
            return _context.Doctors.Include(d => d.Account).ToList();
        }

        // GetById
        public Doctor? GetById(int doctorId)
        {
            return _context.Doctors.Include(d => d.Account).FirstOrDefault(d => d.DoctorId == doctorId);
        }

        // GetDoctorByAccountId
        public Doctor? GetDoctorByAccountId(int accountId)
        {
            return _context.Doctors.FirstOrDefault(d => d.AccountId == accountId);
        }

        // Kiểm tra trùng username 
        public bool IsUserNameExists(string userName, int excludeAccountId = 0)
        {
            return _context.Accounts.Any(a => a.UserName.ToLower() == userName.ToLower()
                                              && a.AccountId != excludeAccountId);
        }

        // Kiểm tra trùng sđt
        public bool IsPhoneExists(string phone, int excludeDoctorId = 0)
        {
            bool isDoctorPhoneExist = _context.Doctors.Any(d => d.Phone == phone && d.DoctorId != excludeDoctorId);
            bool isReceptionistPhoneExist = _context.Receptionists.Any(r => r.Phone == phone);
            return isDoctorPhoneExist || isReceptionistPhoneExist;
        }

        // ADD Doctor + Account with DbContextTransaction
        public bool AddWithAccount(Account accountEntity, Doctor doctorEntity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                   _context.Accounts.Add(accountEntity);
                   _context.SaveChanges();

                   doctorEntity.AccountId = accountEntity.AccountId;
                   _context.Doctors.Add(doctorEntity);
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

        // UPDATE Doctor + Account with DbContextTransaction
        public bool UpdateWithAccount(Doctor doctorEntity, Account accountEntity, bool updatePassword)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                 try
                 {
                     var existingDoctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorEntity.DoctorId);
                     var existingAccount = _context.Accounts.FirstOrDefault(a => a.AccountId == accountEntity.AccountId);

                     if (existingDoctor == null || existingAccount == null) return false;

                     existingDoctor.FullName = doctorEntity.FullName;
                     existingDoctor.Gender = doctorEntity.Gender;
                     existingDoctor.DateOfBirth = doctorEntity.DateOfBirth;
                     existingDoctor.Phone = doctorEntity.Phone;
                     existingDoctor.Email = doctorEntity.Email;
                     existingDoctor.Description = doctorEntity.Description;
                     existingAccount.UserName = accountEntity.UserName;
                     
                    existingAccount.Status = accountEntity.Status;
                    if (updatePassword)
                    {
                       existingAccount.Password = accountEntity.Password;
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

        // DELETE Doctor + Account with DbContextTransaction
        public bool DeleteWithAccount(int doctorId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                 try
                 {
                    var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
                    if (doctor == null) return false;

                    var account = _context.Accounts.FirstOrDefault(a => a.AccountId == doctor.AccountId);

                    _context.Doctors.Remove(doctor);
                    if (account != null)
                    {
                        _context.Accounts.Remove(account);
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
    }
}
