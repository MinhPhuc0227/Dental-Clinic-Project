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
        private readonly Invoice_DAL _dal;

        public Invoice_BLL(Invoice_DAL dal)
        {
            _dal = dal;
        }

        public List<WaitingPaymentDto> GetWaitingPayments(DateTime startDate, DateTime endDate, string keyword = "")
        {
            try
            {
                return _dal.GetWaitingPayments(startDate, endDate, keyword);
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

        public List<InvoiceDetailDisplayDto> GetInvoiceDetailsByInvoice(int invoiceId)
        {
            try
            {
                return _dal.GetInvoiceDetailsByInvoiceId(invoiceId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<InvoiceDetailDisplayDto>();
            }
        }

        public Result CreateUnpaidInvoice(int visitId)
        {
            if (visitId <= 0)
                return Result.Failure("Lượt khám không hợp lệ.");

            try
            {
                var existingInvoice = _dal.GetUnpaidInvoiceByVisitId(visitId);

                if (existingInvoice != null)
                {
                    return Result.Failure("Lượt khám này đã có hóa đơn chưa thanh toán.");
                }

                bool success = _dal.CreateUnpaidInvoice(visitId);

                return success ? Result.Success("Tạo hóa đơn chưa thanh toán thành công!") : Result.Failure("Không thể tạo hóa đơn.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi tạo hóa đơn: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        public Result Checkout(
            int invoiceId,
            int paymentMethodId,
            int receptionistId,
            decimal amountGiven,
            decimal changeAmount)
        {
            if (invoiceId <= 0)
                return Result.Failure("Mã hóa đơn không hợp lệ.");

            if (paymentMethodId <= 0)
                return Result.Failure("Phương thức thanh toán không hợp lệ.");

            if (receptionistId <= 0)
                return Result.Failure("Nhân viên thanh toán không hợp lệ.");

            try
            {
                bool success = _dal.CheckoutInvoice(
                    invoiceId,
                    paymentMethodId,
                    receptionistId,
                    amountGiven,
                    changeAmount);

                return success ? Result.Success("Thanh toán thành công!") : Result.Failure("Không thể thanh toán hóa đơn.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"=== Checkout ERROR ===");
                Debug.WriteLine($"InvoiceId: {invoiceId}");
                Debug.WriteLine($"Message: {ex.Message}");
                return Result.Failure("Lỗi thanh toán: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        public Result CancelInvoice(
            int invoiceId,
            int receptionistId,
            string cancellationReason)
        {
            if (invoiceId <= 0)
                return Result.Failure("Mã hóa đơn không hợp lệ.");

            if (receptionistId <= 0)
                return Result.Failure("Nhân viên hủy hóa đơn không hợp lệ.");

            if (string.IsNullOrWhiteSpace(cancellationReason))
                return Result.Failure("Lý do hủy hóa đơn không được để trống.");

            try
            {
                bool success = _dal.CancelInvoice(
                    invoiceId,
                    receptionistId,
                    cancellationReason.Trim());

                return success ? Result.Success("Hủy hóa đơn thành công.") : Result.Failure("Không thể hủy hóa đơn.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hủy hóa đơn: " + (ex.InnerException?.Message ?? ex.Message));
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

        public List<InvoiceDisplayDto> GetAllInvoices(DateTime from, DateTime to, string keyword = "", InvoiceStatus? status = null)
        {
            try
            {
                return _dal.GetAllInvoices(from, to, keyword, status);
            }
            catch
            {
                return new List<InvoiceDisplayDto>();
            }
        }

        public InvoiceDetailDto? GetInvoiceDetail(int invoiceId)
        {
            try
            {
                return _dal.GetInvoiceDetail(invoiceId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<InvoiceDetailItemDto> GetInvoiceDetailItems(int invoiceId)
        {
            try
            {
                return _dal.GetInvoiceDetailItems(invoiceId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<InvoiceDetailItemDto>();
            }
        }

        public bool HasUnpaidInvoice(int visitId)
        {
            return _dal.GetUnpaidInvoiceByVisitId(visitId) != null;
        }
    }
}
