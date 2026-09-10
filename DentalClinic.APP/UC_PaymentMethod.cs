using DentalClinic.APP;
using DentalClinic.APP.Properties;
using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DentalClinic.App
{
    public partial class UC_PaymentMethod : UserControl
    {
        private readonly PaymentMethod_BLL _paymentMethodBLL;

        public UC_PaymentMethod(PaymentMethod_BLL paymentMethodBLL)
        {
            InitializeComponent();
            _paymentMethodBLL = paymentMethodBLL;
        }

        private void UC_Payment_Load(object sender, EventArgs e)
        {
            dgvPaymentMethod.AutoGenerateColumns = true;
            LoadStatusComboBox();
            LoadSortComboBox();
            LoadDataToGridView();
        }

        // LOAD DỮ LIỆU CHO DGV DANH SÁCH PTTT
        public void LoadDataToGridView()
        {
            PaymentMethodStatus? status = null;

            if (cbStatus.SelectedIndex == 1)
            {
                status = PaymentMethodStatus.Active;
            }
            else if (cbStatus.SelectedIndex == 2)
            {
                status = PaymentMethodStatus.Inactive;
            }

            var result = _paymentMethodBLL.GetAll(txtSearch.Text.Trim(), status);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var paymentMethods = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "IdAsc":
                    paymentMethods = paymentMethods.OrderBy(r => r.PaymentMethodId).ToList();
                    break;

                case "IdDesc":
                    paymentMethods = paymentMethods.OrderByDescending(r => r.PaymentMethodId).ToList();
                    break;

                case "NameAsc":
                    paymentMethods = paymentMethods.OrderBy(r => r.PaymentMethodName).ToList();
                    break;

                case "NameDesc":
                    paymentMethods = paymentMethods.OrderByDescending(r => r.PaymentMethodName).ToList();
                    break;
            }

            dgvPaymentMethod.DataSource = null;
            dgvPaymentMethod.DataSource = paymentMethods;

            AddActionImageColumns();

            var deleteColumn = dgvPaymentMethod.Columns["DeleteCol"];

            if (deleteColumn != null)
            {
                deleteColumn.DisplayIndex =
                    dgvPaymentMethod.Columns.Count - 1;
            }

            var editColumn = dgvPaymentMethod.Columns["EditCol"];

            if (editColumn != null && deleteColumn != null)
            {
                editColumn.DisplayIndex =
                    deleteColumn.DisplayIndex - 1;
            }
        }

        // THÊM CỘT SỬA VÀ CỘT XÓA CHO DGV
        private void AddActionImageColumns()
        {
            if (!dgvPaymentMethod.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewButtonColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };

                dgvPaymentMethod.Columns.Add(imgEdit);
            }

            if (!dgvPaymentMethod.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewButtonColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };

                dgvPaymentMethod.Columns.Add(imgDelete);
            }
        }

        // LOAD CB TRẠNG THÁI
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = (PaymentMethodStatus?)null, Text = "Tất cả" },
                new { Value = (PaymentMethodStatus?)PaymentMethodStatus.Active, Text = "Đang hoạt động" },
                new { Value = (PaymentMethodStatus?)PaymentMethodStatus.Inactive, Text = "Ngừng hoạt động" }
            };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        // LOAD CB SẮP XẾP
        private void LoadSortComboBox()
        {
            var sortList = new List<object>
            {
                new { Value = "IdAsc", Text = "Mã tăng dần" },
                new { Value = "IdDesc", Text = "Mã giảm dần" },
                new { Value = "NameAsc", Text = "Tên A-Z" },
                new { Value = "NameDesc", Text = "Tên Z-A" }
            };

            cbSort.DataSource = sortList;
            cbSort.DisplayMember = "Text";
            cbSort.ValueMember = "Value";
            cbSort.SelectedIndex = 0;
        }

        // ===========================================================

        // SỰ KIỆN NÚT THÊM
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialog_PaymentMethod(_paymentMethodBLL))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGridView();
                }
            }
        }

        // SỰ KIỆN NHẤN NÚT SỬA HOẶC XÓA TRONG DGV
        private void dgvPaymentMethod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvPaymentMethod.Rows[e.RowIndex].DataBoundItem as PaymentMethodDto;

            if (selectedDto == null) return;

            string colName = dgvPaymentMethod.Columns[e.ColumnIndex].Name;

            // Cột sửa
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_PaymentMethod(_paymentMethodBLL, selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataToGridView();
                    }
                }
            }

            // Cột xóa
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

        // EVENT TÌM KIẾM
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        // EVENT CB TRẠNG THÁI
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDataToGridView();
            }
        }

        // EVENT CB SẮP XẾP
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDataToGridView();
            }
        }
    }
}