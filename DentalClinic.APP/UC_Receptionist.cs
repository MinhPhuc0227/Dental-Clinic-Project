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
    public partial class UC_Receptionist : UserControl
    {
        private readonly Receptionist_BLL _bll = new Receptionist_BLL();
        private List<ReceptionistDto> _fullList = new List<ReceptionistDto>();

        public UC_Receptionist()
        {
            InitializeComponent();
        }

        private void UC_Receptionist_Load(object sender, EventArgs e)
        {
            dgvReceptionist.AutoGenerateColumns = true;
            LoadDataToGridView();
        }

        // Load data to datagridview
        public void LoadDataToGridView()
        {
            var result = _bll.GetAll();
            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;
                dgvReceptionist.DataSource = _fullList;
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
            if (!dgvReceptionist.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Image = Resources.edit,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvReceptionist.Columns.Add(imgEdit);
            }

            if (!dgvReceptionist.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Image = Resources.delete,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvReceptionist.Columns.Add(imgDelete);
            }
        }

        // Add button
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Receptionist())
            {
                if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
            }
        }

        // Cellcontentclick (Edite/Delete)
        private void dgvReceptionist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvReceptionist.Rows[e.RowIndex].DataBoundItem as ReceptionistDto;
            if (selectedDto == null) return;

            string colName = dgvReceptionist.Columns[e.ColumnIndex].Name;

            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Receptionist(selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
                }
            }
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa lễ tân '{selectedDto.FullName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var result = _bll.Delete(selectedDto.ReceptionistId);
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
                dgvReceptionist.DataSource = _fullList;
            }
            else
            {
                dgvReceptionist.DataSource = _fullList.Where(r => r.FullName.ToLower().Contains(keyword)
                                                               || r.Phone.Contains(keyword)
                                                               || r.UserName.ToLower().Contains(keyword)).ToList();
            }
        }
    }
}
