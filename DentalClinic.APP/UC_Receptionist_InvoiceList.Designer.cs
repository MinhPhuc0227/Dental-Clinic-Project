namespace DentalClinic.APP
{
    partial class UC_Receptionist_InvoiceList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            txtSearch = new TextBox();
            cbStatus = new ComboBox();
            label7 = new Label();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgvInvoiceList = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceList).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dtpEnd);
            panel1.Controls.Add(dtpStart);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(964, 171);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(665, 81);
            label1.Name = "label1";
            label1.Size = new Size(97, 28);
            label1.TabIndex = 42;
            label1.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(665, 112);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 41;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cbStatus
            // 
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(410, 112);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(200, 31);
            cbStatus.TabIndex = 40;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(410, 81);
            label7.Name = "label7";
            label7.Size = new Size(102, 28);
            label7.TabIndex = 39;
            label7.Text = "Trạng thái";
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "dd/MM/yyyy";
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(217, 112);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(138, 30);
            dtpEnd.TabIndex = 38;
            dtpEnd.ValueChanged += dtpEnd_ValueChanged;
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "dd/MM/yyyy";
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(24, 112);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(138, 30);
            dtpStart.TabIndex = 37;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(217, 81);
            label5.Name = "label5";
            label5.Size = new Size(99, 28);
            label5.TabIndex = 36;
            label5.Text = "Đến ngày";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(24, 81);
            label4.Name = "label4";
            label4.Size = new Size(85, 28);
            label4.TabIndex = 35;
            label4.Text = "Từ ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(17, 20);
            label3.Name = "label3";
            label3.Size = new Size(413, 32);
            label3.TabIndex = 34;
            label3.Text = "DANH SÁCH HÓA ĐƠN PHÁT SINH";
            // 
            // dgvInvoiceList
            // 
            dgvInvoiceList.AllowUserToAddRows = false;
            dgvInvoiceList.AllowUserToDeleteRows = false;
            dgvInvoiceList.AllowUserToOrderColumns = true;
            dgvInvoiceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoiceList.BackgroundColor = Color.White;
            dgvInvoiceList.BorderStyle = BorderStyle.None;
            dgvInvoiceList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvInvoiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvInvoiceList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvInvoiceList.DefaultCellStyle = dataGridViewCellStyle2;
            dgvInvoiceList.Dock = DockStyle.Fill;
            dgvInvoiceList.EnableHeadersVisualStyles = false;
            dgvInvoiceList.GridColor = Color.DarkCyan;
            dgvInvoiceList.Location = new Point(10, 181);
            dgvInvoiceList.MultiSelect = false;
            dgvInvoiceList.Name = "dgvInvoiceList";
            dgvInvoiceList.ReadOnly = true;
            dgvInvoiceList.RowHeadersVisible = false;
            dgvInvoiceList.RowHeadersWidth = 51;
            dgvInvoiceList.RowTemplate.Height = 38;
            dgvInvoiceList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceList.Size = new Size(964, 378);
            dgvInvoiceList.TabIndex = 6;
            dgvInvoiceList.CellContentClick += dgvInvoiceList_CellContentClick;
            // 
            // UC_Receptionist_InvoiceList
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvInvoiceList);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Receptionist_InvoiceList";
            Padding = new Padding(10);
            Size = new Size(984, 569);
            Load += UC_Receptionist_InvoiceList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private ComboBox cbStatus;
        private Label label7;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Label label5;
        private Label label4;
        private Label label1;
        private TextBox txtSearch;
        private DataGridView dgvInvoiceList;
    }
}
