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
        private UC_Account accountUC = new UC_Account();
        private UC_Doctor doctorUC = new UC_Doctor();
        private UC_Receptionist receptionistUC = new UC_Receptionist();
        private UC_Patient patientUC = new UC_Patient();
        private UC_Service serviceUC = new UC_Service();
        private UC_Medicine medicineUC = new UC_Medicine();
        private UC_PaymentMethod paymentUC = new UC_PaymentMethod();

        public Form_Admin()
        {
            InitializeComponent();
        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {
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
                // dashboardUC.LoadDataToGridView(); // Gọi nếu Dashboard có hàm load dữ liệu
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
    }
}
