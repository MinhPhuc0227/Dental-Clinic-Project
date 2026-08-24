using DentalClinic.BLL;
using DentalClinic.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_PatientHistory : Form
    {
        private readonly int _visitId;
        private readonly MedicalRecord_BLL _medicalRecordBLL = new MedicalRecord_BLL(new MedicalRecord_DAL(new AppDbContext()));

        // Nhận ID từ màn hình chính truyền qua
        public Dialog_PatientHistory(int visitId, string patientName)
        {
            InitializeComponent();
            _visitId = visitId;
            this.Text = $"Lịch sử khám - {patientName}";
        }

        private void Dialog_PatientHistory_Load(object sender, EventArgs e)
        {
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExaminationDate", HeaderText = "Ngày Khám", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Bác Sĩ", Width = 150 });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Diagnosis", HeaderText = "Chẩn Đoán", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Conclusion", HeaderText = "Kết Luận", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgvHistory.DataSource = _medicalRecordBLL.GetPatientHistory(_visitId);
        }
    }
}
