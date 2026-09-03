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
    public partial class UC_Supplier : UserControl
    {
        private readonly Supplier_BLL _supplierBLL;

        public UC_Supplier(Supplier_BLL bll)
        {
            InitializeComponent();

            _supplierBLL = bll;
        }

        private void UC_Supplier_Load(
            object sender,
            EventArgs e)
        {
            SetupGrid();
            LoadStatusComboBox();
            LoadData();

            txtSearch.TextChanged +=
                txtSearch_TextChanged;

            cbStatus.SelectedIndexChanged +=
                cbStatus_SelectedIndexChanged;
        }

        // =========================================================
        // GRID
        // =========================================================

        private void SetupGrid()
        {
            dgvSupplier.AutoGenerateColumns = false;
            dgvSupplier.Columns.Clear();

            dgvSupplier.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SupplierId",
                    HeaderText = "Mã",
                    Width = 60
                });

            dgvSupplier.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SupplierName",
                    HeaderText = "Nhà cung cấp",
                    Width = 200
                });

            dgvSupplier.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Phone",
                    HeaderText = "Số điện thoại",
                    Width = 120
                });

            dgvSupplier.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Address",
                    HeaderText = "Địa chỉ",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            dgvSupplier.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Email",
                    HeaderText = "Email",
                    Width = 180
                });

            dgvSupplier.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StatusText",
                    HeaderText = "Trạng thái",
                    Width = 130
                });

            var editColumn =
                new DataGridViewButtonColumn
                {
                    Name = "colEdit",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true,
                    Width = 65
                };

            dgvSupplier.Columns.Add(
                editColumn);

            var deleteColumn =
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true,
                    Width = 65
                };

            dgvSupplier.Columns.Add(
                deleteColumn);

            dgvSupplier.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvSupplier.MultiSelect = false;

            dgvSupplier.ReadOnly = true;

            dgvSupplier.AllowUserToAddRows = false;

            dgvSupplier.RowHeadersVisible = false;
        }

        // =========================================================
        // STATUS FILTER
        // =========================================================

        private void LoadStatusComboBox()
        {
            var statusList =
                new List<object>
                {
                    new
                    {
                        Value = (bool?)null,
                        Text = "Tất cả"
                    },

                    new
                    {
                        Value = (bool?)true,
                        Text = "Đang hoạt động"
                    },

                    new
                    {
                        Value = (bool?)false,
                        Text = "Ngừng hoạt động"
                    }
                };

            cbStatus.DataSource =
                statusList;

            cbStatus.DisplayMember =
                "Text";

            cbStatus.ValueMember =
                "Value";

            cbStatus.SelectedIndex = 0;
        }

        // =========================================================
        // LOAD DATA
        // =========================================================

        public void LoadData()
        {
            bool? isActive = null;

            if (cbStatus.SelectedIndex == 1)
                isActive = true;

            else if (cbStatus.SelectedIndex == 2)
                isActive = false;

            var result =
                _supplierBLL.GetAll(
                    txtSearch.Text.Trim(),
                    isActive);

            if (result.IsSuccess)
            {
                dgvSupplier.DataSource =
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

        // =========================================================
        // SEARCH
        // =========================================================

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadData();
        }

        // =========================================================
        // FILTER
        // =========================================================

        private void cbStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadData();
            }
        }

        // =========================================================
        // ADD
        // =========================================================

        private void btAdd_Click(
            object sender,
            EventArgs e)
        {
            using var dialog =
                new Dialog_Supplier(
                    _supplierBLL,
                    null);

            if (dialog.ShowDialog() ==
                DialogResult.OK)
            {
                LoadData();
            }
        }

        // =========================================================
        // EDIT / DELETE
        // =========================================================

        private void dgvSupplier_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvSupplier.Rows[e.RowIndex]
                .DataBoundItem is not SupplierDto supplier)
            {
                return;
            }

            string columnName =
                dgvSupplier
                    .Columns[e.ColumnIndex]
                    .Name;

            // ----------------------------
            // EDIT
            // ----------------------------

            if (columnName == "colEdit")
            {
                using var dialog =
                    new Dialog_Supplier(
                        _supplierBLL,
                        supplier.SupplierId);

                if (dialog.ShowDialog() ==
                    DialogResult.OK)
                {
                    LoadData();
                }

                return;
            }

            // ----------------------------
            // DELETE
            // ----------------------------

            if (columnName == "colDelete")
            {
                if (!supplier.IsActive)
                {
                    MessageBox.Show(
                        "Nhà cung cấp này đã ngừng hoạt động.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                var confirm =
                    MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa nhà cung cấp " +
                        $"\"{supplier.SupplierName}\" không?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (confirm !=
                    DialogResult.Yes)
                {
                    return;
                }

                var result =
                    _supplierBLL.Delete(
                        supplier.SupplierId);

                MessageBox.Show(
                    result.Message,
                    result.IsSuccess
                        ? "Thành công"
                        : "Không thể xóa",
                    MessageBoxButtons.OK,
                    result.IsSuccess
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Warning);

                if (result.IsSuccess)
                {
                    LoadData();
                }
            }
        }
    }
}
