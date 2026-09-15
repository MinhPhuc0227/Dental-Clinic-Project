using DentalClinic.BLL;
using DentalClinic.BLL.Common;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using Microsoft.Extensions.DependencyInjection;
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

        private readonly IServiceProvider _serviceProvider;

        public Dialog_Visit(Visit_BLL visitBLL, IServiceProvider serviceProvider, int receptionistId)
        {
            InitializeComponent();
            _visitBLL = visitBLL;
            _serviceProvider = serviceProvider;
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
            var createDto = new VisitCreateDto
            {
                PatientId = cbPatient.SelectedValue is int pId ? pId : 0,
                DoctorId = cbDoctor.SelectedValue is int dId ? dId : 0,
                ReasonForVisit = txtReasonForVisit.Text.Trim(),
                ReceptionistId = _receptionistId
            };

            if (createDto.DoctorId <= 0 || createDto.PatientId <= 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Bệnh nhân và Bác sĩ phụ trách.", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var warnings = _visitBLL.GetWalkInWarnings(createDto.DoctorId);

            if (warnings.Count > 0)
            {
                string msg = "Hệ thống phát hiện các vấn đề sau đối với ca tiếp nhận vãng lai này:\n\n";
                foreach (var w in warnings)
                {
                    msg += $"• {w}\n";
                }
                msg += "\nBạn có chắc chắn muốn BỎ QUA CẢNH BÁO và đưa bệnh nhân vào hàng chờ không?";

                var confirmResult = MessageBox.Show(msg, "Cảnh báo linh động", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.No)
                {
                    return; 
                }
            }

            Result result = _visitBLL.CreateWalkInVisit(createDto);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(result.Message, "Lỗi từ chối tiếp nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadPatients()
        {
            var res = _visitBLL.GetPatientsLookup();
            if (res.IsSuccess && res.Data != null)
            {
                cbPatient.DataSource = res.Data;
                cbPatient.DisplayMember = "Name";
                cbPatient.ValueMember = "Id";
                cbPatient.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbPatient.SelectedIndex = -1;
            }
        }


        private void btCreatePatient_Click(object sender, EventArgs e)
        {
            using (var dialogPatient = ActivatorUtilities.CreateInstance<Dialog_Patient>(_serviceProvider))
            {
                if (dialogPatient.ShowDialog() == DialogResult.OK)
                {
                    int newlyAddedPatientId = dialogPatient.CreatedPatientId;
                    LoadPatients(); 
                    cbPatient.SelectedValue = newlyAddedPatientId; 
                }
            }
        }
    }
}
