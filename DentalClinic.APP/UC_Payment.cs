using DentalClinic.APP;
using DentalClinic.BLL;
using DentalClinic.DTO.PaymentMethod;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DentalClinic.App
{
    public partial class UC_Payment : UserControl
    {
        private readonly PaymentMethod_BLL _bll = new PaymentMethod_BLL();

        public UC_Payment()
        {
            InitializeComponent();
        }

        private void UC_Payment_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDataToGridView();
        }

        // Config datagridview
        private void ConfigureDataGridView()
        {
            dgvPaymentMethod.AutoGenerateColumns = false;

            IdCol.DataPropertyName = nameof(PaymentMethodDto.PaymentMethodId);
            NameCol.DataPropertyName = nameof(PaymentMethodDto.PaymentMethodName);
            DescriptionCol.DataPropertyName = nameof(PaymentMethodDto.Description);
            IsCashCol.DataPropertyName = nameof(PaymentMethodDto.IsCash);
            StatusCol.DataPropertyName = nameof(PaymentMethodDto.StatusDisplay);
        }

        // Load datagridview
        public void LoadDataToGridView()
        {
            var result = _bll.GetAll();

            if (result.IsSuccess)
            {
                dgvPaymentMethod.DataSource = result.Data;
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add button
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_PaymentMethod())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var createDto = new CreatePaymentMethodDto
                    {
                        PaymentMethodName = dialog.PaymentData!.PaymentMethodName,
                        Description = dialog.PaymentData.Description,
                        IsCash = dialog.PaymentData.IsCash,
                        Status = dialog.PaymentData.Status
                    };

                    var result = _bll.Add(createDto);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Thêm mới phương thức thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToGridView();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Datagridview cell content click (Edit/Delete column)
        private void dgvPaymentMethod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvPaymentMethod.Rows[e.RowIndex].DataBoundItem as PaymentMethodDto;
            if (selectedDto == null) return;

            string colName = dgvPaymentMethod.Columns[e.ColumnIndex].Name;

            // Edit 
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_PaymentMethod(selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var updateDto = new UpdatePaymentMethodDto
                        {
                            PaymentMethodId = selectedDto.PaymentMethodId,
                            PaymentMethodName = dialog.PaymentData!.PaymentMethodName,
                            Description = dialog.PaymentData.Description,
                            IsCash = dialog.PaymentData.IsCash,
                            Status = dialog.PaymentData.Status
                        };

                        var result = _bll.Update(updateDto);

                        if (result.IsSuccess)
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataToGridView();
                        }
                        else
                        {
                            MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            // 2. Delete 
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa phương thức '{selectedDto.PaymentMethodName}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    var result = _bll.Delete(selectedDto.PaymentMethodId);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToGridView(); 
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
