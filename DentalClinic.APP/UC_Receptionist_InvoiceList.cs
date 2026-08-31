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
        private readonly int _currentReceptionistId;
        private readonly string _currentReceptionistName;
        public event EventHandler? InvoiceChanged;

        public UC_Receptionist_InvoiceList(int receptionistId, string receptionistName)
        {
            InitializeComponent();
            _currentReceptionistId = receptionistId;
            _currentReceptionistName = receptionistName;
        }

        private void UC_Receptionist_InvoiceList_Load(object sender, EventArgs e)
        {
            SetupGrid();

            dgvInvoiceList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceList.MultiSelect = false;
            dgvInvoiceList.ReadOnly = true;

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
            var cancelColumn = new DataGridViewButtonColumn
            {
                Name = "colCancel",
                HeaderText = "Thao tác",
                Text = "Hủy",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };

            cancelColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvInvoiceList.Columns.Add(cancelColumn);
        }

        private void LoadStatusComboBox()
        {
            var statusList = new[]
    {
        new
        {
            Text = "Tất cả",
            Value = (InvoiceStatus?)null
        },

        new
        {
            Text = "Chưa thanh toán",
            Value = (InvoiceStatus?)InvoiceStatus.Unpaid
        },

        new
        {
            Text = "Đã thanh toán",
            Value = (InvoiceStatus?)InvoiceStatus.Paid
        },

        new
        {
            Text = "Đã hủy",
            Value = (InvoiceStatus?)InvoiceStatus.Cancelled
        }
    };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        public void LoadData()
        {
            InvoiceStatus? status = null;

            if (cbStatus.SelectedIndex == 1)
                status = InvoiceStatus.Unpaid;
            else if (cbStatus.SelectedIndex == 2)
                status = InvoiceStatus.Paid;
            else if (cbStatus.SelectedIndex == 3)
                status = InvoiceStatus.Cancelled;

            dgvInvoiceList.DataSource =
                _bll.GetAllInvoices(
                    dtpStart.Value,
                    dtpEnd.Value,
                    status);
        }

        private void dgvInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvInvoiceList.Columns[e.ColumnIndex].Name
                != "colCancel")
                return;

            if (dgvInvoiceList.Rows[e.RowIndex].DataBoundItem
                is not InvoiceDisplayDto invoice)
                return;

            // Chỉ cho hủy hóa đơn Paid
            if (invoice.Status != "Đã thanh toán")
            {
                MessageBox.Show(
                    "Chỉ có thể hủy hóa đơn đã thanh toán.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Mở Dialog
            using var dialog =
                new Dialog_CancelInvoice(
                    _currentReceptionistName,
                    invoice.TotalAmount);

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            // Xác nhận lần cuối
            string confirmMessage;

            if (dialog.RequiresMedicalRecordUpdate)
            {
                confirmMessage =
                    $"Hủy hóa đơn #{invoice.InvoiceId}?\n\n" +
                    $"Số tiền hoàn: {invoice.TotalAmount:N0} VNĐ\n\n" +
                    "Bệnh nhân sẽ quay lại bác sĩ để " +
                    "thay đổi thuốc/dịch vụ.\n" +
                    "Sau khi MedicalRecord được cập nhật, " +
                    "hóa đơn mới sẽ được tạo.";
            }
            else
            {
                confirmMessage =
                    $"Hủy hóa đơn #{invoice.InvoiceId}?\n\n" +
                    $"Số tiền hoàn: {invoice.TotalAmount:N0} VNĐ\n\n" +
                    "Hóa đơn sẽ được hủy hoàn toàn " +
                    "và không tạo hóa đơn mới.";
            }

            var confirm = MessageBox.Show(
                confirmMessage,
                "Xác nhận hủy hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            // Gọi BLL
            var result = _bll.CancelInvoice(
                invoice.InvoiceId,
                _currentReceptionistId,
                dialog.CancellationReason);

            if (result.IsSuccess)
            {
                MessageBox.Show(
                    result.Message,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();

                InvoiceChanged?.Invoke(
                    this,
                    EventArgs.Empty);
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
    }
}
