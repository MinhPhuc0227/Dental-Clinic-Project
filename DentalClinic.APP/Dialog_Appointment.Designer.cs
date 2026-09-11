namespace DentalClinic.APP
{
    partial class Dialog_Appointment
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
            label4 = new Label();
            txtNote = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btSave = new Button();
            label1 = new Label();
            label5 = new Label();
            label8 = new Label();
            label11 = new Label();
            cbPatient = new ComboBox();
            btCreatePatient = new Button();
            lbAppointmentId = new Label();
            label7 = new Label();
            label9 = new Label();
            dtpAppointmentDate = new DateTimePicker();
            cbDoctor = new ComboBox();
            lbStatus = new Label();
            lbCreatedDate = new Label();
            lbReceptionist = new Label();
            txtReasonForVisit = new TextBox();
            label6 = new Label();
            btCancel = new Button();
            btCheckIn = new Button();
            dtpAppointmentTime = new DateTimePicker();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(18, 453);
            label4.Name = "label4";
            label4.Size = new Size(131, 28);
            label4.TabIndex = 54;
            label4.Text = "Ngày tạo lịch";
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Font = new Font("Segoe UI", 10F);
            txtNote.Location = new Point(181, 312);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = ScrollBars.Vertical;
            txtNote.Size = new Size(355, 62);
            txtNote.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(18, 312);
            label3.Name = "label3";
            label3.Size = new Size(99, 28);
            label3.TabIndex = 53;
            label3.Text = "Chú thích";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(18, 495);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 52;
            label2.Text = "Trạng thái";
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.FromArgb(0, 184, 148);
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(435, 555);
            btSave.Name = "btSave";
            btSave.Size = new Size(101, 40);
            btSave.TabIndex = 9;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(19, 123);
            label1.Name = "label1";
            label1.Size = new Size(116, 28);
            label1.TabIndex = 51;
            label1.Text = "Ngày khám";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(18, 411);
            label5.Name = "label5";
            label5.Size = new Size(68, 28);
            label5.TabIndex = 57;
            label5.Text = "Lễ tân";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(18, 211);
            label8.Name = "label8";
            label8.Size = new Size(63, 28);
            label8.TabIndex = 59;
            label8.Text = "Bác sĩ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 12F);
            label11.ForeColor = Color.DarkCyan;
            label11.Location = new Point(19, 78);
            label11.Name = "label11";
            label11.Size = new Size(111, 28);
            label11.TabIndex = 62;
            label11.Text = "Bệnh nhân";
            // 
            // cbPatient
            // 
            cbPatient.Font = new Font("Segoe UI", 10F);
            cbPatient.FormattingEnabled = true;
            cbPatient.Location = new Point(181, 77);
            cbPatient.Name = "cbPatient";
            cbPatient.Size = new Size(291, 31);
            cbPatient.TabIndex = 1;
            // 
            // btCreatePatient
            // 
            btCreatePatient.FlatAppearance.BorderSize = 0;
            btCreatePatient.FlatStyle = FlatStyle.Flat;
            btCreatePatient.Image = Properties.Resources.add;
            btCreatePatient.Location = new Point(478, 72);
            btCreatePatient.Name = "btCreatePatient";
            btCreatePatient.Size = new Size(48, 41);
            btCreatePatient.TabIndex = 2;
            btCreatePatient.TextAlign = ContentAlignment.MiddleRight;
            btCreatePatient.UseVisualStyleBackColor = true;
            btCreatePatient.Click += btCreatePatient_Click;
            // 
            // lbAppointmentId
            // 
            lbAppointmentId.AutoSize = true;
            lbAppointmentId.Font = new Font("Segoe UI", 12F);
            lbAppointmentId.ForeColor = Color.Black;
            lbAppointmentId.Location = new Point(181, 35);
            lbAppointmentId.Name = "lbAppointmentId";
            lbAppointmentId.Size = new Size(24, 28);
            lbAppointmentId.TabIndex = 56;
            lbAppointmentId.Text = "...";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(19, 35);
            label7.Name = "label7";
            label7.Size = new Size(123, 28);
            label7.TabIndex = 55;
            label7.Text = "Mã lịch hẹn:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F);
            label9.ForeColor = Color.DarkCyan;
            label9.Location = new Point(18, 167);
            label9.Name = "label9";
            label9.Size = new Size(100, 28);
            label9.TabIndex = 69;
            label9.Text = "Giờ khám";
            // 
            // dtpAppointmentDate
            // 
            dtpAppointmentDate.CustomFormat = "dd/MM/yyyy";
            dtpAppointmentDate.Font = new Font("Segoe UI", 10F);
            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.Location = new Point(181, 122);
            dtpAppointmentDate.Name = "dtpAppointmentDate";
            dtpAppointmentDate.Size = new Size(355, 30);
            dtpAppointmentDate.TabIndex = 3;
            // 
            // cbDoctor
            // 
            cbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoctor.Font = new Font("Segoe UI", 10F);
            cbDoctor.FormattingEnabled = true;
            cbDoctor.Location = new Point(181, 210);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(355, 31);
            cbDoctor.TabIndex = 5;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 12F);
            lbStatus.ForeColor = Color.Black;
            lbStatus.Location = new Point(181, 495);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(24, 28);
            lbStatus.TabIndex = 73;
            lbStatus.Text = "...";
            // 
            // lbCreatedDate
            // 
            lbCreatedDate.AutoSize = true;
            lbCreatedDate.Font = new Font("Segoe UI", 12F);
            lbCreatedDate.ForeColor = Color.Black;
            lbCreatedDate.Location = new Point(181, 453);
            lbCreatedDate.Name = "lbCreatedDate";
            lbCreatedDate.Size = new Size(24, 28);
            lbCreatedDate.TabIndex = 74;
            lbCreatedDate.Text = "...";
            // 
            // lbReceptionist
            // 
            lbReceptionist.AutoSize = true;
            lbReceptionist.Font = new Font("Segoe UI", 12F);
            lbReceptionist.ForeColor = Color.Black;
            lbReceptionist.Location = new Point(181, 411);
            lbReceptionist.Name = "lbReceptionist";
            lbReceptionist.Size = new Size(24, 28);
            lbReceptionist.TabIndex = 75;
            lbReceptionist.Text = "...";
            // 
            // txtReasonForVisit
            // 
            txtReasonForVisit.BorderStyle = BorderStyle.FixedSingle;
            txtReasonForVisit.Font = new Font("Segoe UI", 10F);
            txtReasonForVisit.Location = new Point(181, 263);
            txtReasonForVisit.Name = "txtReasonForVisit";
            txtReasonForVisit.Size = new Size(355, 30);
            txtReasonForVisit.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(19, 263);
            label6.Name = "label6";
            label6.Size = new Size(118, 28);
            label6.TabIndex = 77;
            label6.Text = "Lý do khám";
            // 
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(20, 555);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 10;
            btCancel.Text = "Hủy lịch";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // btCheckIn
            // 
            btCheckIn.AutoSize = true;
            btCheckIn.BackColor = SystemColors.HotTrack;
            btCheckIn.FlatStyle = FlatStyle.Flat;
            btCheckIn.Font = new Font("Segoe UI Semibold", 12F);
            btCheckIn.ForeColor = Color.White;
            btCheckIn.Location = new Point(137, 555);
            btCheckIn.Name = "btCheckIn";
            btCheckIn.Size = new Size(115, 40);
            btCheckIn.TabIndex = 11;
            btCheckIn.Text = "Tiếp nhận";
            btCheckIn.UseVisualStyleBackColor = false;
            btCheckIn.Click += btCheckIn_Click;
            // 
            // dtpAppointmentTime
            // 
            dtpAppointmentTime.CustomFormat = "HH:mm";
            dtpAppointmentTime.Font = new Font("Segoe UI", 10F);
            dtpAppointmentTime.Format = DateTimePickerFormat.Custom;
            dtpAppointmentTime.Location = new Point(181, 167);
            dtpAppointmentTime.Name = "dtpAppointmentTime";
            dtpAppointmentTime.ShowUpDown = true;
            dtpAppointmentTime.Size = new Size(355, 30);
            dtpAppointmentTime.TabIndex = 4;
            // 
            // Dialog_Appointment
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(565, 615);
            Controls.Add(dtpAppointmentTime);
            Controls.Add(btCheckIn);
            Controls.Add(btCancel);
            Controls.Add(label6);
            Controls.Add(txtReasonForVisit);
            Controls.Add(lbReceptionist);
            Controls.Add(lbCreatedDate);
            Controls.Add(lbStatus);
            Controls.Add(cbDoctor);
            Controls.Add(dtpAppointmentDate);
            Controls.Add(label9);
            Controls.Add(btCreatePatient);
            Controls.Add(cbPatient);
            Controls.Add(label11);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(lbAppointmentId);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(txtNote);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btSave);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_Appointment";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += Dialog_Appointment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private TextBox txtNote;
        private Label label3;
        private Label label2;
        private Button btSave;
        private Label label1;
        private Label label5;
        private Label label8;
        private Label label11;
        private ComboBox cbPatient;
        private Button btCreatePatient;
        private Label lbAppointmentId;
        private Label label7;
        private Label label9;
        private DateTimePicker dtpAppointmentDate;
        private ComboBox cbDoctor;
        private Label lbStatus;
        private Label lbCreatedDate;
        private Label lbReceptionist;
        private TextBox txtReasonForVisit;
        private Label label6;
        private Button btCancel;
        private Button btCheckIn;
        private DateTimePicker dtpAppointmentTime;
    }
}