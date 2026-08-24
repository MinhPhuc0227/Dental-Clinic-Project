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
                return context.Patients.ToList();
            }
        }

        // GetById
        public Patient? GetById(int patientId)
        {
            using (var context = new AppDbContext())
            {
                return context.Patients.FirstOrDefault(p => p.PatientId == patientId);
            }
        }

        // Check if phone exists (excludePatientId) - for Updating
        public bool IsPhoneExists(string phone, int excludePatientId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.Patients.Any(p => p.Phone == phone && p.PatientId != excludePatientId);
            }
        }

        // Add 
        public bool Add(Patient patientEntity)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Patients.Add(patientEntity);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        // Update
        public bool Update(Patient patientEntity)
        {
            using (var context = new AppDbContext())
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

                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        // Delete
        public bool Delete(int patientId)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var patient = context.Patients.FirstOrDefault(p => p.PatientId == patientId);
                    if (patient == null) return false;

                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
