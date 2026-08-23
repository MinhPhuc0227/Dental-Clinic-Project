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
    public partial class UC_Doctor_Examination : UserControl
    {
        private readonly Visit_BLL _visitBLL;
        private readonly int _doctorId;
        public UC_Doctor_Examination(Visit_BLL visitBLL, int doctorId)
        {
            InitializeComponent();
            _visitBLL = visitBLL;
            _doctorId = doctorId;
        }

        private void UC_Doctor_Examination_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadWaitingQueue();
            ClearPatientInfo();
        }

        private void SetupDataGridView()
        {
            // BẮT BUỘC: Tắt tự động sinh cột để không bị rác giao diện
            dgvWaitingQueue.AutoGenerateColumns = false;
            dgvWaitingQueue.Columns.Clear();

            // 1. Cột ẨN (Rất quan trọng): Lưu mã VisitId để khi click vào ta biết đang chọn ca khám nào
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VisitId",
                Name = "VisitId",
                Visible = false
            });

            // 2. Cột STT (Queue Number) - Cho chiều rộng nhỏ lại
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "QueueNumber",
                HeaderText = "STT",
                Width = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9, FontStyle.Bold) }
            });

            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CheckInDateTime",
                HeaderText = "Giờ Nhận",
                Width = 80,
                // Format chỉ lấy Giờ:Phút (VD: 14:30) vì danh sách này mặc định là của ngày hôm nay rồi
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm", Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 3. Cột Tên Bệnh Nhân
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PatientName",
                HeaderText = "Bệnh Nhân",
                Width = 140
            });

            // 4. Cột Lý do khám - Cho cột này "Fill" (tự động giãn ra chiếm hết chỗ trống còn lại)
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReasonForVisit",
                HeaderText = "Lý Do Khám",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Làm đẹp giao diện lưới
            dgvWaitingQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWaitingQueue.ReadOnly = true;
            dgvWaitingQueue.AllowUserToAddRows = false; // Tắt dòng trắng cuối cùng
            dgvWaitingQueue.RowHeadersVisible = false;  // Tắt cái cột mũi tên ngoài cùng bên trái
        }

        public void LoadWaitingQueue()
        {
            try
            {
                // Gọi thẳng hàm GetWaitingQueue đã có sẵn của bạn.
                // Truyền vào: Ngày hôm nay, Từ khóa rỗng "", Mã Bác Sĩ, và Trạng thái Waiting
                var result = _visitBLL.GetWaitingQueue(DateTime.Today, "", _doctorId, VisitStatus.Waiting);

                if (result.IsSuccess && result.Data != null)
                {
                    dgvWaitingQueue.DataSource = result.Data;
                    dgvWaitingQueue.ClearSelection(); // Khi mới load lên không tô xanh dòng nào
                }
                else
                {
                    dgvWaitingQueue.DataSource = null;
                    ClearPatientInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chờ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPatientInfo()
        {
            // Đặt lại các Label về dấu "..." hoặc "---" để báo hiệu đang chờ chọn dữ liệu
            lbFullName.Text = "...";
            lbPhone.Text = "...";
            lbPatientNote.Text = "...";
            lbReasonForVisit.Text = "...";
            lbAppointmentNote.Text = "...";

            // Trả lại màu chữ đen mặc định cho Ghi chú cá nhân (tránh bị dính màu đỏ từ ca bệnh trước)
            lbPatientNote.ForeColor = Color.Black;
        }

        private void dgvWaitingQueue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào tiêu đề cột (RowIndex = -1)
            if (e.RowIndex >= 0)
            {
                // Lấy toàn bộ dữ liệu của dòng đang được click
                if (dgvWaitingQueue.Rows[e.RowIndex].DataBoundItem is WaitingQueueDto selectedVisit)
                {
                    // 1. Đổ dữ liệu Hành chính
                    lbFullName.Text = selectedVisit.PatientName;
                    lbPhone.Text = selectedVisit.PatientPhone;

                    // 2. Đổ dữ liệu Khám & Ghi chú (Nếu rỗng thì hiện chữ "Không có")
                    lbReasonForVisit.Text = string.IsNullOrWhiteSpace(selectedVisit.ReasonForVisit)
                        ? "Không có" : selectedVisit.ReasonForVisit;

                    lbPatientNote.Text = string.IsNullOrWhiteSpace(selectedVisit.PatientNote)
                        ? "Không có" : selectedVisit.PatientNote;

                    lbAppointmentNote.Text = string.IsNullOrWhiteSpace(selectedVisit.AppointmentNote)
                        ? "Không có hẹn / Không có ghi chú" : selectedVisit.AppointmentNote;

                    // Đổi màu đỏ cho ghi chú cá nhân để cảnh báo bác sĩ (Tùy chọn)
                    if (!string.IsNullOrWhiteSpace(selectedVisit.PatientNote))
                    {
                        lbPatientNote.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbPatientNote.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}