using DentalClinic.BLL;
using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class UC_Receptionist_Invoice : UserControl
    {
        // Danh sách lưu tạm chi tiết hóa đơn đang hiển thị
        private int _selectedPaymentMethodId = 0;
        private List<InvoiceDetailDisplayDto> _currentInvoiceDetails = new List<InvoiceDetailDisplayDto>();
        private int _currentInvoiceId = 0;
        private int _currentVisitId = 0;
        private readonly int _currentReceptionistId;
        private readonly string _currentReceptionistName;
        private readonly Invoice_BLL _invoiceBLL;

        public UC_Receptionist_Invoice(int receptionistId, string receptionistName, Invoice_BLL invoiceBLL)
        {
            InitializeComponent();
            _invoiceBLL = invoiceBLL;

            _currentReceptionistId = receptionistId;
            _currentReceptionistName = receptionistName;
        }

        private void UC_Receptionist_Invoice_Load(object sender, EventArgs e)
        {
            SetupWaitingGrid();
            SetupInvoiceDetailGrid();
            ClearPatientInfo();
            LoadPaymentMethods();

            DateTime today = DateTime.Today;
            dtpStart.Value = today;
            dtpEnd.Value = today;

            LoadWaitingList();
        }

        private void LoadPaymentMethods()
        {
            var methods = _invoiceBLL.GetPaymentMethods();

            cbPaymentMethod.DataSource = null;

            cbPaymentMethod.DisplayMember = "PaymentMethodName";
            cbPaymentMethod.ValueMember = "PaymentMethodId";
            cbPaymentMethod.DataSource = methods;

            if (methods.Count > 0)
            {
                cbPaymentMethod.SelectedIndex = 0;

                if (cbPaymentMethod.SelectedItem is PaymentMethodDto selectedMethod)
                {
                    _selectedPaymentMethodId =
                        selectedMethod.PaymentMethodId;
                }
            }
        }

        // Load dữ liệu lên dgvWaitingList
        public void LoadWaitingList()
        {
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;
            string keyword = txtSearch.Text.Trim();

            var waitingList = _invoiceBLL.GetWaitingPayments(
                startDate,
                endDate,
                keyword);

            dgvWaitingList.DataSource = waitingList;
        }

        // Hàm tính tổng tiền 
        private void CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in _currentInvoiceDetails)
            {
                total += item.TotalAmount;
            }
            lbTotalAmount.Text = total.ToString("N0");
        }

        private void SetupWaitingGrid()
        {
            dgvWaitingList.AutoGenerateColumns = false;
            dgvWaitingList.Columns.Clear();

            // Invoice ID
            dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceId",
                HeaderText = "Mã HĐ",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VisitId", Visible = false });
            dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Bệnh Nhân", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            //dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CheckInDateTime", HeaderText = "Giờ", Width = 60, DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" } });
            dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceDateTime",
                HeaderText = "Giờ tạo HĐ",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" }
            });

            dgvWaitingList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWaitingList.ReadOnly = true;
            dgvWaitingList.RowHeadersVisible = false;
            dgvWaitingList.AllowUserToAddRows = false;
        }

        private void SetupInvoiceDetailGrid()
        {
            dgvInvoiceDetail.AutoGenerateColumns = false;
            dgvInvoiceDetail.Columns.Clear();

            dgvInvoiceDetail.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ItemType", HeaderText = "Loại", Width = 80 });
            dgvInvoiceDetail.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ItemName", HeaderText = "Tên Dịch Vụ / Thuốc", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvInvoiceDetail.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 50, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvInvoiceDetail.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn Giá", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvInvoiceDetail.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "Thành Tiền", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });

            dgvInvoiceDetail.ReadOnly = true;
            dgvInvoiceDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceDetail.RowHeadersVisible = false;
            dgvInvoiceDetail.AllowUserToAddRows = false;
        }

        private void ClearPatientInfo()
        {
            lbPatientName.Text = "...";
            lbPhone.Text = "...";
            lbDoctorName.Text = "...";
            lbTotalAmount.Text = "0";

            _currentInvoiceDetails.Clear();
            dgvInvoiceDetail.DataSource = null;

            _currentInvoiceId = 0;
            _currentVisitId = 0;
        }

        private void dgvWaitingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvWaitingList.Rows[e.RowIndex].DataBoundItem is WaitingPaymentDto selectedInvoice)
                {
                    _currentInvoiceId = selectedInvoice.InvoiceId;
                    _currentVisitId = selectedInvoice.VisitId;

                    lbPatientName.Text = selectedInvoice.PatientName;
                    lbPhone.Text = selectedInvoice.Phone;
                    lbDoctorName.Text = selectedInvoice.DoctorName;

                    // Lấy chi tiết từ chính Invoice Unpaid
                    _currentInvoiceDetails =
                        _invoiceBLL.GetInvoiceDetailsByInvoice(
                            _currentInvoiceId);

                    // Load lên dgvInvoiceDetail
                    dgvInvoiceDetail.DataSource = null;
                    dgvInvoiceDetail.DataSource = _currentInvoiceDetails;

                    // Tính tổng tiền
                    CalculateTotalAmount();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadWaitingList();
        }

        private void btPayment_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra hóa đơn
            if (_currentInvoiceId <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn hóa đơn cần thanh toán!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // 2. Kiểm tra phương thức thanh toán
            if (_selectedPaymentMethodId <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức thanh toán!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // 3. Lấy tổng tiền
            decimal totalAmount = GetTotalAmountFromLabel();

            if (totalAmount <= 0)
            {
                MessageBox.Show(
                    "Tổng tiền hóa đơn không hợp lệ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // 4. Lấy phương thức thanh toán
            var paymentMethods = _invoiceBLL.GetPaymentMethods();

            var paymentMethod = paymentMethods.FirstOrDefault(
                x => x.PaymentMethodId == _selectedPaymentMethodId);

            if (paymentMethod == null)
            {
                MessageBox.Show(
                    "Không tìm thấy phương thức thanh toán!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            decimal amountGiven;
            decimal changeAmount;

            // 5. Xử lý theo phương thức thanh toán
            if (paymentMethod.IsCash)
            {
                // TIỀN MẶT
                if (!decimal.TryParse(
                        txtAmountGiven.Text.Replace(",", "").Trim(),
                        out amountGiven))
                {
                    MessageBox.Show(
                        "Số tiền khách đưa không hợp lệ!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtAmountGiven.Focus();
                    return;
                }

                if (amountGiven <= 0)
                {
                    MessageBox.Show(
                        "Số tiền khách đưa phải lớn hơn 0!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtAmountGiven.Focus();
                    return;
                }

                if (amountGiven < totalAmount)
                {
                    MessageBox.Show(
                        "Số tiền khách đưa chưa đủ để thanh toán!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtAmountGiven.Focus();
                    return;
                }

                changeAmount = amountGiven - totalAmount;
            }
            else
            {
                // CHUYỂN KHOẢN
                amountGiven = totalAmount;
                changeAmount = 0;

                txtAmountGiven.Text = totalAmount.ToString("N0");
                txtChange.Text = "0";
            }

            // 6. Hiển thị tiền trả
            txtChange.Text = changeAmount.ToString("N0");

            // 7. Thanh toán
            var result = _invoiceBLL.Checkout(
    _currentInvoiceId,
    _selectedPaymentMethodId,
    _currentReceptionistId,
    amountGiven,
    changeAmount);

            if (!result.IsSuccess)
            {
                MessageBox.Show(
                    result.Message,
                    "Thanh toán thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // 8. Thanh toán thành công
            var printConfirm = MessageBox.Show(
                "Thanh toán hóa đơn thành công!\n\nBạn có muốn in hóa đơn không?",
                "Thanh toán thành công",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            // 9. Nếu chọn Yes → mở Dialog_InvoiceDetail
            if (printConfirm == DialogResult.Yes)
            {
                using var detailDialog = new Dialog_InvoiceDetail(
                    _invoiceBLL,
                    _currentInvoiceId,
                    _currentReceptionistId,
                    _currentReceptionistName);

                detailDialog.ShowDialog(this);
            }

            // 10. Load lại danh sách
            LoadWaitingList();

            // 11. Reset giao diện
            ClearPatientInfo();

            _selectedPaymentMethodId = 0;

            txtAmountGiven.Text = "0";
            txtChange.Text = "0";

            txtAmountGiven.ReadOnly = false;
            txtAmountGiven.ForeColor = Color.Black;

            if (cbPaymentMethod.Items.Count > 0)
            {
                cbPaymentMethod.SelectedIndex = 0;
            }

            dgvWaitingList.ClearSelection();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (_currentVisitId == 0)
            {
                return;
            }

            var confirm = MessageBox.Show("Bạn muốn hủy thao tác thanh toán cho bệnh nhân này?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                ClearPatientInfo();
                dgvWaitingList.ClearSelection();
            }
        }

        private void cbPaymentMethod_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem is not PaymentMethodDto selectedMethod)
            {
                _selectedPaymentMethodId = 0;
                return;
            }

            _selectedPaymentMethodId =
                selectedMethod.PaymentMethodId;

            decimal totalAmount = GetTotalAmountFromLabel();

            if (selectedMethod.IsCash)
            {
                // Tiền mặt
                txtAmountGiven.ReadOnly = false;
                txtAmountGiven.Clear();
                txtChange.Text = "0";
                txtAmountGiven.ForeColor = Color.Black;
            }
            else
            {
                // Chuyển khoản
                txtAmountGiven.ReadOnly = true;

                txtAmountGiven.Text =
                    totalAmount.ToString("N0");

                txtChange.Text = "0";

                txtAmountGiven.ForeColor = Color.Green;
            }
        }

        private void txtAmountGiven_TextChanged(object sender, EventArgs e)
        {
            // Nếu ô trống thì reset
            if (string.IsNullOrWhiteSpace(txtAmountGiven.Text))
            {
                txtChange.Text = "0";
                txtAmountGiven.ForeColor = Color.Black;
                return;
            }

            // Xóa dấu phẩy để chuyển về số tính toán
            string rawText = txtAmountGiven.Text.Replace(",", "");
            decimal totalAmount = GetTotalAmountFromLabel();

            if (decimal.TryParse(rawText, out decimal amountGiven))
            {
                // Tự động định dạng lại có dấu phẩy 
                txtAmountGiven.TextChanged -= txtAmountGiven_TextChanged;
                txtAmountGiven.Text = amountGiven.ToString("N0");
                txtAmountGiven.SelectionStart = txtAmountGiven.Text.Length;
                txtAmountGiven.TextChanged += txtAmountGiven_TextChanged;

                // Logic tính tiền và đổi màu chữ
                if (amountGiven >= totalAmount)
                {
                    txtAmountGiven.ForeColor = Color.Green;
                    decimal change = amountGiven - totalAmount;
                    txtChange.Text = change.ToString("N0");
                }
                else
                {
                    txtAmountGiven.ForeColor = Color.Red;
                    txtChange.Text = "0";
                }
            }
        }

        // Hàm lấy tổng tiền từ label
        private decimal GetTotalAmountFromLabel()
        {
            string rawTotal = lbTotalAmount.Text.Replace(",", "");
            if (decimal.TryParse(rawTotal, out decimal total))
                return total;
            return 0;
        }

        private void txtAmountGiven_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím Backspace (xóa)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            LoadWaitingList();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadWaitingList();
        }
    }
}
