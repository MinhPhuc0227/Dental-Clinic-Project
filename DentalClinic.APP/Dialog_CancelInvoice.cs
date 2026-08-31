using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_CancelInvoice : Form
    {
        public string CancellationReason { get; private set; } = string.Empty;

        // Chỉ dùng trong Dialog, KHÔNG lưu vào Invoice
        public bool RequiresMedicalRecordUpdate { get; private set; }

        private readonly string _receptionistName;
        private readonly decimal _totalAmount;

        public Dialog_CancelInvoice(
            string receptionistName,
            decimal totalAmount)
        {
            InitializeComponent();

            _receptionistName = receptionistName;
            _totalAmount = totalAmount;

            lbCancelledBy.Text = receptionistName;
            lbCancelledDate.Text =
                DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            rbPermanent.Checked = true;
            txtOtherReason.Clear();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            string detail = txtOtherReason.Text.Trim();

            // Hủy hoàn toàn
            if (rbPermanent.Checked)
            {
                RequiresMedicalRecordUpdate = false;

                CancellationReason =
                    "Hủy hoàn toàn hóa đơn";

                if (!string.IsNullOrWhiteSpace(detail))
                {
                    CancellationReason +=
                        ": " + detail;
                }
            }
            // Thay đổi thuốc/dịch vụ
            else if (rbModifyMedicalRecord.Checked)
            {
                RequiresMedicalRecordUpdate = true;

                CancellationReason =
                    "Thay đổi thuốc/dịch vụ";

                if (!string.IsNullOrWhiteSpace(detail))
                {
                    CancellationReason +=
                        ": " + detail;
                }
            }
            else
            {
                MessageBox.Show(
                    "Vui lòng chọn lý do hủy hóa đơn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
