using DentalClinic.BLL;
using DentalClinic.DAL;
using DentalClinic.MODEL;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DentalClinic.APP
{
    public partial class Form_Doctor : Form
    {
        private UC_Doctor_Examination ExaminationUC;
        private UC_Doctor_Appointment DoctorAppointmentUC;
        private UC_Doctor_MedicalRecord MedicalRecordUC;

        private readonly Appointment_BLL _appointmentBLL = new Appointment_BLL(new Appointment_DAL(new AppDbContext()));
        private readonly Visit_BLL _visitBLL = new Visit_BLL(new Visit_DAL(new AppDbContext()));
        private readonly Doctor_BLL _doctorBll = new Doctor_BLL();
        //private readonly MedicalRecord_BLL _medicalRecordBLL = new MedicalRecord_BLL(new MedicalRecord_DAL(new AppDbContext()));

        private readonly int _currentDoctorId;
        private readonly string _currentDoctorName;

        public Form_Doctor(int accountId, string userName)
        {
            InitializeComponent();

            // Tìm thông tin Bác sĩ từ AccountId
            var doctor = _doctorBll.GetDoctorByAccountId(accountId);
            if (doctor != null)
            {
                _currentDoctorId = doctor.DoctorId;
                _currentDoctorName = doctor.FullName;
            }
            else
            {
                _currentDoctorId = 0;
                _currentDoctorName = userName; // Dùng tạm tên đăng nhập nếu chưa có hồ sơ
            }

            // Đổi tiêu đề Form
            this.Text = $"Bác sĩ: {_currentDoctorName}";

            // Truyền đúng _currentDoctorId vào các UserControl
            ExaminationUC = new UC_Doctor_Examination(_visitBLL, _currentDoctorId);
            DoctorAppointmentUC = new UC_Doctor_Appointment(_appointmentBLL, _currentDoctorId);
            MedicalRecordUC = new UC_Doctor_MedicalRecord();
        }

        private void ShowUC(UserControl uc)
        {
            if (!pnContent.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                pnContent.Controls.Add(uc);
            }

            uc.BringToFront();
        }

        private void btLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbExamination_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExamination.Checked)
            {
                ShowUC(ExaminationUC);
                //ExaminationUC.LoadData();
            }
        }

        private void rbDoctorAppointment_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDoctorAppointment.Checked)
            {
                ShowUC(DoctorAppointmentUC);
                //DoctorAppointmentUC.LoadData();
            }
        }

        private void rbMedicalRecord_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMedicalRecord.Checked)
            {
                ShowUC(MedicalRecordUC);
                //MedicalRecordUC.LoadData();
            }
        }
    }
}
