using DentalClinic.APP;
using DentalClinic.MODEL;
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

        public Form_Admin(int accountId)
        {
            InitializeComponent();

            _currentAccountId = accountId;

            dashboardUC = new UC_DashBoard();
            accountUC = new UC_Account();
            doctorUC = new UC_Doctor();
            receptionistUC = new UC_Receptionist();
            patientUC = new UC_Patient();
            serviceUC = new UC_Service();

            // Truyền AccountId của Admin đang đăng nhập
            medicineUC = new UC_Medicine(_currentAccountId);

            paymentUC = new UC_PaymentMethod();
            supplierUC = new UC_Supplier();
        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {
            ShowUC(dashboardUC);
            dashboardUC.LoadDashboard();
        }

        private void ShowUC(UserControl uc)
        {
            if (!pnContent.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                pnContent.Controls.Add(uc);
            }

            uc.BringToFront();
        }

        private void rbDashBoard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDashBoard.Checked)
            {
                ShowUC(dashboardUC);

                dashboardUC.LoadDashboard();
            }
        }

        private void rbAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAccount.Checked)
            {
                ShowUC(accountUC);
                accountUC.LoadDataToGridView();
            }
        }

        private void rbService_CheckedChanged(object sender, EventArgs e)
        {
            if (rbService.Checked)
            {
                ShowUC(serviceUC);
                serviceUC.LoadDataToGridView();
            }
        }

        private void rbMedicine_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMedicine.Checked)
            {
                ShowUC(medicineUC);
                medicineUC.LoadDataToGridView();
            }
        }

        private void rbPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPayment.Checked)
            {
                ShowUC(paymentUC);
                paymentUC.LoadDataToGridView();
            }
        }

        private void rbDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDoctor.Checked)
            {
                ShowUC(doctorUC);
                doctorUC.LoadDataToGridView();
            }
        }

        private void rbReceptionist_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReceptionist.Checked)
            {
                ShowUC(receptionistUC);
                receptionistUC.LoadDataToGridView();
            }
        }

        private void rbPatient_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPatient.Checked)
            {
                ShowUC(patientUC);
                patientUC.LoadDataToGridView();
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSupplier.Checked)
            {
                ShowUC(supplierUC);
                supplierUC.LoadData();
            }
        }
    }
}
