using DentalClinic.BLL;
using DentalClinic.DTO.Account;
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
    public partial class Dialog_Account : Form
    {
        private readonly Account_BLL _bll = new Account_BLL();
        public AccountDto? AccountData { get; private set; }

        public Dialog_Account(AccountDto data)
        {
            InitializeComponent();
            this.Text = "Chỉnh sửa tài khoản";
            AccountData = data;

            LoadComboBoxes();

            lbAccountId.Text = data.AccountId.ToString();
            txtUserName.Text = data.UserName;
            txtPassword.Text = string.Empty; // empty if dont need to change password
            cbRole.SelectedValue = data.Role;
            cbStatus.SelectedValue = data.Status;
            lbCreatedDate.Text = data.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            if (data.Role != AccountRole.Admin)
            {
                cbRole.Enabled = false;
            }
        }


        // Load role and status combobox
        private void LoadComboBoxes()
        {
            cbRole.DataSource = new[]
            {
                new { Value = AccountRole.Admin, Display = "Quản trị viên" },
                new { Value = AccountRole.Doctor, Display = "Bác sĩ" },
                new { Value = AccountRole.Receptionist, Display = "Lễ tân" },
                new { Value = AccountRole.Patient, Display = "Bệnh nhân" }
            };
            cbRole.DisplayMember = "Display";
            cbRole.ValueMember = "Value";

            cbStatus.DataSource = new[]
            {
                new { Value = AccountStatus.Active, Display = "Hoạt động" },
                new { Value = AccountStatus.Inactive, Display = "Ngừng hoạt động" },
                new { Value = AccountStatus.Locked, Display = "Đã khóa" }
            };
            cbStatus.DisplayMember = "Display";
            cbStatus.ValueMember = "Value";
        }

        // Cancel button 
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Save button 
        private void btSave_Click(object sender, EventArgs e)
        {
            if (AccountData == null) return;

            var selectedRole = cbRole.SelectedValue != null
                ? (AccountRole)cbRole.SelectedValue
                : AccountRole.Admin;

            var selectedStatus = cbStatus.SelectedValue != null
                ? (AccountStatus)cbStatus.SelectedValue
                : AccountStatus.Active;

            var updateDto = new UpdateAccountDto
            {
                AccountId = AccountData.AccountId,
                UserName = txtUserName.Text.Trim(),
                Password = string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text.Trim(),
                Role = selectedRole,
                Status = selectedStatus
            };

            var result = _bll.Update(updateDto);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
