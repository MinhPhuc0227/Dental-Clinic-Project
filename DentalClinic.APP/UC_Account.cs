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
    public partial class UC_Account : UserControl
    {
        private readonly Account_BLL _bll = new Account_BLL();
        private readonly Doctor_BLL _doctorBLL = new Doctor_BLL(new Doctor_DAL(new AppDbContext()));
        private readonly Receptionist_BLL _receptionistBLL = new Receptionist_BLL();
        private List<AccountDto> _fullList = new List<AccountDto>();
        private readonly int _currentAccountId;

        public UC_Account(int currentAccountId)
        {
            InitializeComponent();
            _currentAccountId = currentAccountId;
        }

        private void UC_Account_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadRoleComboBox();
            LoadDataToGridView();
        }

        // Config datagridview 
        private void ConfigureDataGridView()
        {
            dgvAccount.AutoGenerateColumns = true;
        }

        // Load data to datagridview
        public void LoadDataToGridView()
        {
            var result = _bll.GetAll();

            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;

                AddActionImageColumns();

                ApplyFilter();
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

        // Add edit and delete image columns 
        private void AddActionImageColumns()
        {
            if (!dgvAccount.Columns.Contains("ViewCol"))
            {
                var viewCol = new DataGridViewButtonColumn
                {
                    Name = "ViewCol",
                    HeaderText = "Xem hồ sơ",
                    Text = "Xem",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };

                dgvAccount.Columns.Add(viewCol);
            }

            if (!dgvAccount.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa / Đổi MK",
                    Image = Resources.edit,
                    Width = 80,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvAccount.Columns.Add(imgEdit);
            }

            if (!dgvAccount.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Image = Resources.delete,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvAccount.Columns.Add(imgDelete);
            }
        }

        // Cellcontentclick (Edit/Delete) 
        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvAccount.Rows[e.RowIndex].DataBoundItem as AccountDto;
            if (selectedDto == null) return;

            string colName = dgvAccount.Columns[e.ColumnIndex].Name;

            // XEM HỒ SƠ
            if (colName == "ViewCol")
            {
                if (selectedDto.Role == AccountRole.Doctor &&
                    selectedDto.DoctorId.HasValue)
                {
                    var result =
                        _doctorBLL.GetById(
                            selectedDto.DoctorId.Value);

                    if (!result.IsSuccess ||
                        result.Data == null)
                    {
                        MessageBox.Show(
                            "Không tìm thấy hồ sơ bác sĩ.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    using var dialog =
                        new Dialog_Doctor(
                            result.Data,
                            true);

                    dialog.ShowDialog(this);
                }
                else if (
                    selectedDto.Role == AccountRole.Receptionist &&
                    selectedDto.ReceptionistId.HasValue)
                {
                    var result =
                        _receptionistBLL.GetById(
                            selectedDto.ReceptionistId.Value);

                    if (!result.IsSuccess ||
                        result.Data == null)
                    {
                        MessageBox.Show(
                            "Không tìm thấy hồ sơ lễ tân.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    using var dialog =
                        new Dialog_Receptionist(
                            result.Data,
                            true);

                    dialog.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(
                        "Tài khoản Admin không có hồ sơ nhân sự riêng.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                return;
            }

            // EDIT
            else if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Account(selectedDto, _currentAccountId))
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
                // Không cho xóa chính tài khoản đang đăng nhập
                if (selectedDto.AccountId == _currentAccountId)
                {
                    MessageBox.Show(
                        "Bạn không thể xóa tài khoản đang đăng nhập.",
                        "Không thể thực hiện",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa tài khoản '{selectedDto.UserName}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    var result = _bll.Delete(selectedDto.AccountId);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show(
                            result.Message,
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadDataToGridView();
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
            }
        }

        // Search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btCreateAdmin_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Admin())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
        }

        private void LoadRoleComboBox()
        {
            cbRole.DataSource = new[]
            {
        new
        {
            Value = (AccountRole?)null,
            Display = "-- Tất cả --"
        },
        new
        {
            Value = (AccountRole?)AccountRole.Admin,
            Display = "Quản trị viên"
        },
        new
        {
            Value = (AccountRole?)AccountRole.Doctor,
            Display = "Bác sĩ"
        },
        new
        {
            Value = (AccountRole?)AccountRole.Receptionist,
            Display = "Lễ tân"
        }
    };

            cbRole.DisplayMember = "Display";
            cbRole.ValueMember = "Value";
            cbRole.SelectedIndex = 0;
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            AccountRole? selectedRole = null;

            if (cbRole.SelectedValue is AccountRole role)
            {
                selectedRole = role;
            }

            var filtered = _fullList.AsEnumerable();

            // Lọc theo từ khóa
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(a =>
                    a.UserName.ToLower().Contains(keyword) ||
                    a.FullName.ToLower().Contains(keyword) ||
                    a.RoleDisplay.ToLower().Contains(keyword) ||
                    a.StatusDisplay.ToLower().Contains(keyword));
            }

            // Lọc theo vai trò
            if (selectedRole.HasValue)
            {
                filtered = filtered.Where(a =>
                    a.Role == selectedRole.Value);
            }

            dgvAccount.DataSource = filtered.ToList();
        }
    }
}
