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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            label1 = new Label();
            txtUserName = new TextBox();
            chkShowPassword = new CheckBox();
            btLogin = new Button();
            label2 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(547, 201);
            label1.Name = "label1";
            label1.Size = new Size(124, 23);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Font = new Font("Segoe UI", 10F);
            txtUserName.ForeColor = Color.Black;
            txtUserName.Location = new Point(547, 241);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(260, 30);
            txtUserName.TabIndex = 1;
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 10F);
            chkShowPassword.ForeColor = Color.DarkCyan;
            chkShowPassword.Location = new Point(547, 375);
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
            btLogin.Location = new Point(547, 429);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(260, 41);
            btLogin.TabIndex = 4;
            btLogin.Text = "Đăng nhập";
            btLogin.UseVisualStyleBackColor = false;
            btLogin.Click += btLogin_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 14F);
            label2.ForeColor = Color.FromArgb(6, 104, 105);
            label2.Location = new Point(547, 132);
            label2.Name = "label2";
            label2.Size = new Size(256, 47);
            label2.TabIndex = 4;
            label2.Text = "Đăng nhập hệ thống";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(547, 288);
            label3.Name = "label3";
            label3.Size = new Size(84, 23);
            label3.TabIndex = 5;
            label3.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(547, 328);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(260, 30);
            txtPassword.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btLogin);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(chkShowPassword);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 508);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(584, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(175, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(31, 30);
            label4.Name = "label4";
            label4.Size = new Size(387, 108);
            label4.TabIndex = 8;
            label4.Text = "HỆ THỐNG QUẢN LÝ PHÒNG KHÁM NHA KHOA GIA AN";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.background_login;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(452, 508);
            panel2.TabIndex = 7;
            // 
            // Form_Login
            // 
            AcceptButton = btLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(884, 508);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nha Khoa Gia An";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtUserName;
        private CheckBox chkShowPassword;
        private Button btLogin;
        private Label label2;
        private Label label3;
        private TextBox txtPassword;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label4;
        private Panel panel2;
    }
}