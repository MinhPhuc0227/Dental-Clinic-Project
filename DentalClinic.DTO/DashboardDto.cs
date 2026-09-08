using System;
using System.Collections.Generic;

namespace DentalClinic.DTO
{
    // Các chỉ số tổng quan 
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

    // Thống kê theo ngày
    public class DashboardDailyStatisticDto
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
    }


    // Thống kê theo trạng thái lượt khams
    public class DashboardVisitStatusDto
    {
        public string Status { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    // Cảnh báo tồn kho
    public class DashboardLowStockDto
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
    }

    // Nhập kho gần đây
    public class DashboardRecentImportDto
    {
        public int MedicineImportId { get; set; }
        public DateTime ImportDate { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }


    // Thống kê bác sĩ
    public class DashboardDoctorStatisticDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public int VisitCount { get; set; }
    }

    // Thống kê bệnh nhân
    public class DashboardPatientStatisticDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public int VisitCount { get; set; }
        public DateTime LastVisit { get; set; }
    }
}