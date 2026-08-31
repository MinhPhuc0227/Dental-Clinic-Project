using DentalClinic.BLL;
using DentalClinic.DAL;
using DentalClinic.DTO;
using System;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_PatientHistory : Form
    {
        private readonly int _visitId;

        private readonly MedicalRecord_BLL _medicalRecordBLL =
            new MedicalRecord_BLL(
                new MedicalRecord_DAL(
                    new AppDbContext()));

        public Dialog_PatientHistory(
            int visitId,
            string patientName)
        {
            InitializeComponent();

            _visitId = visitId;

            Text = $"Lịch sử khám - {patientName}";
            StartPosition = FormStartPosition.CenterParent;
        }

        private void Dialog_PatientHistory_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                SetupHistoryGrid();
                SetupServiceGrid();
                SetupMedicineGrid();

                LoadHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khởi tạo lịch sử khám:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // 1. BẢNG LỊCH SỬ KHÁM
        // =====================================================
        private void SetupHistoryGrid()
        {
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colVisitId",
                    DataPropertyName = "VisitId",
                    Visible = false
                });

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ExaminationDate",
                    HeaderText = "Ngày Khám",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy"
                    }
                });

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DoctorName",
                    HeaderText = "Bác Sĩ",
                    Width = 150
                });

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Diagnosis",
                    HeaderText = "Chẩn Đoán",
                    Width = 250
                });

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Conclusion",
                    HeaderText = "Kết Luận",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            dgvHistory.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHistory.MultiSelect = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.RowHeadersVisible = false;
        }

        // =====================================================
        // 2. BẢNG DỊCH VỤ
        // =====================================================
        private void SetupServiceGrid()
        {
            dgvServices.AutoGenerateColumns = false;
            dgvServices.Columns.Clear();

            dgvServices.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ServiceName",
                    HeaderText = "Tên Dịch Vụ",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            dgvServices.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "Số Lượng",
                    Width = 100
                });

            dgvServices.ReadOnly = true;
            dgvServices.AllowUserToAddRows = false;
            dgvServices.RowHeadersVisible = false;
        }

        // =====================================================
        // 3. BẢNG THUỐC
        // =====================================================
        private void SetupMedicineGrid()
        {
            dgvMedicines.AutoGenerateColumns = false;
            dgvMedicines.Columns.Clear();

            dgvMedicines.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MedicineName",
                    HeaderText = "Tên Thuốc",
                    Width = 180
                });

            dgvMedicines.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "Số Lượng",
                    Width = 100
                });

            dgvMedicines.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Instruction",
                    HeaderText = "Cách Dùng",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            dgvMedicines.ReadOnly = true;
            dgvMedicines.AllowUserToAddRows = false;
            dgvMedicines.RowHeadersVisible = false;
        }

        // =====================================================
        // 4. LOAD LỊCH SỬ
        // =====================================================
        private void LoadHistory()
        {
            var history =
                _medicalRecordBLL.GetPatientHistory(_visitId);

            if (history == null || history.Count == 0)
            {
                dgvHistory.DataSource = null;
                dgvServices.DataSource = null;
                dgvMedicines.DataSource = null;

                MessageBox.Show(
                    "Bệnh nhân chưa có lịch sử khám hoàn thành.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            dgvHistory.DataSource = history;

            // TỰ ĐỘNG CHỌN LẦN KHÁM ĐẦU TIÊN
            if (dgvHistory.Rows.Count > 0)
            {
                dgvHistory.Rows[0].Selected = true;

                if (dgvHistory.Rows[0].DataBoundItem
                    is MedicalHistoryDto firstRecord)
                {
                    LoadRecordDetails(firstRecord.VisitId);
                }
            }
        }

        // =====================================================
        // 5. CLICK VÀO LỊCH SỬ KHÁM
        // =====================================================
        private void dgvHistory_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvHistory.Rows[e.RowIndex].DataBoundItem
                is MedicalHistoryDto selectedRecord)
            {
                LoadRecordDetails(
                    selectedRecord.VisitId);
            }
        }

        // =====================================================
        // 6. LOAD DỊCH VỤ + THUỐC CỦA LẦN KHÁM
        // =====================================================
        private void LoadRecordDetails(int visitId)
        {
            try
            {
                var result =
                    _medicalRecordBLL.GetRecordDetails(visitId);

                dgvServices.DataSource =
                    result.Services;

                dgvMedicines.DataSource =
                    result.Medicines;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dịch vụ và thuốc:\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}