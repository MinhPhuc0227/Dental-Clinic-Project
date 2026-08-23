using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.DAL
{
    public class Doctor_DAL
    {
        // GetAll
        public List<Doctor> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Doctors
                              .Include(d => d.Account)
                              .ToList();
            }
        }

        // GetById
        public Doctor? GetById(int doctorId)
        {
            using (var context = new AppDbContext())
            {
                return context.Doctors
                              .Include(d => d.Account)
                              .FirstOrDefault(d => d.DoctorId == doctorId);
            }
        }

        public Doctor? GetDoctorByAccountId(int accountId)
        {
            using (var context = new AppDbContext())
            {
                return context.Doctors.FirstOrDefault(d => d.AccountId == accountId);
            }
        }

        // Check if UserName exists (excluding a specific AccountId) - for Updating 
        public bool IsUserNameExists(string userName, int excludeAccountId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.Accounts.Any(a => a.UserName.ToLower() == userName.ToLower()
                                              && a.AccountId != excludeAccountId);
            }
        }

        // Check if Phone exists (excluding a specific DoctorId) - for Updating
        public bool IsPhoneExists(string phone, int excludeDoctorId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.Doctors.Any(d => d.Phone == phone
                                             && d.DoctorId != excludeDoctorId
                                             && d.Account.Status == AccountStatus.Active);
            }
        }

        // ADD Doctor + Account with DbContextTransaction
        public bool AddWithAccount(Account accountEntity, Doctor doctorEntity)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Accounts.Add(accountEntity);
                        context.SaveChanges();

                        doctorEntity.AccountId = accountEntity.AccountId;
                        context.Doctors.Add(doctorEntity);
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

        // UPDATE Doctor + Account with DbContextTransaction
        public bool UpdateWithAccount(Doctor doctorEntity, Account accountEntity, bool updatePassword)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var existingDoctor = context.Doctors.FirstOrDefault(d => d.DoctorId == doctorEntity.DoctorId);
                        var existingAccount = context.Accounts.FirstOrDefault(a => a.AccountId == accountEntity.AccountId);

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

        // DELETE Doctor + Account with DbContextTransaction
        public bool DeleteWithAccount(int doctorId)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var doctor = context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
                        if (doctor == null) return false;

                        var account = context.Accounts.FirstOrDefault(a => a.AccountId == doctor.AccountId);

                        context.Doctors.Remove(doctor);
                        if (account != null)
                        {
                            context.Accounts.Remove(account);
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
    }
}
