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
        private readonly int _currentAccountId;

        // Khởi tạo BLL
        private readonly Account_BLL _accountBLL;
        private readonly Doctor_BLL _doctorBLL;
        private readonly Receptionist_BLL _receptionistBLL;

        public UC_Account(int currentAccountId, Account_BLL accountBLL, Receptionist_BLL receptionistBLL, Doctor_BLL doctorBLL)
        {
            InitializeComponent();
            _currentAccountId = currentAccountId;
            _accountBLL = accountBLL;
            _receptionistBLL = receptionistBLL;
            _doctorBLL = doctorBLL;
        }

        private void UC_Account_Load(object sender, EventArgs e)
        {
            dgvAccount.AutoGenerateColumns = true;
            LoadRoleComboBox();
            LoadStatusComboBox();
            LoadSortComboBox();
            LoadDataToGridView();
        }

        // LOAD CB TRẠNG THÁI
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new {Value = (AccountStatus?)null, Text = "Tất cả"},
                new {Value = (AccountStatus?)AccountStatus.Active, Text = "Đang hoạt động"},
                new {Value = (AccountStatus?)AccountStatus.Inactive, Text = "Ngừng hoạt động"},
                new {Value = (AccountStatus?)AccountStatus.Locked, Text = "Đã khóa"}
            };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        // LOAD CB VAI TRÒ
        private void LoadRoleComboBox()
        {
            var roleList = new[]
            {
                new {Value = (AccountRole?)null, Text = "Tất cả"},
                new {Value = (AccountRole?)AccountRole.Admin, Text = "Quản trị viên"},
                new {Value = (AccountRole?)AccountRole.Doctor, Text = "Bác sĩ"},
                new {Value = (AccountRole?)AccountRole.Receptionist, Text = "Lễ tân"}
            };

            cbRole.DataSource = roleList;
            cbRole.DisplayMember = "Text";
            cbRole.ValueMember = "Value";
            cbRole.SelectedIndex = 0;
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

        // LOAD DỮ LIỆU LÊN DGV DANH SÁCH TÀI KHOẢN
        public void LoadDataToGridView()
        {
            AccountRole? role = null;

            if (cbRole.SelectedIndex == 1)
            {
                role = AccountRole.Admin;
            }
            else if (cbRole.SelectedIndex == 2)
            {
                role = AccountRole.Doctor;
            }
            else if (cbRole.SelectedIndex == 3)
            {
                role = AccountRole.Receptionist;
            }

            AccountStatus? status = null;

            if (cbStatus.SelectedIndex == 1)
            {
                status = AccountStatus.Active;
            }
            else if (cbStatus.SelectedIndex == 2)
            {
                status = AccountStatus.Inactive;
            }
            else if (cbStatus.SelectedIndex == 3)
            {
                status = AccountStatus.Locked;
            }

            var result = _accountBLL.GetAll(txtSearch.Text.Trim(), role, status);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var accounts = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "IdAsc":
                    accounts = accounts.OrderBy(a => a.AccountId).ToList();
                    break;

                case "IdDesc":
                    accounts = accounts.OrderByDescending(a => a.AccountId).ToList();
                    break;

                case "NameAsc":
                    accounts = accounts.OrderBy(a => a.FullName).ToList();
                    break;

                case "NameDesc":
                    accounts = accounts.OrderByDescending(a => a.FullName).ToList();
                    break;

                case "CreatedAsc":
                    accounts = accounts.OrderBy(a => a.CreatedAt).ToList();
                    break;

                case "CreatedDesc":
                    accounts = accounts.OrderByDescending(a => a.CreatedAt).ToList();
                    break;
            }

            dgvAccount.DataSource = null;
            dgvAccount.DataSource = accounts;

            AddActionImageColumns();

            // Đưa Xóa về cuối
            var deleteColumn = dgvAccount.Columns["DeleteCol"];

            if (deleteColumn != null)
            {
                deleteColumn.DisplayIndex = dgvAccount.Columns.Count - 1;
            }

            // Đưa Sửa ngay trước Xóa
            var editColumn = dgvAccount.Columns["EditCol"];

            if (editColumn != null && deleteColumn != null)
            {
                editColumn.DisplayIndex = deleteColumn.DisplayIndex - 1;
            }

            // Đặt tên hiển thị cho một số cột
            var doctorIdColumn = dgvAccount.Columns["DoctorId"];
            if (doctorIdColumn != null)
            {
                doctorIdColumn.HeaderText = "Mã Bác Sĩ";
            }

            var receptionistIdColumn = dgvAccount.Columns["ReceptionistId"];
            if (receptionistIdColumn != null)
            {
                receptionistIdColumn.HeaderText = "Mã Lễ Tân";
            }

            var fullNameColumn = dgvAccount.Columns["FullName"];
            if (fullNameColumn != null)
            {
                fullNameColumn.HeaderText = "Họ và Tên";
            }
        }

        // THÊM CỘT SỬA VÀ XÓA CHO DGV
        private void AddActionImageColumns()
        {
            if (!dgvAccount.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewButtonColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };
                dgvAccount.Columns.Add(imgEdit);
            }

            if (!dgvAccount.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewButtonColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };
                dgvAccount.Columns.Add(imgDelete);
            }
        }

        // =====================================================

        // SỰ KIỆN CỘT SỬA, XÓA TRONG DGV 
        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvAccount.Rows[e.RowIndex].DataBoundItem as AccountDto;
            if (selectedDto == null) return;

            string colName = dgvAccount.Columns[e.ColumnIndex].Name;

            // Cột sửa
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Account(selectedDto, _currentAccountId, _accountBLL))
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
                    var result = _accountBLL.Delete(selectedDto.AccountId);

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
        
        // SỰ KIỆN NÚT THÊM ADMIN
        private void btCreateAdmin_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_Admin(_accountBLL))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
        }

        // SỰ KIỆN TÌM KIẾM
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        // SỰ KIỆN CB VAI TRÒ
        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
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

        // SỰ KIỆN CB SẮP XẾP
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDataToGridView();
            }
        }
    }
}
