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
        //public List<WaitingQueueDto> GetWaitingQueue(DateTime date, string keyword, int? doctorId, VisitStatus? status)
        //{
        //    var query = _context.Visits
        //        .Include(v => v.Patient)
        //        .Include(v => v.Doctor)
        //        .Include(v => v.Appointment)
        //        .AsNoTracking()
        //        .Where(v => v.CheckInDateTime.Date == date.Date);

        //    // Lọc theo trạng thái
        //    if (status.HasValue)
        //    {
        //        query = query.Where(v => v.Status == status.Value);
        //    }

        //    // Lọc theo bác sĩ
        //    if (doctorId.HasValue && doctorId.Value > 0)
        //    {
        //        query = query.Where(v => v.DoctorId == doctorId.Value);
        //    }

        //    // Lọc theo từ khóa tìm kiếm (Tên hoặc SĐT)
        //    if (!string.IsNullOrWhiteSpace(keyword))
        //    {
        //        string kw = keyword.Trim().ToLower();
        //        query = query.Where(v => v.Patient.FullName.ToLower().Contains(kw) ||
        //                                 v.Patient.Phone.Contains(kw));
        //    }

        //    // Sắp xếp ai đến trước (Thời gian tiếp nhận sớm hơn) thì lên đầu hàng chờ
        //    return query.OrderBy(v => v.CheckInDateTime)
        //        .Select(v => new WaitingQueueDto
        //        {
        //            VisitId = v.VisitId,
        //            QueueNumber = v.QueueNumber,
        //            PatientName = v.Patient.FullName,
        //            PatientPhone = v.Patient.Phone,
        //            DoctorName = v.Doctor != null ? v.Doctor.FullName : "",
        //            CheckInDateTime = v.CheckInDateTime,
        //            ReasonForVisit = v.ReasonForVisit,
        //            Status = v.Status,
        //            PatientNote = v.Patient.Note,
        //            AppointmentNote = v.Appointment != null ? v.Appointment.Note : null
        //        }).ToList();
        //}

        public List<WaitingQueueDto> GetWaitingQueue(DateTime date, string keyword, int? doctorId, VisitStatus? status)
        {
            var query = _context.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .Include(v => v.Appointment)
                .AsNoTracking()
                .Where(v => v.CheckInDateTime.Date == date.Date);

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
                query = query.Where(v => v.Patient.FullName.ToLower().Contains(kw) ||
                                         v.Patient.Phone.Contains(kw));
            }

            var rawList = query
                .Select(v => new WaitingQueueDto
                {
                    VisitId = v.VisitId,
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

            // Ưu tiên 1: Khách có lịch hẹn (IsAppointment = true) lên trên đầu.
            // Ưu tiên 2: Ai check-in sớm hơn (CheckInDateTime) được khám trước.
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

        public List<VisitListDto> GetAllVisits(DateTime date, string keyword)
        {
            var query = _context.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .AsNoTracking()
                .Where(v => v.CheckInDateTime.Date == date.Date);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(v => v.Patient.FullName.ToLower().Contains(kw) ||
                                         v.Patient.Phone.Contains(kw));
            }

            return query.OrderByDescending(v => v.CheckInDateTime)
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
                }).ToList();
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
    }
}
