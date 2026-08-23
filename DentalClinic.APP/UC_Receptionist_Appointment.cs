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
    public partial class UC_Receptionist_Appointment : UserControl
    {
        private readonly Appointment_BLL _appointmentBLL;
        private readonly int _currentReceptionistId;
        private readonly string _currentReceptionistName;

        public UC_Receptionist_Appointment(Appointment_BLL appointmentBLL, int receptionistId, string receptionistName)
        {
            InitializeComponent();
            _appointmentBLL = appointmentBLL;
            _currentReceptionistId = receptionistId;
            _currentReceptionistName = receptionistName;
        }

        private void UC_Receptionist_Appointment_Load(object sender, EventArgs e)
        {
            InitFilterControls();
            SetupDataGridView();
            LoadData();
        }

        private void InitFilterControls()
        {
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today.AddDays(7);

            // Nạp danh sách bác sĩ vào ComboBox
            var doctorRes = _appointmentBLL.GetDoctorsLookup();
            if (doctorRes.IsSuccess && doctorRes.Data != null)
            {
                var doctors = new List<LookupItemDto> { new LookupItemDto { Id = 0, Name = "-- Tất cả Bác sĩ --" } };
                doctors.AddRange(doctorRes.Data);
                cbDoctor.DataSource = doctors;
                cbDoctor.DisplayMember = "Name";
                cbDoctor.ValueMember = "Id";
            }

            // Nạp danh sách Trạng thái
            var statusList = new List<object>
            {
                new { Value = (AppointmentStatus?)null, Text = "-- Tất cả Trạng thái --" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Pending, Text = "Chờ khám" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Confirmed, Text = "Đã xác nhận" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Completed, Text = "Đã hoàn thành" },
                new { Value = (AppointmentStatus?)AppointmentStatus.Cancelled, Text = "Đã hủy" }
            };
            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";

            // Sự kiện tự động lọc
            txtSearch.TextChanged += (s, e) => LoadData();
            dtpStart.ValueChanged += (s, e) => LoadData();
            dtpEnd.ValueChanged += (s, e) => LoadData();
            cbDoctor.SelectedIndexChanged += (s, e) => LoadData();
            cbStatus.SelectedIndexChanged += (s, e) => LoadData();
        }

        private void SetupDataGridView()
        {
            dgvAppointment.AutoGenerateColumns = false;
            dgvAppointment.Columns.Clear();

            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AppointmentId", HeaderText = "Mã Lịch Hẹn", Width = 90 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Bệnh Nhân", Width = 140 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientPhone", HeaderText = "SĐT", Width = 100 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Bác Sĩ", Width = 140 });
            //dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AppointmentDateTime", HeaderText = "Thời Gian Khám", Width = 130 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AppointmentDateTime",
                HeaderText = "Thời Gian Khám",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StatusText", HeaderText = "Trạng Thái", Width = 110 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReasonForVisit", HeaderText = "Lý Do Khám", Width = 150 });
            dgvAppointment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Note", HeaderText = "Ghi Chú", Width = 120 });

            // Cột nút tiếp nhận
            DataGridViewButtonColumn checkInCol = new DataGridViewButtonColumn
            {
                Name = "colCheckIn",
                HeaderText = "Thao tác",
                Text = "Tiếp nhận",
                UseColumnTextForButtonValue = true,
                Width = 80
            };

            dgvAppointment.Columns.Add(checkInCol);

            // Cột nút Edit
            DataGridViewButtonColumn editCol = new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "Thao tác",
                Text = "Sửa",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvAppointment.Columns.Add(editCol);
        }

        public void LoadData()
        {
            var filter = new AppointmentFilterDto
            {
                Keyword = txtSearch.Text,
                StartDate = dtpStart.Value,
                EndDate = dtpEnd.Value,
                DoctorId = cbDoctor.SelectedValue is int dId && dId > 0 ? dId : null,
                Status = cbStatus.SelectedValue as AppointmentStatus?
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

        private void btAdd_Click(object? sender, EventArgs e)
        {
            using (var dialog = new Dialog_Appointment(_appointmentBLL, _currentReceptionistId, _currentReceptionistName, null))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void DgvAppointment_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var columnName = dgvAppointment.Columns[e.ColumnIndex].Name;
                if (dgvAppointment.Rows[e.RowIndex].DataBoundItem is AppointmentListDto dto)
                {
                    // Xử lý khi nhấn Tiếp nhận
                    if (columnName == "colCheckIn")
                    {
                        // Chỉ cho phép tiếp nhận nếu đang ở trạng thái Chờ hoặc Đã xác nhận
                        if (dto.Status == AppointmentStatus.Cancelled || dto.Status == AppointmentStatus.Completed)
                        {
                            MessageBox.Show("Lịch hẹn đã hủy hoặc hoàn thành, không thể tiếp nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (MessageBox.Show($"Xác nhận tiếp nhận bệnh nhân {dto.PatientName}?", "Tiếp nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                             Result res = _appointmentBLL.CreateVisitFromAppointment(dto.AppointmentId, _currentReceptionistId);
                             if (res.IsSuccess) { LoadData(); }
                        }
                    }
                    // Xử lý khi nhấn Sửa
                    else if (columnName == "colEdit")
                    {
                        using (var dialog = new Dialog_Appointment(_appointmentBLL, _currentReceptionistId, _currentReceptionistName, dto.AppointmentId))
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                }
            }
        }
    }
}
