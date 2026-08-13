namespace DentalClinic.APP
{
    partial class Form_Login
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
            txtUserName = new TextBox();
            chkShowPassword = new CheckBox();
            btLogin = new Button();
            label2 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            btExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(24, 105);
            label1.Name = "label1";
            label1.Size = new Size(148, 28);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Font = new Font("Segoe UI", 12F);
            txtUserName.ForeColor = Color.Black;
            txtUserName.Location = new Point(24, 146);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(260, 34);
            txtUserName.TabIndex = 1;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 10F);
            chkShowPassword.ForeColor = Color.DarkCyan;
            chkShowPassword.Location = new Point(24, 274);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(144, 27);
            chkShowPassword.TabIndex = 3;
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btLogin
            // 
            btLogin.BackColor = Color.DarkCyan;
            btLogin.FlatAppearance.BorderSize = 0;
            btLogin.FlatStyle = FlatStyle.Flat;
            btLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btLogin.ForeColor = Color.White;
            btLogin.Location = new Point(178, 376);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(106, 41);
            btLogin.TabIndex = 5;
            btLogin.Text = "Đăng nhập";
            btLogin.UseVisualStyleBackColor = false;
            btLogin.Click += btLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 20F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(59, 21);
            label2.Name = "label2";
            label2.Size = new Size(195, 46);
            label2.TabIndex = 4;
            label2.Text = "Đăng Nhập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(24, 194);
            label3.Name = "label3";
            label3.Size = new Size(98, 28);
            label3.TabIndex = 5;
            label3.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(24, 225);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(260, 34);
            txtPassword.TabIndex = 2;
            // 
            // btExit
            // 
            btExit.BackColor = Color.Red;
            btExit.FlatAppearance.BorderSize = 0;
            btExit.FlatStyle = FlatStyle.Flat;
            btExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btExit.ForeColor = Color.White;
            btExit.Location = new Point(59, 376);
            btExit.Name = "btExit";
            btExit.Size = new Size(106, 41);
            btExit.TabIndex = 4;
            btExit.Text = "Thoát";
            btExit.UseVisualStyleBackColor = false;
            btExit.Click += btExit_Click;
            // 
            // Form_Login
            // 
            AcceptButton = btLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btExit;
            ClientSize = new Size(309, 455);
            Controls.Add(btExit);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btLogin);
            Controls.Add(chkShowPassword);
            Controls.Add(txtUserName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUserName;
        private CheckBox chkShowPassword;
        private Button btLogin;
        private Label label2;
        private Label label3;
        private TextBox txtPassword;
        private Button btExit;
    }
}