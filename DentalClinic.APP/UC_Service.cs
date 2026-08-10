using DentalClinic.BLL;
using DentalClinic.DTO.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class UC_Service : UserControl
    {
        private readonly Service_BLL _bll = new Service_BLL();
        private List<ServiceDto> _fullList = new List<ServiceDto>();

        public UC_Service()
        {
            InitializeComponent();
        }

        private void UC_Service_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDataToGridView();
        }

        // Config DataGridView
        private void ConfigureDataGridView()
        {
            dgvService.AutoGenerateColumns = true;
        }

        // Load data to DataGridView
        public void LoadDataToGridView()
        {
            var result = _bll.GetAll();

            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;
                dgvService.DataSource = _fullList;
                AddActionImageColumns();
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add Edit and Delete image column
        private void AddActionImageColumns()
        {
            if (!dgvService.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Image = SystemIcons.Information.ToBitmap(),
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvService.Columns.Add(imgEdit);
            }

            if (!dgvService.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Image = SystemIcons.Error.ToBitmap(),
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvService.Columns.Add(imgDelete);
            }
        }

        // Add button 
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Service())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
        }

        // CellContentClick (Edit/Delete)
        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvService.Rows[e.RowIndex].DataBoundItem as ServiceDto;
            if (selectedDto == null) return;

            string colName = dgvService.Columns[e.ColumnIndex].Name;

            // Edit
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Service(selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataToGridView();
                    }
                }
            }
            // Delete
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa dịch vụ '{selectedDto.ServiceName}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    var result = _bll.Delete(selectedDto.ServiceId);

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

        // Search 
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvService.DataSource = _fullList;
            }
            else
            {
                var filtered = _fullList.Where(s => s.ServiceName.ToLower().Contains(keyword)).ToList();
                dgvService.DataSource = filtered;
            }
        }
    }
}
