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
    public partial class UC_Doctor_Appointment : UserControl
    {
        private readonly Appointment_BLL _appointmentBLL;
        private readonly int _doctorId;

        public UC_Doctor_Appointment(Appointment_BLL appointmentBLL, int doctorId)
        {
            InitializeComponent();
            _appointmentBLL = appointmentBLL;
            _doctorId = doctorId;
        }

        private void UC_Doctor_Appointment_Load(object sender, EventArgs e)
        {
            InitFilterControls();
            SetupDataGridView();
            LoadData();
        }

        private void InitFilterControls()
        {
            // Mặc định DateTimePicker lấy tháng hiện tại
            DateTime today = DateTime.Today;
            dtpStart.Value = new DateTime(today.Year, today.Month, 1);
            dtpEnd.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            var statusList = new List<object>
            {
                new { Value = (AppointmentStatus?)null, Text = "Tất cả" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Scheduled, Text = "Đã đặt lịch" },
                new { Value = (AppointmentStatus?)AppointmentStatus.CheckedIn, Text = "Đã tiếp nhận" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Cancelled, Text = "Đã hủy" }
            };

            cbAppointmentStatus.DataSource = statusList;
            cbAppointmentStatus.DisplayMember = "Text";
            cbAppointmentStatus.ValueMember = "Value";
        }

        private void SetupDataGridView()
        {
            dgvAppointment.AutoGenerateColumns = false;
            dgvAppointment.Columns.Clear();
            
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "AppointmentId", 
                HeaderText = "Mã Lịch Hẹn", 
                Width = 90, 
                Visible = false });
            
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "PatientName", 
                HeaderText = "Bệnh Nhân", 
                Width = 150 
            });
            
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn 
            {
                DataPropertyName = "PatientPhone",
                HeaderText = "SĐT", 
                Width = 110 
            });
            
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AppointmentDateTime",
                HeaderText = "Giờ Hẹn",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm dd/MM/yyyy" }
            });

            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "StatusText", 
                HeaderText = "Trạng Thái", 
                Width = 120 
            });
            
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "ReasonForVisit", 
                HeaderText = "Lý Do Khám", 
                Width = 180 
            });
            
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Note", 
                HeaderText = "Ghi Chú", 
                Width = 150 
            });

            dgvAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointment.ReadOnly = true;
        }

        public void LoadData()
        {
            var filter = new AppointmentFilterDto
            {
                Keyword = txtSearch.Text.Trim(),
                StartDate = dtpStart.Value.Date,
                EndDate = dtpEnd.Value.Date,
                DoctorId = _doctorId, 
                Status = cbAppointmentStatus.SelectedValue as AppointmentStatus?
            };

            var result = _appointmentBLL.GetFiltered(filter);

            if (result.IsSuccess)
            {
                dgvAppointment.DataSource = result.Data;
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbAppointmentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
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
    }
}
