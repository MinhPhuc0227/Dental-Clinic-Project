using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.DAL
{
    public class Treatment_DAL
    {
        private readonly AppDbContext _context;

        public Treatment_DAL(AppDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách Treatment của một bệnh nhân
        public List<Treatment> GetByPatientId(int patientId)
        {
            return _context.Treatments
                .Include(t => t.Service)
                .Include(t => t.Doctor)
                .Include(t => t.Visits) 
                .Where(t => t.PatientId == patientId)
                .OrderByDescending(t => t.StartDate)
                .ToList();
        }

        // Lấy Treatment theo Id
        public Treatment? GetById(int treatmentId)
        {
            return _context.Treatments
                .Include(t => t.Service)
                .Include(t => t.Doctor)
                .FirstOrDefault(t => t.TreatmentId == treatmentId);
        }

        // Thêm Treatment
        public bool Add(Treatment entity)
        {
            _context.Treatments.Add(entity);
            return _context.SaveChanges() > 0;
        }

        // Cập nhật Treatment
        public bool Update(Treatment entity)
        {
            var existing = _context.Treatments.FirstOrDefault(t => t.TreatmentId == entity.TreatmentId);

            if (existing == null)
                return false;

            existing.DoctorId = entity.DoctorId;
            existing.ServiceId = entity.ServiceId;
            existing.StartDate = entity.StartDate;
            existing.EndDate = entity.EndDate;
            existing.PlannedSessions = entity.PlannedSessions;
            existing.TotalAmount = entity.TotalAmount;
            existing.Status = entity.Status;
            existing.Note = entity.Note;

            return _context.SaveChanges() > 0;
        }

        // Xóa Treatment
        public bool Delete(int treatmentId)
        {
            var existing = _context.Treatments.FirstOrDefault(t => t.TreatmentId == treatmentId);

            if (existing == null)
                return false;

            _context.Treatments.Remove(existing);
            return _context.SaveChanges() > 0;
        }

        // Kiểm tra Treatment đã có Visit hay chưa
        public bool HasVisits(int treatmentId)
        {
            return _context.Visits.Any(v => v.TreatmentId == treatmentId);
        }

        // Lấy các Visit thuộc Treatment
        public List<Visit> GetVisitsByTreatmentId(int treatmentId)
        {
            return _context.Visits
                .Include(v => v.Doctor)
                .Where(v => v.TreatmentId == treatmentId)
                .OrderBy(v => v.TreatmentSessionNumber)
                .ThenBy(v => v.CheckInDateTime)
                .ToList();
        }

        // Đếm Visit đã hoàn thành
        public int GetCompletedVisitCount(int treatmentId)
        {
            return _context.Visits
                .Count(v =>
                    v.TreatmentId == treatmentId &&
                    v.Status == VisitStatus.Completed);
        }

        // Lấy số Session tiếp theo
        public int GetNextSessionNumber(int treatmentId)
        {
            var maxSession = _context.Visits
                .Where(v =>
                    v.TreatmentId == treatmentId &&
                    v.TreatmentSessionNumber.HasValue)
                .Select(v => (int?)v.TreatmentSessionNumber)
                .Max() ?? 0;

            return maxSession + 1;
        }

        public bool UpdateStatus(int treatmentId, TreatmentStatus status)
        {
            var existing = _context.Treatments.FirstOrDefault(t => t.TreatmentId == treatmentId);

            if (existing == null)
                return false;

            existing.Status = status;
            return _context.SaveChanges() > 0;
        }

        public Treatment? GetActiveByPatientAndService(int patientId, int serviceId)
        {
            return _context.Treatments
                .Include(t => t.Service)
                .Include(t => t.Doctor)
                .Include(t => t.Visits)
                .FirstOrDefault(t =>
                    t.PatientId == patientId &&
                    t.ServiceId == serviceId &&
                    t.Status == TreatmentStatus.InProgress);
        }
    }
}