using DentalClinic.BLL;
using DentalClinic.DAL;
using DentalClinic.MODEL;
using Microsoft.Extensions.DependencyInjection;
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
        // Khai báo các User Control
        private UC_Doctor_Examination ExaminationUC;
        private UC_Doctor_Appointment DoctorAppointmentUC;
        private UC_Doctor_MedicalRecord MedicalRecordUC;

        // Khai báo biến lưu thông tin bác sĩ đang đăng nhập
        private readonly int _currentDoctorId;
        private readonly string _currentDoctorName;

        // BLL
        private readonly Doctor_BLL _doctorBll;
        private readonly MedicalRecord_BLL _medicalRecordBLL;
        private readonly Visit_BLL _visitBLL;
        private readonly Appointment_BLL _appointmentBLL;

        // Dependency Injection
        private readonly IServiceProvider _serviceProvider;

        public Form_Doctor(
    int accountId,
    string userName,
    Doctor_BLL doctorBll,
    MedicalRecord_BLL medicalRecordBLL,
    Visit_BLL visitBLL,
    Appointment_BLL appointmentBLL,
    IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _doctorBll = doctorBll;
            _medicalRecordBLL = medicalRecordBLL;
            _visitBLL = visitBLL;
            _appointmentBLL = appointmentBLL;
            _serviceProvider = serviceProvider;

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
                _currentDoctorName = userName;
            }

            this.Text = $"Bác sĩ: {_currentDoctorName}";

            ExaminationUC = ActivatorUtilities.CreateInstance<UC_Doctor_Examination>(
                _serviceProvider,
                _currentDoctorId);

            DoctorAppointmentUC =
                new UC_Doctor_Appointment(
                    _appointmentBLL,
                    _currentDoctorId);

            MedicalRecordUC =
                new UC_Doctor_MedicalRecord(
                    _medicalRecordBLL,
                    _currentDoctorId);
        }

        private void ShowUC(UserControl uc)
        {
            if (uc == null) return;

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

                ExaminationUC.LoadWaitingQueue();
                ExaminationUC.LoadInExamination();
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
