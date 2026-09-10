using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace DentalClinic.DAL
{
    public class Visit_DAL
    {
        private readonly AppDbContext _context;

        public Visit_DAL(AppDbContext context)
        {
            _context = context;
        }

        public List<WaitingQueueDto> GetWaitingQueue(DateTime startDate, DateTime endDate, string keyword, int? doctorId, VisitStatus? status)
        {
            DateTime start = startDate.Date;
            DateTime end = endDate.Date.AddDays(1);

            var query = _context.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .Include(v => v.Appointment)
                .AsNoTracking()
                .Where(v => v.CheckInDateTime >= start && v.CheckInDateTime < end);

            // Lọc theo trạng thái
            if (status.HasValue)
            {
                query = query.Where(v => v.Status == status.Value);
            }

            // Lọc theo bác sĩ
            if (doctorId.HasValue && doctorId.Value > 0)
            {
                query = query.Where(v => v.DoctorId == doctorId.Value);
            }

            // Lọc theo từ khóa tìm kiếm (Tên hoặc SĐT)
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();

                query = query.Where(v =>
                    v.Patient.FullName.ToLower().Contains(kw) ||
                    v.Patient.Phone.Contains(kw));
            }

            var rawList = query
                .Select(v => new WaitingQueueDto
                {
                    VisitId = v.VisitId,
                    PatientId = v.PatientId,
                    QueueNumber = v.QueueNumber,
                    PatientName = v.Patient.FullName,
                    PatientPhone = v.Patient.Phone,
                    DoctorName = v.Doctor != null ? v.Doctor.FullName : "",
                    CheckInDateTime = v.CheckInDateTime,
                    ReasonForVisit = v.ReasonForVisit,
                    Status = v.Status,
                    PatientNote = v.Patient.Note,
                    AppointmentNote = v.Appointment != null ? v.Appointment.Note : null,
                    IsAppointment = v.AppointmentId.HasValue && v.AppointmentId.Value > 0
                })
                .ToList();

            // Ưu tiên 1: Khách có lịch hẹn lên trước.
            // Ưu tiên 2: Ai check-in sớm hơn được khám trước.
            return rawList
                .OrderByDescending(x => x.IsAppointment)
                .ThenBy(x => x.CheckInDateTime)
                .ToList();
        }

        // Hỗ trợ nạp ComboBox Bác sĩ
        public List<LookupItemDto> GetDoctorsLookup()
        {
            return _context.Doctors.AsNoTracking()
                .Select(d => new LookupItemDto { Id = d.DoctorId, Name = "BS. " + d.FullName })
                .ToList();
        }

        // Hỗ trợ nạp ComboBox Bệnh nhân
        public List<LookupItemDto> GetPatientsLookup()
        {
            return _context.Patients.AsNoTracking()
                .Select(p => new LookupItemDto { Id = p.PatientId, Name = p.FullName + " - " + p.Phone })
                .ToList();
        }

        public List<VisitListDto> GetAllVisits(
    DateTime startDate,
    DateTime endDate,
    string keyword = "",
    int? doctorId = null,
    VisitStatus? status = null)
        {
            DateTime start = startDate.Date;
            DateTime end = endDate.Date.AddDays(1);

            var query = _context.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .AsNoTracking()
                .Where(v => v.CheckInDateTime >= start &&
                            v.CheckInDateTime < end);

            // Tìm kiếm theo tên bệnh nhân hoặc SĐT
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim();

                query = query.Where(v =>
                    v.Patient.FullName.Contains(kw) ||
                    v.Patient.Phone.Contains(kw));
            }

            // Lọc theo bác sĩ
            if (doctorId.HasValue && doctorId.Value > 0)
            {
                query = query.Where(v => v.DoctorId == doctorId.Value);
            }

            // Lọc theo trạng thái
            if (status.HasValue)
            {
                query = query.Where(v => v.Status == status.Value);
            }

            return query
                .OrderByDescending(v => v.CheckInDateTime)
                .Select(v => new VisitListDto
                {
                    VisitId = v.VisitId,
                    PatientName = v.Patient.FullName,
                    PatientPhone = v.Patient.Phone,
                    DoctorName = v.Doctor != null ? v.Doctor.FullName : "",
                    CheckInDateTime = v.CheckInDateTime,
                    ReasonForVisit = v.ReasonForVisit,
                    Status = v.Status,
                    AppointmentId = v.AppointmentId,
                    QueueNumber = v.QueueNumber
                })
                .ToList();
        }


        public bool AddWalkInVisit(Visit visit)
        {
            // Đếm số lượng bệnh nhân của Bác sĩ này trong NGÀY HÔM NAY
            int currentQueueCount = _context.Visits
                .Count(v => v.DoctorId == visit.DoctorId && v.CheckInDateTime.Date == DateTime.Today);

            visit.QueueNumber = currentQueueCount + 1; // Cấp số thứ tự tiếp theo

            _context.Visits.Add(visit);
            return _context.SaveChanges() > 0;
        }

        public int CountVisitsToday(int doctorId)
        {
            return _context.Visits
                .Count(v => v.DoctorId == doctorId && v.CheckInDateTime.Date == DateTime.Today);
        }

        public bool HasActiveVisitToday(int patientId)
        {
            return _context.Visits.Any(v =>
                v.PatientId == patientId &&
                v.CheckInDateTime.Date == DateTime.Today &&
                (
                    v.Status == VisitStatus.Waiting ||
                    v.Status == VisitStatus.InExamination ||
                    v.Status == VisitStatus.WaitingForPayment
                ));
        }

        public bool UpdateStatus(int visitId, VisitStatus newStatus)
        {
            try
            {
                var visit = _context.Visits.FirstOrDefault(v => v.VisitId == visitId);
                if (visit == null)
                {
                    return false; // Không tìm thấy ca khám
                }

                visit.Status = newStatus;
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                // Có thể ghi log lỗi ở đây nếu cần
                return false;
            }
        }

        public Visit? GetById(int visitId)
        {
            return _context.Visits
                .FirstOrDefault(v => v.VisitId == visitId);
        }

        // Treatment
        public bool AssignTreatment(
    int visitId,
    int treatmentId,
    int sessionNumber)
        {
            var existing = _context.Visits
                .FirstOrDefault(v => v.VisitId == visitId);

            if (existing == null)
                return false;

            if (existing.TreatmentId.HasValue)
                return false;

            existing.TreatmentId = treatmentId;
            existing.TreatmentSessionNumber = sessionNumber;

            return _context.SaveChanges() > 0;
        }
    }
}