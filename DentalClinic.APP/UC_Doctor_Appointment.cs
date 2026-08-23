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

        // Constructor nhận vào BLL và DoctorId từ Form_Doctor truyền sang
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
            // 1. Mặc định DateTimePicker chọn ngày hôm nay
            dtpAppointmentDate.Value = DateTime.Today;

            // 2. Nạp danh sách Trạng thái vào ComboBox (giống mẫu Lễ tân)
            var statusList = new List<object>
            {
                new { Value = (AppointmentStatus?)null, Text = "-- Tất cả Trạng thái --" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Pending, Text = "Chờ khám" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Confirmed, Text = "Đã xác nhận" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Completed, Text = "Đã hoàn thành" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Cancelled, Text = "Đã hủy" }
            };
            cbAppointmentStatus.DataSource = statusList;
            cbAppointmentStatus.DisplayMember = "Text";
            cbAppointmentStatus.ValueMember = "Value";

            // 3. Đăng ký sự kiện tự động lọc khi thay đổi giá trị
            txtSearch.TextChanged += (s, e) => LoadData();
            dtpAppointmentDate.ValueChanged += (s, e) => LoadData();
            cbAppointmentStatus.SelectedIndexChanged += (s, e) => LoadData();
        }

        private void SetupDataGridView()
        {
            dgvAppointment.AutoGenerateColumns = false;
            dgvAppointment.Columns.Clear();

            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AppointmentId", HeaderText = "Mã Lịch Hẹn", Width = 90, Visible = false });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Bệnh Nhân", Width = 150 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientPhone", HeaderText = "SĐT", Width = 110 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AppointmentDateTime",
                HeaderText = "Giờ Hẹn",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm dd/MM/yyyy" }
            });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StatusText", HeaderText = "Trạng Thái", Width = 120 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReasonForVisit", HeaderText = "Lý Do Khám", Width = 180 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Note", HeaderText = "Ghi Chú", Width = 150 });

            dgvAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointment.ReadOnly = true;
        }

        public void LoadData()
        {
            // Thiết lập bộ lọc (tận dụng AppointmentFilterDto sẵn có)
            var filter = new AppointmentFilterDto
            {
                Keyword = txtSearch.Text.Trim(),
                // Lọc trọn vẹn trong ngày mà bác sĩ chọn trên dtpAppointmentDate
                StartDate = dtpAppointmentDate.Value.Date,
                EndDate = dtpAppointmentDate.Value.Date,
                DoctorId = _doctorId, // Cố định đúng mã của Bác sĩ đang đăng nhập
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
    }
}
