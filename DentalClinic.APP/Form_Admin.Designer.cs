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
            panel3 = new Panel();
            rbPayment = new RadioButton();
            rbMedicine = new RadioButton();
            rbService = new RadioButton();
            rbAccount = new RadioButton();
            rbDashBoard = new RadioButton();
            pnContent = new Panel();
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
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 513);
            panel2.Name = "panel2";
            panel2.Size = new Size(1019, 63);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkCyan;
            panel3.Controls.Add(rbPayment);
            panel3.Controls.Add(rbMedicine);
            panel3.Controls.Add(rbService);
            panel3.Controls.Add(rbAccount);
            panel3.Controls.Add(rbDashBoard);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 56);
            panel3.Name = "panel3";
            panel3.Size = new Size(199, 457);
            panel3.TabIndex = 2;
            // 
            // rbPayment
            // 
            rbPayment.Appearance = Appearance.Button;
            rbPayment.BackColor = Color.DarkCyan;
            rbPayment.FlatAppearance.BorderSize = 0;
            rbPayment.FlatStyle = FlatStyle.Flat;
            rbPayment.Font = new Font("Segoe UI Semibold", 12F);
            rbPayment.ForeColor = Color.White;
            rbPayment.Location = new Point(12, 238);
            rbPayment.Name = "rbPayment";
            rbPayment.Size = new Size(169, 38);
            rbPayment.TabIndex = 1;
            rbPayment.TabStop = true;
            rbPayment.Text = "Thanh toán";
            rbPayment.UseVisualStyleBackColor = false;
            rbPayment.CheckedChanged += rbPayment_CheckedChanged;
            // 
            // rbMedicine
            // 
            rbMedicine.Appearance = Appearance.Button;
            rbMedicine.BackColor = Color.DarkCyan;
            rbMedicine.FlatAppearance.BorderSize = 0;
            rbMedicine.FlatStyle = FlatStyle.Flat;
            rbMedicine.Font = new Font("Segoe UI Semibold", 12F);
            rbMedicine.ForeColor = Color.White;
            rbMedicine.Location = new Point(12, 185);
            rbMedicine.Name = "rbMedicine";
            rbMedicine.Size = new Size(169, 38);
            rbMedicine.TabIndex = 2;
            rbMedicine.TabStop = true;
            rbMedicine.Text = "Thuốc";
            rbMedicine.UseVisualStyleBackColor = false;
            rbMedicine.CheckedChanged += rbMedicine_CheckedChanged;
            // 
            // rbService
            // 
            rbService.Appearance = Appearance.Button;
            rbService.BackColor = Color.DarkCyan;
            rbService.FlatAppearance.BorderSize = 0;
            rbService.FlatStyle = FlatStyle.Flat;
            rbService.Font = new Font("Segoe UI Semibold", 12F);
            rbService.ForeColor = Color.White;
            rbService.Location = new Point(12, 127);
            rbService.Name = "rbService";
            rbService.Size = new Size(169, 38);
            rbService.TabIndex = 3;
            rbService.TabStop = true;
            rbService.Text = "Dịch vụ";
            rbService.UseVisualStyleBackColor = false;
            rbService.CheckedChanged += rbService_CheckedChanged;
            // 
            // rbAccount
            // 
            rbAccount.Appearance = Appearance.Button;
            rbAccount.BackColor = Color.DarkCyan;
            rbAccount.FlatAppearance.BorderSize = 0;
            rbAccount.FlatStyle = FlatStyle.Flat;
            rbAccount.Font = new Font("Segoe UI Semibold", 12F);
            rbAccount.ForeColor = Color.White;
            rbAccount.Location = new Point(12, 74);
            rbAccount.Name = "rbAccount";
            rbAccount.Size = new Size(169, 38);
            rbAccount.TabIndex = 5;
            rbAccount.TabStop = true;
            rbAccount.Text = "Tài khoản";
            rbAccount.UseVisualStyleBackColor = false;
            rbAccount.CheckedChanged += rbAccount_CheckedChanged;
            // 
            // rbDashBoard
            // 
            rbDashBoard.Appearance = Appearance.Button;
            rbDashBoard.BackColor = Color.DarkCyan;
            rbDashBoard.FlatAppearance.BorderSize = 0;
            rbDashBoard.FlatStyle = FlatStyle.Flat;
            rbDashBoard.Font = new Font("Segoe UI Semibold", 12F);
            rbDashBoard.ForeColor = Color.White;
            rbDashBoard.Location = new Point(12, 17);
            rbDashBoard.Name = "rbDashBoard";
            rbDashBoard.Size = new Size(169, 38);
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
            pnContent.Location = new Point(199, 56);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(820, 457);
            pnContent.TabIndex = 3;
            // 
            // Form_Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 576);
            Controls.Add(pnContent);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form_Admin";
            Text = "Dental Clinic Management System - Admin";
            WindowState = FormWindowState.Maximized;
            Load += Admin_Form_Load;
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
    }
}