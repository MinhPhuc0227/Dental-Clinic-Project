namespace DentalClinic.APP
{
    partial class UC_Doctor_Examination
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
            panel1 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            dgvWaitingQueue = new DataGridView();
            panel2 = new Panel();
            lbFullName = new Label();
            label7 = new Label();
            label1 = new Label();
            lbPhone = new Label();
            label3 = new Label();
            lbPatientNote = new Label();
            label5 = new Label();
            lbReasonForVisit = new Label();
            label8 = new Label();
            lbAppointmentNote = new Label();
            label10 = new Label();
            btViewMedicalHistory = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaitingQueue).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 192);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(700, 712);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(btViewMedicalHistory);
            panel4.Controls.Add(lbAppointmentNote);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(lbReasonForVisit);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(lbPatientNote);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(lbPhone);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(lbFullName);
            panel4.Controls.Add(label7);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(10, 288);
            panel4.Name = "panel4";
            panel4.Size = new Size(680, 414);
            panel4.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvWaitingQueue);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(10, 10);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 0, 0, 10);
            panel3.Size = new Size(680, 278);
            panel3.TabIndex = 0;
            // 
            // dgvWaitingQueue
            // 
            dgvWaitingQueue.AllowUserToAddRows = false;
            dgvWaitingQueue.AllowUserToDeleteRows = false;
            dgvWaitingQueue.AllowUserToOrderColumns = true;
            dgvWaitingQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWaitingQueue.BackgroundColor = Color.White;
            dgvWaitingQueue.BorderStyle = BorderStyle.None;
            dgvWaitingQueue.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvWaitingQueue.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvWaitingQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvWaitingQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvWaitingQueue.DefaultCellStyle = dataGridViewCellStyle2;
            dgvWaitingQueue.Dock = DockStyle.Fill;
            dgvWaitingQueue.EnableHeadersVisualStyles = false;
            dgvWaitingQueue.GridColor = Color.DarkCyan;
            dgvWaitingQueue.Location = new Point(0, 0);
            dgvWaitingQueue.MultiSelect = false;
            dgvWaitingQueue.Name = "dgvWaitingQueue";
            dgvWaitingQueue.ReadOnly = true;
            dgvWaitingQueue.RowHeadersVisible = false;
            dgvWaitingQueue.RowHeadersWidth = 51;
            dgvWaitingQueue.RowTemplate.Height = 38;
            dgvWaitingQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWaitingQueue.Size = new Size(680, 268);
            dgvWaitingQueue.TabIndex = 6;
            dgvWaitingQueue.CellClick += dgvWaitingQueue_CellClick;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(710, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(410, 712);
            panel2.TabIndex = 1;
            // 
            // lbFullName
            // 
            lbFullName.AutoSize = true;
            lbFullName.Font = new Font("Segoe UI", 12F);
            lbFullName.ForeColor = Color.Black;
            lbFullName.Location = new Point(268, 73);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(112, 28);
            lbFullName.TabIndex = 29;
            lbFullName.Text = "lbFullName";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(15, 73);
            label7.Name = "label7";
            label7.Size = new Size(80, 28);
            label7.TabIndex = 28;
            label7.Text = "Họ tên:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(11, 23);
            label1.Name = "label1";
            label1.Size = new Size(300, 32);
            label1.TabIndex = 30;
            label1.Text = "THÔNG TIN BỆNH NHÂN";
            // 
            // lbPhone
            // 
            lbPhone.AutoSize = true;
            lbPhone.Font = new Font("Segoe UI", 12F);
            lbPhone.ForeColor = Color.Black;
            lbPhone.Location = new Point(268, 117);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(84, 28);
            lbPhone.TabIndex = 32;
            lbPhone.Text = "lbPhone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(15, 117);
            label3.Name = "label3";
            label3.Size = new Size(53, 28);
            label3.TabIndex = 31;
            label3.Text = "SĐT:";
            // 
            // lbPatientNote
            // 
            lbPatientNote.AutoSize = true;
            lbPatientNote.Font = new Font("Segoe UI", 12F);
            lbPatientNote.ForeColor = Color.Black;
            lbPatientNote.Location = new Point(268, 161);
            lbPatientNote.Name = "lbPatientNote";
            lbPatientNote.Size = new Size(133, 28);
            lbPatientNote.TabIndex = 34;
            lbPatientNote.Text = "lbPatientNote";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(15, 161);
            label5.Name = "label5";
            label5.Size = new Size(246, 28);
            label5.TabIndex = 33;
            label5.Text = "Ghi chú cá nhân (nếu có):";
            // 
            // lbReasonForVisit
            // 
            lbReasonForVisit.AutoSize = true;
            lbReasonForVisit.Font = new Font("Segoe UI", 12F);
            lbReasonForVisit.ForeColor = Color.Black;
            lbReasonForVisit.Location = new Point(268, 205);
            lbReasonForVisit.Name = "lbReasonForVisit";
            lbReasonForVisit.Size = new Size(157, 28);
            lbReasonForVisit.TabIndex = 36;
            lbReasonForVisit.Text = "lbReasonForVisit";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(15, 249);
            label8.Name = "label8";
            label8.Size = new Size(247, 28);
            label8.TabIndex = 35;
            label8.Text = "Ghi chú lịch hẹn (nếu có):";
            // 
            // lbAppointmentNote
            // 
            lbAppointmentNote.AutoSize = true;
            lbAppointmentNote.Font = new Font("Segoe UI", 12F);
            lbAppointmentNote.ForeColor = Color.Black;
            lbAppointmentNote.Location = new Point(268, 249);
            lbAppointmentNote.Name = "lbAppointmentNote";
            lbAppointmentNote.Size = new Size(190, 28);
            lbAppointmentNote.TabIndex = 38;
            lbAppointmentNote.Text = "lbAppointmentNote";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F);
            label10.ForeColor = Color.DarkCyan;
            label10.Location = new Point(15, 205);
            label10.Name = "label10";
            label10.Size = new Size(123, 28);
            label10.TabIndex = 37;
            label10.Text = "Lý do khám:";
            // 
            // btViewMedicalHistory
            // 
            btViewMedicalHistory.Location = new Point(455, 23);
            btViewMedicalHistory.Name = "btViewMedicalHistory";
            btViewMedicalHistory.Size = new Size(203, 50);
            btViewMedicalHistory.TabIndex = 39;
            btViewMedicalHistory.Text = "Xem lịch sử khám";
            btViewMedicalHistory.UseVisualStyleBackColor = true;
            // 
            // UC_Doctor_Examination
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Doctor_Examination";
            Padding = new Padding(10);
            Size = new Size(1130, 732);
            Load += UC_Doctor_Examination_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWaitingQueue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvWaitingQueue;
        private Panel panel4;
        private Panel panel3;
        private Label lbFullName;
        private Label label7;
        private Label label1;
        private Label lbAppointmentNote;
        private Label label10;
        private Label lbReasonForVisit;
        private Label label8;
        private Label lbPatientNote;
        private Label label5;
        private Label lbPhone;
        private Label label3;
        private Button btViewMedicalHistory;
    }
}
