namespace DentalClinic.APP
{
    partial class Form_Doctor
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
            pnContent = new Panel();
            panel2 = new Panel();
            rbExamination = new RadioButton();
            btLogout = new Button();
            rbMedicalRecord = new RadioButton();
            rbDoctorAppointment = new RadioButton();
            panel1 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnContent
            // 
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(210, 66);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(802, 543);
            pnContent.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkCyan;
            panel2.Controls.Add(rbExamination);
            panel2.Controls.Add(btLogout);
            panel2.Controls.Add(rbMedicalRecord);
            panel2.Controls.Add(rbDoctorAppointment);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(10, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 543);
            panel2.TabIndex = 6;
            // 
            // rbExamination
            // 
            rbExamination.Appearance = Appearance.Button;
            rbExamination.FlatAppearance.BorderSize = 0;
            rbExamination.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbExamination.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbExamination.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbExamination.FlatStyle = FlatStyle.Flat;
            rbExamination.Font = new Font("Segoe UI Semibold", 12F);
            rbExamination.ForeColor = Color.White;
            rbExamination.Location = new Point(0, 0);
            rbExamination.Name = "rbExamination";
            rbExamination.Size = new Size(200, 60);
            rbExamination.TabIndex = 8;
            rbExamination.Text = "Khám Bệnh";
            rbExamination.UseVisualStyleBackColor = true;
            rbExamination.CheckedChanged += rbExamination_CheckedChanged;
            // 
            // btLogout
            // 
            btLogout.Font = new Font("Segoe UI", 12F);
            btLogout.Location = new Point(13, 487);
            btLogout.Margin = new Padding(4);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(172, 43);
            btLogout.TabIndex = 1;
            btLogout.Text = "Đăng xuất";
            btLogout.UseVisualStyleBackColor = true;
            btLogout.Click += btLogout_Click_1;
            // 
            // rbMedicalRecord
            // 
            rbMedicalRecord.Appearance = Appearance.Button;
            rbMedicalRecord.FlatAppearance.BorderSize = 0;
            rbMedicalRecord.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbMedicalRecord.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbMedicalRecord.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbMedicalRecord.FlatStyle = FlatStyle.Flat;
            rbMedicalRecord.Font = new Font("Segoe UI Semibold", 12F);
            rbMedicalRecord.ForeColor = Color.White;
            rbMedicalRecord.Location = new Point(0, 120);
            rbMedicalRecord.Name = "rbMedicalRecord";
            rbMedicalRecord.Size = new Size(200, 60);
            rbMedicalRecord.TabIndex = 5;
            rbMedicalRecord.Text = "Bệnh Án";
            rbMedicalRecord.UseVisualStyleBackColor = true;
            rbMedicalRecord.CheckedChanged += rbMedicalRecord_CheckedChanged;
            // 
            // rbDoctorAppointment
            // 
            rbDoctorAppointment.Appearance = Appearance.Button;
            rbDoctorAppointment.FlatAppearance.BorderSize = 0;
            rbDoctorAppointment.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbDoctorAppointment.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbDoctorAppointment.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbDoctorAppointment.FlatStyle = FlatStyle.Flat;
            rbDoctorAppointment.Font = new Font("Segoe UI Semibold", 12F);
            rbDoctorAppointment.ForeColor = Color.White;
            rbDoctorAppointment.Location = new Point(0, 60);
            rbDoctorAppointment.Name = "rbDoctorAppointment";
            rbDoctorAppointment.Size = new Size(200, 60);
            rbDoctorAppointment.TabIndex = 4;
            rbDoctorAppointment.Text = "Lịch Hẹn Của Tôi";
            rbDoctorAppointment.UseVisualStyleBackColor = true;
            rbDoctorAppointment.CheckedChanged += rbDoctorAppointment_CheckedChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkCyan;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1002, 56);
            panel1.TabIndex = 5;
            // 
            // Form_Doctor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1022, 619);
            Controls.Add(pnContent);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form_Doctor";
            Padding = new Padding(10);
            Text = "Form_Doctor";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnContent;
        private Panel panel2;
        private RadioButton rbExamination;
        private Button btLogout;
        private RadioButton rbMedicalRecord;
        private RadioButton rbDoctorAppointment;
        private Panel panel1;
    }
}