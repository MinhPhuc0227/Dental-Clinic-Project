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
            
            // Xem
            var viewColumn = new DataGridViewButtonColumn
            {
                Name = "colView",
                HeaderText = "Xem",
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                Width = 65
            };

            dgvInvoiceList.Columns.Add(viewColumn);
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

        private void dgvInvoiceList_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName =
                dgvInvoiceList.Columns[e.ColumnIndex].Name;

            if (columnName != "colView")
                return;

            if (dgvInvoiceList.Rows[e.RowIndex].DataBoundItem
                is not InvoiceDisplayDto invoice)
            {
                return;
            }

            using var detailDialog =
                new Dialog_InvoiceDetail(
                    invoice.InvoiceId,
                    _currentReceptionistId,
                    _currentReceptionistName);

            if (detailDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();

                InvoiceChanged?.Invoke(
                    this,
                    EventArgs.Empty);
            }
        }
    }
}
