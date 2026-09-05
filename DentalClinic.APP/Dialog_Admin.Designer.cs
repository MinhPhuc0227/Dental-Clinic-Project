namespace DentalClinic.APP
{
    partial class Dialog_Admin
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
            label1 = new Label();
            label2 = new Label();
            txtUserName = new TextBox();
            cbRole = new ComboBox();
            btCancel = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btSave = new Button();
            chkShowPassword = new CheckBox();
            txtPassword = new TextBox();
            cbStatus = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(89, 19);
            label1.Name = "label1";
            label1.Size = new Size(245, 28);
            label1.TabIndex = 0;
            label1.Text = "TẠO TÀI KHOẢN ADMIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(29, 82);
            label2.Name = "label2";
            label2.Size = new Size(128, 23);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập:";
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Location = new Point(189, 78);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(222, 30);
            txtUserName.TabIndex = 1;
            // 
            // cbRole
            // 
            cbRole.Enabled = false;
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(189, 205);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(222, 31);
            cbRole.TabIndex = 4;
            // 
            // btCancel
            // 
            btCancel.BackColor = Color.Red;
            btCancel.FlatAppearance.BorderSize = 0;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 10F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(217, 334);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(94, 40);
            btCancel.TabIndex = 6;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(29, 250);
            label3.Name = "label3";
            label3.Size = new Size(91, 23);
            label3.TabIndex = 5;
            label3.Text = "Trạng thái:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(29, 209);
            label4.Name = "label4";
            label4.Size = new Size(64, 23);
            label4.TabIndex = 6;
            label4.Text = "Vai trò:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(29, 123);
            label5.Name = "label5";
            label5.Size = new Size(88, 23);
            label5.TabIndex = 7;
            label5.Text = "Mật khẩu:";
            // 
            // btSave
            // 
            btSave.BackColor = Color.FromArgb(0, 184, 148);
            btSave.FlatAppearance.BorderSize = 0;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 10F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(317, 334);
            btSave.Name = "btSave";
            btSave.Size = new Size(94, 40);
            btSave.TabIndex = 7;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 10F);
            chkShowPassword.ForeColor = Color.DarkCyan;
            chkShowPassword.Location = new Point(34, 164);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(144, 27);
            chkShowPassword.TabIndex = 3;
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(189, 119);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(222, 30);
            txtPassword.TabIndex = 2;
            // 
            // cbStatus
            // 
            cbStatus.Enabled = false;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(189, 246);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(222, 31);
            cbStatus.TabIndex = 5;
            // 
            // Dialog_Admin
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btCancel;
            ClientSize = new Size(447, 399);
            Controls.Add(cbStatus);
            Controls.Add(txtPassword);
            Controls.Add(chkShowPassword);
            Controls.Add(btSave);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btCancel);
            Controls.Add(cbRole);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_Admin";
            StartPosition = FormStartPosition.CenterParent;
            Load += Dialog_Admin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUserName;
        private ComboBox cbRole;
        private Button btCancel;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btSave;
        private CheckBox chkShowPassword;
        private TextBox txtPassword;
        private ComboBox cbStatus;
    }
}