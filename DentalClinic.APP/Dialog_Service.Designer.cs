namespace DentalClinic.APP
{
    partial class Dialog_Service
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
            lbServiceId = new Label();
            txtServiceName = new TextBox();
            txtUnitPrice = new TextBox();
            label7 = new Label();
            label4 = new Label();
            cbStatus = new ComboBox();
            txtDescription = new TextBox();
            btCancel = new Button();
            label3 = new Label();
            label2 = new Label();
            btSave = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lbServiceId
            // 
            lbServiceId.AutoSize = true;
            lbServiceId.Font = new Font("Segoe UI Semibold", 12F);
            lbServiceId.ForeColor = Color.DarkCyan;
            lbServiceId.Location = new Point(140, 17);
            lbServiceId.Name = "lbServiceId";
            lbServiceId.Size = new Size(47, 28);
            lbServiceId.TabIndex = 44;
            lbServiceId.Text = "lbId";
            // 
            // txtServiceName
            // 
            txtServiceName.BorderStyle = BorderStyle.FixedSingle;
            txtServiceName.Font = new Font("Segoe UI", 12F);
            txtServiceName.Location = new Point(140, 65);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(378, 34);
            txtServiceName.TabIndex = 1;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BorderStyle = BorderStyle.FixedSingle;
            txtUnitPrice.Font = new Font("Segoe UI", 12F);
            txtUnitPrice.Location = new Point(140, 117);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(378, 34);
            txtUnitPrice.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(16, 17);
            label7.Name = "label7";
            label7.Size = new Size(112, 28);
            label7.TabIndex = 38;
            label7.Text = "Mã dịch vụ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(16, 120);
            label4.Name = "label4";
            label4.Size = new Size(83, 28);
            label4.TabIndex = 35;
            label4.Text = "Đơn giá";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 12F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(140, 180);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(378, 36);
            cbStatus.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(140, 243);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(378, 186);
            txtDescription.TabIndex = 4;
            // 
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(310, 456);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 5;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(16, 243);
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
            label2.Location = new Point(16, 184);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 30;
            label2.Text = "Trạng thái";
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.DarkCyan;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(417, 456);
            btSave.Name = "btSave";
            btSave.Size = new Size(101, 40);
            btSave.TabIndex = 6;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(16, 68);
            label1.Name = "label1";
            label1.Size = new Size(116, 28);
            label1.TabIndex = 28;
            label1.Text = "Tên dịch vụ";
            // 
            // Dialog_Service
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btCancel;
            ClientSize = new Size(542, 526);
            ControlBox = false;
            Controls.Add(lbServiceId);
            Controls.Add(txtServiceName);
            Controls.Add(txtUnitPrice);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(cbStatus);
            Controls.Add(txtDescription);
            Controls.Add(btCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btSave);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_Service";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dịch vụ";
            Load += Dialog_Service_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbServiceId;
        private TextBox txtServiceName;
        private TextBox txtUnitPrice;
        private Label label7;
        private Label label4;
        private ComboBox cbStatus;
        private TextBox txtDescription;
        private Button btCancel;
        private Label label3;
        private Label label2;
        private Button btSave;
        private Label label1;
    }
}