using DentalClinic.BLL;
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
    public partial class UC_Doctor_MedicalRecord : UserControl
    {
        // Nhận dữ liệu từ Form_Doctor truyền vào
        private readonly int _currentDoctorId;
        private readonly MedicalRecord_BLL _bll;

        // Constructor có chứa BLL và DoctorId
        public UC_Doctor_MedicalRecord(MedicalRecord_BLL bll, int doctorId)
        {
            InitializeComponent();
            _bll = bll;
            _currentDoctorId = doctorId;
        }

        private void UC_Doctor_MedicalRecord_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpStart.Value = new DateTime(today.Year, today.Month, 1);
            dtpEnd.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            SetupVisitHistoryGrid();
            SetupServiceGrid();
            SetupMedicineGrid();
            LoadStatusComboBox();
            LoadData();
        }

        private void LoadStatusComboBox()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add("Tất cả");
            cbStatus.Items.Add("Đang khám");
            cbStatus.Items.Add("Chờ thanh toán");
            cbStatus.Items.Add("Hoàn thành");
            cbStatus.Items.Add("Đã hủy");
            cbStatus.SelectedIndex = 0;
        }

        private void SetupVisitHistoryGrid()
        {
            dgvVisitHistory.AutoGenerateColumns = false;
            dgvVisitHistory.Columns.Clear();

            dgvVisitHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMedicalRecordId",
                    HeaderText = "Mã bệnh án",
                    DataPropertyName = "MedicalRecordId",
                    Visible = false
                });

            dgvVisitHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colExaminationTime",
                    DataPropertyName = "ExaminationTime",
                    HeaderText = "Ngày khám",
                    Width = 145,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm",
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvVisitHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colPatientName",
                    DataPropertyName = "PatientName",
                    HeaderText = "Bệnh nhân",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

            dgvVisitHistory.ReadOnly = true;
            dgvVisitHistory.AllowUserToAddRows = false;
            dgvVisitHistory.AllowUserToDeleteRows = false;
            dgvVisitHistory.RowHeadersVisible = false;
            dgvVisitHistory.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvVisitHistory.MultiSelect = false;
        }

        private void LoadData()
        {
            try
            {
                VisitStatus? status = cbStatus.SelectedIndex switch
                {
                    1 => VisitStatus.InExamination,
                    2 => VisitStatus.WaitingForPayment,
                    3 => VisitStatus.Completed,
                    4 => VisitStatus.Cancelled,
                    _ => null
                };

                string keyword = txtSearch.Text.Trim();

                var data = _bll.GetExaminedRecords(
                    _currentDoctorId,
                    dtpStart.Value.Date,
                    dtpEnd.Value.Date,
                    keyword,
                    status);

                dgvVisitHistory.DataSource = null;
                dgvVisitHistory.DataSource = data;

                if (data.Count > 0)
                {
                    dgvVisitHistory.ClearSelection();
                    dgvVisitHistory.Rows[0].Selected = true;

                    LoadVisitDetails(data[0]);
                }
                else
                {
                    ClearVisitDetails();
                    dgvService.DataSource = null;
                    dgvMedicine.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh sách lượt khám:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadVisitDetails(ExaminedRecordDto record)
        {
            var result = _bll.GetRecordDetails(record.MedicalRecordId);

            lbExaminationDate.Text =
                record.ExaminationTime.ToString("dd/MM/yyyy HH:mm");

            lbVisitStatus.Text = record.VisitStatus switch
            {
                VisitStatus.InExamination => "Đang khám",
                VisitStatus.WaitingForPayment => "Chờ thanh toán",
                VisitStatus.Completed => "Hoàn thành",
                VisitStatus.Cancelled => "Đã hủy",
                _ => "Không xác định"
            };

            txtDiagnosis.Text =
                string.IsNullOrWhiteSpace(result.Diagnosis)
                    ? "Không có"
                    : result.Diagnosis;

            txtConclusion.Text =
                string.IsNullOrWhiteSpace(result.Conclusion)
                    ? "Không có"
                    : result.Conclusion;

            txtNote.Text =
                string.IsNullOrWhiteSpace(result.Note)
                    ? "Không có"
                    : result.Note;

            dgvService.DataSource = result.Services;
            dgvMedicine.DataSource = result.Medicines;
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
                    HeaderText = "Tên dịch vụ / thủ thuật",
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
                        Alignment =
                            DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvService.ReadOnly = true;
            dgvService.AllowUserToAddRows = false;
            dgvService.RowHeadersVisible = false;
            dgvService.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
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
                    Width = 55
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colNoon",
                    DataPropertyName = "Noon",
                    HeaderText = "Trưa",
                    Width = 55
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colAfternoon",
                    DataPropertyName = "Afternoon",
                    HeaderText = "Chiều",
                    Width = 55
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colEvening",
                    DataPropertyName = "Evening",
                    HeaderText = "Tối",
                    Width = 55
                });

            dgvMedicine.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDays",
                    DataPropertyName = "Days",
                    HeaderText = "Ngày",
                    Width = 55
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
            dgvMedicine.RowHeadersVisible = false;
            dgvMedicine.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearVisitDetails()
        {
            lbExaminationDate.Text = "";
            lbVisitStatus.Text = "";

            txtDiagnosis.Clear();
            txtConclusion.Clear();
            txtNote.Clear();

            dgvService.DataSource = null;
            dgvMedicine.DataSource = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvVisitHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvVisitHistory.Rows[e.RowIndex].DataBoundItem
                is ExaminedRecordDto selectedRecord)
            {
                LoadVisitDetails(selectedRecord);
            }
        }
    }
}
