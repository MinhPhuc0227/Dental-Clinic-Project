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
    public partial class UC_Service : UserControl
    {
        private readonly Service_BLL _serviceBLL;

        public UC_Service(Service_BLL serviceBLL)
        {
            InitializeComponent();
            _serviceBLL = serviceBLL;
        }

        private void UC_Service_Load(object sender, EventArgs e)
        {
            dgvService.AutoGenerateColumns = true;
            LoadTypeComboBox();
            LoadStatusComboBox();
            LoadSortComboBox();
            LoadDataToGridView();
        }

        // LOAD CB LOẠI DỊCH VỤ
        private void LoadTypeComboBox()
        {
            var typeList = new[]
            {
                new { Value = (bool?)null, Text = "Tất cả" },
                new { Value = (bool?)false, Text = "Dịch vụ ngắn hạn" },
                new { Value = (bool?)true, Text = "Dịch vụ dài hạn" }
            };

            cbType.DataSource = typeList;
            cbType.DisplayMember = "Text";
            cbType.ValueMember = "Value";
            cbType.SelectedIndex = 0;
        }

        // LOAD CB TRẠNG THÁI
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new {Value = (ServiceStatus?)null, Text = "Tất cả"},
                new {Value = (ServiceStatus?)ServiceStatus.Active, Text = "Đang kinh doanh"},
                new {Value = (ServiceStatus?)ServiceStatus.Inactive, Text = "Ngừng kinh doanh"}
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
                new { Value = "IdAsc", Text = "Mã tăng dần" },
                new { Value = "IdDesc", Text = "Mã giảm dần" },
                new { Value = "NameAsc", Text = "Tên A-Z" },
                new { Value = "NameDesc", Text = "Tên Z-A" }
            };

            cbSort.DataSource = sortList;
            cbSort.DisplayMember = "Text";
            cbSort.ValueMember = "Value";
            cbSort.SelectedIndex = 0;
        }

        // LOAD DỮ LIỆU LÊN DGV DANH SÁCH DỊCH VỤ
        public void LoadDataToGridView()
        {
            bool? isLongTerm = null;

            if (cbType.SelectedIndex == 1)
            {
                isLongTerm = false;
            }
            else if (cbType.SelectedIndex == 2)
            {
                isLongTerm = true;
            }

            ServiceStatus? status = null;

            if (cbStatus.SelectedIndex == 1)
            {
                status = ServiceStatus.Active;
            }
            else if (cbStatus.SelectedIndex == 2)
            {
                status = ServiceStatus.Inactive;
            }

            var result = _serviceBLL.GetAll(txtSearch.Text.Trim(), isLongTerm, status);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var services = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "IdAsc":
                    services = services.OrderBy(s => s.ServiceId).ToList();
                    break;

                case "IdDesc":
                    services = services.OrderByDescending(s => s.ServiceId).ToList();
                    break;

                case "NameAsc":
                    services = services.OrderBy(s => s.ServiceName).ToList();
                    break;

                case "NameDesc":
                    services = services.OrderByDescending(s => s.ServiceName).ToList();
                    break;
            }

            dgvService.DataSource = null;
            dgvService.DataSource = services;

            AddActionImageColumns();

            var deleteColumn = dgvService.Columns["DeleteCol"];

            if (deleteColumn != null)
            {
                deleteColumn.DisplayIndex = dgvService.Columns.Count - 1;
            }

            var editColumn = dgvService.Columns["EditCol"];

            if (editColumn != null && deleteColumn != null)
            {
                editColumn.DisplayIndex = deleteColumn.DisplayIndex - 1;
            }
        }

        // THÊM CỘT SỬA VÀ XÓA CHO DGV
        private void AddActionImageColumns()
        {
            if (!dgvService.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewButtonColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };

                dgvService.Columns.Add(imgEdit);
            }

            if (!dgvService.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewButtonColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };

                dgvService.Columns.Add(imgDelete);
            }
        }

        // SỰ KIỆN NÚT THÊM
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Service(_serviceBLL))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
        }

        // SỰ KIỆN KHI NHẤN CỘT SỬA VÀ XÓA TRONG DGV
        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvService.Rows[e.RowIndex].DataBoundItem as ServiceDto;
            if (selectedDto == null) return;

            string colName = dgvService.Columns[e.ColumnIndex].Name;

            // Cột sửa
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Service(_serviceBLL, selectedDto))
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
                    $"Bạn có chắc chắn muốn xóa dịch vụ '{selectedDto.ServiceName}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    var result = _serviceBLL.Delete(selectedDto.ServiceId);

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
            if (IsHandleCreated) LoadDataToGridView();
        }

        // SỰ KIỆN CB LOẠI
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated) LoadDataToGridView();
        }

        // SỰ KIỆN CB TRẠNG THÁI
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated) LoadDataToGridView();
        }

        // SỰ KIỆN CB SẮP XẾP
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated) LoadDataToGridView();
        }
    }
}
