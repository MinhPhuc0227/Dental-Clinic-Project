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
    public partial class Dialog_Patient : Form
    {
        public PatientDto? PatientData { get; private set; }
        private readonly bool _isEdit = false;
        public int CreatedPatientId { get; private set; }

        private readonly Patient_BLL _bll;

        public Dialog_Patient(Patient_BLL bll)
        {
            InitializeComponent();
            _bll = bll;
            this.Text = "Thêm mới bệnh nhân";
            _isEdit = false;
            lbPatientId.Text = "Tự động";
            LoadComboBoxes();
        }

        public Dialog_Patient(Patient_BLL bll, PatientDto data) : this(bll)
        {
            this.Text = "Chỉnh sửa thông tin bệnh nhân";
            _isEdit = true;
            PatientData = data;
            lbPatientId.Text = data.PatientId.ToString();
            txtFullName.Text = data.FullName;
            cbGender.SelectedValue = data.Gender;
            dtpDateOfBirth.Value = data.DateOfBirth.ToDateTime(TimeOnly.MinValue);
            txtPhone.Text = data.Phone;
            txtEmail.Text = data.Email;
            txtAddress.Text = data.Address;
            txtNote.Text = data.Note;
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
        }

        // Cancel
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Save 
        private void btSave_Click(object sender, EventArgs e)
        {
            var selectedGender = cbGender.SelectedValue != null ? (Gender)cbGender.SelectedValue : Gender.Male;
            var dateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);

            // ADD
            if (!_isEdit)
            {
                var createDto = new CreatePatientDto
                {
                    FullName = txtFullName.Text.Trim(),
                    Gender = selectedGender,
                    DateOfBirth = dateOfBirth,
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Note = txtNote.Text.Trim(),
                };

                var result = _bll.Add(createDto);
                if (!result.IsSuccess)
                {
                    MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CreatedPatientId = result.Data;

                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // UPDATE
            else
            {
                if (PatientData == null) return;

                var updateDto = new UpdatePatientDto
                {
                    PatientId = PatientData.PatientId,
                    FullName = txtFullName.Text.Trim(),
                    Gender = selectedGender,
                    DateOfBirth = dateOfBirth,
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Note = txtNote.Text.Trim(),
                };

                var result = _bll.Update(updateDto);
                if (!result.IsSuccess)
                {
                    MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CreatedPatientId = PatientData.PatientId;

                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Dialog_Patient_Load(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => txtFullName.Focus()));
        }
    }
}
