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
    public partial class Dialog_Receptionist : Form
    {
        private readonly Receptionist_BLL _bll;
        public ReceptionistDto? ReceptionistData { get; private set; }
        private readonly bool _isEdit = false;

        public Dialog_Receptionist(Receptionist_BLL bll)
        {
            InitializeComponent();
            _bll = bll;
            txtPassword.UseSystemPasswordChar = true;
            this.Text = "Thêm mới lễ tân";
            _isEdit = false;

            lbReceptionistId.Text = "Tự động";
            lbAccountId.Text = "Tự động";
            lbCreatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            LoadComboBoxes();
        }

        //public Dialog_Receptionist(ReceptionistDto data) : this()
        //{
        //    this.Text = "Chỉnh sửa thông tin lễ tân";
        //    pnAccount.Enabled = false;
        //    txtPassword.UseSystemPasswordChar = true;
        //    _isEdit = true;
        //    ReceptionistData = data;

        //    lbReceptionistId.Text = data.ReceptionistId.ToString();
        //    txtFullName.Text = data.FullName;
        //    cbGender.SelectedValue = data.Gender;
        //    dtpDateOfBirth.Value = data.DateOfBirth.ToDateTime(TimeOnly.MinValue);
        //    txtPhone.Text = data.Phone;
        //    txtEmail.Text = data.Email;
        //    txtDescription.Text = data.Description;

        //    lbAccountId.Text = data.AccountId.ToString();
        //    txtUserName.Text = data.UserName;
        //    txtPassword.Text = string.Empty;
        //    cbStatus.SelectedValue = data.Status;
        //    lbCreatedDate.Text = data.CreatedAt.ToString("dd/MM/yyyy HH:mm");
        //}

        private readonly bool _viewOnly = false;
        public Dialog_Receptionist(
    Receptionist_BLL bll,
    ReceptionistDto data,
    bool viewOnly = false) : this(bll)
        {
            this.Text = viewOnly
                ? "Thông tin lễ tân"
                : "Chỉnh sửa thông tin lễ tân";

            _viewOnly = viewOnly;

            pnAccount.Enabled = false;

            _isEdit = true;
            ReceptionistData = data;

            lbReceptionistId.Text = data.ReceptionistId.ToString();

            txtFullName.Text = data.FullName;
            cbGender.SelectedValue = data.Gender;
            dtpDateOfBirth.Value =
                data.DateOfBirth.ToDateTime(TimeOnly.MinValue);

            txtPhone.Text = data.Phone;
            txtEmail.Text = data.Email;
            txtDescription.Text = data.Description;

            lbAccountId.Text = data.AccountId.ToString();

            txtUserName.Text = data.UserName;
            txtPassword.Text = string.Empty;

            cbStatus.SelectedValue = data.Status;

            lbCreatedDate.Text =
                data.CreatedAt.ToString("dd/MM/yyyy HH:mm");

            if (viewOnly)
            {
                SetViewOnly();
            }
        }

        private void SetViewOnly()
        {
            txtFullName.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDescription.ReadOnly = true;

            cbGender.Enabled = false;
            dtpDateOfBirth.Enabled = false;
            cbStatus.Enabled = false;

            txtUserName.ReadOnly = true;

            btSave.Visible = false;
        }

        // Load gender, role, status combo box
        private void LoadComboBoxes()
        {
            cbGender.DataSource = new[]
            {
                new { Value = Gender.Male, Display = "Nam" },
                new { Value = Gender.Female, Display = "Nữ" },
                new { Value = Gender.Other, Display = "Khác" }
            };
            cbGender.DisplayMember = "Display";
            cbGender.ValueMember = "Value";

            cbRole.DataSource = new[] { new { Value = AccountRole.Receptionist, Display = "Lễ tân" } };
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
            var selectedGender = cbGender.SelectedValue != null ? (Gender)cbGender.SelectedValue : Gender.Female;
            var selectedStatus = cbStatus.SelectedValue != null ? (AccountStatus)cbStatus.SelectedValue : AccountStatus.Active;
            var dateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);

            if (!_isEdit)
            {
                var createDto = new CreateReceptionistDto
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
                if (ReceptionistData == null) return;

                var updateDto = new UpdateReceptionistDto
                {
                    ReceptionistId = ReceptionistData.ReceptionistId,
                    AccountId = ReceptionistData.AccountId,
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

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dialog_Receptionist_Load(object sender, EventArgs e)
        {
            txtFullName.Focus();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
