namespace DentalClinic.APP
{
    partial class Dialog_Visit
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
            lbCheckInDateTime = new Label();
            lbStatus = new Label();
            btCreatePatient = new Button();
            cbPatient = new ComboBox();
            label11 = new Label();
            lbPatientId = new Label();
            label7 = new Label();
            label4 = new Label();
            txtReasonForVisit = new TextBox();
            btCancel = new Button();
            label3 = new Label();
            label2 = new Label();
            btSave = new Button();
            lbAppointmentId = new Label();
            lbVisitId = new Label();
            lbQueueNumber = new Label();
            label8 = new Label();
            cbDoctor = new ComboBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // lbCheckInDateTime
            // 
            lbCheckInDateTime.AutoSize = true;
            lbCheckInDateTime.Font = new Font("Segoe UI", 12F);
            lbCheckInDateTime.ForeColor = Color.Black;
            lbCheckInDateTime.Location = new Point(243, 364);
            lbCheckInDateTime.Name = "lbCheckInDateTime";
            lbCheckInDateTime.Size = new Size(24, 28);
            lbCheckInDateTime.TabIndex = 95;
            lbCheckInDateTime.Text = "...";
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 12F);
            lbStatus.ForeColor = Color.Black;
            lbStatus.Location = new Point(243, 412);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(24, 28);
            lbStatus.TabIndex = 94;
            lbStatus.Text = "...";
            // 
            // btCreatePatient
            // 
            btCreatePatient.FlatAppearance.BorderSize = 0;
            btCreatePatient.FlatStyle = FlatStyle.Flat;
            btCreatePatient.Image = Properties.Resources.add;
            btCreatePatient.Location = new Point(491, 55);
            btCreatePatient.Name = "btCreatePatient";
            btCreatePatient.Size = new Size(48, 41);
            btCreatePatient.TabIndex = 2;
            btCreatePatient.TextAlign = ContentAlignment.MiddleRight;
            btCreatePatient.UseVisualStyleBackColor = true;
            btCreatePatient.Click += btCreatePatient_Click;
            // 
            // cbPatient
            // 
            cbPatient.Font = new Font("Segoe UI", 10F);
            cbPatient.FormattingEnabled = true;
            cbPatient.Location = new Point(194, 60);
            cbPatient.Name = "cbPatient";
            cbPatient.Size = new Size(291, 31);
            cbPatient.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 12F);
            label11.ForeColor = Color.DarkCyan;
            label11.Location = new Point(32, 61);
            label11.Name = "label11";
            label11.Size = new Size(75, 28);
            label11.TabIndex = 87;
            label11.Text = "Họ tên";
            // 
            // lbPatientId
            // 
            lbPatientId.AutoSize = true;
            lbPatientId.Font = new Font("Segoe UI Semibold", 12F);
            lbPatientId.ForeColor = Color.DarkCyan;
            lbPatientId.Location = new Point(194, 18);
            lbPatientId.Name = "lbPatientId";
            lbPatientId.Size = new Size(85, 28);
            lbPatientId.TabIndex = 84;
            lbPatientId.Text = "tự động";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(32, 18);
            label7.Name = "label7";
            label7.Size = new Size(150, 28);
            label7.TabIndex = 83;
            label7.Text = "Mã bệnh nhân:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(32, 364);
            label4.Name = "label4";
            label4.Size = new Size(195, 28);
            label4.TabIndex = 82;
            label4.Text = "Thời gian tiếp nhận:";
            // 
            // txtReasonForVisit
            // 
            txtReasonForVisit.BorderStyle = BorderStyle.FixedSingle;
            txtReasonForVisit.Font = new Font("Segoe UI", 10F);
            txtReasonForVisit.Location = new Point(194, 111);
            txtReasonForVisit.Multiline = true;
            txtReasonForVisit.Name = "txtReasonForVisit";
            txtReasonForVisit.ScrollBars = ScrollBars.Vertical;
            txtReasonForVisit.Size = new Size(355, 119);
            txtReasonForVisit.TabIndex = 3;
            // 
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(335, 522);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 5;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(32, 111);
            label3.Name = "label3";
            label3.Size = new Size(118, 28);
            label3.TabIndex = 81;
            label3.Text = "Lý do khám";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(32, 412);
            label2.Name = "label2";
            label2.Size = new Size(107, 28);
            label2.TabIndex = 80;
            label2.Text = "Trạng thái:";
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.FromArgb(0, 184, 148);
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(442, 522);
            btSave.Name = "btSave";
            btSave.Size = new Size(107, 40);
            btSave.TabIndex = 6;
            btSave.Text = "Xác nhận";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // lbAppointmentId
            // 
            lbAppointmentId.AutoSize = true;
            lbAppointmentId.Font = new Font("Segoe UI", 12F);
            lbAppointmentId.ForeColor = Color.Black;
            lbAppointmentId.Location = new Point(243, 316);
            lbAppointmentId.Name = "lbAppointmentId";
            lbAppointmentId.Size = new Size(24, 28);
            lbAppointmentId.TabIndex = 96;
            lbAppointmentId.Text = "...";
            // 
            // lbVisitId
            // 
            lbVisitId.AutoSize = true;
            lbVisitId.Font = new Font("Segoe UI Semibold", 12F);
            lbVisitId.ForeColor = Color.DarkCyan;
            lbVisitId.Location = new Point(32, 316);
            lbVisitId.Name = "lbVisitId";
            lbVisitId.Size = new Size(205, 28);
            lbVisitId.TabIndex = 85;
            lbVisitId.Text = "Mã lịch hẹn (nếu có):";
            // 
            // lbQueueNumber
            // 
            lbQueueNumber.AutoSize = true;
            lbQueueNumber.Font = new Font("Segoe UI", 12F);
            lbQueueNumber.ForeColor = Color.Black;
            lbQueueNumber.Location = new Point(243, 460);
            lbQueueNumber.Name = "lbQueueNumber";
            lbQueueNumber.Size = new Size(24, 28);
            lbQueueNumber.TabIndex = 98;
            lbQueueNumber.Text = "...";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(32, 460);
            label8.Name = "label8";
            label8.Size = new Size(102, 28);
            label8.TabIndex = 97;
            label8.Text = "Số thứ tự:";
            // 
            // cbDoctor
            // 
            cbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoctor.Font = new Font("Segoe UI", 10F);
            cbDoctor.FormattingEnabled = true;
            cbDoctor.Location = new Point(194, 251);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(355, 31);
            cbDoctor.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F);
            label9.ForeColor = Color.DarkCyan;
            label9.Location = new Point(32, 252);
            label9.Name = "label9";
            label9.Size = new Size(63, 28);
            label9.TabIndex = 99;
            label9.Text = "Bác sĩ";
            // 
            // Dialog_Visit
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btCancel;
            ClientSize = new Size(585, 588);
            Controls.Add(cbDoctor);
            Controls.Add(label9);
            Controls.Add(lbQueueNumber);
            Controls.Add(label8);
            Controls.Add(lbAppointmentId);
            Controls.Add(lbCheckInDateTime);
            Controls.Add(lbStatus);
            Controls.Add(btCreatePatient);
            Controls.Add(cbPatient);
            Controls.Add(label11);
            Controls.Add(lbVisitId);
            Controls.Add(lbPatientId);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(txtReasonForVisit);
            Controls.Add(btCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_Visit";
            StartPosition = FormStartPosition.CenterParent;
            Load += Dialog_Visit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbCheckInDateTime;
        private Label lbStatus;
        private Button btCreatePatient;
        private ComboBox cbPatient;
        private Label label11;
        private Label lbPatientId;
        private Label label7;
        private Label label4;
        private TextBox txtReasonForVisit;
        private Button btCancel;
        private Label label3;
        private Label label2;
        private Button btSave;
        private Label lbAppointmentId;
        private Label lbVisitId;
        private Label lbQueueNumber;
        private Label label8;
        private ComboBox cbDoctor;
        private Label label9;
    }
}