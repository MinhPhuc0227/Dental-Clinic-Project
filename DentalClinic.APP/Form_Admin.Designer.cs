namespace DentalClinic.App
{
    partial class Form_Admin
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
            panel1 = new Panel();
            panel2 = new Panel();
            btLogout = new Button();
            panel3 = new Panel();
            rbMedicine = new RadioButton();
            rbService = new RadioButton();
            rbDoctor = new RadioButton();
            rbPayment = new RadioButton();
            rbReceptionist = new RadioButton();
            rbPatient = new RadioButton();
            rbAccount = new RadioButton();
            rbDashBoard = new RadioButton();
            pnContent = new Panel();
            rbSupplier = new RadioButton();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkCyan;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1019, 56);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkCyan;
            panel2.Controls.Add(btLogout);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 624);
            panel2.Name = "panel2";
            panel2.Size = new Size(1019, 63);
            panel2.TabIndex = 1;
            // 
            // btLogout
            // 
            btLogout.Font = new Font("Segoe UI", 12F);
            btLogout.Location = new Point(25, 10);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(120, 41);
            btLogout.TabIndex = 0;
            btLogout.Text = "Đăng xuất";
            btLogout.UseVisualStyleBackColor = true;
            btLogout.Click += btLogout_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkCyan;
            panel3.Controls.Add(rbSupplier);
            panel3.Controls.Add(rbMedicine);
            panel3.Controls.Add(rbService);
            panel3.Controls.Add(rbDoctor);
            panel3.Controls.Add(rbPayment);
            panel3.Controls.Add(rbReceptionist);
            panel3.Controls.Add(rbPatient);
            panel3.Controls.Add(rbAccount);
            panel3.Controls.Add(rbDashBoard);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 56);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 568);
            panel3.TabIndex = 2;
            // 
            // rbMedicine
            // 
            rbMedicine.Appearance = Appearance.Button;
            rbMedicine.BackColor = Color.DarkCyan;
            rbMedicine.FlatAppearance.BorderSize = 0;
            rbMedicine.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbMedicine.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbMedicine.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbMedicine.FlatStyle = FlatStyle.Flat;
            rbMedicine.Font = new Font("Segoe UI Semibold", 12F);
            rbMedicine.ForeColor = Color.White;
            rbMedicine.Location = new Point(0, 336);
            rbMedicine.Name = "rbMedicine";
            rbMedicine.Size = new Size(200, 60);
            rbMedicine.TabIndex = 2;
            rbMedicine.Text = "Thuốc";
            rbMedicine.UseVisualStyleBackColor = false;
            rbMedicine.CheckedChanged += rbMedicine_CheckedChanged;
            // 
            // rbService
            // 
            rbService.Appearance = Appearance.Button;
            rbService.BackColor = Color.DarkCyan;
            rbService.FlatAppearance.BorderSize = 0;
            rbService.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbService.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbService.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbService.FlatStyle = FlatStyle.Flat;
            rbService.Font = new Font("Segoe UI Semibold", 12F);
            rbService.ForeColor = Color.White;
            rbService.Location = new Point(0, 280);
            rbService.Name = "rbService";
            rbService.Size = new Size(200, 60);
            rbService.TabIndex = 3;
            rbService.Text = "Dịch vụ";
            rbService.UseVisualStyleBackColor = false;
            rbService.CheckedChanged += rbService_CheckedChanged;
            // 
            // rbDoctor
            // 
            rbDoctor.Appearance = Appearance.Button;
            rbDoctor.BackColor = Color.DarkCyan;
            rbDoctor.FlatAppearance.BorderSize = 0;
            rbDoctor.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbDoctor.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbDoctor.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbDoctor.FlatStyle = FlatStyle.Flat;
            rbDoctor.Font = new Font("Segoe UI Semibold", 12F);
            rbDoctor.ForeColor = Color.White;
            rbDoctor.Location = new Point(0, 112);
            rbDoctor.Name = "rbDoctor";
            rbDoctor.Size = new Size(200, 60);
            rbDoctor.TabIndex = 8;
            rbDoctor.Text = "Bác sĩ";
            rbDoctor.UseVisualStyleBackColor = false;
            rbDoctor.CheckedChanged += rbDoctor_CheckedChanged;
            // 
            // rbPayment
            // 
            rbPayment.Appearance = Appearance.Button;
            rbPayment.BackColor = Color.DarkCyan;
            rbPayment.FlatAppearance.BorderSize = 0;
            rbPayment.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbPayment.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbPayment.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbPayment.FlatStyle = FlatStyle.Flat;
            rbPayment.Font = new Font("Segoe UI Semibold", 12F);
            rbPayment.ForeColor = Color.White;
            rbPayment.Location = new Point(0, 392);
            rbPayment.Name = "rbPayment";
            rbPayment.Size = new Size(200, 60);
            rbPayment.TabIndex = 1;
            rbPayment.Text = "Thanh toán";
            rbPayment.UseVisualStyleBackColor = false;
            rbPayment.CheckedChanged += rbPayment_CheckedChanged;
            // 
            // rbReceptionist
            // 
            rbReceptionist.Appearance = Appearance.Button;
            rbReceptionist.BackColor = Color.DarkCyan;
            rbReceptionist.FlatAppearance.BorderSize = 0;
            rbReceptionist.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbReceptionist.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbReceptionist.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbReceptionist.FlatStyle = FlatStyle.Flat;
            rbReceptionist.Font = new Font("Segoe UI Semibold", 12F);
            rbReceptionist.ForeColor = Color.White;
            rbReceptionist.Location = new Point(0, 168);
            rbReceptionist.Name = "rbReceptionist";
            rbReceptionist.Size = new Size(200, 60);
            rbReceptionist.TabIndex = 7;
            rbReceptionist.Text = "Lễ tân";
            rbReceptionist.UseVisualStyleBackColor = false;
            rbReceptionist.CheckedChanged += rbReceptionist_CheckedChanged;
            // 
            // rbPatient
            // 
            rbPatient.Appearance = Appearance.Button;
            rbPatient.BackColor = Color.DarkCyan;
            rbPatient.FlatAppearance.BorderSize = 0;
            rbPatient.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbPatient.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbPatient.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbPatient.FlatStyle = FlatStyle.Flat;
            rbPatient.Font = new Font("Segoe UI Semibold", 12F);
            rbPatient.ForeColor = Color.White;
            rbPatient.Location = new Point(0, 224);
            rbPatient.Name = "rbPatient";
            rbPatient.Size = new Size(200, 60);
            rbPatient.TabIndex = 6;
            rbPatient.Text = "Bệnh nhân";
            rbPatient.UseVisualStyleBackColor = false;
            rbPatient.CheckedChanged += rbPatient_CheckedChanged;
            // 
            // rbAccount
            // 
            rbAccount.Appearance = Appearance.Button;
            rbAccount.BackColor = Color.DarkCyan;
            rbAccount.FlatAppearance.BorderSize = 0;
            rbAccount.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbAccount.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbAccount.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbAccount.FlatStyle = FlatStyle.Flat;
            rbAccount.Font = new Font("Segoe UI Semibold", 12F);
            rbAccount.ForeColor = Color.White;
            rbAccount.Location = new Point(0, 56);
            rbAccount.Name = "rbAccount";
            rbAccount.Size = new Size(200, 60);
            rbAccount.TabIndex = 5;
            rbAccount.Text = "Tài khoản";
            rbAccount.UseVisualStyleBackColor = false;
            rbAccount.CheckedChanged += rbAccount_CheckedChanged;
            // 
            // rbDashBoard
            // 
            rbDashBoard.Appearance = Appearance.Button;
            rbDashBoard.BackColor = Color.DarkCyan;
            rbDashBoard.Checked = true;
            rbDashBoard.FlatAppearance.BorderSize = 0;
            rbDashBoard.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbDashBoard.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbDashBoard.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbDashBoard.FlatStyle = FlatStyle.Flat;
            rbDashBoard.Font = new Font("Segoe UI Semibold", 12F);
            rbDashBoard.ForeColor = Color.White;
            rbDashBoard.Location = new Point(0, 0);
            rbDashBoard.Name = "rbDashBoard";
            rbDashBoard.Size = new Size(200, 60);
            rbDashBoard.TabIndex = 0;
            rbDashBoard.TabStop = true;
            rbDashBoard.Text = "DashBoard";
            rbDashBoard.UseVisualStyleBackColor = false;
            rbDashBoard.CheckedChanged += rbDashBoard_CheckedChanged;
            // 
            // pnContent
            // 
            pnContent.BackColor = SystemColors.Control;
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(200, 56);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(819, 568);
            pnContent.TabIndex = 3;
            // 
            // rbSupplier
            // 
            rbSupplier.Appearance = Appearance.Button;
            rbSupplier.BackColor = Color.DarkCyan;
            rbSupplier.FlatAppearance.BorderSize = 0;
            rbSupplier.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbSupplier.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbSupplier.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbSupplier.FlatStyle = FlatStyle.Flat;
            rbSupplier.Font = new Font("Segoe UI Semibold", 12F);
            rbSupplier.ForeColor = Color.White;
            rbSupplier.Location = new Point(0, 450);
            rbSupplier.Name = "rbSupplier";
            rbSupplier.Size = new Size(200, 60);
            rbSupplier.TabIndex = 9;
            rbSupplier.Text = "Nhà Cung Cấp";
            rbSupplier.UseVisualStyleBackColor = false;
            rbSupplier.CheckedChanged += rbSupplier_CheckedChanged;
            // 
            // Form_Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 687);
            Controls.Add(pnContent);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form_Admin";
            Text = "Dental Clinic Management System - Admin";
            WindowState = FormWindowState.Maximized;
            Load += Admin_Form_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel pnContent;
        private RadioButton rbDashBoard;
        private RadioButton rbAccount;
        private RadioButton rbService;
        private RadioButton rbMedicine;
        private RadioButton rbPayment;
        private RadioButton rbDoctor;
        private RadioButton rbReceptionist;
        private RadioButton rbPatient;
        private Button btLogout;
        private RadioButton rbSupplier;
    }
}