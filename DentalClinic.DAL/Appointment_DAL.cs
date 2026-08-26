using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Appointment_DAL
    {
        private readonly AppDbContext _context;

        public Appointment_DAL (AppDbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public List<AppointmentListDto> GetFiltered(AppointmentFilterDto filter)
        {
            var query = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Receptionist)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Keyword))
            {
                string kw = filter.Keyword.Trim().ToLower();
                query = query.Where(a => a.Patient.FullName.ToLower().Contains(kw) ||
                                         a.Patient.Phone.Contains(kw) ||
                                         a.AppointmentId.ToString().Contains(kw));
            }

            if (filter.StartDate.HasValue)
            {
                var start = filter.StartDate.Value.Date;
                query = query.Where(a => a.AppointmentDateTime >= start);
            }

            if (filter.EndDate.HasValue)
            {
                var end = filter.EndDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(a => a.AppointmentDateTime <= end);
            }

            if (filter.DoctorId.HasValue && filter.DoctorId.Value > 0)
            {
                query = query.Where(a => a.DoctorId == filter.DoctorId.Value);
            }

            if (filter.Status.HasValue)
            {
                query = query.Where(a => a.Status == filter.Status.Value);
            }

            return query
                .OrderBy(a => a.AppointmentDateTime)
                .ThenBy(a => a.AppointmentId)
                .Select(a => new AppointmentListDto
                {
                    AppointmentId = a.AppointmentId,
                    PatientName = a.Patient.FullName,
                    PatientPhone = a.Patient.Phone,
                    DoctorName = a.Doctor.FullName,
                    AppointmentDateTime = a.AppointmentDateTime,
                    Status = a.Status,
                    ReasonForVisit = a.ReasonForVisit,
                    Note = a.Note,
                    ReceptionistName = a.Receptionist.FullName,
                    CreatedDate = a.CreatedDate,
                    DoctorId = a.DoctorId
                })
                .ToList();
        }

        public Appointment? GetById(int id)
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Receptionist)
                .FirstOrDefault(a => a.AppointmentId == id);
        }

        public bool Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            return _context.SaveChanges() > 0;
        }

        public List<LookupItemDto> GetPatientsLookup()
        {
            return _context.Patients
                .AsNoTracking()
                .Select(p => new LookupItemDto
                {
                    Id = p.PatientId,
                    Name = p.FullName + " - " + p.Phone
                })
                .ToList();
        }

        public List<LookupItemDto> GetDoctorsLookup()
        {
            return _context.Doctors
                .AsNoTracking()
                .Select(d => new LookupItemDto
                {
                    Id = d.DoctorId,
                    Name = "BS. " + d.FullName
                })
                .ToList();
        }

        public bool CreateVisitFromAppointmentTransaction(int appointmentId, int receptionistId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Lấy lịch hẹn lên và kiểm tra
                    var app = _context.Appointments.Find(appointmentId);
                    if (app == null || app.Status == AppointmentStatus.Cancelled)
                        return false; // Trả về false nếu lịch không hợp lệ

                    // 2. Đổi trạng thái lịch hẹn -> Completed (Đã tới phòng khám)
                    app.Status = AppointmentStatus.Completed;
                    _context.Appointments.Update(app);

                    // Đếm số lượng bệnh nhân của Bác sĩ này trong NGÀY HÔM NAY
                    int currentQueueCount = _context.Visits
                        .Count(v => v.DoctorId == app.DoctorId && v.CheckInDateTime.Date == DateTime.Today);

                    // 3. Tạo dòng mới trong bảng Visit (Đồng thời là thêm vào hàng chờ)
                    var newVisit = new Visit
                    {
                        AppointmentId = app.AppointmentId,
                        PatientId = app.PatientId,
                        DoctorId = app.DoctorId,
                        ReasonForVisit = app.ReasonForVisit,
                        CheckInDateTime = DateTime.Now,
                        Status = VisitStatus.Waiting, 
                        ReceptionistId = receptionistId,
                        QueueNumber = currentQueueCount + 1 
                    };

                    _context.Visits.Add(newVisit);

                    // Hoàn tất Transaction
                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw; 
                }
            }
        }

        // Kiểm tra trùng lịch Bác sĩ
        public bool HasDoctorConflict(int doctorId, DateTime startTime, int durationMinutes, int? excludeAppId = null)
        {
            DateTime endTime = startTime.AddMinutes(durationMinutes);

            return _context.Appointments.Any(a =>
                a.DoctorId == doctorId &&
                (a.Status == AppointmentStatus.Pending || a.Status == AppointmentStatus.Confirmed) &&
                (!excludeAppId.HasValue || a.AppointmentId != excludeAppId.Value) &&
                a.AppointmentDateTime < endTime &&
                a.AppointmentDateTime.AddMinutes(durationMinutes) > startTime
            );
        }

        // Kiểm tra trùng lịch Bệnh nhân (1 người không thể khám 2 phòng cùng lúc)
        public bool HasPatientConflict(int patientId, DateTime startTime, int durationMinutes, int? excludeAppId = null)
        {
            DateTime endTime = startTime.AddMinutes(durationMinutes);

            return _context.Appointments.Any(a =>
                a.PatientId == patientId &&
                (a.Status == AppointmentStatus.Pending || a.Status == AppointmentStatus.Confirmed) &&
                (!excludeAppId.HasValue || a.AppointmentId != excludeAppId.Value) &&
                a.AppointmentDateTime < endTime &&
                a.AppointmentDateTime.AddMinutes(durationMinutes) > startTime
            );
        }
    }
}
