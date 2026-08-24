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
    public partial class Dialog_Doctor : Form
    {
        private readonly Doctor_BLL _bll = new Doctor_BLL(new Doctor_DAL(new AppDbContext()));
        public DoctorDto? DoctorData { get; private set; }
        private readonly bool _isEdit = false;

        public Dialog_Doctor()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            this.Text = "Thêm mới bác sĩ";
            _isEdit = false;

            lbDoctorId.Text = "Tự động";
            lbAccountId.Text = "Tự động";
            lbCreatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            LoadEnumComboBoxes();
        }

        public Dialog_Doctor(DoctorDto data) : this()
        {
            this.Text = "Chỉnh sửa thông tin bác sĩ";
            pnAccount.Enabled = false;
            txtPassword.UseSystemPasswordChar = true;
            _isEdit = true;
            DoctorData = data;

            lbDoctorId.Text = data.DoctorId.ToString();
            txtFullName.Text = data.FullName;
            cbGender.SelectedValue = data.Gender;
            dtpDateOfBirth.Value = data.DateOfBirth.ToDateTime(TimeOnly.MinValue);
            txtPhone.Text = data.Phone;
            txtEmail.Text = data.Email;
            txtDescription.Text = data.Description;

            lbAccountId.Text = data.AccountId.ToString();
            txtUserName.Text = data.UserName;
            txtPassword.Text = string.Empty; // empty when updating 
            cbStatus.SelectedValue = data.Status;
            lbCreatedDate.Text = data.CreatedAt.ToString("dd/MM/yyyy HH:mm");
        }

        // Load gender, role, status combobox
        private void LoadEnumComboBoxes()
        {
            cbGender.DataSource = new[]
            {
                new { Value = Gender.Male, Display = "Nam" },
                new { Value = Gender.Female, Display = "Nữ" },
                new { Value = Gender.Other, Display = "Khác" }
            };
            cbGender.DisplayMember = "Display";
            cbGender.ValueMember = "Value";

            cbRole.DataSource = new[] { new { Value = AccountRole.Doctor, Display = "Bác sĩ" } };
            cbRole.DisplayMember = "Display";
            cbRole.ValueMember = "Value";
            cbRole.Enabled = false;

            cbStatus.DataSource = new[]
            {
                new { Value = AccountStatus.Active, Display = "Hoạt động" },
                new { Value = AccountStatus.Inactive, Display = "Ngừng hoạt động" },
                new { Value = AccountStatus.Locked, Display = "Khóa" }
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
            var selectedGender = cbGender.SelectedValue != null
                ? (Gender)cbGender.SelectedValue
                : Gender.Male;

            var selectedStatus = cbStatus.SelectedValue != null
                ? (AccountStatus)cbStatus.SelectedValue
                : AccountStatus.Active;

            var dateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);

            if (!_isEdit)
            {
                var createDto = new CreateDoctorDto
                {
                    FullName = txtFullName.Text.Trim(),
                    Gender = selectedGender,
                    DateOfBirth = dateOfBirth,
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Status = selectedStatus
                };

                var result = _bll.Add(createDto);
                if (!result.IsSuccess)
                {
                    MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DoctorData == null) return;

                var updateDto = new UpdateDoctorDto
                {
                    DoctorId = DoctorData.DoctorId,
                    AccountId = DoctorData.AccountId,
                    FullName = txtFullName.Text.Trim(),
                    Gender = selectedGender,
                    DateOfBirth = dateOfBirth,
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    Password = string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text.Trim(),
                    Status = selectedStatus
                };

                var result = _bll.Update(updateDto);
                if (!result.IsSuccess)
                {
                    MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Dialog_Doctor_Load(object sender, EventArgs e)
        {
            txtFullName.Focus();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
