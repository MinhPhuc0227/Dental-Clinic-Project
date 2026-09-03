using DentalClinic.APP;
using DentalClinic.APP.Properties;
using DentalClinic.BLL;
using DentalClinic.DTO;
using System;
using System.Windows.Forms;

namespace DentalClinic.App
{
    public partial class UC_PaymentMethod : UserControl
    {
        private readonly PaymentMethod_BLL _paymentMethodBLL;
        private List<PaymentMethodDto> _fullList = new List<PaymentMethodDto>();

        public UC_PaymentMethod(PaymentMethod_BLL paymentMethodBLL)
        {
            InitializeComponent();
            _paymentMethodBLL = paymentMethodBLL;
        }

        private void UC_Payment_Load(object sender, EventArgs e)
        {
            dgvPaymentMethod.AutoGenerateColumns = true;
            LoadDataToGridView();
        }

        // Load data to datagridview
        public void LoadDataToGridView()
        {
            var result = _paymentMethodBLL.GetAll();
            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;
                dgvPaymentMethod.DataSource = _fullList;
                AddActionImageColumns();
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add edit, delete image columns
        private void AddActionImageColumns()
        {
            if (!dgvPaymentMethod.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Image = Resources.edit,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvPaymentMethod.Columns.Add(imgEdit);
            }

            if (!dgvPaymentMethod.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Image = Resources.delete,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvPaymentMethod.Columns.Add(imgDelete);
            }
        }

        // Add button
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_PaymentMethod(_paymentMethodBLL))
            {
                if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
            }
        }

        // Cellcontentclick (Edite/Delete)
        private void dgvPaymentMethod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvPaymentMethod.Rows[e.RowIndex].DataBoundItem as PaymentMethodDto;
            if (selectedDto == null) return;

            string colName = dgvPaymentMethod.Columns[e.ColumnIndex].Name;

            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_PaymentMethod(_paymentMethodBLL, selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK) LoadDataToGridView();
                }
            }
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa phương thức '{selectedDto.PaymentMethodName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var result = _paymentMethodBLL.Delete(selectedDto.PaymentMethodId);
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

        // Search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvPaymentMethod.DataSource = _fullList;
            }
            else
            {
                dgvPaymentMethod.DataSource = _fullList.Where(pm => pm.PaymentMethodName.ToLower().Contains(keyword)
                                                                 || (pm.Description != null && pm.Description.ToLower().Contains(keyword))).ToList();
            }
        }
    }
}