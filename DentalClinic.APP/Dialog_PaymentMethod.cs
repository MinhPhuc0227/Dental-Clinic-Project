using DentalClinic.DTO.PaymentMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_PaymentMethod : Form
    {
        public PaymentMethodDto? PaymentData { get; private set; }

        // Constructor 1: Adding form
        public Dialog_PaymentMethod()
        {
            InitializeComponent();
            this.Text = "Thêm phương thức thanh toán";
            LoadStatusComboBox();
        }

        // Constructor 2: Editing form (with existing data)
        public Dialog_PaymentMethod(PaymentMethodDto data) : this()
        {
            this.Text = "Sửa phương thức thanh toán";
            PaymentData = data;

            txtName.Text = data.PaymentMethodName;
            txtDescription.Text = data.Description;
            checkBoxIsCash.Checked = data.IsCash;
            cbStatus.SelectedValue = data.Status; 
        }

        // Load status combo box (add en -> vi)
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = DentalClinic.MODEL.PaymentMethodStatus.Active, Display = "Hoạt động" },
                new { Value = DentalClinic.MODEL.PaymentMethodStatus.Inactive, Display = "Ngừng hoạt động" }
            };

            cbStatus.DataSource = statusList;
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phương thức!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (PaymentData == null) PaymentData = new PaymentMethodDto();

            PaymentData.PaymentMethodName = txtName.Text.Trim();
            PaymentData.Description = txtDescription.Text.Trim();
            PaymentData.IsCash = checkBoxIsCash.Checked;

            if (cbStatus.SelectedValue != null)
            {
                PaymentData.Status = (DentalClinic.MODEL.PaymentMethodStatus)cbStatus.SelectedValue;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
