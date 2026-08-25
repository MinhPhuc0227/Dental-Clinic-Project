using DentalClinic.BLL;
using DentalClinic.BLL.Common;
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
            var createDto = new VisitCreateDto
            {
                PatientId = cbPatient.SelectedValue is int pId ? pId : 0,
                DoctorId = cbDoctor.SelectedValue is int dId ? dId : 0,
                ReasonForVisit = txtReasonForVisit.Text.Trim(),
                ReceptionistId = _receptionistId
            };

            if (createDto.DoctorId <= 0)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ phụ trách.", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra quá tải lượt khám (1 bác sĩ)
            if (_visitBLL.IsDoctorOverloaded(createDto.DoctorId))
            {
                var confirmResult = MessageBox.Show(
                    $"Bác sĩ này hôm nay đã có từ {SystemConstants.MaxDailyVisitsPerDoctor} bệnh nhân trở lên (cả hẹn và vãng lai).\n\nBạn có chắc chắn muốn tiếp tục tiếp nhận bệnh nhân này vào hàng chờ không?",
                    "Cảnh báo quá tải",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Chọn "No" 
                if (confirmResult == DialogResult.No)
                {
                    return;
                }
                // Chọn "Yes" thì tiếp tục
            }

            // Gọi BLL và lưu
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
            using (var dialogPatient = new Dialog_Patient())
            {
                if (dialogPatient.ShowDialog() == DialogResult.OK)
                {
                    int newlyAddedPatientId = dialogPatient.CreatedPatientId;
                    LoadPatients(); // Nạp lại danh sách bệnh nhân
                    cbPatient.SelectedValue = newlyAddedPatientId; // Tự động chọn bệnh nhân vừa tạo
                }
            }
        }
    }
}
