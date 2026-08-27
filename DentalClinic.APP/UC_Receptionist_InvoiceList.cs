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
    public partial class UC_Receptionist_InvoiceList : UserControl
    {
        private readonly Invoice_BLL _bll = new Invoice_BLL();
        private int _selectedInvoiceId = 0;
        public event EventHandler? InvoiceChanged;

        public UC_Receptionist_InvoiceList()
        {
            InitializeComponent();
        }

        private void UC_Receptionist_InvoiceList_Load(object sender, EventArgs e)
        {
            SetupGrid();

            dgvInvoiceList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceList.MultiSelect = false;
            dgvInvoiceList.ReadOnly = true;

            btCancelInvoice.Visible = false;

            dtpStart.Value = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                1);

            dtpEnd.Value = DateTime.Now;

            LoadStatusComboBox();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvInvoiceList.AutoGenerateColumns = false;
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "InvoiceId", HeaderText = "Mã HĐ", Width = 70 });
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "InvoiceDateTime", HeaderText = "Ngày Thu", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Bệnh Nhân", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReceptionistName", HeaderText = "Người Thu", Width = 150 });
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentMethodName", HeaderText = "Hình Thức", Width = 120 });
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "Tổng Tiền", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AmountGiven", HeaderText = "Tiền Khách Đưa", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ChangeAmount", HeaderText = "Tiền Thối", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvInvoiceList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng Thái", Width = 100 });
        }

        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new { Text = "Tất cả", Value = (InvoiceStatus?)null },
                new { Text = "Đã thanh toán", Value = (InvoiceStatus?)InvoiceStatus.Paid },
                new { Text = "Đã hủy", Value = (InvoiceStatus?)InvoiceStatus.Cancelled }
            };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        public void LoadData()
        {
            InvoiceStatus? status = null;

            if (cbStatus.SelectedIndex > 0)
            {
                status = cbStatus.SelectedIndex == 1 ? InvoiceStatus.Paid : InvoiceStatus.Cancelled;
            }

            dgvInvoiceList.DataSource = _bll.GetAllInvoices(dtpStart.Value, dtpEnd.Value, status);
        }

        private void btCancelInvoice_Click(object sender, EventArgs e)
        {
            if (_selectedInvoiceId <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn hóa đơn cần hủy.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy hóa đơn này không?",
                "Xác nhận hủy hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            var result = _bll.CancelInvoice(_selectedInvoiceId);

            if (result.IsSuccess)
            {
                MessageBox.Show(
                    result.Message,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _selectedInvoiceId = 0;
                btCancelInvoice.Visible = false;

                LoadData();

                // Báo cho UC_Receptionist_Invoice reload danh sách chờ thanh toán
                InvoiceChanged?.Invoke(this, EventArgs.Empty);
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

        private void dgvInvoiceList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoiceList.SelectedRows.Count == 0)
            {
                _selectedInvoiceId = 0;
                btCancelInvoice.Visible = false;
                return;
            }

            var row = dgvInvoiceList.SelectedRows[0];

            if (row.DataBoundItem is InvoiceDisplayDto invoice)
            {
                _selectedInvoiceId = invoice.InvoiceId;

                btCancelInvoice.Visible =
                    invoice.Status == "Đã thanh toán";
            }
            else
            {
                _selectedInvoiceId = 0;
                btCancelInvoice.Visible = false;
            }
        }
    }
}
