using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Patient_DAL
    {
        private readonly AppDbContext _context;

        public Patient_DAL(AppDbContext context)
        {
            _context = context;
        }

        // GetAll 
        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        // GetById
        public Patient? GetById(int patientId)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientId == patientId);
        }

        // Kiểm tra số điện thoại đã tồn tại hay chưa (khi sửa)
        public bool IsPhoneExists(string phone, int excludePatientId = 0)
        {
            return _context.Patients.Any(p => p.Phone == phone && p.PatientId != excludePatientId);
        }

        // ADD
        public bool Add(Patient patientEntity)
        {
            try
            {
                _context.Patients.Add(patientEntity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // UPDATE
        public bool Update(Patient patientEntity)
        {
            try
            {
                var existingPatient = _context.Patients.FirstOrDefault(p => p.PatientId == patientEntity.PatientId);
                if (existingPatient == null) return false;

                existingPatient.FullName = patientEntity.FullName;
                existingPatient.Gender = patientEntity.Gender;
                existingPatient.DateOfBirth = patientEntity.DateOfBirth;
                existingPatient.Phone = patientEntity.Phone;
                existingPatient.Email = patientEntity.Email;
                existingPatient.Address = patientEntity.Address;
                existingPatient.Note = patientEntity.Note;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE
        public bool Delete(int patientId)
        {
            try
            {
                var patient = _context.Patients.FirstOrDefault(p => p.PatientId == patientId);
                if (patient == null) return false;

                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return true;
             }
             catch
             {
                return false;
             }
        }
    }
}
