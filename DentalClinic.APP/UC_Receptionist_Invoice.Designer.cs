namespace DentalClinic.APP
{
    partial class UC_Receptionist_Invoice
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnLeft = new Panel();
            dgvWaitingList = new DataGridView();
            panel2 = new Panel();
            label3 = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            pnRight = new Panel();
            dgvInvoiceDetail = new DataGridView();
            panel5 = new Panel();
            label14 = new Label();
            label13 = new Label();
            txtChange = new TextBox();
            txtAmountGiven = new TextBox();
            label12 = new Label();
            label10 = new Label();
            label11 = new Label();
            btPayment = new Button();
            btCancel = new Button();
            cbPaymentMethod = new ComboBox();
            lbTotalAmount = new Label();
            label9 = new Label();
            label8 = new Label();
            panel4 = new Panel();
            label6 = new Label();
            lbDoctorName = new Label();
            label5 = new Label();
            lbPhone = new Label();
            label4 = new Label();
            lbPatientName = new Label();
            label7 = new Label();
            label2 = new Label();
            pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaitingList).BeginInit();
            panel2.SuspendLayout();
            pnRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceDetail).BeginInit();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // pnLeft
            // 
            pnLeft.BorderStyle = BorderStyle.FixedSingle;
            pnLeft.Controls.Add(dgvWaitingList);
            pnLeft.Controls.Add(panel2);
            pnLeft.Dock = DockStyle.Left;
            pnLeft.Location = new Point(10, 10);
            pnLeft.Name = "pnLeft";
            pnLeft.Padding = new Padding(0, 0, 10, 0);
            pnLeft.Size = new Size(600, 751);
            pnLeft.TabIndex = 0;
            // 
            // dgvWaitingList
            // 
            dgvWaitingList.AllowUserToAddRows = false;
            dgvWaitingList.AllowUserToDeleteRows = false;
            dgvWaitingList.AllowUserToOrderColumns = true;
            dgvWaitingList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWaitingList.BackgroundColor = Color.White;
            dgvWaitingList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvWaitingList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvWaitingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvWaitingList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvWaitingList.DefaultCellStyle = dataGridViewCellStyle2;
            dgvWaitingList.Dock = DockStyle.Fill;
            dgvWaitingList.EnableHeadersVisualStyles = false;
            dgvWaitingList.GridColor = Color.DarkCyan;
            dgvWaitingList.Location = new Point(0, 124);
            dgvWaitingList.MultiSelect = false;
            dgvWaitingList.Name = "dgvWaitingList";
            dgvWaitingList.ReadOnly = true;
            dgvWaitingList.RowHeadersVisible = false;
            dgvWaitingList.RowHeadersWidth = 51;
            dgvWaitingList.RowTemplate.Height = 38;
            dgvWaitingList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWaitingList.Size = new Size(588, 625);
            dgvWaitingList.TabIndex = 7;
            dgvWaitingList.CellClick += dgvWaitingList_CellClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(588, 124);
            panel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(14, 76);
            label3.Name = "label3";
            label3.Size = new Size(319, 28);
            label3.TabIndex = 33;
            label3.Text = "DANH SÁCH CHỜ THANH TOÁN";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(231, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(303, 30);
            txtSearch.TabIndex = 32;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(14, 27);
            label1.Name = "label1";
            label1.Size = new Size(211, 28);
            label1.TabIndex = 31;
            label1.Text = "Tìm kiếm bệnh nhân:";
            // 
            // pnRight
            // 
            pnRight.BorderStyle = BorderStyle.FixedSingle;
            pnRight.Controls.Add(dgvInvoiceDetail);
            pnRight.Controls.Add(panel5);
            pnRight.Controls.Add(panel4);
            pnRight.Dock = DockStyle.Fill;
            pnRight.Location = new Point(610, 10);
            pnRight.Name = "pnRight";
            pnRight.Padding = new Padding(10, 0, 0, 0);
            pnRight.Size = new Size(526, 751);
            pnRight.TabIndex = 1;
            // 
            // dgvInvoiceDetail
            // 
            dgvInvoiceDetail.AllowUserToAddRows = false;
            dgvInvoiceDetail.AllowUserToDeleteRows = false;
            dgvInvoiceDetail.AllowUserToOrderColumns = true;
            dgvInvoiceDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoiceDetail.BackgroundColor = Color.White;
            dgvInvoiceDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInvoiceDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkCyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvInvoiceDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvInvoiceDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvInvoiceDetail.DefaultCellStyle = dataGridViewCellStyle4;
            dgvInvoiceDetail.Dock = DockStyle.Fill;
            dgvInvoiceDetail.EnableHeadersVisualStyles = false;
            dgvInvoiceDetail.GridColor = Color.DarkCyan;
            dgvInvoiceDetail.Location = new Point(10, 250);
            dgvInvoiceDetail.MultiSelect = false;
            dgvInvoiceDetail.Name = "dgvInvoiceDetail";
            dgvInvoiceDetail.ReadOnly = true;
            dgvInvoiceDetail.RowHeadersVisible = false;
            dgvInvoiceDetail.RowHeadersWidth = 51;
            dgvInvoiceDetail.RowTemplate.Height = 38;
            dgvInvoiceDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceDetail.Size = new Size(514, 233);
            dgvInvoiceDetail.TabIndex = 8;
            // 
            // panel5
            // 
            panel5.Controls.Add(label14);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(txtChange);
            panel5.Controls.Add(txtAmountGiven);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(btPayment);
            panel5.Controls.Add(btCancel);
            panel5.Controls.Add(cbPaymentMethod);
            panel5.Controls.Add(lbTotalAmount);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label8);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(10, 483);
            panel5.Name = "panel5";
            panel5.Size = new Size(514, 266);
            panel5.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(454, 103);
            label14.Name = "label14";
            label14.Size = new Size(53, 28);
            label14.TabIndex = 52;
            label14.Text = "VNĐ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(454, 147);
            label13.Name = "label13";
            label13.Size = new Size(53, 28);
            label13.TabIndex = 51;
            label13.Text = "VNĐ";
            // 
            // txtChange
            // 
            txtChange.BorderStyle = BorderStyle.FixedSingle;
            txtChange.Font = new Font("Segoe UI", 10F);
            txtChange.Location = new Point(257, 145);
            txtChange.Name = "txtChange";
            txtChange.ReadOnly = true;
            txtChange.Size = new Size(191, 30);
            txtChange.TabIndex = 50;
            // 
            // txtAmountGiven
            // 
            txtAmountGiven.BorderStyle = BorderStyle.FixedSingle;
            txtAmountGiven.Font = new Font("Segoe UI", 10F);
            txtAmountGiven.Location = new Point(257, 101);
            txtAmountGiven.Name = "txtAmountGiven";
            txtAmountGiven.Size = new Size(191, 30);
            txtAmountGiven.TabIndex = 49;
            txtAmountGiven.TextChanged += txtAmountGiven_TextChanged;
            txtAmountGiven.KeyPress += txtAmountGiven_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F);
            label12.ForeColor = Color.DarkCyan;
            label12.Location = new Point(10, 143);
            label12.Name = "label12";
            label12.Size = new Size(146, 28);
            label12.TabIndex = 48;
            label12.Text = "Tiền trả khách:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F);
            label10.ForeColor = Color.DarkCyan;
            label10.Location = new Point(10, 101);
            label10.Name = "label10";
            label10.Size = new Size(156, 28);
            label10.TabIndex = 47;
            label10.Text = "Tiền khách đưa:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(454, 17);
            label11.Name = "label11";
            label11.Size = new Size(53, 28);
            label11.TabIndex = 46;
            label11.Text = "VNĐ";
            // 
            // btPayment
            // 
            btPayment.Location = new Point(375, 211);
            btPayment.Name = "btPayment";
            btPayment.Size = new Size(132, 41);
            btPayment.TabIndex = 45;
            btPayment.Text = "Thanh toán";
            btPayment.UseVisualStyleBackColor = true;
            btPayment.Click += btPayment_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(258, 211);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(100, 41);
            btCancel.TabIndex = 44;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cbPaymentMethod.FormattingEnabled = true;
            cbPaymentMethod.Location = new Point(257, 58);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new Size(250, 31);
            cbPaymentMethod.TabIndex = 43;
            cbPaymentMethod.SelectedIndexChanged += cbPaymentMethod_SelectedIndexChanged;
            // 
            // lbTotalAmount
            // 
            lbTotalAmount.AutoSize = true;
            lbTotalAmount.Font = new Font("Segoe UI", 12F);
            lbTotalAmount.ForeColor = Color.Black;
            lbTotalAmount.Location = new Point(257, 17);
            lbTotalAmount.Name = "lbTotalAmount";
            lbTotalAmount.Size = new Size(142, 28);
            lbTotalAmount.TabIndex = 42;
            lbTotalAmount.Text = "lbTotalAmount";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F);
            label9.ForeColor = Color.DarkCyan;
            label9.Location = new Point(10, 17);
            label9.Name = "label9";
            label9.Size = new Size(115, 28);
            label9.TabIndex = 41;
            label9.Text = "Tổng cộng:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(10, 61);
            label8.Name = "label8";
            label8.Size = new Size(241, 28);
            label8.TabIndex = 40;
            label8.Text = "Phương thức thanh toán:";
            // 
            // panel4
            // 
            panel4.Controls.Add(label6);
            panel4.Controls.Add(lbDoctorName);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(lbPhone);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(lbPatientName);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(10, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(514, 250);
            panel4.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(10, 204);
            label6.Name = "label6";
            label6.Size = new Size(232, 28);
            label6.TabIndex = 41;
            label6.Text = "CHI TIẾT THANH TOÁN";
            // 
            // lbDoctorName
            // 
            lbDoctorName.AutoSize = true;
            lbDoctorName.Font = new Font("Segoe UI", 12F);
            lbDoctorName.ForeColor = Color.Black;
            lbDoctorName.Location = new Point(141, 150);
            lbDoctorName.Name = "lbDoctorName";
            lbDoctorName.Size = new Size(142, 28);
            lbDoctorName.TabIndex = 40;
            lbDoctorName.Text = "lbDoctorName";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(10, 150);
            label5.Name = "label5";
            label5.Size = new Size(125, 28);
            label5.TabIndex = 39;
            label5.Text = "Bác sĩ khám:";
            // 
            // lbPhone
            // 
            lbPhone.AutoSize = true;
            lbPhone.Font = new Font("Segoe UI", 12F);
            lbPhone.ForeColor = Color.Black;
            lbPhone.Location = new Point(141, 106);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(84, 28);
            lbPhone.TabIndex = 38;
            lbPhone.Text = "lbPhone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(10, 106);
            label4.Name = "label4";
            label4.Size = new Size(53, 28);
            label4.TabIndex = 37;
            label4.Text = "SĐT:";
            // 
            // lbPatientName
            // 
            lbPatientName.AutoSize = true;
            lbPatientName.Font = new Font("Segoe UI", 12F);
            lbPatientName.ForeColor = Color.Black;
            lbPatientName.Location = new Point(141, 62);
            lbPatientName.Name = "lbPatientName";
            lbPatientName.Size = new Size(141, 28);
            lbPatientName.TabIndex = 36;
            lbPatientName.Text = "lbPatientName";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(10, 62);
            label7.Name = "label7";
            label7.Size = new Size(80, 28);
            label7.TabIndex = 35;
            label7.Text = "Họ tên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(10, 11);
            label2.Name = "label2";
            label2.Size = new Size(316, 28);
            label2.TabIndex = 31;
            label2.Text = "THÔNG TIN HÓA ĐƠN ĐIỀU TRỊ";
            // 
            // UC_Receptionist_Invoice
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(pnRight);
            Controls.Add(pnLeft);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Receptionist_Invoice";
            Padding = new Padding(10);
            Size = new Size(1146, 771);
            Load += UC_Receptionist_Invoice_Load;
            pnLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWaitingList).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceDetail).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnLeft;
        private Panel panel2;
        private TextBox txtSearch;
        private Label label1;
        private Panel pnRight;
        private Panel panel4;
        private Label label2;
        private Label label3;
        private DataGridView dgvWaitingList;
        private Panel panel5;
        private DataGridView dgvInvoiceDetail;
        private Button btPayment;
        private Button btCancel;
        private ComboBox cbPaymentMethod;
        private Label lbTotalAmount;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label lbDoctorName;
        private Label label5;
        private Label lbPhone;
        private Label label4;
        private Label lbPatientName;
        private Label label7;
        private Label label11;
        private Label label14;
        private Label label13;
        private TextBox txtChange;
        private TextBox txtAmountGiven;
        private Label label12;
        private Label label10;
    }
}
