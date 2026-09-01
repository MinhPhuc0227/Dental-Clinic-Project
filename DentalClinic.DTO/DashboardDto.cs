using System;
using System.Collections.Generic;

namespace DentalClinic.DTO
{
    // =========================================================
    // SUMMARY
    // =========================================================
    public class DashboardSummaryDto
    {
        public int Patients { get; set; }

        public int Visits { get; set; }

        public decimal Revenue { get; set; }

        public int Waiting { get; set; }

        public int WaitingPayment { get; set; }

        public int MedicineStock { get; set; }

        public int TotalMedicines { get; set; }
    }


    // =========================================================
    // DAILY STATISTIC
    // =========================================================
    public class DashboardDailyStatisticDto
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }

        public decimal Amount { get; set; }
    }


    // =========================================================
    // VISIT STATUS
    // =========================================================
    public class DashboardVisitStatusDto
    {
        public string Status { get; set; } = string.Empty;

        public int Count { get; set; }
    }


    // =========================================================
    // LOW STOCK
    // =========================================================
    public class DashboardLowStockDto
    {
        public int MedicineId { get; set; }

        public string MedicineName { get; set; } = string.Empty;

        public string Unit { get; set; } = string.Empty;

        public int QuantityInStock { get; set; }
    }


    // =========================================================
    // RECENT IMPORT
    // =========================================================
    public class DashboardRecentImportDto
    {
        public int MedicineImportId { get; set; }

        public DateTime ImportDate { get; set; }

        public string SupplierName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
    }


    // =========================================================
    // DOCTOR STATISTIC
    // =========================================================
    public class DashboardDoctorStatisticDto
    {
        public int DoctorId { get; set; }

        public string DoctorName { get; set; } = string.Empty;

        public int VisitCount { get; set; }
    }


    // =========================================================
    // PATIENT STATISTIC
    // =========================================================
    public class DashboardPatientStatisticDto
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public int VisitCount { get; set; }

        public DateTime LastVisit { get; set; }
    }
}