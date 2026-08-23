using DentalClinic.BLL;
using DentalClinic.DTO;
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

        public Dialog_PaymentMethod()
        {
            InitializeComponent();
            this.Text = "Thêm phương thức thanh toán";
            _isEdit = false;

            lbPaymentMethodId.Text = "Tự động";
            LoadComboBoxes();
        }

        public Dialog_PaymentMethod(PaymentMethodDto data) : this()
        {
            this.Text = "Chỉnh sửa phương thức thanh toán";
            _isEdit = true;
            PaymentData = data;

            lbPaymentMethodId.Text = data.PaymentMethodId.ToString();
            txtPaymentMethodName.Text = data.PaymentMethodName;
            txtDescription.Text = data.Description;
            chkIsCash.Checked = data.IsCash;
            cbStatus.SelectedValue = data.Status;
        }

        // Load status combobox
        private void LoadComboBoxes()
        {
            cbStatus.DataSource = new[]
            {
                new { Value = PaymentMethodStatus.Active, Display = "Hoạt động" },
                new { Value = PaymentMethodStatus.Inactive, Display = "Ngừng hoạt động" }
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
            var selectedStatus = cbStatus.SelectedValue != null ? (PaymentMethodStatus)cbStatus.SelectedValue : PaymentMethodStatus.Active;

            // Add
            if (!_isEdit)
            {
                var createDto = new CreatePaymentMethodDto
                {
                    PaymentMethodName = txtPaymentMethodName.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                    IsCash = chkIsCash.Checked,
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
            // Edit
            else
            {
                if (PaymentData == null) return;

                var updateDto = new UpdatePaymentMethodDto
                {
                    PaymentMethodId = PaymentData.PaymentMethodId,
                    PaymentMethodName = txtPaymentMethodName.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                    IsCash = chkIsCash.Checked,
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

        private void Dialog_PaymentMethod_Load(object sender, EventArgs e)
        {
            txtPaymentMethodName.Focus();
        }
    }
}