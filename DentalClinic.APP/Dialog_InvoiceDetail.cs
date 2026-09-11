using DentalClinic.BLL;
using DentalClinic.DAL;
using DentalClinic.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_InvoiceDetail : Form
    {
        private readonly Invoice_BLL _invoiceBLL;

        private readonly int _invoiceId;
        private readonly int _currentReceptionistId;
        private readonly string _currentReceptionistName;

        private InvoiceDetailDto? _invoice;
        private List<InvoiceDetailItemDto> _items = new List<InvoiceDetailItemDto>();

        private readonly PrintDocument _printDocument = new PrintDocument();

        public Dialog_InvoiceDetail(
            Invoice_BLL invoiceBLL,
            int invoiceId,
            int receptionistId,
            string receptionistName)
        {
            InitializeComponent();

            _invoiceBLL = invoiceBLL;
            _invoiceId = invoiceId;
            _currentReceptionistId = receptionistId;
            _currentReceptionistName = receptionistName;

            _printDocument.PrintPage += PrintDocument_PrintPage;
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

                // Hóa đơn chưa thanh toán hoặc đã thanh toán được phép hủy
                btnCancelInvoice.Visible = _invoice.Status == "Đã thanh toán" || _invoice.Status == "Chưa thanh toán";
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

            if (_invoice.Status != "Đã thanh toán" &&
                _invoice.Status != "Chưa thanh toán")
            {
                MessageBox.Show(
                    "Chỉ có thể hủy hóa đơn chưa thanh toán hoặc đã thanh toán.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using var cancelDialog = new Dialog_CancelInvoice(
                _currentReceptionistName,
                _invoice.TotalAmount);

            if (cancelDialog.ShowDialog(this) != DialogResult.OK)
                return;

            string confirmMessage =
                $"Bạn có chắc chắn muốn hủy hóa đơn #{_invoice.InvoiceId}?\n\n" +
                "Hóa đơn sẽ được hủy và ca khám sẽ kết thúc.";

            if (_invoice.Status == "Đã thanh toán")
            {
                confirmMessage +=
                    "\n\nThuốc đã xuất trong hóa đơn sẽ được hoàn lại tồn kho.";
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

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnPrinInvoice_Click(object sender, EventArgs e)
        {
            if (_invoice == null)
            {
                MessageBox.Show(
                    "Không có dữ liệu hóa đơn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using var printDialog = new PrintDialog
            {
                Document = _printDocument,
                AllowSomePages = false,
                AllowSelection = false,
                UseEXDialog = true
            };

            if (printDialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _printDocument.Print();

                // Đưa Dialog_InvoiceDetail trở lại phía trước
                this.WindowState = FormWindowState.Normal;
                this.Show();
                this.BringToFront();
                this.Activate();
                this.Focus();

                MessageBox.Show(
                    "In hóa đơn thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Sau khi đóng MessageBox vẫn giữ form phía trước
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                this.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi in hóa đơn:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                this.Activate();
            }
        }

        // VẼ HÓA ĐƠN

        private void DrawText(Graphics g, string text, Font font, float x, float y)
        {
            g.DrawString(text ?? "", font, Brushes.Black, x, y);
        }

        private void DrawTextRight(Graphics g, string text, Font font, float x, float y)
        {
            SizeF size = g.MeasureString(text ?? "", font);
            g.DrawString(text ?? "", font, Brushes.Black, x - size.Width, y);
        }

        private void DrawCenteredText(Graphics g, string text, Font font, float centerX, float y)
        {
            SizeF size = g.MeasureString(text ?? "", font);
            g.DrawString(text ?? "", font, Brushes.Black, centerX - size.Width / 2, y);
        }

        private void DrawSectionTitle(Graphics g, string text, Font font, float x, float right, ref float y)
        {
            g.DrawString(text, font, Brushes.Black, x, y);
            y += 6;
            g.DrawLine(Pens.Black, x, y, right, y);
            y += 3;
        }

        private void DrawLabelValue(Graphics g, string label, string value, Font font, float x, ref float y)
        {
            const float labelWidth = 32;

            g.DrawString(label + ":", font, Brushes.Black, x, y);
            g.DrawString(value ?? "", font, Brushes.Black, x + labelWidth, y);
            y += 6;
        }

        private void DrawRightLabelValue(Graphics g, string label, string value, Font font, float left, float right, ref float y)
        {
            float labelX = 125;
            float valueX = 195;

            DrawTextRight(g, label, font, labelX, y);
            DrawTextRight(g, value, font, valueX, y);
            y += 7;
        }

        private void DrawCenteredInRect(Graphics g, string text, Font font, RectangleF rect)
        {
            SizeF size = g.MeasureString(text ?? "", font);
            float x = rect.X + (rect.Width - size.Width) / 2;
            float y = rect.Y + (rect.Height - size.Height) / 2;

            g.DrawString(text ?? "", font, Brushes.Black, x, y);
        }

        private void DrawRightInRect(Graphics g, string text, Font font, RectangleF rect)
        {
            SizeF size = g.MeasureString(text ?? "", font);
            float x = rect.Right - size.Width;
            float y = rect.Y + (rect.Height - size.Height) / 2;

            g.DrawString(text ?? "", font, Brushes.Black, x, y);
        }

        private void DrawTextInRect(Graphics g, string text, Font font, RectangleF rect)
        {
            using StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };

            g.DrawString(text ?? "", font, Brushes.Black, rect, format);
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_invoice == null) return;

            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            float left = 15;
            float right = 195;
            float top = 12;
            float contentWidth = right - left;

            using Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            using Font invoiceTitleFont = new Font("Arial", 13, FontStyle.Bold);
            using Font sectionFont = new Font("Arial", 10, FontStyle.Bold);
            using Font normalFont = new Font("Arial", 9);
            using Font boldFont = new Font("Arial", 9, FontStyle.Bold);
            using Font totalFont = new Font("Arial", 11, FontStyle.Bold);
            using Pen linePen = new Pen(Color.Black, 0.5f);

            float y = top;

            // HEADER
            DrawCenteredText(g, "DENTAL CLINIC", titleFont, 105, y);
            y += 8;

            DrawCenteredText(g, "HÓA ĐƠN THANH TOÁN", invoiceTitleFont, 105, y);
            y += 8;

            DrawCenteredText(g, "---------------------------------------------", normalFont, 105, y);
            y += 6;

            // THÔNG TIN HÓA ĐƠN
            DrawText(g, $"Mã hóa đơn: #{_invoice.InvoiceId}", normalFont, left, y);
            DrawTextRight(g, $"Ngày lập: {_invoice.InvoiceDateTime:dd/MM/yyyy HH:mm}", normalFont, right, y);
            y += 6;

            DrawText(g, $"Trạng thái: {_invoice.Status}", normalFont, left, y);
            y += 9;

            // THÔNG TIN BỆNH NHÂN
            DrawSectionTitle(g, "THÔNG TIN BỆNH NHÂN", sectionFont, left, right, ref y);
            DrawLabelValue(g, "Họ tên", _invoice.PatientName, normalFont, left, ref y);
            DrawLabelValue(g, "Số điện thoại", _invoice.PatientPhone, normalFont, left, ref y);
            DrawLabelValue(g, "Ngày sinh", _invoice.PatientDateOfBirth.ToString("dd/MM/yyyy"), normalFont, left, ref y);
            DrawLabelValue(g, "Địa chỉ", string.IsNullOrWhiteSpace(_invoice.PatientAddress) ? "Không có" : _invoice.PatientAddress, normalFont, left, ref y);
            y += 3;

            // THÔNG TIN KHÁM
            DrawSectionTitle(g, "THÔNG TIN KHÁM", sectionFont, left, right, ref y);
            DrawLabelValue(g, "Bác sĩ", _invoice.DoctorName, normalFont, left, ref y);
            DrawLabelValue(g, "Ngày khám", _invoice.ExaminationDateTime.HasValue ? _invoice.ExaminationDateTime.Value.ToString("dd/MM/yyyy HH:mm") : "Không có", normalFont, left, ref y);
            DrawLabelValue(g, "Lý do khám", string.IsNullOrWhiteSpace(_invoice.ReasonForVisit) ? "Không có" : _invoice.ReasonForVisit, normalFont, left, ref y);
            DrawLabelValue(g, "Chẩn đoán", string.IsNullOrWhiteSpace(_invoice.Diagnosis) ? "Không có" : _invoice.Diagnosis, normalFont, left, ref y);
            DrawLabelValue(g, "Kết luận", string.IsNullOrWhiteSpace(_invoice.Conclusion) ? "Không có" : _invoice.Conclusion, normalFont, left, ref y);
            y += 4;

            // CHI TIẾT HÓA ĐƠN
            DrawSectionTitle(g, "CHI TIẾT HÓA ĐƠN", sectionFont, left, right, ref y);

            float xStt = left;
            float xName = left + 10;
            float xQty = left + 105;
            float xPrice = left + 117;
            float xTotal = left + 147;

            float wStt = 10;
            float wName = 95;
            float wQty = 12;
            float wPrice = 30;
            float wTotal = 33;
            float headerHeight = 9;

            using Brush headerBrush = new SolidBrush(Color.FromArgb(235, 235, 235));

            g.FillRectangle(headerBrush, left, y, contentWidth, headerHeight);
            g.DrawRectangle(linePen, left, y, contentWidth, headerHeight);

            DrawCenteredInRect(g, "STT", boldFont, new RectangleF(xStt, y, wStt, headerHeight));
            DrawCenteredInRect(g, "Nội dung", boldFont, new RectangleF(xName, y, wName, headerHeight));
            DrawCenteredInRect(g, "SL", boldFont, new RectangleF(xQty, y, wQty, headerHeight));
            DrawCenteredInRect(g, "Đơn giá", boldFont, new RectangleF(xPrice, y, wPrice, headerHeight));
            DrawCenteredInRect(g, "Thành tiền", boldFont, new RectangleF(xTotal, y, wTotal, headerHeight));

            y += headerHeight;

            // ITEMS
            int stt = 1;

            foreach (var item in _items)
            {
                float rowHeight = 10;

                g.DrawRectangle(linePen, left, y, contentWidth, rowHeight);

                DrawCenteredInRect(g, stt.ToString(), normalFont, new RectangleF(xStt, y, wStt, rowHeight));

                string itemName = $"{item.ItemName} ({item.ItemType})";
                DrawTextInRect(g, itemName, normalFont, new RectangleF(xName + 1, y + 1, wName - 2, rowHeight - 2));

                DrawCenteredInRect(g, item.Quantity.ToString(), normalFont, new RectangleF(xQty, y, wQty, rowHeight));

                DrawRightInRect(g, item.UnitPrice.ToString("N0"), normalFont, new RectangleF(xPrice, y, wPrice - 1, rowHeight));

                DrawRightInRect(g, item.TotalAmount.ToString("N0"), normalFont, new RectangleF(xTotal, y, wTotal - 1, rowHeight));

                y += rowHeight;
                stt++;

                if (item.ItemType == "Thuốc" && !string.IsNullOrWhiteSpace(item.Instruction))
                {
                    float instructionHeight = 8;

                    g.DrawRectangle(linePen, left, y, contentWidth, instructionHeight);
                    DrawTextInRect(g, $"Cách dùng: {item.Instruction}", normalFont, new RectangleF(xName + 1, y + 1, contentWidth - 2, instructionHeight - 2));

                    y += instructionHeight;
                }

                if (item.ItemType == "Dịch vụ" && !string.IsNullOrWhiteSpace(item.Note))
                {
                    float noteHeight = 8;

                    g.DrawRectangle(linePen, left, y, contentWidth, noteHeight);
                    DrawTextInRect(g, $"Ghi chú: {item.Note}", normalFont, new RectangleF(xName + 1, y + 1, contentWidth - 2, noteHeight - 2));

                    y += noteHeight;
                }
            }

            y += 6;

            // TỔNG TIỀN
            DrawRightLabelValue(g, "Tạm tính:", _invoice.TotalAmount.ToString("N0") + " VNĐ", normalFont, left, right, ref y);
            y += 2;

            DrawRightLabelValue(g, "TỔNG CỘNG:", _invoice.TotalAmount.ToString("N0") + " VNĐ", totalFont, left, right, ref y);
            y += 5;

            // THANH TOÁN
            DrawSectionTitle(g, "THÔNG TIN THANH TOÁN", sectionFont, left, right, ref y);
            DrawLabelValue(g, "Phương thức", _invoice.PaymentMethodName, normalFont, left, ref y);
            DrawLabelValue(g, "Tiền khách đưa", _invoice.AmountGiven.ToString("N0") + " VNĐ", normalFont, left, ref y);
            DrawLabelValue(g, "Tiền thối", _invoice.ChangeAmount.ToString("N0") + " VNĐ", normalFont, left, ref y);

            // THÔNG TIN HỦY
            if (_invoice.Status == "Đã hủy")
            {
                y += 4;

                DrawSectionTitle(g, "THÔNG TIN HỦY", sectionFont, left, right, ref y);
                DrawLabelValue(g, "Lý do hủy", string.IsNullOrWhiteSpace(_invoice.CancellationReason) ? "Không có" : _invoice.CancellationReason, normalFont, left, ref y);
                DrawLabelValue(g, "Ngày hủy", _invoice.CancelledDate.HasValue ? _invoice.CancelledDate.Value.ToString("dd/MM/yyyy HH:mm") : "Không có", normalFont, left, ref y);
                DrawLabelValue(g, "Người hủy", string.IsNullOrWhiteSpace(_invoice.CancelledByName) ? "Không có" : _invoice.CancelledByName, normalFont, left, ref y);
            }

            // FOOTER
            y += 8;

            g.DrawLine(linePen, left, y, right, y);
            y += 6;

            DrawCenteredText(g, "Cảm ơn quý khách đã sử dụng dịch vụ!", boldFont, 105, y);
            y += 6;

            DrawCenteredText(g, $"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm}", normalFont, 105, y);

            e.HasMorePages = false;
        }
    }
}