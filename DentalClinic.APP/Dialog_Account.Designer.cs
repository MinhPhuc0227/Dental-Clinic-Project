namespace DentalClinic.APP
{
    partial class Dialog_Account
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
            label9 = new Label();
            panel2 = new Panel();
            label1 = new Label();
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
            btCancel = new Button();
            btSave = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 20F);
            label9.ForeColor = Color.FromArgb(0, 69, 139);
            label9.Location = new Point(12, 9);
            label9.Name = "label9";
            label9.Size = new Size(497, 46);
            label9.TabIndex = 54;
            label9.Text = "Thông tin tài khoản đăng nhập";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
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
            panel2.Location = new Point(12, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(541, 385);
            panel2.TabIndex = 53;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 10F, FontStyle.Italic);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(168, 166);
            label1.Name = "label1";
            label1.Size = new Size(306, 23);
            label1.TabIndex = 62;
            label1.Text = "*Để trống nếu không muốn đổi mật khẩu";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbCreatedDate
            // 
            lbCreatedDate.AutoSize = true;
            lbCreatedDate.Font = new Font("Segoe UI Semibold", 12F);
            lbCreatedDate.ForeColor = Color.DarkCyan;
            lbCreatedDate.Location = new Point(168, 305);
            lbCreatedDate.Name = "lbCreatedDate";
            lbCreatedDate.Size = new Size(89, 28);
            lbCreatedDate.TabIndex = 61;
            lbCreatedDate.Text = "Tự động";
            // 
            // cbStatus
            // 
            cbStatus.Font = new Font("Segoe UI", 12F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(168, 253);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(348, 36);
            cbStatus.TabIndex = 60;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(168, 129);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(348, 34);
            txtPassword.TabIndex = 59;
            // 
            // cbRole
            // 
            cbRole.Font = new Font("Segoe UI", 12F);
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(168, 201);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(348, 36);
            cbRole.TabIndex = 49;
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
            label11.Location = new Point(14, 253);
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
            label12.Location = new Point(14, 201);
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
            label13.Size = new Size(139, 28);
            label13.TabIndex = 52;
            label13.Text = "Mật khẩu mới";
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
            label15.Location = new Point(14, 305);
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
            txtUserName.TabIndex = 55;
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
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(345, 502);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 56;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.DarkCyan;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(452, 502);
            btSave.Name = "btSave";
            btSave.Size = new Size(101, 40);
            btSave.TabIndex = 55;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // Dialog_Account
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(572, 554);
            ControlBox = false;
            Controls.Add(btCancel);
            Controls.Add(btSave);
            Controls.Add(label9);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "Dialog_Account";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chỉnh sửa tài khoản";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Panel panel2;
        private Label lbCreatedDate;
        private ComboBox cbStatus;
        private TextBox txtPassword;
        private ComboBox cbRole;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label lbAccountId;
        private Label label15;
        private TextBox txtUserName;
        private Label label16;
        private Button btCancel;
        private Button btSave;
        private Label label1;
    }
}