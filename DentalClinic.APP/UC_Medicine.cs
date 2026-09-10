using DentalClinic.APP.Properties;
using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class UC_Medicine : UserControl
    {
        // Khai báo biến
        private readonly int _accountId;

        // Dependency Injection
        private readonly IServiceProvider _serviceProvider;

        // BLL 
        private readonly Medicine_BLL _bll;

        public UC_Medicine(int accountId, Medicine_BLL bll, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _accountId = accountId;
            _bll = bll;
            _serviceProvider = serviceProvider;
        }

        private void UC_Medicine_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadStatusComboBox();
            LoadSortComboBox();
            LoadDataToGridView();
        }

        // LOAD CB TRẠNG THÁI
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new {Value = (MedicineStatus?)null, Text = "Tất cả"},
                new {Value = (MedicineStatus?)MedicineStatus.Active, Text = "Đang kinh doanh"},
                new {Value = (MedicineStatus?)MedicineStatus.Inactive, Text = "Ngừng kinh doanh"}
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

        // SET UP DGV DANH SÁCH 
        private void SetupGrid()
        {
            dgvMedicine.AutoGenerateColumns = true;
        }

        // LOAD DỮ LIỆU LÊN DANH SÁCH 
        public void LoadDataToGridView()
        {
            MedicineStatus? status = null;

            if (cbStatus.SelectedValue is MedicineStatus selectedStatus)
            {
                status = selectedStatus;
            }

            var result = _bll.GetAll(txtSearch.Text.Trim(), status);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var medicines = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "IdAsc":
                    medicines = medicines.OrderBy(m => m.MedicineId).ToList();
                    break;

                case "IdDesc":
                    medicines = medicines.OrderByDescending(m => m.MedicineId).ToList();
                    break;

                case "NameAsc":
                    medicines = medicines.OrderBy(m => m.MedicineName).ToList();
                    break;

                case "NameDesc":
                    medicines = medicines.OrderByDescending(m => m.MedicineName).ToList();
                    break;
            }

            dgvMedicine.DataSource = null;
            dgvMedicine.DataSource = medicines;

            AddActionImageColumns();
        }

        // THÊM 2 CỘT SỬA VÀ XÓA
        private void AddActionImageColumns()
        {
            // Cột sửa
            if (!dgvMedicine.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewButtonColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };

                dgvMedicine.Columns.Add(imgEdit);
            }

            // Cột xóa
            if (!dgvMedicine.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewButtonColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };

                dgvMedicine.Columns.Add(imgDelete);
            }

            // Đưa cột Xóa xuống cuối và cột Sửa ngay trước cột Xóa
            var deleteColumn = dgvMedicine.Columns["DeleteCol"];
            var editColumn = dgvMedicine.Columns["EditCol"];

            if (deleteColumn != null)
                deleteColumn.DisplayIndex = dgvMedicine.Columns.Count - 1;

            if (editColumn != null)
                editColumn.DisplayIndex = deleteColumn != null ? deleteColumn.DisplayIndex - 1 : dgvMedicine.Columns.Count - 1;

        }

        // ==========================================================================
        // SỰ KIỆN TÌM KIẾM
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        // SỰ KIỆN CB TRẠNG THÁI
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDataToGridView();
            }
        }

        // SỰ KIỆN CB SẮP XẾP
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDataToGridView();
            }
        }

        // SỰ KIỆN NHẤN NÚT THÊM MỚI THUỐC
        private void btAdd_Click(object sender, EventArgs e)
        {
            using var dialog = ActivatorUtilities.CreateInstance<Dialog_Medicine>(_serviceProvider);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadDataToGridView();
            }
        }

        // SỰ KIỆN NHẤN NÚT SỬA HOẶC XÓA TRONG DGV
        private void dgvMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvMedicine.Rows[e.RowIndex].DataBoundItem as MedicineDto;

            if (selectedDto == null) return;

            string colName = dgvMedicine.Columns[e.ColumnIndex].Name;

            // Nút sửa
            if (colName == "EditCol")
            {
                using var dialog = ActivatorUtilities.CreateInstance<Dialog_Medicine>(_serviceProvider, selectedDto);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
            // Nút xóa
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa thuốc '{selectedDto.MedicineName}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    var result = _bll.Delete(selectedDto.MedicineId);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToGridView();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // SỰ KIỆN NHẤN NÚT NHẬP THUỐC
        private void btImport_Click(object sender, EventArgs e)
        {
            using var dialog = ActivatorUtilities.CreateInstance<Dialog_MedicineImport>(_serviceProvider, _accountId);

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadDataToGridView();
            }
        }

        // SỰ KIỆN NHẤN NÚT LỊCH SỬ NHẬP THUỐC
        private void btImportHistory_Click(object sender, EventArgs e)
        {
            using var dialog = ActivatorUtilities.CreateInstance<Dialog_MedicineImportHistory>(_serviceProvider);
            dialog.ShowDialog(this);
        }
    }
}