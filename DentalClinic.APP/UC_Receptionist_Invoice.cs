using DentalClinic.BLL;
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
        private List<InvoiceDetailDisplayDto> _currentInvoiceDetails = new List<InvoiceDetailDisplayDto>();
        private int _currentInvoiceId = 0;
        private int _currentVisitId = 0;
        private readonly int _currentReceptionistId;
        private readonly string _currentReceptionistName;
        private readonly Invoice_BLL _invoiceBLL = new Invoice_BLL();

        public UC_Receptionist_Invoice(int receptionistId, string receptionistName)
        {
            InitializeComponent();

            _currentReceptionistId = receptionistId;
            _currentReceptionistName = receptionistName;
        }

        private void UC_Receptionist_Invoice_Load(object sender, EventArgs e)
        {
            SetupWaitingGrid();
            SetupInvoiceDetailGrid();
            ClearPatientInfo();
            LoadPaymentMethods();
            LoadWaitingList();
        }

        private void LoadPaymentMethods()
        {
            cbPaymentMethod.DataSource = _invoiceBLL.GetPaymentMethods();
            cbPaymentMethod.DisplayMember = "PaymentMethodName";
            cbPaymentMethod.ValueMember = "PaymentMethodId";
        }

        // Load dữ liệu lên dgvWaitingList
        public void LoadWaitingList(string keyword = "")
        {
            var waitingList = _invoiceBLL.GetWaitingPayments(keyword);
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
            LoadWaitingList(txtSearch.Text.Trim());
        }

        private void btPayment_Click(object sender, EventArgs e)
        {
            if (_currentInvoiceId == 0 || _currentInvoiceDetails.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn hóa đơn cần thanh toán!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cbPaymentMethod.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức thanh toán!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Lấy tổng tiền của Invoice
            decimal totalAmount = GetTotalAmountFromLabel();

            // Lấy tiền khách đưa
            string rawGiven = txtAmountGiven.Text.Replace(",", "");

            if (!decimal.TryParse(rawGiven, out decimal givenAmount))
            {
                MessageBox.Show(
                    "Số tiền khách đưa không hợp lệ!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAmountGiven.Focus();
                return;
            }

            // Kiểm tra tiền khách đưa đủ
            if (givenAmount < totalAmount)
            {
                MessageBox.Show(
                    "Số tiền khách đưa chưa đủ để thanh toán!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAmountGiven.Focus();
                return;
            }

            decimal changeAmount = givenAmount - totalAmount;

            var confirm = MessageBox.Show(
                $"Xác nhận thanh toán hóa đơn #{_currentInvoiceId}\n" +
                $"Tổng tiền: {totalAmount:N0} VNĐ?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            int paymentMethodId = (int)cbPaymentMethod.SelectedValue;

            // Thanh toán Invoice Unpaid hiện tại
            var result = _invoiceBLL.Checkout(
                _currentInvoiceId,
                paymentMethodId,
                _currentReceptionistId,
                givenAmount,
                changeAmount);

            if (result.IsSuccess)
            {
                var printConfirm = MessageBox.Show(
                    "Thanh toán hóa đơn thành công!\n\n" +
                    "Bạn có muốn in hóa đơn không?",
                    "Thanh toán thành công",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                // Nếu chọn Yes -> mở chi tiết hóa đơn
                if (printConfirm == DialogResult.Yes)
                {
                    using var dialog = new Dialog_InvoiceDetail(_currentInvoiceId, _currentReceptionistId, _currentReceptionistName);

                    dialog.ShowDialog(this);
                }

                // Reset giao diện sau khi thanh toán
                ClearPatientInfo();
                LoadWaitingList();
                txtSearch.Clear();
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

        private void cbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem is PaymentMethodDto selectedMethod)
            {
                // Tiền mặt
                if (!selectedMethod.IsCash)
                {
                    txtAmountGiven.Text = lbTotalAmount.Text; 
                    txtAmountGiven.ReadOnly = true;         
                    txtChange.Text = "0";
                    txtAmountGiven.ForeColor = Color.Green;
                }
                // Khác
                else
                {
                    txtAmountGiven.ReadOnly = false;         
                    txtAmountGiven.Clear();
                    txtChange.Text = "0";
                    txtAmountGiven.ForeColor = Color.Black;
                    txtAmountGiven.Focus();                   
                }
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
    }
}
