namespace DentalClinic.APP
{
    partial class Dialog_Medicine
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
            cbStatus = new ComboBox();
            txtDescription = new TextBox();
            btCancel = new Button();
            label3 = new Label();
            label2 = new Label();
            btSave = new Button();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtQuantityInStock = new TextBox();
            txtUnitPrice = new TextBox();
            txtUnit = new TextBox();
            txtMedicineName = new TextBox();
            lbQuantityInStock = new Label();
            lbMedicineId = new Label();
            SuspendLayout();
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 12F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(143, 229);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(270, 36);
            cbStatus.TabIndex = 17;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(143, 344);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(378, 186);
            txtDescription.TabIndex = 16;
            // 
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(313, 550);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 15;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(19, 344);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 14;
            label3.Text = "Mô tả";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(19, 233);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 13;
            label2.Text = "Trạng thái";
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.DarkCyan;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(420, 550);
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
            label1.Location = new Point(19, 79);
            label1.Name = "label1";
            label1.Size = new Size(102, 28);
            label1.TabIndex = 9;
            label1.Text = "Tên thuốc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(19, 181);
            label4.Name = "label4";
            label4.Size = new Size(83, 28);
            label4.TabIndex = 18;
            label4.Text = "Đơn giá";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(19, 130);
            label5.Name = "label5";
            label5.Size = new Size(113, 28);
            label5.TabIndex = 19;
            label5.Text = "Đơn vị tính";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(19, 285);
            label6.Name = "label6";
            label6.Size = new Size(88, 28);
            label6.TabIndex = 20;
            label6.Text = "Tồn kho";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(19, 28);
            label7.Name = "label7";
            label7.Size = new Size(103, 28);
            label7.TabIndex = 21;
            label7.Text = "Mã thuốc:";
            // 
            // txtQuantityInStock
            // 
            txtQuantityInStock.BorderStyle = BorderStyle.FixedSingle;
            txtQuantityInStock.Font = new Font("Segoe UI", 12F);
            txtQuantityInStock.Location = new Point(372, 282);
            txtQuantityInStock.Name = "txtQuantityInStock";
            txtQuantityInStock.Size = new Size(149, 34);
            txtQuantityInStock.TabIndex = 22;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BorderStyle = BorderStyle.FixedSingle;
            txtUnitPrice.Font = new Font("Segoe UI", 12F);
            txtUnitPrice.Location = new Point(143, 178);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(378, 34);
            txtUnitPrice.TabIndex = 23;
            // 
            // txtUnit
            // 
            txtUnit.BorderStyle = BorderStyle.FixedSingle;
            txtUnit.Font = new Font("Segoe UI", 12F);
            txtUnit.Location = new Point(143, 127);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(378, 34);
            txtUnit.TabIndex = 24;
            // 
            // txtMedicineName
            // 
            txtMedicineName.BorderStyle = BorderStyle.FixedSingle;
            txtMedicineName.Font = new Font("Segoe UI", 12F);
            txtMedicineName.Location = new Point(143, 76);
            txtMedicineName.Name = "txtMedicineName";
            txtMedicineName.Size = new Size(378, 34);
            txtMedicineName.TabIndex = 25;
            // 
            // lbQuantityInStock
            // 
            lbQuantityInStock.AutoSize = true;
            lbQuantityInStock.Font = new Font("Segoe UI Semibold", 12F);
            lbQuantityInStock.ForeColor = Color.DarkCyan;
            lbQuantityInStock.Location = new Point(143, 288);
            lbQuantityInStock.Name = "lbQuantityInStock";
            lbQuantityInStock.Size = new Size(78, 28);
            lbQuantityInStock.TabIndex = 26;
            lbQuantityInStock.Text = "lbStock";
            // 
            // lbMedicineId
            // 
            lbMedicineId.AutoSize = true;
            lbMedicineId.Font = new Font("Segoe UI Semibold", 12F);
            lbMedicineId.ForeColor = Color.DarkCyan;
            lbMedicineId.Location = new Point(143, 28);
            lbMedicineId.Name = "lbMedicineId";
            lbMedicineId.Size = new Size(47, 28);
            lbMedicineId.TabIndex = 27;
            lbMedicineId.Text = "lbId";
            // 
            // Dialog_Medicine
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(544, 606);
            ControlBox = false;
            Controls.Add(lbMedicineId);
            Controls.Add(lbQuantityInStock);
            Controls.Add(txtMedicineName);
            Controls.Add(txtUnit);
            Controls.Add(txtUnitPrice);
            Controls.Add(txtQuantityInStock);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cbStatus);
            Controls.Add(txtDescription);
            Controls.Add(btCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btSave);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Dialog_Medicine";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbStatus;
        private TextBox txtDescription;
        private Button btCancel;
        private Label label3;
        private Label label2;
        private Button btSave;
        private TextBox ds;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtQuantityInStock;
        private TextBox txtUnitPrice;
        private TextBox txtUnit;
        private TextBox txtMedicineName;
        private Label lbQuantityInStock;
        private Label lbMedicineId;
    }
}