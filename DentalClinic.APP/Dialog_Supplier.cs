using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_Supplier : Form
    {
        private readonly Supplier_BLL _supplierBLL;
        private readonly int? _supplierId;

        public Dialog_Supplier(Supplier_BLL supplierBLL, int? supplierId)
        {
            InitializeComponent();
            _supplierBLL = supplierBLL;
            _supplierId = supplierId;
        }

        private void Dialog_Supplier_Load(object sender, EventArgs e)
        {
            LoadStatus();

            if (_supplierId.HasValue && _supplierId.Value > 0)
            {
                Text = "Cập nhật nhà cung cấp";
                LoadSupplier(_supplierId.Value);
            }
            else
            {
                Text = "Thêm nhà cung cấp";
                cbStatus.SelectedValue = true;
            }
        }

        // STATUS

        private void LoadStatus()
        {
            var statusList =
                new[]
                {
                    new
                    {
                        Value = true,
                        Text = "Đang hoạt động"
                    },

                    new
                    {
                        Value = false,
                        Text = "Ngừng hoạt động"
                    }
                };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
        }

        // LOAD DETAIL

        private void LoadSupplier(int id)
        {
            var result = _supplierBLL.GetById(id);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(
                    result.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
                return;
            }

            var supplier = result.Data;
            txtSupplierName.Text = supplier.SupplierName;
            txtPhone.Text = supplier.Phone ?? "";
            txtAddress.Text = supplier.Address ?? "";
            txtEmail.Text = supplier.Email ?? "";
            txtNote.Text = supplier.Note ?? "";
            cbStatus.SelectedValue = supplier.IsActive;
        }

        // SAVE

        private void btSave_Click(object sender, EventArgs e)
        {
            Result result;

            if (!_supplierId.HasValue)
            {
                var dto =
                    new SupplierCreateDto
                    {
                        SupplierName = txtSupplierName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Note = txtNote.Text.Trim()
                    };

                result = _supplierBLL.Create(dto);
            }
            else
            {
                bool isActive = cbStatus.SelectedValue is bool value && value;

                var dto =
                    new SupplierUpdateDto
                    {
                        SupplierId = _supplierId.Value,
                        SupplierName = txtSupplierName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Note = txtNote.Text.Trim(),
                        IsActive = isActive
                    };

                result = _supplierBLL.Update(dto);
            }

            if (result.IsSuccess)
            {
                MessageBox.Show(
                    result.Message,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Không thể lưu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // CANCEL
        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
