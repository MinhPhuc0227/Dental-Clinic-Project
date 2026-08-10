using DentalClinic.BLL;
using DentalClinic.DTO.Service;
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
    public partial class Dialog_Service : Form
    {
        private readonly Service_BLL _bll = new Service_BLL();
        public ServiceDto? ServiceData { get; private set; }
        private readonly bool _isEdit = false;

        // Constructor 1: for Adding
        public Dialog_Service()
        {
            InitializeComponent();
            this.Text = "Thêm mới dịch vụ";
            _isEdit = false;
            lbServiceId.Text = "Tự động";
            LoadStatusComboBox();
        }

        // Constructor 2: for Updating
        public Dialog_Service(ServiceDto data) : this()
        {
            this.Text = "Chỉnh sửa dịch vụ";
            _isEdit = true;
            ServiceData = data;

            lbServiceId.Text = data.ServiceId.ToString();
            txtServiceName.Text = data.ServiceName;
            txtUnitPrice.Text = data.UnitPrice.ToString("G29");
            txtDescription.Text = data.Description;
            cbStatus.SelectedValue = data.Status;
        }

        // Load status combo box
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = ServiceStatus.Active, Display = "Kinh doanh" },
                new { Value = ServiceStatus.Inactive, Display = "Ngừng kinh doanh" }
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
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal unitPrice) || unitPrice < 0)
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ và lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitPrice.Focus();
                return;
            }

            var selectedStatus = cbStatus.SelectedValue != null
                ? (ServiceStatus)cbStatus.SelectedValue
                : ServiceStatus.Active;

            // Save new data to database (using BLL)
            if (!_isEdit)
            {
                var createDto = new CreateServiceDto
                {
                    ServiceName = txtServiceName.Text.Trim(),
                    UnitPrice = unitPrice,
                    Description = txtDescription.Text.Trim(),
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
                if (ServiceData == null) return;

                var updateDto = new UpdateServiceDto
                {
                    ServiceId = ServiceData.ServiceId,
                    ServiceName = txtServiceName.Text.Trim(),
                    UnitPrice = unitPrice,
                    Description = txtDescription.Text.Trim(),
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
