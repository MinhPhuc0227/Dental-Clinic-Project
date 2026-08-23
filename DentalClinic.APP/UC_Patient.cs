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
    public partial class UC_Patient : UserControl
    {
        private readonly Patient_BLL _bll = new Patient_BLL();
        private List<PatientDto> _fullList = new List<PatientDto>();

        public UC_Patient()
        {
            InitializeComponent();
        }

        private void UC_Patient_Load(object sender, EventArgs e)
        {
            dgvPatient.AutoGenerateColumns = true;
            LoadDataToGridView();
        }

        // Load data to datagridview
        public void LoadDataToGridView()
        {
            var result = _bll.GetAll();
            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;
                dgvPatient.DataSource = _fullList;
                AddActionImageColumns();
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add Edit and Delete image columns 
        private void AddActionImageColumns()
        {
            if (!dgvPatient.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Image = Resources.edit,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvPatient.Columns.Add(imgEdit);
            }

            if (!dgvPatient.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Image = Resources.delete,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvPatient.Columns.Add(imgDelete);
            }
        }

        // Add button
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Patient())
            {
                if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
            }
        }

        // Cellcontentclick (Edit/Delete)
        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvPatient.Rows[e.RowIndex].DataBoundItem as PatientDto;
            if (selectedDto == null) return;

            string colName = dgvPatient.Columns[e.ColumnIndex].Name;

            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Patient(selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
                }
            }
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa bệnh nhân '{selectedDto.FullName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var result = _bll.Delete(selectedDto.PatientId);
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
                dgvPatient.DataSource = _fullList;
            }
            else
            {
                dgvPatient.DataSource = _fullList.Where(p => p.FullName.ToLower().Contains(keyword)
                                                          || p.Phone.Contains(keyword)
                                                          || p.UserName.ToLower().Contains(keyword)).ToList();
            }
        }
    }
}
