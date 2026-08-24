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
        private int _currentVisitId = 0;
        private readonly int _currentReceptionistId;
        private readonly Invoice_BLL _invoiceBLL = new Invoice_BLL();

        public UC_Receptionist_Invoice(int receptionistId)
        {
            InitializeComponent();
            _currentReceptionistId = receptionistId;
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

            dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VisitId", Visible = false });
            dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Bệnh Nhân", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            //dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CheckInDateTime", HeaderText = "Giờ", Width = 60, DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" } });
            dgvWaitingList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CompletedTime",
                HeaderText = "Giờ ra", // Đổi tên hiển thị cho rõ nghĩa
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
            _currentVisitId = 0;
        }

        private void dgvWaitingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvWaitingList.Rows[e.RowIndex].DataBoundItem is WaitingPaymentDto selectedPatient)
                {
                    _currentVisitId = selectedPatient.VisitId;

                    // Load thông tin lên các Label
                    lbPatientName.Text = selectedPatient.PatientName;
                    lbPhone.Text = selectedPatient.Phone;
                    lbDoctorName.Text = selectedPatient.DoctorName;

                    // Load chi tiết dịch vụ + thuốc
                    _currentInvoiceDetails = _invoiceBLL.GetInvoiceDetails(_currentVisitId);

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
            if (_currentVisitId == 0 || _currentInvoiceDetails.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbPaymentMethod.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số tiền nhập (nếu chọn thanh toán bằng tiền mặt)
            decimal totalAmount = GetTotalAmountFromLabel();
            string rawGiven = txtAmountGiven.Text.Replace(",", "");
            decimal.TryParse(rawGiven, out decimal givenAmount);

            if (givenAmount < totalAmount)
            {
                MessageBox.Show("Số tiền khách đưa chưa đủ để thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountGiven.Focus();
                return;
            }

            var confirm = MessageBox.Show($"Xác nhận thanh toán hóa đơn với tổng tiền: {lbTotalAmount.Text} VNĐ?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int paymentMethodId = (int)cbPaymentMethod.SelectedValue;
                int currentReceptionistId = _currentReceptionistId;

                // Tính lại tổng tiền 
                totalAmount = 0;
                foreach (var item in _currentInvoiceDetails) totalAmount += item.TotalAmount;

                // Lấy giá trị tiền khách đưa và tiền trả khách từ giao diện
                decimal amountGiven = string.IsNullOrEmpty(txtAmountGiven.Text) ? 0 : decimal.Parse(txtAmountGiven.Text.Replace(",", ""));
                decimal changeAmount = string.IsNullOrEmpty(txtChange.Text) ? 0 : decimal.Parse(txtChange.Text.Replace(",", ""));

                // Gọi BLL lưu hóa đơn 
                var result = _invoiceBLL.Checkout(_currentVisitId, paymentMethodId, currentReceptionistId, totalAmount, amountGiven, changeAmount, _currentInvoiceDetails);

                if (result.IsSuccess)
                {
                    MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset giao diện
                    ClearPatientInfo();
                    LoadWaitingList();
                    txtSearch.Clear();
                }
                else
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
