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
        private readonly Patient_BLL _patientBLL;

        public UC_Patient(Patient_BLL patientBLL)
        {
            InitializeComponent();
            _patientBLL = patientBLL;
        }

        private void UC_Patient_Load(object sender, EventArgs e)
        {
            dgvPatient.AutoGenerateColumns = true;
            LoadSortComboBox();
            LoadDataToGridView();
        }

        // LOAD DỮ LIỆU LÊN DGV DANH SÁCH BỆNH NHÂN
        public void LoadDataToGridView()
        {
            var result = _patientBLL.GetAll(txtSearch.Text.Trim());

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(
                    result.Message,
                    "Thông báo lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var patients = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "IdAsc":
                    patients = patients
                        .OrderBy(p => p.PatientId)
                        .ToList();
                    break;

                case "IdDesc":
                    patients = patients
                        .OrderByDescending(p => p.PatientId)
                        .ToList();
                    break;

                case "NameAsc":
                    patients = patients
                        .OrderBy(p => p.FullName)
                        .ToList();
                    break;

                case "NameDesc":
                    patients = patients
                        .OrderByDescending(p => p.FullName)
                        .ToList();
                    break;
            }

            dgvPatient.DataSource = null;
            dgvPatient.DataSource = patients;

            AddActionImageColumns();
        }

        // THÊM CỘT SỬA VÀ XÓA VÀO DGV 
        private void AddActionImageColumns()
        {
            if (!dgvPatient.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewButtonColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };
                dgvPatient.Columns.Add(imgEdit);
            }

            if (!dgvPatient.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewButtonColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };
                dgvPatient.Columns.Add(imgDelete);
            }

            // Đưa cột Xóa xuống cuối và cột Sửa ngay trước cột Xóa
            var deleteColumn = dgvPatient.Columns["DeleteCol"];
            var editColumn = dgvPatient.Columns["EditCol"];

            if (deleteColumn != null)
                deleteColumn.DisplayIndex = dgvPatient.Columns.Count - 1;
         
            if (editColumn != null)
                editColumn.DisplayIndex = deleteColumn != null ? deleteColumn.DisplayIndex - 1 : dgvPatient.Columns.Count - 1;
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

        // =========================================================
        // SỰ KIỆN NÚT THÊM
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Patient(_patientBLL))
            {
                if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
            }
        }

        // SỰ KIỆN KHI NHẤN CỘT SỬA HOẶC XÓA TRONG DGV
        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvPatient.Rows[e.RowIndex].DataBoundItem as PatientDto;
            if (selectedDto == null) return;

            string colName = dgvPatient.Columns[e.ColumnIndex].Name;

            // Cột sửa
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Patient(_patientBLL, selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
                }
            }
            // Cột xóa
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa bệnh nhân '{selectedDto.FullName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var result = _patientBLL.Delete(selectedDto.PatientId);
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

        // SỰ KIỆN TÌM KIẾM
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        // SỰ KIỆN CB SẮP XẾP
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated) LoadDataToGridView();
        }
    }
}
