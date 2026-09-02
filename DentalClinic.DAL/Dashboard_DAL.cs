using DentalClinic.BLL.Common;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.DAL
{
    public class Dashboard_DAL
    {
        private readonly AppDbContext _context;

        public Dashboard_DAL(AppDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // 1. SUMMARY
        // =========================================================

        public DashboardSummaryDto GetSummary(
            DateTime fromDate,
            DateTime toDate)
        {
            DateTime from = fromDate.Date;
            DateTime to = toDate.Date.AddDays(1);

            var visits = _context.Visits
                .Where(v =>
                    v.CheckInDateTime >= from &&
                    v.CheckInDateTime < to);

            var invoices = _context.Invoices
                .Where(i =>
                    i.InvoiceDateTime >= from &&
                    i.InvoiceDateTime < to);

            int patients = visits
                .Select(v => v.PatientId)
                .Distinct()
                .Count();

            int visitCount = visits.Count();

            decimal revenue = invoices
                .Where(i =>
                    i.Status == InvoiceStatus.Paid)
                .Sum(i => (decimal?)i.TotalAmount) ?? 0;

            int waiting = visits.Count(v =>
                v.Status == VisitStatus.Waiting);

            int waitingPayment = visits.Count(v =>
                v.Status == VisitStatus.WaitingForPayment);

            int medicineStock = _context.Medicines
                .Where(m =>
                    m.Status == MedicineStatus.Active)
                .Sum(m => m.QuantityInStock);

            int totalMedicines = _context.Medicines
                .Count(m =>
                    m.Status == MedicineStatus.Active);

            return new DashboardSummaryDto
            {
                Patients = patients,
                Visits = visitCount,
                Revenue = revenue,
                Waiting = waiting,
                WaitingPayment = waitingPayment,
                MedicineStock = medicineStock,
                TotalMedicines = totalMedicines
            };
        }


        // =========================================================
        // 2. VISIT BY DAY
        // =========================================================

        public List<DashboardDailyStatisticDto>
            GetVisitStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            DateTime from = fromDate.Date;
            DateTime to = toDate.Date.AddDays(1);

            var rawData = _context.Visits
                .Where(v =>
                    v.CheckInDateTime >= from &&
                    v.CheckInDateTime < to)
                .GroupBy(v =>
                    v.CheckInDateTime.Date)
                .Select(g =>
                    new DashboardDailyStatisticDto
                    {
                        Date = g.Key,
                        Count = g.Count()
                    })
                .ToList();

            var result =
                new List<DashboardDailyStatisticDto>();

            for (
                DateTime date = from;
                date < toDate.Date.AddDays(1);
                date = date.AddDays(1))
            {
                var item = rawData.FirstOrDefault(x =>
                    x.Date == date);

                result.Add(
                    new DashboardDailyStatisticDto
                    {
                        Date = date,
                        Count = item?.Count ?? 0
                    });
            }

            return result;
        }


        // =========================================================
        // 3. REVENUE BY DAY
        // =========================================================

        public List<DashboardDailyStatisticDto>
            GetRevenueStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            DateTime from = fromDate.Date;
            DateTime to = toDate.Date.AddDays(1);

            var rawData = _context.Invoices
                .Where(i =>
                    i.Status == InvoiceStatus.Paid &&
                    i.InvoiceDateTime >= from &&
                    i.InvoiceDateTime < to)
                .GroupBy(i =>
                    i.InvoiceDateTime.Date)
                .Select(g =>
                    new DashboardDailyStatisticDto
                    {
                        Date = g.Key,
                        Amount =
                            g.Sum(x => x.TotalAmount)
                    })
                .ToList();

            var result =
                new List<DashboardDailyStatisticDto>();

            for (
                DateTime date = from;
                date < toDate.Date.AddDays(1);
                date = date.AddDays(1))
            {
                var item = rawData.FirstOrDefault(x =>
                    x.Date == date);

                result.Add(
                    new DashboardDailyStatisticDto
                    {
                        Date = date,
                        Amount = item?.Amount ?? 0
                    });
            }

            return result;
        }


        // =========================================================
        // 4. VISIT STATUS
        // =========================================================

        public List<DashboardVisitStatusDto>
            GetVisitStatusStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            DateTime from = fromDate.Date;
            DateTime to = toDate.Date.AddDays(1);

            var data = _context.Visits
                .Where(v =>
                    v.CheckInDateTime >= from &&
                    v.CheckInDateTime < to)
                .GroupBy(v => v.Status)
                .Select(g =>
                    new
                    {
                        Status = g.Key,
                        Count = g.Count()
                    })
                .ToList();

            var result =
                new List<DashboardVisitStatusDto>();

            foreach (var item in data)
            {
                string statusText =
                    item.Status switch
                    {
                        VisitStatus.Waiting =>
                            "Chờ khám",

                        VisitStatus.InExamination =>
                            "Đang khám",

                        VisitStatus.WaitingForPayment =>
                            "Chờ thanh toán",

                        VisitStatus.Completed =>
                            "Hoàn thành",

                        VisitStatus.Cancelled =>
                            "Đã hủy",

                        _ =>
                            item.Status.ToString()
                    };

                result.Add(
                    new DashboardVisitStatusDto
                    {
                        Status = statusText,
                        Count = item.Count
                    });
            }

            return result
                .OrderByDescending(x => x.Count)
                .ToList();
        }


        // =========================================================
        // 5. LOW STOCK
        // =========================================================

        public List<DashboardLowStockDto>
            GetLowStockMedicines(
                int threshold = SystemConstants.LowStockThreshold)
        {
            return _context.Medicines
                .AsNoTracking()
                .Where(m =>
                    m.Status == MedicineStatus.Active &&
                    m.QuantityInStock <= threshold)
                .OrderBy(m =>
                    m.QuantityInStock)
                .Select(m =>
                    new DashboardLowStockDto
                    {
                        MedicineId =
                            m.MedicineId,

                        MedicineName =
                            m.MedicineName,

                        Unit =
                            m.Unit,

                        QuantityInStock =
                            m.QuantityInStock
                    })
                .ToList();
        }


        // =========================================================
        // 6. RECENT IMPORT
        // =========================================================

        public List<DashboardRecentImportDto>
            GetRecentImports(int count = 5)
        {
            return _context.MedicineImports
                .AsNoTracking()
                .Include(i => i.Supplier)
                .Include(i => i.Account)
                .OrderByDescending(i =>
                    i.ImportDate)
                .Take(count)
                .Select(i =>
                    new DashboardRecentImportDto
                    {
                        MedicineImportId =
                            i.MedicineImportId,

                        ImportDate =
                            i.ImportDate,

                        SupplierName =
                            i.Supplier.SupplierName,

                        UserName =
                            i.Account.UserName,

                        TotalAmount =
                            i.TotalAmount
                    })
                .ToList();
        }


        // =========================================================
        // 7. VISIT BY DOCTOR
        // =========================================================

        public List<DashboardDoctorStatisticDto>
            GetDoctorStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            DateTime from = fromDate.Date;
            DateTime to = toDate.Date.AddDays(1);

            return _context.Visits
                .AsNoTracking()
                .Where(v =>
                    v.CheckInDateTime >= from &&
                    v.CheckInDateTime < to)
                .GroupBy(v => new
                {
                    v.DoctorId,
                    v.Doctor.FullName
                })
                .Select(g =>
                    new DashboardDoctorStatisticDto
                    {
                        DoctorId =
                            g.Key.DoctorId,

                        DoctorName =
                            g.Key.FullName,

                        VisitCount =
                            g.Count()
                    })
                .OrderByDescending(x =>
                    x.VisitCount)
                .ToList();
        }


        // =========================================================
        // 8. PATIENT STATISTICS
        // =========================================================

        public List<DashboardPatientStatisticDto>
            GetPatientStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            DateTime from = fromDate.Date;
            DateTime to = toDate.Date.AddDays(1);

            return _context.Visits
                .AsNoTracking()
                .Where(v =>
                    v.CheckInDateTime >= from &&
                    v.CheckInDateTime < to)
                .GroupBy(v => new
                {
                    v.PatientId,
                    v.Patient.FullName
                })
                .Select(g =>
                    new DashboardPatientStatisticDto
                    {
                        PatientId =
                            g.Key.PatientId,

                        PatientName =
                            g.Key.FullName,

                        VisitCount =
                            g.Count(),

                        LastVisit =
                            g.Max(x =>
                                x.CheckInDateTime)
                    })
                .OrderByDescending(x =>
                    x.VisitCount)
                .ThenByDescending(x =>
                    x.LastVisit)
                .ToList();
        }
    }
}