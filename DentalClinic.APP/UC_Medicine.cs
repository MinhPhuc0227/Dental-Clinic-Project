using DentalClinic.BLL;
using DentalClinic.DTO.Medicine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class UC_Medicine : UserControl
    {
        private readonly Medicine_BLL _bll = new Medicine_BLL();
        private List<MedicineDto> _fullList = new List<MedicineDto>();

        public UC_Medicine()
        {
            InitializeComponent();
        }

        private void UC_Medicine_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDataToGridView();
        }

        // Cấu hình DataGridView tự động sinh cột
        private void ConfigureDataGridView()
        {
            dgvMedicine.AutoGenerateColumns = true;
        }

        // Tải dữ liệu lên bảng
        public void LoadDataToGridView()
        {
            var result = _bll.GetAll();

            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;
                dgvMedicine.DataSource = _fullList;

                // Thêm 2 cột ImageColumn Sửa và Xóa vào cuối bảng
                AddActionImageColumns();
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Image = SystemIcons.Information.ToBitmap(),
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
                    Image = SystemIcons.Error.ToBitmap(),
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvMedicine.Columns.Add(imgDelete);
            }
        }

        // Nút THÊM MỚI (+ Thêm mới)
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Medicine())
            {
                // Dialog_Medicine đã tự xử lý gọi BLL.Add() và hiển thị thông báo.
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
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
                using (var dialog = new Dialog_Medicine(selectedDto))
                {
                    // Dialog_Medicine đã tự xử lý gọi BLL.Update() và hiển thị thông báo.
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataToGridView();
                    }
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvMedicine.DataSource = _fullList;
            }
            else
            {
                var filtered = _fullList.Where(m => m.MedicineName.ToLower().Contains(keyword)
                                                 || m.Unit.ToLower().Contains(keyword)).ToList();
                dgvMedicine.DataSource = filtered;
            }
        }
    }
}