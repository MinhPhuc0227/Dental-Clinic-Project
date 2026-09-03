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
        private List<MedicineDto> _fullList = new List<MedicineDto>();
        private readonly int _accountId;

        // Dependency Injection
        private readonly IServiceProvider _serviceProvider;

        // BLL 
        private readonly Medicine_BLL _bll;

        public UC_Medicine(
    int accountId,
    Medicine_BLL bll,
    IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _accountId = accountId;
            _bll = bll;
            _serviceProvider = serviceProvider;
        }

        private void UC_Medicine_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadStatusComboBox();
            LoadDataToGridView();
        }

        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
        new
        {
            Value = (MedicineStatus?)null,
            Text = "Tất cả"
        },

        new
        {
            Value = (MedicineStatus?)MedicineStatus.Active,
            Text = "Đang kinh doanh"
        },

        new
        {
            Value = (MedicineStatus?)MedicineStatus.Inactive,
            Text = "Ngừng kinh doanh"
        }
    };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        // Cấu hình DataGridView tự động sinh cột
        private void ConfigureDataGridView()
        {
            dgvMedicine.AutoGenerateColumns = true;
        }

        // Tải dữ liệu lên bảng
        public void LoadDataToGridView()
        {
            MedicineStatus? status = null;

            if (cbStatus.SelectedValue is MedicineStatus selectedStatus)
            {
                status = selectedStatus;
            }

            var result = _bll.GetAll(
                txtSearch.Text.Trim(),
                status);

            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;

                dgvMedicine.DataSource = null;
                dgvMedicine.DataSource = _fullList;

                AddActionImageColumns();

                dgvMedicine.Columns["EditCol"].DisplayIndex =
    dgvMedicine.Columns.Count - 2;

                dgvMedicine.Columns["DeleteCol"].DisplayIndex =
                    dgvMedicine.Columns.Count - 1;
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Thông báo lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Thêm 2 cột ImageColumn (Sửa/Xóa)
        private void AddActionImageColumns()
        {
            // Cột Sửa
            if (!dgvMedicine.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Image = Resources.edit,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };

                dgvMedicine.Columns.Add(imgEdit);
            }

            // Cột Xóa
            if (!dgvMedicine.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Image = Resources.delete,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };

                dgvMedicine.Columns.Add(imgDelete);
            }

            // Đưa 2 cột xuống cuối
            dgvMedicine.Columns["EditCol"].DisplayIndex =
                dgvMedicine.Columns.Count - 2;

            dgvMedicine.Columns["DeleteCol"].DisplayIndex =
                dgvMedicine.Columns.Count - 1;
        }

        // Nút THÊM MỚI (+ Thêm mới)
        private void btAdd_Click(object sender, EventArgs e)
        {
            using var dialog =
        ActivatorUtilities.CreateInstance<Dialog_Medicine>(
            _serviceProvider);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadDataToGridView();
            }
        }

        // Sự kiện Click vào ô DataGridView (Xử lý Sửa/Xóa)
        private void dgvMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvMedicine.Rows[e.RowIndex].DataBoundItem as MedicineDto;
            if (selectedDto == null) return;

            string colName = dgvMedicine.Columns[e.ColumnIndex].Name;

            // 1. Xử lý SỬA
            if (colName == "EditCol")
            {
                using var dialog =
        ActivatorUtilities.CreateInstance<Dialog_Medicine>(
            _serviceProvider,
            selectedDto);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
            // 2. Xử lý XÓA
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

        // Xử lý Tìm kiếm real-time
        private void txtSearch_TextChanged(
    object sender,
    EventArgs e)
        {
            LoadDataToGridView();
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            using var dialog =
    ActivatorUtilities.CreateInstance<Dialog_MedicineImport>(
        _serviceProvider,
        _accountId);

            if (dialog.ShowDialog(this) ==
                DialogResult.OK)
            {
                LoadDataToGridView();
            }
        }

        private void btImportHistory_Click(object sender, EventArgs e)
        {
            using var dialog =
        ActivatorUtilities.CreateInstance<Dialog_MedicineImportHistory>(
            _serviceProvider);

            dialog.ShowDialog(this);
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDataToGridView();
            }
        }
    }
}