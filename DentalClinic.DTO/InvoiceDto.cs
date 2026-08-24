using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DTO
{
    // Hiển thị danh sách hàng chờ thanh toán (pnLeft)
    public class WaitingPaymentDto
    {
        public int VisitId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime CheckInDateTime { get; set; }
        public DateTime CompletedTime { get; set; }
    }

    // Hiển thị chi tiết hóa đơn dịch vụ + thuốc (pnRight)
    public class InvoiceDetailDisplayDto
    {
        public string ItemType { get; set; } = string.Empty; // Dịch vụ, Thuốc
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }

        public int? MedicalRecordServiceId { get; set; }
        public int? PrescriptionDetailId { get; set; }
    }

    public class InvoiceDisplayDto
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string ReceptionistName { get; set; } = string.Empty; 
        public string PaymentMethodName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal AmountGiven { get; set; }
        public decimal ChangeAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
