using DentalClinic.BLL;
using DentalClinic.DTO;
using System;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_VisitHistory : Form
    {
        private readonly int _visitId;
        private readonly MedicalRecord_BLL _medicalRecordBLL;

        public Dialog_VisitHistory(MedicalRecord_BLL medicalRecordBLL, int visitId, string patientName)
        {
            InitializeComponent();

            _medicalRecordBLL = medicalRecordBLL;
            _visitId = visitId;

            Text = $"Lịch sử khám - {patientName}";
            StartPosition = FormStartPosition.CenterParent;
        }

        private void Dialog_VisitHistory_Load(object sender, EventArgs e)
        {
            try
            {
                SetupVisitHistoryGrid();
                SetupServiceGrid();
                SetupMedicineGrid();

                SetupDetailControls();
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

        private void SetupDetailControls()
        {
            txtDiagnosis.ReadOnly = true;
            txtConclusion.ReadOnly = true;
            txtNote.ReadOnly = true;
            ClearVisitDetails();
        }

        private void ClearVisitDetails()
        {
            lbExaminationDate.Text = "";
            txtDiagnosis.Clear();
            txtConclusion.Clear();
            txtNote.Clear();
        }

        private void SetupVisitHistoryGrid()
        {
            dgvVisitHistory.AutoGenerateColumns = false;
            dgvVisitHistory.Columns.Clear();

            dgvVisitHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colVisitId",
                    DataPropertyName = "VisitId",
                    Visible = false
                });

            dgvVisitHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colExaminationDate",
                    DataPropertyName = "ExaminationDate",
                    HeaderText = "Ngày khám",
                    Width = 130,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm",
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvVisitHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDoctorName",
                    DataPropertyName = "DoctorName",
                    HeaderText = "Bác sĩ",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

            dgvVisitHistory.ReadOnly = true;
            dgvVisitHistory.AllowUserToAddRows = false;
            dgvVisitHistory.AllowUserToDeleteRows = false;
            dgvVisitHistory.RowHeadersVisible = false;
            dgvVisitHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisitHistory.MultiSelect = false;
        }

        private void SetupServiceGrid()
        {
            dgvService.AutoGenerateColumns = false;
            dgvService.Columns.Clear();

            dgvService.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colServiceName",
                    DataPropertyName = "ServiceName",
                    HeaderText = "Tên dịch vụ",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

            dgvService.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colServiceQuantity",
                    DataPropertyName = "Quantity",
                    HeaderText = "Số lượng",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvService.ReadOnly = true;
            dgvService.AllowUserToAddRows = false;
            dgvService.AllowUserToDeleteRows = false;
            dgvService.RowHeadersVisible = false;
            dgvService.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvService.MultiSelect = false;
        }

        private void SetupMedicineGrid()
        {
            dgvMedicine.AutoGenerateColumns = false;
            dgvMedicine.Columns.Clear();

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMedicineName",
                    DataPropertyName = "MedicineName",
                    HeaderText = "Tên thuốc",
                    Width = 200
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMorning",
                    DataPropertyName = "Morning",
                    HeaderText = "Sáng",
                    Width = 65,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colNoon",
                    DataPropertyName = "Noon",
                    HeaderText = "Trưa",
                    Width = 65,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colAfternoon",
                    DataPropertyName = "Afternoon",
                    HeaderText = "Chiều",
                    Width = 65,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colEvening",
                    DataPropertyName = "Evening",
                    HeaderText = "Tối",
                    Width = 65,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDays",
                    DataPropertyName = "Days",
                    HeaderText = "Ngày",
                    Width = 65,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colInstruction",
                    DataPropertyName = "Instruction",
                    HeaderText = "Cách dùng",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

            dgvMedicine.ReadOnly = true;
            dgvMedicine.AllowUserToAddRows = false;
            dgvMedicine.AllowUserToDeleteRows = false;
            dgvMedicine.RowHeadersVisible = false;
            dgvMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicine.MultiSelect = false;
        }

        private void LoadHistory()
        {
            var history = _medicalRecordBLL.GetPatientHistory(_visitId);

            if (history == null || history.Count == 0)
            {
                dgvVisitHistory.DataSource = null;
                dgvService.DataSource = null;
                dgvMedicine.DataSource = null;

                ClearVisitDetails();

                MessageBox.Show(
                    "Bệnh nhân chưa có lịch sử khám hoàn thành.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
                return;
            }

            dgvVisitHistory.DataSource = history;

            if (dgvVisitHistory.Rows.Count > 0 && dgvVisitHistory.Rows[0].DataBoundItem is PatientHistoryDto firstRecord)
            {
                dgvVisitHistory.ClearSelection();
                dgvVisitHistory.Rows[0].Selected = true;
                LoadRecordDetails(firstRecord.MedicalRecordId);
            }
        }

        private void dgvVisitHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvVisitHistory.Rows[e.RowIndex].DataBoundItem is PatientHistoryDto selectedRecord)
            {
                LoadRecordDetails(selectedRecord.MedicalRecordId);
            }
        }

        private void LoadRecordDetails(int medicalRecordId)
        {
            try
            {
                var result = _medicalRecordBLL.GetRecordDetails(medicalRecordId);

                lbExaminationDate.Text = GetHistoryDateText(medicalRecordId);

                txtDiagnosis.Text = string.IsNullOrWhiteSpace(result.Diagnosis) ? "Không có" : result.Diagnosis;

                txtConclusion.Text = string.IsNullOrWhiteSpace(result.Conclusion) ? "Không có" : result.Conclusion;

                txtNote.Text = string.IsNullOrWhiteSpace(result.Note) ? "Không có" : result.Note;

                dgvService.DataSource = result.Services;
                dgvMedicine.DataSource = result.Medicines;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải thông tin lần khám:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GetHistoryDateText(int medicalRecordId)
        {
            foreach (DataGridViewRow row in dgvVisitHistory.Rows)
            {
                if (row.DataBoundItem is PatientHistoryDto record &&
                    record.MedicalRecordId == medicalRecordId)
                {
                    return record.ExaminationDate.ToString("dd/MM/yyyy HH:mm");
                }
            }

            return "";
        }
    }
}