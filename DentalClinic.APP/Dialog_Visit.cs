using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
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
    public partial class Dialog_Visit : Form
    {
        private readonly Visit_BLL _visitBLL;
        private readonly int _receptionistId;

        public Dialog_Visit(Visit_BLL visitBLL, int receptionistId)
        {
            InitializeComponent();
            _visitBLL = visitBLL;
            _receptionistId = receptionistId;
        }

        private void Dialog_Visit_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            // Load Bệnh nhân
            var patientRes = _visitBLL.GetPatientsLookup();
            if (patientRes.IsSuccess && patientRes.Data != null)
            {
                cbPatient.DataSource = patientRes.Data;
                cbPatient.DisplayMember = "Name";
                cbPatient.ValueMember = "Id";
                cbPatient.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbPatient.SelectedIndex = -1;
            }

            // Load Bác sĩ
            var doctorRes = _visitBLL.GetDoctorsLookup();
            if (doctorRes.IsSuccess && doctorRes.Data != null)
            {
                cbDoctor.DataSource = doctorRes.Data;
                cbDoctor.DisplayMember = "Name";
                cbDoctor.ValueMember = "Id";
                cbDoctor.SelectedIndex = -1;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu gán vào DTO
            var createDto = new VisitCreateDto
            {
                PatientId = cbPatient.SelectedValue is int pId ? pId : 0,
                DoctorId = cbDoctor.SelectedValue is int dId ? dId : 0,
                ReasonForVisit = txtReasonForVisit.Text.Trim(),
                ReceptionistId = _receptionistId
            };

            // Gọi BLL để validate và lưu
            Result result = _visitBLL.CreateWalkInVisit(createDto);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                //this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
