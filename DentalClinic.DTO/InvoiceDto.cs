using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DTO
{
    // Hiển thị danh sách hàng chờ thanh toán (pnLeft)
    public class WaitingPaymentDto
    {
        public int InvoiceId { get; set; }
        public int VisitId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime InvoiceDateTime { get; set; }
        //public DateTime CompletedTime { get; set; }
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

    public class InvoiceDetailDto
    {
        // Invoice
        public int InvoiceId { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public string Status { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
        public decimal AmountGiven { get; set; }
        public decimal ChangeAmount { get; set; }

        public string PaymentMethodName { get; set; } = string.Empty;
        public string ReceptionistName { get; set; } = string.Empty;

        // Cancellation
        public string? CancellationReason { get; set; }
        public DateTime? CancelledDate { get; set; }
        public string? CancelledByName { get; set; }

        // Patient
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public DateOnly PatientDateOfBirth { get; set; }
        public string? PatientAddress { get; set; }

        // Visit
        public int VisitId { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public string ReasonForVisit { get; set; } = string.Empty;

        // Doctor
        public string DoctorName { get; set; } = string.Empty;

        // Medical Record
        public int? MedicalRecordId { get; set; }
        public DateTime? ExaminationDateTime { get; set; }
        public string? Diagnosis { get; set; }
        public string? Conclusion { get; set; }
    }

    public class InvoiceDetailItemDto
    {
        public int InvoiceDetailId { get; set; }

        public string ItemType { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }

        // Dành cho thuốc
        public int Morning { get; set; }
        public int Noon { get; set; }
        public int Afternoon { get; set; }
        public int Evening { get; set; }
        public int Days { get; set; }
        public string Instruction { get; set; } = string.Empty;

        public string? Note { get; set; }
    }
}
