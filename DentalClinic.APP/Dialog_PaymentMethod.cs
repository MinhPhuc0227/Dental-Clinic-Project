using DentalClinic.BLL;
using DentalClinic.DTO.PaymentMethod;
using DentalClinic.MODEL;
using System;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_PaymentMethod : Form
    {
        private readonly PaymentMethod_BLL _bll = new PaymentMethod_BLL();
        public PaymentMethodDto? PaymentData { get; private set; }
        private readonly bool _isEdit = false;

        // Constructor 1: for Adding 
        public Dialog_PaymentMethod()
        {
            InitializeComponent();
            this.Text = "Thêm phương thức thanh toán";
            _isEdit = false;
            LoadStatusComboBox();
        }

        // Constructor 2: for Updating 
        public Dialog_PaymentMethod(PaymentMethodDto data) : this()
        {
            this.Text = "Sửa phương thức thanh toán";
            _isEdit = true;
            PaymentData = data;

            txtName.Text = data.PaymentMethodName;
            txtDescription.Text = data.Description;
            checkBoxIsCash.Checked = data.IsCash;
            cbStatus.SelectedValue = data.Status;
        }

        // Load status combo box
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = PaymentMethodStatus.Active, Display = "Hoạt động" },
                new { Value = PaymentMethodStatus.Inactive, Display = "Ngừng hoạt động" }
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

            var selectedStatus = cbStatus.SelectedValue != null
                ? (PaymentMethodStatus)cbStatus.SelectedValue
                : PaymentMethodStatus.Active;

            // Save new data to database (using BLL)
            if (!_isEdit)
            {
                // Add
                var createDto = new CreatePaymentMethodDto
                {
                    PaymentMethodName = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    IsCash = checkBoxIsCash.Checked,
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
                // Update
                if (PaymentData == null) return;

                var updateDto = new UpdatePaymentMethodDto
                {
                    PaymentMethodId = PaymentData.PaymentMethodId,
                    PaymentMethodName = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    IsCash = checkBoxIsCash.Checked,
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
    }
}