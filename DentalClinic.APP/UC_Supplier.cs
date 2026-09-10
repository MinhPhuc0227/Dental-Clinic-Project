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

        private void UC_Supplier_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadSortComboBox();
            LoadStatusComboBox();
            LoadData();
        }

        // SET UP DGV DANH SÁCH NCC

        // Sinh cột tự động
        private void SetupGrid()
        {
            dgvSupplier.AutoGenerateColumns = true;
        }

        // Set up từng cột
        //private void SetupGrid()
        //{
        //    dgvSupplier.AutoGenerateColumns = false;
        //    dgvSupplier.Columns.Clear();

        //    dgvSupplier.Columns.Add(
        //        new DataGridViewTextBoxColumn
        //        {
        //            DataPropertyName = "SupplierId",
        //            HeaderText = "Mã",
        //            Width = 60
        //        });

        //    dgvSupplier.Columns.Add(
        //        new DataGridViewTextBoxColumn
        //        {
        //            DataPropertyName = "SupplierName",
        //            HeaderText = "Nhà cung cấp",
        //            Width = 200
        //        });

        //    dgvSupplier.Columns.Add(
        //        new DataGridViewTextBoxColumn
        //        {
        //            DataPropertyName = "Phone",
        //            HeaderText = "Số điện thoại",
        //            Width = 120
        //        });

        //    dgvSupplier.Columns.Add(
        //        new DataGridViewTextBoxColumn
        //        {
        //            DataPropertyName = "Address",
        //            HeaderText = "Địa chỉ",
        //            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        //        });

        //    dgvSupplier.Columns.Add(
        //        new DataGridViewTextBoxColumn
        //        {
        //            DataPropertyName = "Email",
        //            HeaderText = "Email",
        //            Width = 180
        //        });

        //    dgvSupplier.Columns.Add(
        //        new DataGridViewTextBoxColumn
        //        {
        //            DataPropertyName = "StatusText",
        //            HeaderText = "Trạng thái",
        //            Width = 130
        //        });

        //    // Cột sửa
        //    var editColumn =
        //        new DataGridViewButtonColumn
        //        {
        //            Name = "colEdit",
        //            HeaderText = "Sửa",
        //            Text = "Sửa",
        //            UseColumnTextForButtonValue = true,
        //            Width = 65
        //        };

        //    dgvSupplier.Columns.Add(editColumn);

        //    // Cột xóa
        //    var deleteColumn =
        //        new DataGridViewButtonColumn
        //        {
        //            Name = "colDelete",
        //            HeaderText = "Xóa",
        //            Text = "Xóa",
        //            UseColumnTextForButtonValue = true,
        //            Width = 65
        //        };

        //    dgvSupplier.Columns.Add(deleteColumn);
        //}

        // LOAD DỮ LIỆU LÊN DANH SÁCH NCC
        public void LoadData()
        {
            bool? isActive = null;

            if (cbStatus.SelectedIndex == 1)
                isActive = true;

            else if (cbStatus.SelectedIndex == 2)
                isActive = false;

            var result = _supplierBLL.GetAll(txtSearch.Text.Trim(), isActive);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var suppliers = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "IdAsc":
                    suppliers = suppliers.OrderBy(s => s.SupplierId).ToList();
                    break;

                case "IdDesc":
                    suppliers = suppliers.OrderByDescending(s => s.SupplierId).ToList();
                    break;

                case "NameAsc":
                    suppliers = suppliers.OrderBy(s => s.SupplierName).ToList();
                    break;

                case "NameDesc":
                    suppliers = suppliers.OrderByDescending(s => s.SupplierName).ToList();
                    break;
            }

            dgvSupplier.DataSource = suppliers;
            AddActionImageColumns();

            // Cho 2 cột sửa và xóa ở vị trí cuối
            //var editColumn = dgvSupplier.Columns["EditCol"];
            //var deleteColumn = dgvSupplier.Columns["DeleteCol"];

            //if (editColumn != null)
            //    editColumn.DisplayIndex = dgvSupplier.Columns.Count - 2;

            //if (deleteColumn != null)
            //    deleteColumn.DisplayIndex = dgvSupplier.Columns.Count - 1;
        }

        // THÊM 2 CỘT SỬA VÀ XÓA CHO DGV
        private void AddActionImageColumns()
        {
            // Cột sửa
            if (!dgvSupplier.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewButtonColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };

                dgvSupplier.Columns.Add(imgEdit);
            }

            // Cột xóa
            if (!dgvSupplier.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewButtonColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };

                dgvSupplier.Columns.Add(imgDelete);
            }

            // Đưa cột Xóa xuống cuối và cột Sửa ngay trước cột Xóa
            var deleteColumn = dgvSupplier.Columns["DeleteCol"];
            var editColumn = dgvSupplier.Columns["EditCol"];

            if (deleteColumn != null)
                deleteColumn.DisplayIndex = dgvSupplier.Columns.Count - 1;

            if (editColumn != null)
                editColumn.DisplayIndex = deleteColumn != null ? deleteColumn.DisplayIndex - 1 : dgvSupplier.Columns.Count - 1;

        }

        // LOAD CB TRẠNG THÁI
        private void LoadStatusComboBox()
        {
            var statusList =
                new List<object>
                {
                    new {Value = (bool?)null, Text = "Tất cả"},
                    new {Value = (bool?)true, Text = "Đang hoạt động"},
                    new {Value = (bool?)false, Text = "Ngừng hoạt động"}
                };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        // LOAD CB SẮP XẾP
        private void LoadSortComboBox()
        {
            var sortList = new List<object>
            {
                new {Value = "IdAsc", Text = "Mã tăng dần"},
                new {Value = "IdDesc", Text = "Mã giảm dần"},
                new {Value = "NameAsc", Text = "Tên A-Z"},
                new {Value = "NameDesc",Text = "Tên Z-A"}
            };

            cbSort.DataSource = sortList;
            cbSort.DisplayMember = "Text";
            cbSort.ValueMember = "Value";
            cbSort.SelectedIndex = 0;
        }

        // ================================================

        // SỰ KIỆN TÌM KIẾM
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        // SỰ KIỆN LỌC TRẠNG THÁI
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated) LoadData();
        }

        // SỰ KIỆN CB SẮP XẾP
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated) LoadData();
        }

        // SỰ KIỆN NÚT THÊM
        private void btAdd_Click(object sender, EventArgs e)
        {
            using var dialog = new Dialog_Supplier(_supplierBLL, null);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        // SỰ KIỆN NHẤN NÚT SỬA HOẶC XÓA TRONG DGV
        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvSupplier.Rows[e.RowIndex].DataBoundItem is not SupplierDto supplier)
            {
                return;
            }

            string columnName = dgvSupplier.Columns[e.ColumnIndex].Name;

            // Cột sửa
            if (columnName == "EditCol")
            {
                using var dialog = new Dialog_Supplier(_supplierBLL, supplier.SupplierId);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }

                return;
            }

            // Cột xóa
            if (columnName == "DeleteCol")
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

                if (confirm != DialogResult.Yes)
                {
                    return;
                }

                var result = _supplierBLL.Delete(supplier.SupplierId);

                MessageBox.Show(
                    result.Message,
                    result.IsSuccess ? "Thành công" : "Không thể xóa",
                    MessageBoxButtons.OK,
                    result.IsSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (result.IsSuccess)
                {
                    LoadData();
                }
            }
        }
    }
}
