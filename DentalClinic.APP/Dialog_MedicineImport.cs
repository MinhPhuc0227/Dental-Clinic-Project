using DentalClinic.BLL;
using DentalClinic.DAL;
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
    public partial class Dialog_MedicineImport : Form
    {
        private DateTime _importDate;
        private readonly int _accountId;

        private readonly MedicineImport_BLL _importBLL =
            new MedicineImport_BLL();

        private readonly Supplier_BLL _supplierBLL =
            new Supplier_BLL();

        private readonly Medicine_BLL _medicineBLL =
            new Medicine_BLL();

        private readonly Invoice_BLL _invoiceBLL =
            new Invoice_BLL();

        private readonly Account_BLL _accountBLL =
            new Account_BLL();

        private BindingList<MedicineImportItemDto> _items =
            new BindingList<MedicineImportItemDto>();

        public Dialog_MedicineImport(int accountId)
        {
            InitializeComponent();

            _accountId = accountId;

            StartPosition =
                FormStartPosition.CenterParent;
        }

        private void Dialog_MedicineImport_Load(
    object sender,
    EventArgs e)
        {
            lbImportId.Text = "Tự động";

            _importDate = DateTime.Now;

            lbImportDate.Text =
                _importDate.ToString("dd/MM/yyyy HH:mm");

            LoadAccount();
            LoadSuppliers();
            LoadMedicines();
            LoadPaymentMethods();

            SetupImportGrid();

            cbSupplier.SelectedIndex = -1;
            cbMedicine.SelectedIndex = -1;

            txtCurrentStock.Text = "0";
        }

        private void LoadAccount()
        {
            using var context =
                new AppDbContext();

            var account =
                context.Accounts
                    .FirstOrDefault(a =>
                        a.AccountId == _accountId);

            if (account == null)
            {
                MessageBox.Show(
                    "Không tìm thấy tài khoản đăng nhập.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();

                return;
            }

            if (account.Role != AccountRole.Admin)
            {
                MessageBox.Show(
                    "Chỉ Admin mới được nhập kho.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();

                return;
            }

            lbAccountName.Text =
                account.UserName;
        }

        private void LoadSuppliers()
        {
            var result =
                _supplierBLL.GetAll("", true);

            if (result.IsSuccess &&
                result.Data != null)
            {
                cbSupplier.DataSource =
                    result.Data;

                cbSupplier.DisplayMember =
                    "SupplierName";

                cbSupplier.ValueMember =
                    "SupplierId";

                cbSupplier.SelectedIndex =
                    -1;
            }
        }

        private void LoadMedicines()
        {
            var result =
                _medicineBLL.GetAll();

            if (result.IsSuccess &&
                result.Data != null)
            {
                var medicines =
                    result.Data
                        .Where(m =>
                            m.Status ==
                            MedicineStatus.Active)
                        .ToList();

                cbMedicine.DataSource =
                    medicines;

                cbMedicine.DisplayMember =
                    "MedicineName";

                cbMedicine.ValueMember =
                    "MedicineId";

                cbMedicine.SelectedIndex =
                    -1;
            }
        }

        private void LoadPaymentMethods()
        {
            var methods =
                _invoiceBLL.GetPaymentMethods();

            cbPaymentMethod.DataSource = null;

            cbPaymentMethod.DisplayMember = "PaymentMethodName";
            cbPaymentMethod.ValueMember = "PaymentMethodId";
            cbPaymentMethod.DataSource = methods;

            if (methods.Count > 0)
            {
                // Có phương thức → chọn phương thức đầu tiên
                cbPaymentMethod.SelectedIndex = 0;
            }
            else
            {
                // Không có phương thức → để trống
                cbPaymentMethod.SelectedIndex = -1;
            }
        }

        private void cbMedicine_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            if (cbMedicine.SelectedValue is not int medicineId)
            {
                txtCurrentStock.Text = "0";
                return;
            }

            var result =
                _medicineBLL.GetById(
                    medicineId);

            if (result.IsSuccess &&
                result.Data != null)
            {
                txtCurrentStock.Text =
                    result.Data.QuantityInStock
                        .ToString();
            }
            else
            {
                txtCurrentStock.Text = "0";
            }
        }

        private void SetupImportGrid()
        {
            dgvImportDetail.AutoGenerateColumns = false;
            dgvImportDetail.Columns.Clear();

            // Tên thuốc - chỉ xem
            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMedicineName",
                    DataPropertyName = "MedicineName",
                    HeaderText = "Tên thuốc",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });

            // Đơn vị - chỉ xem
            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colUnit",
                    DataPropertyName = "Unit",
                    HeaderText = "Đơn vị",
                    Width = 80,
                    ReadOnly = true
                });

            // Số lượng - CHO PHÉP SỬA
            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colQuantity",
                    DataPropertyName = "Quantity",
                    HeaderText = "SL nhập",
                    Width = 80,
                    ReadOnly = false,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment =
                            DataGridViewContentAlignment.MiddleCenter
                    }
                });

            // Giá nhập - CHO PHÉP SỬA
            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colImportPrice",
                    DataPropertyName = "UnitImportPrice",
                    HeaderText = "Giá nhập",
                    Width = 110,
                    ReadOnly = false,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "N0",
                        Alignment =
                            DataGridViewContentAlignment.MiddleRight
                    }
                });

            // Thành tiền - KHÔNG CHO SỬA
            dgvImportDetail.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colTotal",
                    DataPropertyName = "TotalAmount",
                    HeaderText = "Thành tiền",
                    Width = 130,
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "N0",
                        Alignment =
                            DataGridViewContentAlignment.MiddleRight
                    }
                });

            // Xóa
            dgvImportDetail.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true,
                    Width = 60
                });

            dgvImportDetail.DataSource = _items;

            dgvImportDetail.AllowUserToAddRows = false;
            dgvImportDetail.RowHeadersVisible = false;
            dgvImportDetail.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Đăng ký sự kiện sửa dữ liệu
            dgvImportDetail.CellEndEdit +=
                dgvImportDetail_CellEndEdit;

            dgvImportDetail.CellValidating +=
                dgvImportDetail_CellValidating;

            dgvImportDetail.DataError +=
                dgvImportDetail_DataError;
        }

        private void btAddMedicine_Click(
    object sender,
    EventArgs e)
        {
            if (cbMedicine.SelectedValue is not int medicineId)
            {
                MessageBox.Show(
                    "Vui lòng chọn thuốc.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(
                txtQuantity.Text.Trim(),
                out int quantity))
            {
                MessageBox.Show(
                    "Số lượng nhập không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!decimal.TryParse(
                txtImportPrice.Text
                    .Replace(",", "")
                    .Trim(),
                out decimal importPrice))
            {
                MessageBox.Show(
                    "Giá nhập không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show(
                    "Số lượng nhập phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (importPrice <= 0)
            {
                MessageBox.Show(
                    "Giá nhập phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Không cho trùng thuốc
            if (_items.Any(x =>
                x.MedicineId == medicineId))
            {
                MessageBox.Show(
                    "Thuốc này đã có trong phiếu nhập.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var result =
                _medicineBLL.GetById(
                    medicineId);

            if (!result.IsSuccess ||
                result.Data == null)
            {
                MessageBox.Show(
                    "Không tìm thấy thuốc.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var medicine =
                result.Data;

            if (medicine.Status !=
                MedicineStatus.Active)
            {
                MessageBox.Show(
                    "Thuốc này đã ngừng hoạt động.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _items.Add(
                new MedicineImportItemDto
                {
                    MedicineId =
                        medicine.MedicineId,

                    MedicineName =
                        medicine.MedicineName,

                    Unit =
                        medicine.Unit,

                    Quantity =
                        quantity,

                    UnitImportPrice =
                        importPrice
                });

            dgvImportDetail.Refresh();

            CalculateTotal();

            // Reset input
            cbMedicine.SelectedIndex = -1;

            txtCurrentStock.Text = "0";

            txtQuantity.Clear();

            txtImportPrice.Clear();

            cbMedicine.Focus();
        }

        private void CalculateTotal()
        {
            decimal total =
                _items.Sum(x =>
                    x.TotalAmount);

            lbTotalAmount.Text =
                total.ToString("N0") +
                " VNĐ";
        }

        private void dgvImportDetail_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvImportDetail
                .Columns[e.ColumnIndex]
                .Name != "colDelete")
            {
                return;
            }

            var confirm =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa thuốc này khỏi phiếu nhập?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            _items.RemoveAt(e.RowIndex);

            CalculateTotal();
        }

        private void btConfirmImport_Click(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedValue is not int supplierId)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cbPaymentMethod.SelectedValue is not int paymentMethodId)
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức thanh toán.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_items.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng thêm ít nhất một loại thuốc.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_importDate > DateTime.Now)
            {
                MessageBox.Show(
                    "Ngày nhập không được lớn hơn thời gian hiện tại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal total =
                _items.Sum(x =>
                    x.TotalAmount);

            var confirm =
                MessageBox.Show(
                    $"Xác nhận nhập kho?\n\n" +
                    $"Số loại thuốc: {_items.Count}\n" +
                    $"Tổng tiền: {total:N0} VNĐ",
                    "Xác nhận nhập kho",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            var dto =
                new CreateMedicineImportDto
                {
                    SupplierId =
                        supplierId,

                    AccountId =
                        _accountId,

                    PaymentMethodId =
                        paymentMethodId,

                    ImportDate = _importDate,

                    Note =
                        string.IsNullOrWhiteSpace(
                            txtNote.Text)
                            ? null
                            : txtNote.Text.Trim(),

                    Items =
                        _items.ToList()
                };

            var result =
                _importBLL.Create(dto);

            if (result.IsSuccess)
            {
                MessageBox.Show(
                    result.Message,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Không thể nhập kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvImportDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName =
                dgvImportDetail.Columns[e.ColumnIndex].Name;

            if (columnName == "colQuantity" ||
                columnName == "colImportPrice")
            {
                dgvImportDetail.Refresh();

                CalculateTotal();
            }
        }

        private void dgvImportDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName =
                dgvImportDetail.Columns[e.ColumnIndex].Name;

            string value =
                e.FormattedValue?.ToString()?.Trim() ?? "";

            // =========================
            // KIỂM TRA SỐ LƯỢNG
            // =========================
            if (columnName == "colQuantity")
            {
                if (!int.TryParse(value, out int quantity) ||
                    quantity <= 0)
                {
                    e.Cancel = true;

                    MessageBox.Show(
                        "Số lượng nhập phải là số nguyên lớn hơn 0.",
                        "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            // =========================
            // KIỂM TRA GIÁ NHẬP
            // =========================
            if (columnName == "colImportPrice")
            {
                string rawValue =
                    value.Replace(",", "");

                if (!decimal.TryParse(
                        rawValue,
                        out decimal price) ||
                    price <= 0)
                {
                    e.Cancel = true;

                    MessageBox.Show(
                        "Giá nhập phải là số lớn hơn 0.",
                        "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }
        }

        private void dgvImportDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            MessageBox.Show(
                "Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại số lượng hoặc giá nhập.",
                "Dữ liệu không hợp lệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
