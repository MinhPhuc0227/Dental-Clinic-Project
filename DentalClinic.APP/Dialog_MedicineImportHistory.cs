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
    public partial class Dialog_MedicineImportHistory : Form
    {
        // BLL 
        private readonly MedicineImport_BLL _importBLL;
        private readonly Supplier_BLL _supplierBLL;

        public Dialog_MedicineImportHistory(
    MedicineImport_BLL importBLL,
    Supplier_BLL supplierBLL)
        {
            InitializeComponent();

            _importBLL = importBLL;
            _supplierBLL = supplierBLL;
        }

        private void Dialog_MedicineImportHistory_Load(
    object sender,
    EventArgs e)
        {
            dtpStart.Value =
                DateTime.Today.AddMonths(-1);

            dtpEnd.Value =
                DateTime.Today;

            SetupImportGrid();
            SetupDetailGrid();

            LoadSuppliers();
            LoadHistory();

            txtSearch.TextChanged +=
                txtSearch_TextChanged;

            dtpStart.ValueChanged +=
                dtpStart_ValueChanged;

            dtpEnd.ValueChanged +=
                dtpEnd_ValueChanged;

            cbSupplier.SelectedIndexChanged +=
                cbSupplier_SelectedIndexChanged;
        }

        private void LoadSuppliers()
        {
            var result =
                _supplierBLL.GetAll();

            if (!result.IsSuccess ||
                result.Data == null)
            {
                return;
            }

            var suppliers =
                new List<SupplierDto>();

            suppliers.Add(
                new SupplierDto
                {
                    SupplierId = 0,
                    SupplierName = "Tất cả"
                });

            suppliers.AddRange(
                result.Data);

            cbSupplier.DataSource =
                suppliers;

            cbSupplier.DisplayMember =
                "SupplierName";

            cbSupplier.ValueMember =
                "SupplierId";

            cbSupplier.SelectedIndex = 0;
        }

        private void SetupImportGrid()
        {
            dgvImportHistory.AutoGenerateColumns =
                false;

            dgvImportHistory.Columns.Clear();

            dgvImportHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "MedicineImportId",

                    HeaderText =
                        "Mã",

                    Width = 70
                });

            dgvImportHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "ImportDate",

                    HeaderText =
                        "Ngày nhập",

                    Width = 130,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format =
                                "dd/MM/yyyy HH:mm"
                        }
                });

            dgvImportHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "SupplierName",

                    HeaderText =
                        "Nhà cung cấp",

                    Width = 160
                });

            dgvImportHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "TotalAmount",

                    HeaderText =
                        "Tổng tiền",

                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "N0",
                            Alignment =
                                DataGridViewContentAlignment.MiddleRight
                        }
                });

            dgvImportHistory.ReadOnly = true;

            dgvImportHistory.AllowUserToAddRows =
                false;

            dgvImportHistory.RowHeadersVisible =
                false;

            dgvImportHistory.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvImportHistory.MultiSelect =
                false;
        }

        private void LoadHistory()
        {
            int? supplierId = null;

            if (cbSupplier.SelectedValue is int id &&
                id > 0)
            {
                supplierId = id;
            }

            var result =
                _importBLL.GetHistory(
                    dtpStart.Value,
                    dtpEnd.Value,
                    supplierId,
                    txtSearch.Text.Trim());

            if (result.IsSuccess)
            {
                dgvImportHistory.DataSource =
                    result.Data;
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

        private void txtSearch_TextChanged(
    object sender,
    EventArgs e)
        {
            LoadHistory();
        }

        private void dtpStart_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
                LoadHistory();
        }

        private void dtpEnd_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
                LoadHistory();
        }

        private void cbSupplier_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
                LoadHistory();
        }

        private void SetupDetailGrid()
        {
            dgvImportDetail.AutoGenerateColumns =
                false;

            dgvImportDetail.Columns.Clear();

            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "MedicineName",

                    HeaderText =
                        "Tên thuốc",

                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "Unit",

                    HeaderText =
                        "Đơn vị",

                    Width = 70
                });

            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "Quantity",

                    HeaderText =
                        "SL nhập",

                    Width = 75
                });

            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "UnitImportPrice",

                    HeaderText =
                        "Giá nhập",

                    Width = 100,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "N0",
                            Alignment =
                                DataGridViewContentAlignment.MiddleRight
                        }
                });

            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "TotalAmount",

                    HeaderText =
                        "Thành tiền",

                    Width = 120,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "N0",
                            Alignment =
                                DataGridViewContentAlignment.MiddleRight
                        }
                });

            dgvImportDetail.ReadOnly = true;

            dgvImportDetail.AllowUserToAddRows =
                false;

            dgvImportDetail.RowHeadersVisible =
                false;
        }

        private void dgvImportHistory_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvImportHistory.Rows[e.RowIndex]
                .DataBoundItem
                is not MedicineImportListDto import)
            {
                return;
            }

            LoadImportDetail(
                import.MedicineImportId);
        }

        private void LoadImportDetail(
    int importId)
        {
            var result =
                _importBLL.GetDetail(
                    importId);

            if (!result.IsSuccess ||
                result.Data == null)
            {
                MessageBox.Show(
                    result.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var detail =
                result.Data;

            lbImportDate.Text =
                detail.ImportDate
                    .ToString(
                        "dd/MM/yyyy HH:mm");

            lbSupplier.Text =
                detail.SupplierName;

            lbAccount.Text =
                detail.UserName;

            txtNote.Text =
                string.IsNullOrWhiteSpace(
                    detail.Note)
                    ? "Không có"
                    : detail.Note;

            lbTotalAmount.Text =
                detail.TotalAmount.ToString("N0")
                + " VNĐ";

            lbPaymentMethod.Text =
                detail.PaymentMethodName;

            dgvImportDetail.DataSource =
                detail.Items;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
