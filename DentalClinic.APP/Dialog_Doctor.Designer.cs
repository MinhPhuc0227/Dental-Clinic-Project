namespace DentalClinic.APP
{
    partial class Dialog_Doctor
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
            lbDoctorId = new Label();
            txtFullName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtDescription = new TextBox();
            btCancel = new Button();
            label3 = new Label();
            label2 = new Label();
            btSave = new Button();
            label1 = new Label();
            txtPhone = new TextBox();
            cbGender = new ComboBox();
            dtpDateOfBirth = new DateTimePicker();
            label8 = new Label();
            panel1 = new Panel();
            txtEmail = new TextBox();
            panel2 = new Panel();
            lbCreatedDate = new Label();
            cbStatus = new ComboBox();
            txtPassword = new TextBox();
            cbRole = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            lbAccountId = new Label();
            label15 = new Label();
            txtUserName = new TextBox();
            label16 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lbDoctorId
            // 
            lbDoctorId.AutoSize = true;
            lbDoctorId.Font = new Font("Segoe UI Semibold", 12F);
            lbDoctorId.ForeColor = Color.DarkCyan;
            lbDoctorId.Location = new Point(136, 27);
            lbDoctorId.Name = "lbDoctorId";
            lbDoctorId.Size = new Size(89, 28);
            lbDoctorId.TabIndex = 44;
            lbDoctorId.Text = "Tự động";
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(136, 75);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(378, 34);
            txtFullName.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(12, 27);
            label7.Name = "label7";
            label7.Size = new Size(97, 28);
            label7.TabIndex = 38;
            label7.Text = "Mã bác sĩ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(12, 284);
            label6.Name = "label6";
            label6.Size = new Size(60, 28);
            label6.TabIndex = 37;
            label6.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(12, 129);
            label5.Name = "label5";
            label5.Size = new Size(90, 28);
            label5.TabIndex = 36;
            label5.Text = "Giới tính";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(12, 180);
            label4.Name = "label4";
            label4.Size = new Size(103, 28);
            label4.TabIndex = 35;
            label4.Text = "Ngày sinh";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(136, 343);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(378, 186);
            txtDescription.TabIndex = 6;
            // 
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(880, 594);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 11;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(12, 343);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 31;
            label3.Text = "Mô tả";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(12, 232);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 30;
            label2.Text = "Điện thoại";
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.DarkCyan;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(987, 594);
            btSave.Name = "btSave";
            btSave.Size = new Size(101, 40);
            btSave.TabIndex = 12;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(12, 78);
            label1.Name = "label1";
            label1.Size = new Size(101, 28);
            label1.TabIndex = 28;
            label1.Text = "Họ và tên";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(136, 232);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(378, 34);
            txtPhone.TabIndex = 4;
            // 
            // cbGender
            // 
            cbGender.Font = new Font("Segoe UI", 12F);
            cbGender.FormattingEnabled = true;
            cbGender.Location = new Point(136, 126);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(378, 36);
            cbGender.TabIndex = 2;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDateOfBirth.Font = new Font("Segoe UI", 12F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.Location = new Point(136, 182);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(378, 34);
            dtpDateOfBirth.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 20F);
            label8.ForeColor = Color.FromArgb(0, 69, 139);
            label8.Location = new Point(17, 25);
            label8.Name = "label8";
            label8.Size = new Size(395, 46);
            label8.TabIndex = 49;
            label8.Text = "Thông tin cá nhân bác sĩ";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpDateOfBirth);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbGender);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lbDoctorId);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(17, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(528, 543);
            panel1.TabIndex = 50;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(136, 284);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(378, 34);
            txtEmail.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lbCreatedDate);
            panel2.Controls.Add(cbStatus);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(cbRole);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(lbAccountId);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(txtUserName);
            panel2.Controls.Add(label16);
            panel2.Location = new Point(571, 91);
            panel2.Name = "panel2";
            panel2.Size = new Size(541, 349);
            panel2.TabIndex = 51;
            // 
            // lbCreatedDate
            // 
            lbCreatedDate.AutoSize = true;
            lbCreatedDate.Font = new Font("Segoe UI Semibold", 12F);
            lbCreatedDate.ForeColor = Color.DarkCyan;
            lbCreatedDate.Location = new Point(168, 284);
            lbCreatedDate.Name = "lbCreatedDate";
            lbCreatedDate.Size = new Size(89, 28);
            lbCreatedDate.TabIndex = 61;
            lbCreatedDate.Text = "Tự động";
            // 
            // cbStatus
            // 
            cbStatus.Font = new Font("Segoe UI", 12F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(168, 232);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(348, 36);
            cbStatus.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(168, 129);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(348, 34);
            txtPassword.TabIndex = 8;
            // 
            // cbRole
            // 
            cbRole.Enabled = false;
            cbRole.Font = new Font("Segoe UI", 12F);
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(168, 180);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(348, 36);
            cbRole.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F);
            label10.ForeColor = Color.DarkCyan;
            label10.Location = new Point(14, 78);
            label10.Name = "label10";
            label10.Size = new Size(148, 28);
            label10.TabIndex = 49;
            label10.Text = "Tên đăng nhập";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 12F);
            label11.ForeColor = Color.DarkCyan;
            label11.Location = new Point(14, 232);
            label11.Name = "label11";
            label11.Size = new Size(102, 28);
            label11.TabIndex = 50;
            label11.Text = "Trạng thái";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F);
            label12.ForeColor = Color.DarkCyan;
            label12.Location = new Point(14, 180);
            label12.Name = "label12";
            label12.Size = new Size(71, 28);
            label12.TabIndex = 51;
            label12.Text = "Vai trò";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 12F);
            label13.ForeColor = Color.DarkCyan;
            label13.Location = new Point(14, 129);
            label13.Name = "label13";
            label13.Size = new Size(98, 28);
            label13.TabIndex = 52;
            label13.Text = "Mật khẩu";
            // 
            // lbAccountId
            // 
            lbAccountId.AutoSize = true;
            lbAccountId.Font = new Font("Segoe UI Semibold", 12F);
            lbAccountId.ForeColor = Color.DarkCyan;
            lbAccountId.Location = new Point(168, 27);
            lbAccountId.Name = "lbAccountId";
            lbAccountId.Size = new Size(89, 28);
            lbAccountId.TabIndex = 56;
            lbAccountId.Text = "Tự động";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 12F);
            label15.ForeColor = Color.DarkCyan;
            label15.Location = new Point(14, 284);
            label15.Name = "label15";
            label15.Size = new Size(132, 28);
            label15.TabIndex = 53;
            label15.Text = "Thời gian tạo";
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Font = new Font("Segoe UI", 12F);
            txtUserName.Location = new Point(168, 75);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(348, 34);
            txtUserName.TabIndex = 7;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 12F);
            label16.ForeColor = Color.DarkCyan;
            label16.Location = new Point(14, 27);
            label16.Name = "label16";
            label16.Size = new Size(131, 28);
            label16.TabIndex = 54;
            label16.Text = "Mã tài khoản";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 20F);
            label9.ForeColor = Color.FromArgb(0, 69, 139);
            label9.Location = new Point(571, 25);
            label9.Name = "label9";
            label9.Size = new Size(343, 46);
            label9.TabIndex = 52;
            label9.Text = "Tài khoản đăng nhập";
            // 
            // Dialog_Doctor
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btCancel;
            ClientSize = new Size(1124, 672);
            ControlBox = false;
            Controls.Add(label9);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(btCancel);
            Controls.Add(btSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_Doctor";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bác sĩ";
            Load += Dialog_Doctor_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbDoctorId;
        private TextBox txtFullName;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtDescription;
        private Button btCancel;
        private Label label3;
        private Label label2;
        private Button btSave;
        private Label label1;
        private TextBox txtPhone;
        private ComboBox cbGender;
        private DateTimePicker dtpDateOfBirth;
        private Label label8;
        private Panel panel1;
        private Panel panel2;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label lbAccountId;
        private Label label15;
        private TextBox txtUserName;
        private Label label16;
        private Label lbCreatedDate;
        private ComboBox cbStatus;
        private TextBox txtPassword;
        private ComboBox cbRole;
        private TextBox txtEmail;
    }
}