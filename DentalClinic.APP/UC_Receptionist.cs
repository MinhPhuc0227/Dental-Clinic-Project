using DentalClinic.APP.Properties;
using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.MODEL;
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
        private readonly Receptionist_BLL _receptionistBLL;

        public UC_Receptionist(Receptionist_BLL receptionistBLL)
        {
            InitializeComponent();
            _receptionistBLL = receptionistBLL;
        }

        private void UC_Receptionist_Load(object sender, EventArgs e)
        {
            dgvReceptionist.AutoGenerateColumns = true;
            LoadSortComboBox();
            LoadStatusComboBox();
            LoadDataToGridView();
        }

        // LOAD DỮ LIỆU LÊN DGV DANH SÁCH LỄ TÂN
        public void LoadDataToGridView()
        {
            AccountStatus? status = null;

            if (cbStatus.SelectedValue is AccountStatus selectedStatus)
            {
                status = selectedStatus;
            }

            var result = _receptionistBLL.GetAll(txtSearch.Text.Trim(), status);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var receptionists = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "IdAsc":
                    receptionists = receptionists.OrderBy(r => r.ReceptionistId).ToList();
                    break;

                case "IdDesc":
                    receptionists = receptionists.OrderByDescending(r => r.ReceptionistId).ToList();
                    break;

                case "NameAsc":
                    receptionists = receptionists.OrderBy(r => r.FullName).ToList();
                    break;

                case "NameDesc":
                    receptionists = receptionists.OrderByDescending(r => r.FullName).ToList();
                    break;

                case "CreatedAsc":
                    receptionists = receptionists.OrderBy(r => r.CreatedAt).ToList();
                    break;

                case "CreatedDesc":
                    receptionists = receptionists.OrderByDescending(r => r.CreatedAt).ToList();
                    break;
            }

            dgvReceptionist.DataSource = null;
            dgvReceptionist.DataSource = receptionists;

            AddActionImageColumns();

            // Đưa Sửa và Xóa về cuối
            var deleteColumn = dgvReceptionist.Columns["DeleteCol"];

            if (deleteColumn != null)
            {
                deleteColumn.DisplayIndex = dgvReceptionist.Columns.Count - 1;
            }

            var editColumn = dgvReceptionist.Columns["EditCol"];

            if (editColumn != null && deleteColumn != null)
            {
                editColumn.DisplayIndex = deleteColumn.DisplayIndex - 1;
            }
        }

        // THÊM CỘT SỬA VÀ CỘT XÓA CHO DGV
        private void AddActionImageColumns()
        {
            if (!dgvReceptionist.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewButtonColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };
                dgvReceptionist.Columns.Add(imgEdit);
            }

            if (!dgvReceptionist.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewButtonColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };
                dgvReceptionist.Columns.Add(imgDelete);
            }
        }

        // LOAD CB SẮP XẾP
        private void LoadSortComboBox()
        {
            var sortList = new List<object>
            {
                new { Value = "IdAsc", Text = "Mã tăng dần" },
                new { Value = "IdDesc", Text = "Mã giảm dần" },
                new { Value = "NameAsc", Text = "Tên A-Z" },
                new { Value = "NameDesc", Text = "Tên Z-A" },
                new { Value = "CreatedAsc", Text = "Ngày tạo cũ → mới" },
                new { Value = "CreatedDesc", Text = "Ngày tạo mới → cũ" }
            };

            cbSort.DataSource = sortList;
            cbSort.DisplayMember = "Text";
            cbSort.ValueMember = "Value";
            cbSort.SelectedIndex = 0;
        }

        // LOAD CB TRẠNG THÁI
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new {Value = (AccountStatus?)null, Text = "Tất cả"},
                new {Value = (AccountStatus?)AccountStatus.Active, Text = "Đang hoạt động"},
                new {Value = (AccountStatus?)AccountStatus.Inactive, Text = "Ngừng hoạt động"},
                new { Value = (AccountStatus?)AccountStatus.Locked, Text = "Đã khóa" }
            };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        // =========================================================

        // SỰ KIỆN NÚT THÊM 
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Receptionist(_receptionistBLL))
            {
                if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
            }
        }

        // SỰ KIỆN NHẤN NÚT SỬA HOẶC XÓA TRONG DGV
        private void dgvReceptionist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvReceptionist.Rows[e.RowIndex].DataBoundItem as ReceptionistDto;
            
            if (selectedDto == null) return;

            string colName = dgvReceptionist.Columns[e.ColumnIndex].Name;

            // Cột sửa
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Receptionist(_receptionistBLL, selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                        LoadDataToGridView();
                }
            }
            // Cột xóa
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa lễ tân '{selectedDto.FullName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var result = _receptionistBLL.Delete(selectedDto.ReceptionistId);
                    
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
            if (IsHandleCreated)
            {
                LoadDataToGridView();
            }
        }

        // SỰ KIỆN CB TRẠNG THÁI
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDataToGridView();
            }
        }
    }
}
