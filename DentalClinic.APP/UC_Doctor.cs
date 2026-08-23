using DentalClinic.APP.Properties;
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
    public partial class UC_Doctor : UserControl
    {
        private readonly Doctor_BLL _bll = new Doctor_BLL();
        private List<DoctorDto> _fullList = new List<DoctorDto>();

        public UC_Doctor()
        {
            InitializeComponent();
        }

        private void UC_Doctor_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDataToGridView();
        }

        // Config datagridview
        private void ConfigureDataGridView()
        {
            dgvDoctor.AutoGenerateColumns = true;
        }

        // Load data to datagridview
        public void LoadDataToGridView()
        {
            var result = _bll.GetAll();

            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;
                dgvDoctor.DataSource = _fullList;
                AddActionImageColumns();
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add edit and delete image columns 
        private void AddActionImageColumns()
        {
            if (!dgvDoctor.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Image = Resources.edit,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvDoctor.Columns.Add(imgEdit);
            }

            if (!dgvDoctor.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Image = Resources.delete,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvDoctor.Columns.Add(imgDelete);
            }
        }

        // Add button
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Doctor())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
        }

        // Cellcontentclick (Edit/Delete)
        private void dgvDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvDoctor.Rows[e.RowIndex].DataBoundItem as DoctorDto;
            if (selectedDto == null) return;

            string colName = dgvDoctor.Columns[e.ColumnIndex].Name;

            // EDIT
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Doctor(selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataToGridView();
                    }
                }
            }
            // DELETE
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa bác sĩ '{selectedDto.FullName}' và tài khoản liên quan không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    var result = _bll.Delete(selectedDto.DoctorId);

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
                dgvDoctor.DataSource = _fullList;
            }
            else
            {
                var filtered = _fullList.Where(d => d.FullName.ToLower().Contains(keyword)
                                                 || d.Phone.Contains(keyword)
                                                 || d.UserName.ToLower().Contains(keyword)).ToList();
                dgvDoctor.DataSource = filtered;
            }
        }
    }
}
