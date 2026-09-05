namespace DentalClinic.APP
{
    partial class Dialog_Supplier
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtSupplierName = new TextBox();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            txtNote = new TextBox();
            txtPhone = new TextBox();
            btCancel = new Button();
            btSave = new Button();
            label7 = new Label();
            cbStatus = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(56, 23);
            label1.Name = "label1";
            label1.Size = new Size(338, 32);
            label1.TabIndex = 1;
            label1.Text = "THÔNG TIN NHÀ CUNG CẤP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(25, 99);
            label2.Name = "label2";
            label2.Size = new Size(149, 23);
            label2.TabIndex = 2;
            label2.Text = "Tên nhà cung cấp:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(25, 146);
            label3.Name = "label3";
            label3.Size = new Size(115, 23);
            label3.TabIndex = 3;
            label3.Text = "Số điện thoại:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(25, 193);
            label4.Name = "label4";
            label4.Size = new Size(55, 23);
            label4.TabIndex = 4;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(25, 240);
            label5.Name = "label5";
            label5.Size = new Size(66, 23);
            label5.TabIndex = 5;
            label5.Text = "Địa chỉ:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(25, 287);
            label6.Name = "label6";
            label6.Size = new Size(73, 23);
            label6.TabIndex = 6;
            label6.Text = "Ghi chú:";
            // 
            // txtSupplierName
            // 
            txtSupplierName.BorderStyle = BorderStyle.FixedSingle;
            txtSupplierName.Font = new Font("Segoe UI", 10F);
            txtSupplierName.Location = new Point(197, 92);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(314, 30);
            txtSupplierName.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(197, 238);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(314, 30);
            txtAddress.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(197, 193);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(314, 30);
            txtEmail.TabIndex = 3;
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Font = new Font("Segoe UI", 10F);
            txtNote.Location = new Point(197, 287);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(314, 82);
            txtNote.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(197, 144);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(314, 30);
            txtPhone.TabIndex = 2;
            // 
            // btCancel
            // 
            btCancel.BackColor = Color.Red;
            btCancel.FlatAppearance.BorderSize = 0;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 10F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(317, 468);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(94, 38);
            btCancel.TabIndex = 7;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // btSave
            // 
            btSave.BackColor = Color.FromArgb(0, 184, 148);
            btSave.FlatAppearance.BorderSize = 0;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 10F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(417, 468);
            btSave.Name = "btSave";
            btSave.Size = new Size(94, 38);
            btSave.TabIndex = 8;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(25, 391);
            label7.Name = "label7";
            label7.Size = new Size(91, 23);
            label7.TabIndex = 14;
            label7.Text = "Trạng thái:";
            // 
            // cbStatus
            // 
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(197, 388);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(314, 31);
            cbStatus.TabIndex = 6;
            // 
            // Dialog_Supplier
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btCancel;
            ClientSize = new Size(535, 536);
            Controls.Add(cbStatus);
            Controls.Add(label7);
            Controls.Add(btSave);
            Controls.Add(btCancel);
            Controls.Add(txtPhone);
            Controls.Add(txtNote);
            Controls.Add(txtEmail);
            Controls.Add(txtAddress);
            Controls.Add(txtSupplierName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_Supplier";
            StartPosition = FormStartPosition.CenterParent;
            Load += Dialog_Supplier_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtSupplierName;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private TextBox txtNote;
        private TextBox txtPhone;
        private Button btCancel;
        private Button btSave;
        private Label label7;
        private ComboBox cbStatus;
    }
}