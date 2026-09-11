namespace DentalClinic.APP
{
    partial class Dialog_Patient
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
            txtAddress = new TextBox();
            label14 = new Label();
            txtEmail = new TextBox();
            txtNote = new TextBox();
            label1 = new Label();
            dtpDateOfBirth = new DateTimePicker();
            label2 = new Label();
            cbGender = new ComboBox();
            label3 = new Label();
            txtPhone = new TextBox();
            label4 = new Label();
            label5 = new Label();
            lbPatientId = new Label();
            label6 = new Label();
            txtFullName = new TextBox();
            label7 = new Label();
            label8 = new Label();
            btCancel = new Button();
            btSave = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpDateOfBirth);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbGender);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lbPatientId);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(15, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(528, 543);
            panel1.TabIndex = 56;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(163, 339);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(351, 34);
            txtAddress.TabIndex = 6;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 12F);
            label14.ForeColor = Color.DarkCyan;
            label14.Location = new Point(12, 345);
            label14.Name = "label14";
            label14.Size = new Size(73, 28);
            label14.TabIndex = 50;
            label14.Text = "Địa chỉ";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(163, 284);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(351, 34);
            txtEmail.TabIndex = 5;
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Font = new Font("Segoe UI", 12F);
            txtNote.Location = new Point(163, 401);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = ScrollBars.Vertical;
            txtNote.Size = new Size(351, 128);
            txtNote.TabIndex = 7;
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
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.AllowDrop = true;
            dtpDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDateOfBirth.Font = new Font("Segoe UI", 12F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.Location = new Point(163, 182);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(351, 34);
            dtpDateOfBirth.TabIndex = 3;
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
            // cbGender
            // 
            cbGender.Font = new Font("Segoe UI", 12F);
            cbGender.FormattingEnabled = true;
            cbGender.Location = new Point(163, 126);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(351, 36);
            cbGender.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(12, 401);
            label3.Name = "label3";
            label3.Size = new Size(82, 28);
            label3.TabIndex = 31;
            label3.Text = "Ghi chú";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(163, 232);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(351, 34);
            txtPhone.TabIndex = 4;
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
            // lbPatientId
            // 
            lbPatientId.AutoSize = true;
            lbPatientId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPatientId.ForeColor = Color.Black;
            lbPatientId.Location = new Point(163, 27);
            lbPatientId.Name = "lbPatientId";
            lbPatientId.Size = new Size(24, 28);
            lbPatientId.TabIndex = 44;
            lbPatientId.Text = "...";
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
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(163, 75);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(351, 34);
            txtFullName.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(12, 27);
            label7.Name = "label7";
            label7.Size = new Size(145, 28);
            label7.TabIndex = 38;
            label7.Text = "Mã bệnh nhân";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(147, 19);
            label8.Name = "label8";
            label8.Size = new Size(270, 37);
            label8.TabIndex = 55;
            label8.Text = "HỒ SƠ BỆNH NHÂN";
            // 
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(335, 657);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 13;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.FromArgb(0, 184, 148);
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(442, 657);
            btSave.Name = "btSave";
            btSave.Size = new Size(101, 40);
            btSave.TabIndex = 14;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // Dialog_Patient
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btCancel;
            ClientSize = new Size(560, 715);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(btCancel);
            Controls.Add(btSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_Patient";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += Dialog_Patient_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private TextBox txtEmail;
        private TextBox txtNote;
        private Label label1;
        private DateTimePicker dtpDateOfBirth;
        private Label label2;
        private ComboBox cbGender;
        private Label label3;
        private TextBox txtPhone;
        private Label label4;
        private Label label5;
        private Label lbPatientId;
        private Label label6;
        private TextBox txtFullName;
        private Label label7;
        private Label label8;
        private Button btCancel;
        private Button btSave;
        private TextBox txtAddress;
        private Label label14;
    }
}