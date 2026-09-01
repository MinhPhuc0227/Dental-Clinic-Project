namespace DentalClinic.APP
{
    partial class Dialog_MedicineImportHistory
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

        #region Windows Form Designer generated code

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
            panel1 = new Panel();
            txtSearch = new TextBox();
            cbSupplier = new ComboBox();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            dgvImportHistory = new DataGridView();
            panel5 = new Panel();
            label13 = new Label();
            panel3 = new Panel();
            dgvImportDetail = new DataGridView();
            panel6 = new Panel();
            lbTotalAmount = new Label();
            lbPaymentMethod = new Label();
            label12 = new Label();
            label11 = new Label();
            panel4 = new Panel();
            txtNote = new TextBox();
            lbAccount = new Label();
            lbSupplier = new Label();
            lbImportDate = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImportHistory).BeginInit();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImportDetail).BeginInit();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(cbSupplier);
            panel1.Controls.Add(dtpEnd);
            panel1.Controls.Add(dtpStart);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1228, 237);
            panel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(742, 165);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(233, 30);
            txtSearch.TabIndex = 42;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cbSupplier
            // 
            cbSupplier.Font = new Font("Segoe UI", 10F);
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(215, 164);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(226, 31);
            cbSupplier.TabIndex = 41;
            cbSupplier.SelectedIndexChanged += cbSupplier_SelectedIndexChanged;
            // 
            // dtpEnd
            // 
            dtpEnd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpEnd.CustomFormat = "dd/MM/yyyy";
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(742, 118);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(233, 30);
            dtpEnd.TabIndex = 40;
            dtpEnd.ValueChanged += dtpEnd_ValueChanged;
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "dd/MM/yyyy";
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(215, 120);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(226, 30);
            dtpStart.TabIndex = 39;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(632, 166);
            label5.Name = "label5";
            label5.Size = new Size(97, 28);
            label5.TabIndex = 38;
            label5.Text = "Tìm kiếm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(46, 164);
            label4.Name = "label4";
            label4.Size = new Size(142, 28);
            label4.TabIndex = 37;
            label4.Text = "Nhà cung cấp:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(46, 120);
            label2.Name = "label2";
            label2.Size = new Size(90, 28);
            label2.TabIndex = 36;
            label2.Text = "Từ ngày:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(632, 118);
            label3.Name = "label3";
            label3.Size = new Size(104, 28);
            label3.TabIndex = 35;
            label3.Text = "Đến ngày:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(421, 42);
            label1.Name = "label1";
            label1.Size = new Size(241, 32);
            label1.TabIndex = 34;
            label1.Text = "LỊCH SỬ NHẬP KHO";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvImportHistory);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 237);
            panel2.Name = "panel2";
            panel2.Size = new Size(582, 713);
            panel2.TabIndex = 1;
            // 
            // dgvImportHistory
            // 
            dgvImportHistory.AllowUserToAddRows = false;
            dgvImportHistory.AllowUserToDeleteRows = false;
            dgvImportHistory.AllowUserToOrderColumns = true;
            dgvImportHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportHistory.BackgroundColor = Color.White;
            dgvImportHistory.BorderStyle = BorderStyle.None;
            dgvImportHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvImportHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvImportHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvImportHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvImportHistory.DefaultCellStyle = dataGridViewCellStyle2;
            dgvImportHistory.Dock = DockStyle.Fill;
            dgvImportHistory.EnableHeadersVisualStyles = false;
            dgvImportHistory.GridColor = Color.DarkCyan;
            dgvImportHistory.Location = new Point(0, 58);
            dgvImportHistory.MultiSelect = false;
            dgvImportHistory.Name = "dgvImportHistory";
            dgvImportHistory.ReadOnly = true;
            dgvImportHistory.RowHeadersVisible = false;
            dgvImportHistory.RowHeadersWidth = 51;
            dgvImportHistory.RowTemplate.Height = 38;
            dgvImportHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImportHistory.Size = new Size(582, 655);
            dgvImportHistory.TabIndex = 7;
            dgvImportHistory.CellClick += dgvImportHistory_CellClick;
            // 
            // panel5
            // 
            panel5.Controls.Add(label13);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(582, 58);
            panel5.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label13.ForeColor = Color.DarkCyan;
            label13.Location = new Point(198, 16);
            label13.Name = "label13";
            label13.Size = new Size(133, 28);
            label13.TabIndex = 3;
            label13.Text = "PHIẾU NHẬP";
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvImportDetail);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(582, 237);
            panel3.Name = "panel3";
            panel3.Size = new Size(646, 713);
            panel3.TabIndex = 2;
            // 
            // dgvImportDetail
            // 
            dgvImportDetail.AllowUserToAddRows = false;
            dgvImportDetail.AllowUserToDeleteRows = false;
            dgvImportDetail.AllowUserToOrderColumns = true;
            dgvImportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportDetail.BackgroundColor = Color.White;
            dgvImportDetail.BorderStyle = BorderStyle.None;
            dgvImportDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvImportDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkCyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvImportDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvImportDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvImportDetail.DefaultCellStyle = dataGridViewCellStyle4;
            dgvImportDetail.Dock = DockStyle.Fill;
            dgvImportDetail.EnableHeadersVisualStyles = false;
            dgvImportDetail.GridColor = Color.DarkCyan;
            dgvImportDetail.Location = new Point(0, 235);
            dgvImportDetail.MultiSelect = false;
            dgvImportDetail.Name = "dgvImportDetail";
            dgvImportDetail.ReadOnly = true;
            dgvImportDetail.RowHeadersVisible = false;
            dgvImportDetail.RowHeadersWidth = 51;
            dgvImportDetail.RowTemplate.Height = 38;
            dgvImportDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImportDetail.Size = new Size(646, 387);
            dgvImportDetail.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Controls.Add(lbTotalAmount);
            panel6.Controls.Add(lbPaymentMethod);
            panel6.Controls.Add(label12);
            panel6.Controls.Add(label11);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 622);
            panel6.Name = "panel6";
            panel6.Size = new Size(646, 91);
            panel6.TabIndex = 2;
            // 
            // lbTotalAmount
            // 
            lbTotalAmount.AutoSize = true;
            lbTotalAmount.Font = new Font("Segoe UI", 10F);
            lbTotalAmount.Location = new Point(269, 14);
            lbTotalAmount.Name = "lbTotalAmount";
            lbTotalAmount.Size = new Size(80, 23);
            lbTotalAmount.TabIndex = 20;
            lbTotalAmount.Text = "tổng tiền";
            // 
            // lbPaymentMethod
            // 
            lbPaymentMethod.AutoSize = true;
            lbPaymentMethod.Font = new Font("Segoe UI", 10F);
            lbPaymentMethod.Location = new Point(269, 50);
            lbPaymentMethod.Name = "lbPaymentMethod";
            lbPaymentMethod.Size = new Size(199, 23);
            lbPaymentMethod.TabIndex = 19;
            lbPaymentMethod.Text = "phương thức thanh toán";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F);
            label12.ForeColor = Color.DarkCyan;
            label12.Location = new Point(24, 47);
            label12.Name = "label12";
            label12.Size = new Size(241, 28);
            label12.TabIndex = 16;
            label12.Text = "Phương thức thanh toán:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 12F);
            label11.ForeColor = Color.DarkCyan;
            label11.Location = new Point(24, 14);
            label11.Name = "label11";
            label11.Size = new Size(105, 28);
            label11.TabIndex = 15;
            label11.Text = "Tổng tiền:";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtNote);
            panel4.Controls.Add(lbAccount);
            panel4.Controls.Add(lbSupplier);
            panel4.Controls.Add(lbImportDate);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(646, 235);
            panel4.TabIndex = 1;
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Font = new Font("Segoe UI", 10F);
            txtNote.Location = new Point(174, 192);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(318, 30);
            txtNote.TabIndex = 43;
            // 
            // lbAccount
            // 
            lbAccount.AutoSize = true;
            lbAccount.Font = new Font("Segoe UI", 10F);
            lbAccount.Location = new Point(174, 150);
            lbAccount.Name = "lbAccount";
            lbAccount.Size = new Size(98, 23);
            lbAccount.TabIndex = 20;
            lbAccount.Text = "người nhập";
            // 
            // lbSupplier
            // 
            lbSupplier.AutoSize = true;
            lbSupplier.Font = new Font("Segoe UI", 10F);
            lbSupplier.Location = new Point(174, 106);
            lbSupplier.Name = "lbSupplier";
            lbSupplier.Size = new Size(114, 23);
            lbSupplier.TabIndex = 19;
            lbSupplier.Text = "nhà cung cấp";
            // 
            // lbImportDate
            // 
            lbImportDate.AutoSize = true;
            lbImportDate.Font = new Font("Segoe UI", 10F);
            lbImportDate.Location = new Point(174, 62);
            lbImportDate.Name = "lbImportDate";
            lbImportDate.Size = new Size(91, 23);
            lbImportDate.TabIndex = 18;
            lbImportDate.Text = "ngày nhập";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F);
            label10.ForeColor = Color.DarkCyan;
            label10.Location = new Point(24, 57);
            label10.Name = "label10";
            label10.Size = new Size(116, 28);
            label10.TabIndex = 17;
            label10.Text = "Ngày nhập:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F);
            label9.ForeColor = Color.DarkCyan;
            label9.Location = new Point(24, 101);
            label9.Name = "label9";
            label9.Size = new Size(142, 28);
            label9.TabIndex = 16;
            label9.Text = "Nhà cung cấp:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(24, 145);
            label8.Name = "label8";
            label8.Size = new Size(125, 28);
            label8.TabIndex = 15;
            label8.Text = "Người nhập:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(24, 189);
            label7.Name = "label7";
            label7.Size = new Size(87, 28);
            label7.TabIndex = 14;
            label7.Text = "Ghi chú:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(166, 16);
            label6.Name = "label6";
            label6.Size = new Size(219, 28);
            label6.TabIndex = 2;
            label6.Text = "CHI TIẾT PHIẾU NHẬP";
            // 
            // Dialog_MedicineImportHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1228, 950);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Dialog_MedicineImportHistory";
            Text = "Dialog_ImportHistory";
            Load += Dialog_MedicineImportHistory_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvImportHistory).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvImportDetail).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox txtSearch;
        private ComboBox cbSupplier;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label1;
        private Panel panel5;
        private Label label13;
        private Panel panel3;
        private DataGridView dgvImportHistory;
        private Panel panel4;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Panel panel6;
        private Label label12;
        private Label label11;
        private DataGridView dgvImportDetail;
        private Label lbTotalAmount;
        private Label lbPaymentMethod;
        private TextBox txtNote;
        private Label lbAccount;
        private Label lbSupplier;
        private Label lbImportDate;
    }
}