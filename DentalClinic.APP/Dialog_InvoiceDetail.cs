using DentalClinic.BLL;
using DentalClinic.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_InvoiceDetail : Form
    {
        private readonly Invoice_BLL _invoiceBLL = new Invoice_BLL();

        private readonly int _invoiceId;
        private readonly int _currentReceptionistId;
        private readonly string _currentReceptionistName;

        private InvoiceDetailDto? _invoice;
        private List<InvoiceDetailItemDto> _items =
            new List<InvoiceDetailItemDto>();

        public Dialog_InvoiceDetail(
    int invoiceId,
    int receptionistId,
    string receptionistName)
        {
            InitializeComponent();

            _invoiceId = invoiceId;
            _currentReceptionistId = receptionistId;
            _currentReceptionistName = receptionistName;

            StartPosition = FormStartPosition.CenterParent;
        }

        private void Dialog_InvoiceDetail_Load(
            object sender,
            EventArgs e)
        {
            SetupGrid();
            LoadInvoice();
        }

        private void SetupGrid()
        {
            dgvInvoiceDetail.AutoGenerateColumns = false;
            dgvInvoiceDetail.Columns.Clear();

            dgvInvoiceDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ItemType",
                    HeaderText = "Loại",
                    Width = 100
                });

            dgvInvoiceDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ItemName",
                    HeaderText = "Tên thuốc / dịch vụ",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            dgvInvoiceDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "SL",
                    Width = 60
                });

            dgvInvoiceDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "UnitPrice",
                    HeaderText = "Đơn giá",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "N0",
                        Alignment =
                            DataGridViewContentAlignment.MiddleRight
                    }
                });

            dgvInvoiceDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TotalAmount",
                    HeaderText = "Thành tiền",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "N0",
                        Alignment =
                            DataGridViewContentAlignment.MiddleRight
                    }
                });

            dgvInvoiceDetail.ReadOnly = true;
            dgvInvoiceDetail.AllowUserToAddRows = false;
            dgvInvoiceDetail.RowHeadersVisible = false;
            dgvInvoiceDetail.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadInvoice()
        {
            try
            {
                _invoice =
                    _invoiceBLL.GetInvoiceDetail(_invoiceId);

                if (_invoice == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy hóa đơn.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Close();
                    return;
                }

                // Invoice
                lbInvoiceId.Text =
                    _invoice.InvoiceId.ToString();

                lbInvoiceDate.Text =
                    _invoice.InvoiceDateTime
                        .ToString("dd/MM/yyyy HH:mm");

                lbInvoiceStatus.Text =
                    _invoice.Status;

                lbInvoiceReceptionist.Text =
                    _invoice.ReceptionistName;

                // Patient
                lbPatientId.Text =
                    _invoice.PatientId.ToString();

                lbPatientName.Text =
                    _invoice.PatientName;

                lbPatientPhone.Text =
                    _invoice.PatientPhone;

                lbPatientDateOfBirth.Text =
                    _invoice.PatientDateOfBirth
                        .ToString("dd/MM/yyyy");

                txtPatientAddress.Text =
                    string.IsNullOrWhiteSpace(
                        _invoice.PatientAddress)
                        ? "Không có"
                        : _invoice.PatientAddress;

                // Visit
                lbVisitId.Text =
                    _invoice.VisitId.ToString();

                lbExaminationDate.Text =
                    _invoice.ExaminationDateTime.HasValue
                        ? _invoice.ExaminationDateTime
                            .Value.ToString("dd/MM/yyyy HH:mm")
                        : "Không có";

                lbDoctorName.Text =
                    _invoice.DoctorName;

                lbDiagnosis.Text =
                    string.IsNullOrWhiteSpace(
                        _invoice.Diagnosis)
                        ? "Không có"
                        : _invoice.Diagnosis;

                txtConclusion.Text =
                    string.IsNullOrWhiteSpace(
                        _invoice.Conclusion)
                        ? "Không có"
                        : _invoice.Conclusion;

                // Payment
                lbTotalAmount.Text =
                    _invoice.TotalAmount.ToString("N0")
                    + " VNĐ";

                lbAmountGiven.Text =
                    _invoice.AmountGiven.ToString("N0")
                    + " VNĐ";

                lbChangeAmount.Text =
                    _invoice.ChangeAmount.ToString("N0")
                    + " VNĐ";

                lbPaymentMethod.Text =
                    _invoice.PaymentMethodName;

                // Cancellation
                bool isCancelled =
                    _invoice.Status == "Đã hủy";

                lbCancellationReason.Visible = isCancelled;
                lbCancelledDate.Visible = isCancelled;
                lbCancelledBy.Visible = isCancelled;

                if (isCancelled)
                {
                    lbCancellationReason.Text =
                        string.IsNullOrWhiteSpace(
                            _invoice.CancellationReason)
                            ? "Không có"
                            : _invoice.CancellationReason;

                    lbCancelledDate.Text =
                        _invoice.CancelledDate.HasValue
                            ? _invoice.CancelledDate
                                .Value.ToString("dd/MM/yyyy HH:mm")
                            : "Không có";

                    lbCancelledBy.Text =
                        string.IsNullOrWhiteSpace(
                            _invoice.CancelledByName)
                            ? "Không có"
                            : _invoice.CancelledByName;
                }

                // Load items
                _items =
                    _invoiceBLL.GetInvoiceDetailItems(
                        _invoiceId);

                dgvInvoiceDetail.DataSource = _items;

                // Chỉ hóa đơn Paid mới được hủy
                btnCancelInvoice.Visible =
                    _invoice.Status == "Đã thanh toán";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải chi tiết hóa đơn:\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelInvoice_Click(object sender, EventArgs e)
        {
            if (_invoice == null)
                return;

            if (_invoice.Status != "Đã thanh toán")
            {
                MessageBox.Show(
                    "Chỉ có thể hủy hóa đơn đã thanh toán.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using var cancelDialog =
                new Dialog_CancelInvoice(
                    _currentReceptionistName,
                    _invoice.TotalAmount);

            if (cancelDialog.ShowDialog(this) != DialogResult.OK)
                return;

            string confirmMessage;

            if (cancelDialog.RequiresMedicalRecordUpdate)
            {
                confirmMessage =
                    $"Bạn có chắc chắn muốn hủy hóa đơn #{_invoice.InvoiceId}?\n\n" +
                    $"Số tiền hoàn: {_invoice.TotalAmount:N0} VNĐ\n\n" +
                    "Bệnh nhân sẽ được tiếp nhận lại để khám và lập hóa đơn mới.";
            }
            else
            {
                confirmMessage =
                    $"Bạn có chắc chắn muốn hủy hóa đơn #{_invoice.InvoiceId}?\n\n" +
                    $"Số tiền hoàn: {_invoice.TotalAmount:N0} VNĐ\n\n" +
                    "Hóa đơn sẽ được hủy hoàn toàn.";
            }

            var confirm = MessageBox.Show(
                confirmMessage,
                "Xác nhận hủy hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            var result = _invoiceBLL.CancelInvoice(
                _invoice.InvoiceId,
                _currentReceptionistId,
                cancelDialog.CancellationReason);

            if (!result.IsSuccess)
            {
                MessageBox.Show(
                    result.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                result.Message,
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Báo cho form cha biết dữ liệu đã thay đổi
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
