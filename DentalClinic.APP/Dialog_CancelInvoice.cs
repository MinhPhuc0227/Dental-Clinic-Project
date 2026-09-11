using System;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_CancelInvoice : Form
    {
        public string CancellationReason { get; private set; } = string.Empty;

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
            lbCancelledDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            txtOtherReason.Clear();
            txtOtherReason.Focus();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            string reason = txtOtherReason.Text.Trim();

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show(
                    "Vui lòng nhập lý do hủy hóa đơn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtOtherReason.Focus();
                return;
            }

            CancellationReason = reason;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}