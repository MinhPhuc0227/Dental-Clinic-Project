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
            SetupGrids();

            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now;

            LoadExaminedList();
        }

        private void LoadExaminedList()
        {
            VisitStatus? selectedStatus = null;

            //if (cbStatus.SelectedIndex > 0)
            //{
            //    selectedStatus = (VisitStatus?)cbStatus.SelectedValue;
            //}

            dgvExaminedList.DataSource = _bll.GetExaminedRecords(
                _currentDoctorId,
                dtpStart.Value,
                dtpEnd.Value,
                txtSearch.Text.Trim(),
                selectedStatus
            );

            ClearDetails();
        }

        private void ClearDetails()
        {
            lbMedicalRecordId.Text = "...";
            lbExaminationDateTime.Text = "...";
            lbPatientName.Text = "...";
            txtDiagnosis.Clear();
            txtConclusion.Clear();
            txtNote.Clear();
            dgvService.DataSource = null;
            dgvMedicine.DataSource = null;
        }

        // Sự kiện khi click vào 1 dòng trên lưới danh sách ca khám
        private void dgvExaminedList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy ra DataBoundItem của dòng đang chọn
                if (dgvExaminedList.Rows[e.RowIndex].DataBoundItem is ExaminedRecordDto selectedRecord)
                {
                    lbMedicalRecordId.Text = selectedRecord.MedicalRecordId.ToString();
                    lbExaminationDateTime.Text = selectedRecord.ExaminationTime.ToString("dd/MM/yyyy HH:mm");
                    lbPatientName.Text = selectedRecord.PatientName;

                    // Lấy chi tiết bệnh án từ DB lên
                    var details = _bll.GetRecordDetails(selectedRecord.VisitId);

                    // Hiển thị lên giao diện
                    txtDiagnosis.Text = details.Diagnosis;
                    txtConclusion.Text = details.Conclusion;
                    txtNote.Text = details.Note;
                    dgvService.DataSource = details.Services;
                    dgvMedicine.DataSource = details.Medicines;
                }
            }
        }

        private void SetupGrids()
        {
            // dgvExaminedList
            dgvExaminedList.AutoGenerateColumns = false;
            dgvExaminedList.Columns.Clear();

            // Cột ẩn VisitId (Chỉ để lưu data, không cần hiện cho bác sĩ xem)
            dgvExaminedList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VisitId", Visible = false });

            dgvExaminedList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicalRecordId", HeaderText = "Mã BA", Width = 70 });
            dgvExaminedList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExaminationTime", HeaderText = "Giờ khám", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvExaminedList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Bệnh nhân", Width = 150 });
            dgvExaminedList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Diagnosis", HeaderText = "Chẩn đoán", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            // dgvService
            dgvService.AutoGenerateColumns = false;
            dgvService.Columns.Clear();
            dgvService.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceName", HeaderText = "Tên dịch vụ / Thủ thuật", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvService.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số lượng", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });

            // dgvMedicine 
            dgvMedicine.AutoGenerateColumns = false;
            dgvMedicine.Columns.Clear();
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicineName", HeaderText = "Tên thuốc", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số lượng", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Instruction", HeaderText = "Cách dùng / Liều dùng", Width = 250 });
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadExaminedList();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            LoadExaminedList();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadExaminedList();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
