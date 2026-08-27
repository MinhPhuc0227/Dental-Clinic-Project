using DentalClinic.BLL;
using DentalClinic.DAL;
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
    public partial class Form_Receptionist : Form
    {
        // 1. Khai báo biến lưu thông tin Lễ tân đang đăng nhập
        private readonly int _currentReceptionistId;
        private readonly string _currentReceptionistName;

        // 2. Khai báo các User Control
        private UC_Receptionist_Visit VisitUC;
        private UC_Receptionist_Appointment AppointmentUC;
        private UC_Receptionist_WaitingQueue WaitingQueueUC;
        private UC_Receptionist_Invoice InvoiceUC;
        private UC_Receptionist_InvoiceList InvoiceListUC;

        // 3. Khai báo BLL
        private readonly Appointment_BLL _appointmentBLL = new Appointment_BLL(new Appointment_DAL(new AppDbContext()));
        private readonly Visit_BLL _visitBLL = new Visit_BLL(new Visit_DAL(new AppDbContext()));
        private readonly Receptionist_BLL _receptionistBLL = new Receptionist_BLL();

        public Form_Receptionist(int accountId, string receptionistName)
        {
            InitializeComponent();

            var receptionist = _receptionistBLL.GetReceptionistByAccountId(accountId);

            if (receptionist != null)
            {
                _currentReceptionistId = receptionist.ReceptionistId; // Lấy đúng ID = 1 của bảng Receptionist
                _currentReceptionistName = receptionist.FullName;
            }
            else
            {
                _currentReceptionistId = 0;
                _currentReceptionistName = receptionistName;
            }

            // 4. Khởi tạo UC và truyền chính xác ID, Tên động vào
            AppointmentUC = new UC_Receptionist_Appointment(_appointmentBLL, _currentReceptionistId, _currentReceptionistName);
            WaitingQueueUC = new UC_Receptionist_WaitingQueue(_visitBLL);
            VisitUC = new UC_Receptionist_Visit(_visitBLL, _currentReceptionistId);
            InvoiceUC = new UC_Receptionist_Invoice(_currentReceptionistId);
            InvoiceListUC = new UC_Receptionist_InvoiceList();
            InvoiceListUC.InvoiceChanged += InvoiceListUC_InvoiceChanged;

            this.Text = $"Lễ tân: {_currentReceptionistName}";

            ShowUC(VisitUC);
        }

        private void InvoiceListUC_InvoiceChanged(object? sender, EventArgs e)
        {
            InvoiceUC?.LoadWaitingList();
        }

        private void ShowUC(UserControl uc)
        {
            if (uc == null) return;

            if (!pnContent.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                pnContent.Controls.Add(uc);
            }

            uc.BringToFront();
        }

        private void rbVisit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVisit.Checked)
            {
                ShowUC(VisitUC);
                VisitUC?.LoadData();
            }
        }

        private void rbAppointment_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAppointment.Checked)
            {
                ShowUC(AppointmentUC);
                AppointmentUC?.LoadData();
            }
        }

        private void rbWaitingQueue_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWaitingQueue.Checked)
            {
                ShowUC(WaitingQueueUC);
                WaitingQueueUC?.LoadData();
            }
        }

        private void rbInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInvoice.Checked)
            {
                ShowUC(InvoiceUC);
                InvoiceUC?.LoadWaitingList();
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbInvoiceList_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInvoiceList.Checked)
            {
                ShowUC(InvoiceListUC);
                InvoiceListUC?.LoadData();
            }
        }
    }
}
