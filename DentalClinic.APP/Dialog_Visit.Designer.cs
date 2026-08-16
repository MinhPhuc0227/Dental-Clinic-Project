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
            lbCreatedDate = new Label();
            lbStatus = new Label();
            dtpAppointmentDate = new DateTimePicker();
            btAddPatient = new Button();
            cbPatient = new ComboBox();
            label11 = new Label();
            lbAppoinmentId = new Label();
            label7 = new Label();
            label4 = new Label();
            txtDescription = new TextBox();
            btCancel = new Button();
            label3 = new Label();
            label2 = new Label();
            btSave = new Button();
            label1 = new Label();
            lbReceptionist = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            comboBox1 = new ComboBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // lbCreatedDate
            // 
            lbCreatedDate.AutoSize = true;
            lbCreatedDate.Font = new Font("Segoe UI Semibold", 12F);
            lbCreatedDate.ForeColor = Color.DarkCyan;
            lbCreatedDate.Location = new Point(230, 402);
            lbCreatedDate.Name = "lbCreatedDate";
            lbCreatedDate.Size = new Size(186, 28);
            lbCreatedDate.TabIndex = 95;
            lbCreatedDate.Text = "thời gian tiếp nhận";
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI Semibold", 12F);
            lbStatus.ForeColor = Color.DarkCyan;
            lbStatus.Location = new Point(197, 444);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(193, 28);
            lbStatus.TabIndex = 94;
            lbStatus.Text = "trạng thái tiếp nhận";
            // 
            // dtpAppointmentDate
            // 
            dtpAppointmentDate.CustomFormat = "dd/MM/yyyy";
            dtpAppointmentDate.Font = new Font("Segoe UI", 10F);
            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.Location = new Point(194, 105);
            dtpAppointmentDate.Name = "dtpAppointmentDate";
            dtpAppointmentDate.Size = new Size(355, 30);
            dtpAppointmentDate.TabIndex = 91;
            // 
            // btAddPatient
            // 
            btAddPatient.FlatAppearance.BorderSize = 0;
            btAddPatient.FlatStyle = FlatStyle.Flat;
            btAddPatient.Image = Properties.Resources.add;
            btAddPatient.Location = new Point(491, 55);
            btAddPatient.Name = "btAddPatient";
            btAddPatient.Size = new Size(48, 41);
            btAddPatient.TabIndex = 89;
            btAddPatient.TextAlign = ContentAlignment.MiddleRight;
            btAddPatient.UseVisualStyleBackColor = true;
            // 
            // cbPatient
            // 
            cbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPatient.Font = new Font("Segoe UI", 10F);
            cbPatient.FormattingEnabled = true;
            cbPatient.Location = new Point(194, 60);
            cbPatient.Name = "cbPatient";
            cbPatient.Size = new Size(291, 31);
            cbPatient.TabIndex = 88;
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
            // lbAppoinmentId
            // 
            lbAppoinmentId.AutoSize = true;
            lbAppoinmentId.Font = new Font("Segoe UI Semibold", 12F);
            lbAppoinmentId.ForeColor = Color.DarkCyan;
            lbAppoinmentId.Location = new Point(194, 18);
            lbAppoinmentId.Name = "lbAppoinmentId";
            lbAppoinmentId.Size = new Size(85, 28);
            lbAppoinmentId.TabIndex = 84;
            lbAppoinmentId.Text = "tự động";
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
            label4.Location = new Point(34, 402);
            label4.Name = "label4";
            label4.Size = new Size(190, 28);
            label4.TabIndex = 82;
            label4.Text = "Thời gian tiếp nhận";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(194, 155);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(355, 119);
            txtDescription.TabIndex = 76;
            // 
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(354, 500);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 77;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(31, 155);
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
            label2.Location = new Point(34, 444);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 80;
            label2.Text = "Trạng thái";
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.DarkCyan;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(461, 500);
            btSave.Name = "btSave";
            btSave.Size = new Size(107, 40);
            btSave.TabIndex = 78;
            btSave.Text = "Xác nhận";
            btSave.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(32, 106);
            label1.Name = "label1";
            label1.Size = new Size(48, 28);
            label1.TabIndex = 79;
            label1.Text = "SĐT";
            // 
            // lbReceptionist
            // 
            lbReceptionist.AutoSize = true;
            lbReceptionist.Font = new Font("Segoe UI Semibold", 12F);
            lbReceptionist.ForeColor = Color.DarkCyan;
            lbReceptionist.Location = new Point(197, 360);
            lbReceptionist.Name = "lbReceptionist";
            lbReceptionist.Size = new Size(84, 28);
            lbReceptionist.TabIndex = 96;
            lbReceptionist.Text = "lịch hẹn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(34, 360);
            label5.Name = "label5";
            label5.Size = new Size(89, 28);
            label5.TabIndex = 85;
            label5.Text = "Lịch hẹn";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(197, 505);
            label6.Name = "label6";
            label6.Size = new Size(95, 28);
            label6.TabIndex = 98;
            label6.Text = "số thứ tự";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(34, 505);
            label8.Name = "label8";
            label8.Size = new Size(97, 28);
            label8.TabIndex = 97;
            label8.Text = "Số thứ tự";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(194, 295);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(291, 31);
            comboBox1.TabIndex = 100;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F);
            label9.ForeColor = Color.DarkCyan;
            label9.Location = new Point(32, 296);
            label9.Name = "label9";
            label9.Size = new Size(63, 28);
            label9.TabIndex = 99;
            label9.Text = "Bác sĩ";
            // 
            // Dialog_Visit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(631, 590);
            Controls.Add(comboBox1);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(lbReceptionist);
            Controls.Add(lbCreatedDate);
            Controls.Add(lbStatus);
            Controls.Add(dtpAppointmentDate);
            Controls.Add(btAddPatient);
            Controls.Add(cbPatient);
            Controls.Add(label11);
            Controls.Add(label5);
            Controls.Add(lbAppoinmentId);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(txtDescription);
            Controls.Add(btCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btSave);
            Controls.Add(label1);
            Name = "Dialog_Visit";
            Text = "Thông tin tiếp nhận";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbCreatedDate;
        private Label lbStatus;
        private DateTimePicker dtpAppointmentDate;
        private Button btAddPatient;
        private ComboBox cbPatient;
        private Label label11;
        private Label lbAppoinmentId;
        private Label label7;
        private Label label4;
        private TextBox txtDescription;
        private Button btCancel;
        private Label label3;
        private Label label2;
        private Button btSave;
        private Label label1;
        private Label lbReceptionist;
        private Label label5;
        private Label label6;
        private Label label8;
        private ComboBox comboBox1;
        private Label label9;
    }
}