using DentalClinic.APP.Properties;
using DentalClinic.BLL;
using DentalClinic.DAL;
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
    public partial class UC_Doctor : UserControl
    {
        private readonly Doctor_BLL _bll;

        public UC_Doctor(Doctor_BLL bll)
        {
            InitializeComponent();
            _bll = bll;
        }

        private void UC_Doctor_Load(object sender, EventArgs e)
        {
            dgvDoctor.AutoGenerateColumns = true;
            LoadSortComboBox();
            LoadStatusComboBox();
            LoadDataToGridView();
        }

        // LOAD DỮ LIỆU LÊN DGV DANH SÁCH BÁC SĨ
        public void LoadDataToGridView()
        {
            AccountStatus? status = null;

            if (cbStatus.SelectedValue is AccountStatus selectedStatus)
            {
                status = selectedStatus;
            }

            var result = _bll.GetAll(txtSearch.Text.Trim(), status);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(result.Message,"Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var receptionists = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "IdAsc":
                    receptionists = receptionists.OrderBy(r => r.DoctorId).ToList();
                    break;

                case "IdDesc":
                    receptionists = receptionists.OrderByDescending(r => r.DoctorId).ToList();
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

            dgvDoctor.DataSource = null;
            dgvDoctor.DataSource = receptionists;

            dgvDoctor.Columns["ProfileImage"].Visible = false;
            dgvDoctor.Columns["AccountId"].Visible = false;
            dgvDoctor.Columns["Username"].Visible = false;
            dgvDoctor.Columns["CreatedAt"].Visible = false;

            AddActionImageColumns();

            // Đưa Sửa và Xóa về cuối
            var deleteColumn = dgvDoctor.Columns["DeleteCol"];

            if (deleteColumn != null)
            {
                deleteColumn.DisplayIndex = dgvDoctor.Columns.Count - 1;
            }

            var editColumn = dgvDoctor.Columns["EditCol"];

            if (editColumn != null && deleteColumn != null)
            {
                editColumn.DisplayIndex = deleteColumn.DisplayIndex - 1;
            }
        }

        // THÊM CỘT SỬA VÀ CỘT XÓA CHO DGV
        private void AddActionImageColumns()
        {
            if (!dgvDoctor.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewButtonColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };
                dgvDoctor.Columns.Add(imgEdit);
            }

            if (!dgvDoctor.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewButtonColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };
                dgvDoctor.Columns.Add(imgDelete);
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

        // ===================================================

        // SỰ KIỆN NÚT THÊM
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Doctor(_bll))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
        }

        // SỰ KIỆN NHẤN NÚT SỬA HOẶC XÓA TRONG DGV
        private void dgvDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvDoctor.Rows[e.RowIndex].DataBoundItem as DoctorDto;
            if (selectedDto == null) return;

            string colName = dgvDoctor.Columns[e.ColumnIndex].Name;

            // Cột sửa
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Doctor(_bll, selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataToGridView();
                    }
                }
            }
            // Cột xóa
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
