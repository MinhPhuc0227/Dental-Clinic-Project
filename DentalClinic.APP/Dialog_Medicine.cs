using DentalClinic.BLL;
using DentalClinic.DTO.Medicine;
using DentalClinic.MODEL;
using System;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_Medicine : Form
    {
        private readonly Medicine_BLL _bll = new Medicine_BLL();
        public MedicineDto? MedicineData { get; private set; }
        private readonly bool _isEdit = false;

        // Constructor 1: for Adding 
        public Dialog_Medicine()
        {
            InitializeComponent();
            this.Text = "Thêm mới thuốc";
            _isEdit = false;
            lbMedicineId.Text = "Tự động";
            LoadStatusComboBox();
        }

        // Constructor 2: for Updating
        public Dialog_Medicine(MedicineDto data) : this()
        {
            this.Text = "Chỉnh sửa thông tin thuốc";
            _isEdit = true;
            MedicineData = data;

            lbMedicineId.Text = data.MedicineId.ToString();
            txtMedicineName.Text = data.MedicineName;
            txtUnit.Text = data.Unit;
            txtUnitPrice.Text = data.UnitPrice.ToString("G29");

            var stockControl = Controls.Find("txtQuantityInStock", true);
            if (stockControl.Length > 0)
                stockControl[0].Text = data.QuantityInStock.ToString();

            txtDescription.Text = data.Description;
            cbStatus.SelectedValue = data.Status;
        }

        // Load Status ComboBox 
        private void LoadStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = MedicineStatus.Active, Display = "Kinh doanh" },
                new { Value = MedicineStatus.Inactive, Display = "Ngừng kinh doanh" }
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
            if (string.IsNullOrWhiteSpace(txtMedicineName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedicineName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Focus();
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal unitPrice) || unitPrice < 0)
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ và lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitPrice.Focus();
                return;
            }

            int quantityInStock = 0;
            var stockControl = Controls.Find("txtQuantityInStock", true);
            if (stockControl.Length > 0 && !int.TryParse(stockControl[0].Text.Trim(), out quantityInStock))
            {
                MessageBox.Show("Số lượng tồn kho phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stockControl[0].Focus();
                return;
            }

            var selectedStatus = cbStatus.SelectedValue != null
                ? (MedicineStatus)cbStatus.SelectedValue
                : MedicineStatus.Active;

            // Save data to database (using BLL)
            if (!_isEdit)
            {
                // Add 
                var createDto = new CreateMedicineDto
                {
                    MedicineName = txtMedicineName.Text.Trim(),
                    Unit = txtUnit.Text.Trim(),
                    UnitPrice = unitPrice,
                    QuantityInStock = quantityInStock,
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
                // Update
                if (MedicineData == null) return;

                var updateDto = new UpdateMedicineDto
                {
                    MedicineId = MedicineData.MedicineId,
                    MedicineName = txtMedicineName.Text.Trim(),
                    Unit = txtUnit.Text.Trim(),
                    UnitPrice = unitPrice,
                    QuantityInStock = quantityInStock,
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

        private void Dialog_Medicine_Load(object sender, EventArgs e)
        {
            txtMedicineName.Focus();
        }
    }
}