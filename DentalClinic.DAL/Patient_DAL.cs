using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Patient_DAL
    {
        // GetAll
        public List<Patient> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Patients.Include(p => p.Account).ToList();
            }
        }

        // GetById
        public Patient? GetById(int patientId)
        {
            using (var context = new AppDbContext())
            {
                return context.Patients.Include(p => p.Account).FirstOrDefault(p => p.PatientId == patientId);
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

        // Check if phone exists (excludePatientId, active account) - for Updating
        public bool IsPhoneExists(string phone, int excludePatientId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.Patients.Any(p => p.Phone == phone
                                              && p.PatientId != excludePatientId
                                              && (p.AccountId == null || p.Account!.Status == AccountStatus.Active));
            }
        }

        // Add patient + account with transaction
        public bool AddWithAccount(Account? accountEntity, Patient patientEntity)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (accountEntity != null)
                        {
                            context.Accounts.Add(accountEntity);
                            context.SaveChanges();
                            patientEntity.AccountId = accountEntity.AccountId;
                        }

                        context.Patients.Add(patientEntity);
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

        // Update patient + account with transaction
        public bool UpdateWithAccount(Patient patientEntity, Account? accountEntity, bool updatePassword)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var existingPatient = context.Patients.FirstOrDefault(p => p.PatientId == patientEntity.PatientId);
                        if (existingPatient == null) return false;

                        existingPatient.FullName = patientEntity.FullName;
                        existingPatient.Gender = patientEntity.Gender;
                        existingPatient.DateOfBirth = patientEntity.DateOfBirth;
                        existingPatient.Phone = patientEntity.Phone;
                        existingPatient.Email = patientEntity.Email;
                        existingPatient.Address = patientEntity.Address;
                        existingPatient.Note = patientEntity.Note;

                        if (accountEntity != null)
                        {
                            // Case 1: hasn't had an account yet -> add new account
                            if (!existingPatient.AccountId.HasValue)
                            {
                                context.Accounts.Add(accountEntity);
                                context.SaveChanges(); 

                                existingPatient.AccountId = accountEntity.AccountId; 
                            }
                            // Case 2: already had an account -> update existing account
                            else
                            {
                                var existingAcc = context.Accounts.FirstOrDefault(a => a.AccountId == existingPatient.AccountId.Value);
                                if (existingAcc != null)
                                {
                                    existingAcc.UserName = accountEntity.UserName;
                                    existingAcc.Status = accountEntity.Status;
                                    if (updatePassword) existingAcc.Password = accountEntity.Password;
                                }
                            }
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

        // Delete patient + account with transaction
        public bool DeleteWithAccount(int patientId)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var patient = context.Patients.FirstOrDefault(p => p.PatientId == patientId);
                        if (patient == null) return false;

                        Account? account = null;
                        if (patient.AccountId.HasValue)
                        {
                            account = context.Accounts.FirstOrDefault(a => a.AccountId == patient.AccountId.Value);
                        }

                        context.Patients.Remove(patient);
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
