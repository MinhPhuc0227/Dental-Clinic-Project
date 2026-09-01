namespace DentalClinic.APP
{
    partial class Dialog_MedicineImport
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lbImportDate = new Label();
            lbAccountName = new Label();
            lbImportId = new Label();
            cbSupplier = new ComboBox();
            txtNote = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            dgvImportDetail = new DataGridView();
            panel4 = new Panel();
            lbTotalAmount = new TextBox();
            cbPaymentMethod = new ComboBox();
            label13 = new Label();
            label12 = new Label();
            btConfirmImport = new Button();
            btCancel = new Button();
            panel3 = new Panel();
            btAddMedicine = new Button();
            txtCurrentStock = new TextBox();
            txtImportPrice = new TextBox();
            txtQuantity = new TextBox();
            cbMedicine = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImportDetail).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lbImportDate);
            panel1.Controls.Add(lbAccountName);
            panel1.Controls.Add(lbImportId);
            panel1.Controls.Add(cbSupplier);
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1068, 217);
            panel1.TabIndex = 0;
            // 
            // lbImportDate
            // 
            lbImportDate.AutoSize = true;
            lbImportDate.Font = new Font("Segoe UI", 10F);
            lbImportDate.Location = new Point(184, 117);
            lbImportDate.Name = "lbImportDate";
            lbImportDate.Size = new Size(91, 23);
            lbImportDate.TabIndex = 26;
            lbImportDate.Text = "ngày nhập";
            // 
            // lbAccountName
            // 
            lbAccountName.AutoSize = true;
            lbAccountName.Font = new Font("Segoe UI", 10F);
            lbAccountName.Location = new Point(753, 65);
            lbAccountName.Name = "lbAccountName";
            lbAccountName.Size = new Size(98, 23);
            lbAccountName.TabIndex = 25;
            lbAccountName.Text = "người nhập";
            // 
            // lbImportId
            // 
            lbImportId.AutoSize = true;
            lbImportId.Font = new Font("Segoe UI", 10F);
            lbImportId.Location = new Point(184, 73);
            lbImportId.Name = "lbImportId";
            lbImportId.Size = new Size(126, 23);
            lbImportId.TabIndex = 24;
            lbImportId.Text = "mã phiếu nhập";
            // 
            // cbSupplier
            // 
            cbSupplier.Font = new Font("Segoe UI", 10F);
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(184, 164);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(248, 31);
            cbSupplier.TabIndex = 23;
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Font = new Font("Segoe UI", 10F);
            txtNote.Location = new Point(753, 110);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(274, 82);
            txtNote.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(596, 112);
            label6.Name = "label6";
            label6.Size = new Size(73, 23);
            label6.TabIndex = 16;
            label6.Text = "Ghi chú:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(596, 65);
            label5.Name = "label5";
            label5.Size = new Size(106, 23);
            label5.TabIndex = 15;
            label5.Text = "Người nhập:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(16, 164);
            label4.Name = "label4";
            label4.Size = new Size(121, 23);
            label4.TabIndex = 14;
            label4.Text = "Nhà cung cấp:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(16, 117);
            label3.Name = "label3";
            label3.Size = new Size(99, 23);
            label3.TabIndex = 13;
            label3.Text = "Ngày nhập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(16, 70);
            label2.Name = "label2";
            label2.Size = new Size(87, 23);
            label2.TabIndex = 12;
            label2.Text = "Mã phiếu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(456, 12);
            label1.Name = "label1";
            label1.Size = new Size(133, 28);
            label1.TabIndex = 9;
            label1.Text = "PHIẾU NHẬP";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(10, 425);
            panel2.Name = "panel2";
            panel2.Size = new Size(1068, 266);
            panel2.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(dgvImportDetail);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1068, 130);
            panel5.TabIndex = 1;
            // 
            // dgvImportDetail
            // 
            dgvImportDetail.AllowUserToAddRows = false;
            dgvImportDetail.AllowUserToDeleteRows = false;
            dgvImportDetail.AllowUserToOrderColumns = true;
            dgvImportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportDetail.BackgroundColor = Color.White;
            dgvImportDetail.BorderStyle = BorderStyle.None;
            dgvImportDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvImportDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvImportDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvImportDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvImportDetail.DefaultCellStyle = dataGridViewCellStyle2;
            dgvImportDetail.Dock = DockStyle.Fill;
            dgvImportDetail.EnableHeadersVisualStyles = false;
            dgvImportDetail.GridColor = Color.DarkCyan;
            dgvImportDetail.Location = new Point(0, 0);
            dgvImportDetail.MultiSelect = false;
            dgvImportDetail.Name = "dgvImportDetail";
            dgvImportDetail.RowHeadersVisible = false;
            dgvImportDetail.RowHeadersWidth = 51;
            dgvImportDetail.RowTemplate.Height = 38;
            dgvImportDetail.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvImportDetail.Size = new Size(1068, 130);
            dgvImportDetail.TabIndex = 5;
            dgvImportDetail.CellContentClick += dgvImportDetail_CellContentClick;
            dgvImportDetail.CellEndEdit += dgvImportDetail_CellEndEdit;
            dgvImportDetail.CellValidating += dgvImportDetail_CellValidating;
            dgvImportDetail.DataError += dgvImportDetail_DataError;
            // 
            // panel4
            // 
            panel4.Controls.Add(lbTotalAmount);
            panel4.Controls.Add(cbPaymentMethod);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(btConfirmImport);
            panel4.Controls.Add(btCancel);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 130);
            panel4.Name = "panel4";
            panel4.Size = new Size(1068, 136);
            panel4.TabIndex = 0;
            // 
            // lbTotalAmount
            // 
            lbTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            lbTotalAmount.Font = new Font("Segoe UI", 10F);
            lbTotalAmount.Location = new Point(184, 20);
            lbTotalAmount.Name = "lbTotalAmount";
            lbTotalAmount.Size = new Size(248, 30);
            lbTotalAmount.TabIndex = 26;
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cbPaymentMethod.FormattingEnabled = true;
            cbPaymentMethod.Location = new Point(184, 66);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new Size(248, 31);
            cbPaymentMethod.TabIndex = 24;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 10F);
            label13.ForeColor = Color.DarkCyan;
            label13.Location = new Point(19, 74);
            label13.Name = "label13";
            label13.Size = new Size(51, 23);
            label13.TabIndex = 19;
            label13.Text = "PTTT:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10F);
            label12.ForeColor = Color.DarkCyan;
            label12.Location = new Point(19, 27);
            label12.Name = "label12";
            label12.Size = new Size(87, 23);
            label12.TabIndex = 18;
            label12.Text = "Tổng tiền:";
            // 
            // btConfirmImport
            // 
            btConfirmImport.Location = new Point(909, 66);
            btConfirmImport.Name = "btConfirmImport";
            btConfirmImport.Size = new Size(142, 49);
            btConfirmImport.TabIndex = 17;
            btConfirmImport.Text = "Xác nhận nhập";
            btConfirmImport.UseVisualStyleBackColor = true;
            btConfirmImport.Click += btConfirmImport_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(812, 66);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(91, 49);
            btCancel.TabIndex = 16;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btAddMedicine);
            panel3.Controls.Add(txtCurrentStock);
            panel3.Controls.Add(txtImportPrice);
            panel3.Controls.Add(txtQuantity);
            panel3.Controls.Add(cbMedicine);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(10, 227);
            panel3.Name = "panel3";
            panel3.Size = new Size(1068, 198);
            panel3.TabIndex = 1;
            // 
            // btAddMedicine
            // 
            btAddMedicine.Location = new Point(475, 122);
            btAddMedicine.Name = "btAddMedicine";
            btAddMedicine.Size = new Size(91, 49);
            btAddMedicine.TabIndex = 27;
            btAddMedicine.Text = "Thêm";
            btAddMedicine.UseVisualStyleBackColor = true;
            btAddMedicine.Click += btAddMedicine_Click;
            // 
            // txtCurrentStock
            // 
            txtCurrentStock.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentStock.Font = new Font("Segoe UI", 10F);
            txtCurrentStock.Location = new Point(184, 132);
            txtCurrentStock.Name = "txtCurrentStock";
            txtCurrentStock.Size = new Size(254, 30);
            txtCurrentStock.TabIndex = 25;
            // 
            // txtImportPrice
            // 
            txtImportPrice.BorderStyle = BorderStyle.FixedSingle;
            txtImportPrice.Font = new Font("Segoe UI", 10F);
            txtImportPrice.Location = new Point(753, 132);
            txtImportPrice.Name = "txtImportPrice";
            txtImportPrice.Size = new Size(274, 30);
            txtImportPrice.TabIndex = 24;
            // 
            // txtQuantity
            // 
            txtQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtQuantity.Font = new Font("Segoe UI", 10F);
            txtQuantity.Location = new Point(753, 82);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(274, 30);
            txtQuantity.TabIndex = 23;
            // 
            // cbMedicine
            // 
            cbMedicine.Font = new Font("Segoe UI", 10F);
            cbMedicine.FormattingEnabled = true;
            cbMedicine.Location = new Point(184, 81);
            cbMedicine.Name = "cbMedicine";
            cbMedicine.Size = new Size(254, 31);
            cbMedicine.TabIndex = 17;
            cbMedicine.SelectedIndexChanged += cbMedicine_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10F);
            label11.ForeColor = Color.DarkCyan;
            label11.Location = new Point(19, 81);
            label11.Name = "label11";
            label11.Size = new Size(133, 23);
            label11.TabIndex = 16;
            label11.Text = "Tên thuốc nhập:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10F);
            label10.ForeColor = Color.DarkCyan;
            label10.Location = new Point(19, 134);
            label10.Name = "label10";
            label10.Size = new Size(139, 23);
            label10.TabIndex = 15;
            label10.Text = "Tồn kho hiện tại:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10F);
            label9.ForeColor = Color.DarkCyan;
            label9.Location = new Point(595, 82);
            label9.Name = "label9";
            label9.Size = new Size(127, 23);
            label9.TabIndex = 14;
            label9.Text = "Số lượng nhập:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(595, 132);
            label8.Name = "label8";
            label8.Size = new Size(83, 23);
            label8.TabIndex = 13;
            label8.Text = "Giá nhập:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(423, 20);
            label7.Name = "label7";
            label7.Size = new Size(206, 28);
            label7.TabIndex = 10;
            label7.Text = "THÊM THUỐC NHẬP";
            // 
            // Dialog_MedicineImport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1088, 701);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Dialog_MedicineImport";
            Padding = new Padding(10);
            Text = "Dialog_MedicineImport";
            Load += Dialog_MedicineImport_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvImportDetail).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private TextBox txtNote;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtImportPrice;
        private TextBox txtQuantity;
        private ComboBox cbMedicine;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private ComboBox cbSupplier;
        private Panel panel5;
        private Panel panel4;
        private TextBox txtCurrentStock;
        private ComboBox cbPaymentMethod;
        private Label label13;
        private Label label12;
        private Button btConfirmImport;
        private Button btCancel;
        private TextBox lbTotalAmount;
        private DataGridView dgvImportDetail;
        private Label lbImportId;
        private Label lbImportDate;
        private Label lbAccountName;
        private Button btAddMedicine;
    }
}