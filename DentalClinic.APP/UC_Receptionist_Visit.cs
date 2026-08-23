using DentalClinic.BLL;
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
    public partial class UC_Receptionist_Visit : UserControl
    {
        private readonly Visit_BLL _visitBLL;
        private readonly int _currentReceptionistId;

        public UC_Receptionist_Visit(Visit_BLL visitBLL, int receptionistId)
        {
            InitializeComponent();
            _visitBLL = visitBLL;
            _currentReceptionistId = receptionistId;
        }

        private void UC_Receptionist_Visit_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            dtpDate.Value = DateTime.Today;

            // Đăng ký sự kiện tự động tìm kiếm
            dtpDate.ValueChanged += (s, ev) => LoadData();
            txtSearch.TextChanged += (s, ev) => LoadData();

            LoadData();
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
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CheckInDateTime", HeaderText = "Giờ Đến", Width = 120 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReasonForVisit", HeaderText = "Lý Do Khám", Width = 150 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StatusText", HeaderText = "Trạng Thái", Width = 100 });
            dgvVisit.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VisitType", HeaderText = "Loại", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        public void LoadData()
        {
            var result = _visitBLL.GetAllVisits(dtpDate.Value, txtSearch.Text);
            if (result.IsSuccess)
            {
                dgvVisit.DataSource = result.Data;
            }
        }

        private void btCreateVisit_Click(object sender, EventArgs e)
        {
            // Truyền _currentReceptionistId vào Dialog_Visit để lưu xuống dtb
            using (var dialog = new Dialog_Visit(_visitBLL, _currentReceptionistId))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
