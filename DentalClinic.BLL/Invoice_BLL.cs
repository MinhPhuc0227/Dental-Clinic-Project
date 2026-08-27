using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DentalClinic.BLL
{
    public class Invoice_BLL
    {
        private readonly Invoice_DAL _dal = new Invoice_DAL();

        public List<WaitingPaymentDto> GetWaitingPayments(string keyword = "")
        {
            try
            {
                return _dal.GetWaitingPayments(keyword);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}");
                Debug.WriteLine($"Inner: {ex.InnerException?.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                return new List<WaitingPaymentDto>();
            }
        }

        public List<InvoiceDetailDisplayDto> GetInvoiceDetails(int visitId)
        {
            try
            {
                return _dal.GetInvoiceDetailsByVisit(visitId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}");
                Debug.WriteLine($"Inner: {ex.InnerException?.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                return new List<InvoiceDetailDisplayDto>();
            }
        }

        public Result Checkout(int visitId, int paymentMethodId, int receptionistId, decimal totalAmount, decimal amountGiven, decimal changeAmount, List<InvoiceDetailDisplayDto> details)
        {
            if (visitId == 0 || details == null || !details.Any())
                return Result.Failure("Vui lòng chọn một bệnh nhân có dịch vụ/thuốc để thanh toán.");

            try
            {
                bool success = _dal.CheckoutInvoice(visitId, paymentMethodId, receptionistId, totalAmount, amountGiven, changeAmount, details);
                return success ? Result.Success("Thanh toán thành công!") : Result.Failure("Lỗi lưu hóa đơn.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        public Result CancelInvoice(int invoiceId)
        {
            if (invoiceId <= 0)
                return Result.Failure("Mã hóa đơn không hợp lệ.");

            try
            {
                bool success = _dal.CancelInvoice(invoiceId);

                return success
                    ? Result.Success("Hủy hóa đơn thành công.")
                    : Result.Failure("Không thể hủy hóa đơn.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("=== CancelInvoice ERROR ===");
                Debug.WriteLine($"InvoiceId: {invoiceId}");
                Debug.WriteLine($"Message: {ex.Message}");
                Debug.WriteLine($"Inner: {ex.InnerException?.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");

                return Result.Failure(
                    "Lỗi hủy hóa đơn: " +
                    (ex.InnerException?.Message ?? ex.Message));
            }
        }
        public List<PaymentMethodDto> GetPaymentMethods()
        {
            try
            {
                return _dal.GetPaymentMethods().Select(p => new PaymentMethodDto
                {
                    PaymentMethodId = p.PaymentMethodId,
                    PaymentMethodName = p.PaymentMethodName,
                    IsCash = p.IsCash
                }).ToList();
            }
            catch
            {
                return new List<PaymentMethodDto>();
            }
        }

        public List<InvoiceDisplayDto> GetAllInvoices(DateTime from, DateTime to, InvoiceStatus? status)
        {
            try
            {
                return _dal.GetAllInvoices(from, to, status);
            }
            catch { return new List<InvoiceDisplayDto>(); }
        }
    }
}
