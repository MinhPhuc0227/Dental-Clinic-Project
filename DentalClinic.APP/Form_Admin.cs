using DentalClinic.APP;
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
        private UC_DashBoard dashboardUC = new UC_DashBoard();
        private UC_Account userUC = new UC_Account();
        private UC_Service serviceUC = new UC_Service();
        private UC_Medicine medicineUC = new UC_Medicine();
        private UC_PaymentMethod paymentUC = new UC_PaymentMethod();

        public Form_Admin()
        {
            InitializeComponent();
        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {
            //ShowUC(dashboardUC);
            ShowUC(paymentUC);
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
            ShowUC(dashboardUC);
        }

        private void rbAccount_CheckedChanged(object sender, EventArgs e)
        {
            ShowUC(userUC);
        }

        private void rbService_CheckedChanged(object sender, EventArgs e)
        {
            ShowUC(serviceUC);
        }

        private void rbMedicine_CheckedChanged(object sender, EventArgs e)
        {
            ShowUC(medicineUC);
        }

        private void rbPayment_CheckedChanged(object sender, EventArgs e)
        {
            ShowUC(paymentUC);
        }
    }
}
