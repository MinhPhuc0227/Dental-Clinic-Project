using DentalClinic.BLL;
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
    public partial class UC_Receptionist_Visit : UserControl
    {
        private readonly int _currentReceptionistId;

        private readonly IServiceProvider _serviceProvider;

        private readonly Visit_BLL _visitBLL;

        public UC_Receptionist_Visit(Visit_BLL visitBLL, IServiceProvider serviceProvider, int receptionistId)
        {
            InitializeComponent();
            _visitBLL = visitBLL;
            _serviceProvider = serviceProvider;
            _currentReceptionistId = receptionistId;
        }

        private void UC_Receptionist_Visit_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            InitFilterControls();
            LoadData();
        }

        private void InitFilterControls()
        {
            DateTime today = DateTime.Today;
            dtpStart.Value = today;
            dtpEnd.Value = today;
   
            var doctorResult = _visitBLL.GetDoctorsLookup();

            if (doctorResult.IsSuccess && doctorResult.Data != null)
            {
                var doctors = new List<LookupItemDto>
                {
                    new LookupItemDto {Id = 0, Name = "Tất cả Bác sĩ"}
                };

                doctors.AddRange(doctorResult.Data);
                cbDoctor.DataSource = doctors;
                cbDoctor.DisplayMember = "Name";
                cbDoctor.ValueMember = "Id";
                cbDoctor.SelectedIndex = 0;
            }

            var statusList = new[]
            {
                new { Value = (VisitStatus?)null, Text = "Tất cả Trạng thái" },
                new { Value = (VisitStatus?)VisitStatus.Waiting, Text = "Chờ khám" },
                new { Value = (VisitStatus?)VisitStatus.InExamination, Text = "Đang khám" },
                new { Value = (VisitStatus?)VisitStatus.WaitingForPayment, Text = "Chờ thanh toán" },
                new { Value = (VisitStatus?)VisitStatus.Completed, Text = "Khám xong" },
                new { Value = (VisitStatus?)VisitStatus.Cancelled, Text = "Đã hủy" }
            };

            cbStatus.DataSource = statusList;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;

            var sortList = new List<object>
            {
                new { Value = "VisitIdAsc", Text = "Mã tiếp nhận tăng dần" },
                new { Value = "VisitIdDesc", Text = "Mã tiếp nhận giảm dần" },
                new { Value = "QueueAsc", Text = "STT tăng dần" },
                new { Value = "QueueDesc", Text = "STT giảm dần" }
            };

            cbSort.DataSource = sortList;
            cbSort.DisplayMember = "Text";
            cbSort.ValueMember = "Value";
            cbSort.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvVisit.AutoGenerateColumns = false;
            dgvVisit.Columns.Clear();
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VisitId", HeaderText = "Mã tiếp nhận", Width = 50 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QueueNumber", HeaderText = "STT", Width = 50 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Bệnh Nhân", Width = 150 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientPhone", HeaderText = "SĐT", Width = 100 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Bác Sĩ", Width = 150 });

            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CheckInDateTime",
                HeaderText = "Ngày Đến",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReasonForVisit", HeaderText = "Lý Do Khám", Width = 150 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StatusText", HeaderText = "Trạng Thái", Width = 100 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VisitType", HeaderText = "Loại", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        public void LoadData()
        {
            int? doctorId = null;

            if (cbDoctor.SelectedValue is int dId && dId > 0)
            {
                doctorId = dId;
            }

            VisitStatus? status = null;

            if (cbStatus.SelectedValue is VisitStatus selectedStatus)
            {
                status = selectedStatus;
            }

            var result = _visitBLL.GetAllVisits(
                dtpStart.Value.Date,
                dtpEnd.Value.Date,
                txtSearch.Text.Trim(),
                doctorId,
                status);

            if (!result.IsSuccess || result.Data == null)
            {
                dgvVisit.DataSource = null;
                MessageBox.Show(
                    result.Message,
                    "Thông báo lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var visits = result.Data;

            switch (cbSort.SelectedValue?.ToString())
            {
                case "VisitIdAsc":
                    visits = visits.OrderBy(v => v.VisitId).ToList();
                    break;

                case "VisitIdDesc":
                    visits = visits.OrderByDescending(v => v.VisitId).ToList();
                    break;

                case "QueueAsc":
                    visits = visits.OrderBy(v => v.QueueNumber).ToList();
                    break;

                case "QueueDesc":
                    visits = visits.OrderByDescending(v => v.QueueNumber).ToList();
                    break;
            }

            dgvVisit.DataSource = null;
            dgvVisit.DataSource = visits;
        }

        private void btCreateVisit_Click(object sender, EventArgs e)
        {
            using (var dialog = ActivatorUtilities.CreateInstance<Dialog_Visit>(_serviceProvider, _currentReceptionistId))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
