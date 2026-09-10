using DentalClinic.APP;
using DentalClinic.BLL;
using DentalClinic.MODEL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.App
{
    public partial class Form_Admin : Form
    {
        private readonly int _currentAccountId;

        private UC_DashBoard dashboardUC;
        private UC_Account accountUC;
        private UC_Doctor doctorUC;
        private UC_Receptionist receptionistUC;
        private UC_Patient patientUC;
        private UC_Service serviceUC;
        private UC_Medicine medicineUC;
        private UC_PaymentMethod paymentUC;
        private UC_Supplier supplierUC;

        // Dependency Injection
        private readonly IServiceProvider _serviceProvider;

        // BLL
        private readonly Dashboard_BLL _dashboardBLL;
        private readonly Account_BLL _accountBLL;

        public Form_Admin(int accountId, Dashboard_BLL dashboardBLL, Account_BLL accountBLL, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _currentAccountId = accountId;
            _dashboardBLL = dashboardBLL;
            _accountBLL = accountBLL;
            _serviceProvider = serviceProvider;

            dashboardUC = new UC_DashBoard(_dashboardBLL);
            accountUC = ActivatorUtilities.CreateInstance<UC_Account>(_serviceProvider, _currentAccountId);
            doctorUC = ActivatorUtilities.CreateInstance<UC_Doctor>(_serviceProvider);
            receptionistUC = ActivatorUtilities.CreateInstance<UC_Receptionist>(_serviceProvider);
            patientUC = ActivatorUtilities.CreateInstance<UC_Patient>(_serviceProvider);
            serviceUC = ActivatorUtilities.CreateInstance<UC_Service>(_serviceProvider);
            medicineUC = ActivatorUtilities.CreateInstance<UC_Medicine>(_serviceProvider, _currentAccountId);
            paymentUC = ActivatorUtilities.CreateInstance<UC_PaymentMethod>(_serviceProvider);
            supplierUC = ActivatorUtilities.CreateInstance<UC_Supplier>(_serviceProvider);
        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {
            ShowUC(dashboardUC);
            dashboardUC.LoadDashboard();
        }

        // HÀM MỞ UC
        private void ShowUC(UserControl uc)
        {
            if (!pnContent.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                pnContent.Controls.Add(uc);
            }

            uc.BringToFront();
        }

        // DASHBOARD
        private void rbDashBoard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDashBoard.Checked)
            {
                ShowUC(dashboardUC);
                dashboardUC.LoadDashboard();
            }
        }

        // ACCOUNT
        private void rbAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAccount.Checked)
            {
                ShowUC(accountUC);
                accountUC.LoadDataToGridView();
            }
        }

        // SERVICE
        private void rbService_CheckedChanged(object sender, EventArgs e)
        {
            if (rbService.Checked)
            {
                ShowUC(serviceUC);
                serviceUC.LoadDataToGridView();
            }
        }

        // MEDICINE
        private void rbMedicine_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMedicine.Checked)
            {
                ShowUC(medicineUC);
                medicineUC.LoadDataToGridView();
            }
        }

        // PAYMENTMETHOD
        private void rbPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPayment.Checked)
            {
                ShowUC(paymentUC);
                paymentUC.LoadDataToGridView();
            }
        }

        // DOCTOR
        private void rbDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDoctor.Checked)
            {
                ShowUC(doctorUC);
                doctorUC.LoadDataToGridView();
            }
        }

        // RECEPTIONIST
        private void rbReceptionist_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReceptionist.Checked)
            {
                ShowUC(receptionistUC);
                receptionistUC.LoadDataToGridView();
            }
        }

        // PATIENT
        private void rbPatient_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPatient.Checked)
            {
                ShowUC(patientUC);
                patientUC.LoadDataToGridView();
            }
        }

        // SUPPLIER
        private void rbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSupplier.Checked)
            {
                ShowUC(supplierUC);
                supplierUC.LoadData();
            }
        }

        // LOG OUT
        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
