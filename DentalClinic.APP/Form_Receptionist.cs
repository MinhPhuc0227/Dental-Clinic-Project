using DentalClinic.BLL;
using DentalClinic.DAL;
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
        private readonly Receptionist_BLL _receptionistBLL;
        private readonly Visit_BLL _visitBLL;
        private readonly Appointment_BLL _appointmentBLL;

        // dependency injection
        private readonly IServiceProvider _serviceProvider;

        public Form_Receptionist(
            int accountId,
            string receptionistName,
            Receptionist_BLL receptionistBLL,
            Visit_BLL visitBLL,
            Appointment_BLL appointmentBLL,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _receptionistBLL = receptionistBLL;
            _visitBLL = visitBLL;
            _appointmentBLL = appointmentBLL;
            _serviceProvider = serviceProvider;

            var receptionist =
                _receptionistBLL.GetReceptionistByAccountId(accountId);

            if (receptionist != null)
            {
                _currentReceptionistId = receptionist.ReceptionistId;
                _currentReceptionistName = receptionist.FullName;
            }
            else
            {
                _currentReceptionistId = 0;
                _currentReceptionistName = receptionistName;
            }

            AppointmentUC = new UC_Receptionist_Appointment(
                _appointmentBLL,
                _visitBLL,
                _serviceProvider,
                _currentReceptionistId,
                _currentReceptionistName);

            WaitingQueueUC = new UC_Receptionist_WaitingQueue(
                _visitBLL);

            VisitUC = new UC_Receptionist_Visit(
                _visitBLL,
                _serviceProvider,
                _currentReceptionistId);

            InvoiceUC = ActivatorUtilities.CreateInstance<UC_Receptionist_Invoice>(
                _serviceProvider,
                _currentReceptionistId,
                _currentReceptionistName);

            InvoiceListUC = ActivatorUtilities.CreateInstance<UC_Receptionist_InvoiceList>(
                _serviceProvider,
                _currentReceptionistId,
                _currentReceptionistName);

            InvoiceListUC.InvoiceChanged += InvoiceListUC_InvoiceChanged;

            this.Text = $"Lễ tân: {_currentReceptionistName}";
            rbVisit.Checked = true;
            ShowUC(VisitUC);
        }

        // SỰ KIỆN 
        private void InvoiceListUC_InvoiceChanged(object? sender, EventArgs e)
        {
            InvoiceUC?.LoadWaitingList();
        }

        // HÀM MỞ UC
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

        // VISIT
        private void rbVisit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVisit.Checked)
            {
                ShowUC(VisitUC);
                VisitUC?.LoadData();
            }
        }

        // APPOINTMENT
        private void rbAppointment_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAppointment.Checked)
            {
                ShowUC(AppointmentUC);
                AppointmentUC?.LoadData();
            }
        }

        // WAITING QUEUE
        private void rbWaitingQueue_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWaitingQueue.Checked)
            {
                ShowUC(WaitingQueueUC);
                WaitingQueueUC?.LoadData();
            }
        }

        // INVOICE
        private void rbInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInvoice.Checked)
            {
                ShowUC(InvoiceUC);
                InvoiceUC?.LoadWaitingList();
            }
        }

        // INVOCIE LIST
        private void rbInvoiceList_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInvoiceList.Checked)
            {
                ShowUC(InvoiceListUC);
                InvoiceListUC?.LoadData();
            }
        }

        // LOG OUT
        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
