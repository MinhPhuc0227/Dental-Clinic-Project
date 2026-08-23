using DentalClinic.BLL;
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
    public partial class UC_Receptionist_WaitingQueue : UserControl
    {
        private readonly Visit_BLL _visitBLL; // Đảm bảo bạn đã truyền BLL này từ Form_Receptionist vào

        public UC_Receptionist_WaitingQueue(Visit_BLL visitBLL)
        {
            InitializeComponent();
            _visitBLL = visitBLL;
        }

        private void UC_Receptionist_WaitingQueue_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            InitFilterControls();
            LoadData();
        }

        private void InitFilterControls()
        {
            dtpDate.Value = DateTime.Today;

            // 1. Nạp danh sách bác sĩ
            var doctorRes = _visitBLL.GetDoctorsLookup(); // Giả sử bạn có hàm này
            if (doctorRes.IsSuccess && doctorRes.Data != null)
            {
                var doctors = new List<LookupItemDto> { new LookupItemDto { Id = 0, Name = "-- Tất cả Bác sĩ --" } };
                doctors.AddRange(doctorRes.Data);
                cbDoctor.DataSource = doctors;
                cbDoctor.DisplayMember = "Name";
                cbDoctor.ValueMember = "Id";
            }

            // 2. Nạp danh sách Trạng thái (Mặc định chọn "Đang chờ khám")
            var statusList = new List<object>
            {
                new { Value = (VisitStatus?)null, Text = "-- Tất cả Trạng thái --" },
                new { Value = (VisitStatus?)VisitStatus.Waiting, Text = "Đang chờ khám" },
                new { Value = (VisitStatus?)VisitStatus.InExamination, Text = "Đang khám" },
                new { Value = (VisitStatus?)VisitStatus.Completed, Text = "Khám xong" }
            };
            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";

            // Ép ComboBox chọn dòng "Đang chờ khám" làm mặc định
            cbStatus.SelectedIndex = 1;

            // 3. Đăng ký sự kiện tự động lọc khi thay đổi
            dtpDate.ValueChanged += (s, e) => LoadData();
            cbDoctor.SelectedIndexChanged += (s, e) => LoadData();
            cbStatus.SelectedIndexChanged += (s, e) => LoadData();
            txtSearch.TextChanged += (s, e) => LoadData();
        }

        private void SetupDataGridView()
        {
            dgvWaitingQueue.AutoGenerateColumns = false;
            dgvWaitingQueue.Columns.Clear();

            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QueueNumber", HeaderText = "STT", Width = 50 });
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Bệnh Nhân", Width = 150 });
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientPhone", HeaderText = "SĐT", Width = 100 });
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Bác Sĩ", Width = 150 });
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TimeString", HeaderText = "Giờ Nhận", Width = 90 });
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StatusText", HeaderText = "Trạng Thái", Width = 110 });
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReasonForVisit", HeaderText = "Lý Do Khám", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        public void LoadData()
        {
            DateTime selectedDate = dtpDate.Value;
            string keyword = txtSearch.Text;
            int? doctorId = cbDoctor.SelectedValue is int dId && dId > 0 ? dId : null;
            VisitStatus? status = cbStatus.SelectedValue as VisitStatus?;

            var result = _visitBLL.GetWaitingQueue(selectedDate, keyword, doctorId, status);
            if (result.IsSuccess)
            {
                dgvWaitingQueue.DataSource = result.Data;
            }
            else
            {
                MessageBox.Show(result.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
