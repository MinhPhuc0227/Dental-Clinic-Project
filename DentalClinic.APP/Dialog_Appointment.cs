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
    public partial class Dialog_Appointment : Form
    {
        private readonly Appointment_BLL _appointmentBLL;
        private readonly int _receptionistId;
        private readonly string _receptionistName;
        private readonly int? _appointmentId;
        private AppointmentStatus _currentStatus = AppointmentStatus.Pending;

        public Dialog_Appointment(Appointment_BLL appointmentBLL, int receptionistId, string receptionistName, int? appointmentId = null)
        {
            InitializeComponent();
            _appointmentBLL = appointmentBLL;
            _receptionistId = receptionistId;
            _receptionistName = receptionistName;
            _appointmentId = appointmentId;
        }

        private void Dialog_Appointment_Load(object sender, EventArgs e)
        {
            LoadPatients();
            LoadDoctors();

            lbReceptionist.Text = _receptionistName;

            if (_appointmentId.HasValue && _appointmentId > 0)
            {
                // CHẾ ĐỘ SỬA
                lbAppointmentId.Text = _appointmentId.Value.ToString();
                LoadAppointmentDetail(_appointmentId.Value);

                // Ẩn/Hiện nút Tiếp nhận dựa trên trạng thái hiện tại
                if (_currentStatus == AppointmentStatus.Completed || _currentStatus == AppointmentStatus.Cancelled)
                {
                    btCheckIn.Visible = false; // Đã xong hoặc hủy thì không tiếp nhận nữa
                    btSave.Enabled = false;    // Tùy chọn: Khóa luôn nút Lưu
                }
                else
                {
                    btCheckIn.Visible = true;
                }
            }
            else
            {
                btCheckIn.Visible = false;
                // CHẾ ĐỘ TẠO MỚI
                lbAppointmentId.Text = "Tự động";
                dtpAppointmentDate.Value = DateTime.Today;
                dtpAppointmentTime.Value = DateTime.Now;
                lbCreatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                _currentStatus = AppointmentStatus.Pending;
                lbStatus.Text = "Chờ khám (Pending)";
            }
        }

        private void LoadPatients()
        {
            var res = _appointmentBLL.GetPatientsLookup();
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

        private void LoadDoctors()
        {
            var res = _appointmentBLL.GetDoctorsLookup();
            if (res.IsSuccess && res.Data != null)
            {
                cbDoctor.DataSource = res.Data;
                cbDoctor.DisplayMember = "Name";
                cbDoctor.ValueMember = "Id";
                cbDoctor.SelectedIndex = -1;
            }
        }

        private void LoadAppointmentDetail(int id)
        {
            var res = _appointmentBLL.GetById(id);
            if (res.IsSuccess && res.Data != null)
            {
                var dto = res.Data;
                cbPatient.SelectedValue = dto.PatientId;
                cbDoctor.SelectedValue = dto.DoctorId;
                dtpAppointmentDate.Value = dto.AppointmentDate;
                dtpAppointmentTime.Value = DateTime.Today.Add(dto.AppointmentTime);
                txtReasonForVisit.Text = dto.ReasonForVisit;
                txtNote.Text = dto.Note;

                lbReceptionist.Text = !string.IsNullOrEmpty(dto.ReceptionistName) ? dto.ReceptionistName : _receptionistName;
                lbCreatedDate.Text = dto.CreatedDate.ToString("dd/MM/yyyy HH:mm");

                _currentStatus = dto.Status;
                lbStatus.Text = GetStatusDisplayText(_currentStatus);
            }
            else
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
            }
        }

        private string GetStatusDisplayText(AppointmentStatus status) => status switch
        {
            AppointmentStatus.Pending => "Chờ khám (Pending)",
            AppointmentStatus.Confirmed => "Đã xác nhận (Confirmed)",
            AppointmentStatus.Completed => "Đã hoàn thành (Completed)",
            AppointmentStatus.Cancelled => "Đã hủy (Cancelled)",
            _ => "Khác"
        };

        private void btCreatePatient_Click(object? sender, EventArgs e)
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

        private void btSave_Click(object? sender, EventArgs e)
        {
            Result result;

            int selectedPatientId = cbPatient.SelectedValue is int pId ? pId : 0;
            int selectedDoctorId = cbDoctor.SelectedValue is int dId ? dId : 0;

            if (!_appointmentId.HasValue || _appointmentId.Value == 0)
            {
                // TẠO MỚI -> Dùng AppointmentCreateDto
                var createDto = new AppointmentCreateDto
                {
                    PatientId = selectedPatientId,
                    DoctorId = selectedDoctorId,
                    AppointmentDate = dtpAppointmentDate.Value,
                    AppointmentTime = dtpAppointmentTime.Value.TimeOfDay,
                    ReasonForVisit = txtReasonForVisit.Text.Trim(),
                    Note = txtNote.Text.Trim(),
                    ReceptionistId = _receptionistId
                };

                result = _appointmentBLL.Create(createDto);
            }
            else
            {
                // CẬP NHẬT -> Dùng AppointmentUpdateDto (Kế thừa AppointmentCreateDto)
                var updateDto = new AppointmentUpdateDto
                {
                    AppointmentId = _appointmentId.Value,
                    PatientId = selectedPatientId,
                    DoctorId = selectedDoctorId,
                    AppointmentDate = dtpAppointmentDate.Value,
                    AppointmentTime = dtpAppointmentTime.Value.TimeOfDay,
                    ReasonForVisit = txtReasonForVisit.Text.Trim(),
                    Note = txtNote.Text.Trim(),
                    ReceptionistId = _receptionistId,
                    Status = _currentStatus
                };

                result = _appointmentBLL.Update(updateDto);
            }

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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nếu đang ở chế độ Tạo mới (chưa có ID lịch hẹn trong DB)
            if (!_appointmentId.HasValue || _appointmentId.Value <= 0)
            {
                MessageBox.Show("Lịch hẹn chưa được tạo nên không thể thực hiện hủy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra các trạng thái không hợp lệ để hủy
            if (_currentStatus == AppointmentStatus.Cancelled)
            {
                MessageBox.Show("Lịch hẹn này đã được hủy từ trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_currentStatus == AppointmentStatus.Completed)
            {
                MessageBox.Show("Lịch hẹn đã hoàn thành, không thể hủy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Hỏi xác nhận người dùng
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn HỦY lịch hẹn này không?",
                "Xác nhận hủy lịch",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            // 4. Lấy dữ liệu trên Form và chuyển trạng thái sang Cancelled
            int selectedPatientId = cbPatient.SelectedValue is int pId ? pId : 0;
            int selectedDoctorId = cbDoctor.SelectedValue is int dId ? dId : 0;

            var updateDto = new AppointmentUpdateDto
            {
                AppointmentId = _appointmentId.Value,
                PatientId = selectedPatientId,
                DoctorId = selectedDoctorId,
                AppointmentDate = dtpAppointmentDate.Value,
                AppointmentTime = dtpAppointmentTime.Value.TimeOfDay,
                ReasonForVisit = txtReasonForVisit.Text.Trim(),
                Note = txtNote.Text.Trim(),
                ReceptionistId = _receptionistId,
                Status = AppointmentStatus.Cancelled // Đổi trạng thái thành Đã hủy
            };

            // 5. Gọi BLL cập nhật xuống Database
            Result result = _appointmentBLL.Update(updateDto);

            if (result.IsSuccess)
            {
                MessageBox.Show("Hủy lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Đặt DialogResult để Form cha (UC) tự động reload lại danh sách
                //this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btCheckIn_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem lịch hẹn đã được tạo chưa (có ID chưa)
            if (!_appointmentId.HasValue || _appointmentId.Value <= 0)
            {
                MessageBox.Show("Vui lòng Lưu lịch hẹn mới trước khi thực hiện Tiếp nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hỏi xác nhận
            var confirm = MessageBox.Show(
                "Xác nhận tiếp nhận bệnh nhân này và đưa vào hàng chờ khám?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            // 3. Gọi hàm BLL vừa viết
            Result result = _appointmentBLL.CreateVisitFromAppointment(_appointmentId.Value, _receptionistId);

            // 4. Xử lý kết quả trả về
            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đặt DialogResult = OK để UserControl bên ngoài biết mà load lại danh sách DataGridView
                this.DialogResult = DialogResult.OK;
                //this.Close(); // Đóng form Dialog
            }
            else
            {
                MessageBox.Show(result.Message, "Lỗi tiếp nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
