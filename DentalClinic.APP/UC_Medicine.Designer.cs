namespace DentalClinic.APP
{
    partial class UC_Medicine
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
            btImportHistory = new Button();
            btImport = new Button();
            cbStatus = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            txtSearch = new TextBox();
            btAdd = new Button();
            label1 = new Label();
            dgvMedicine = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicine).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btImportHistory);
            panel1.Controls.Add(btImport);
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btAdd);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1386, 140);
            panel1.TabIndex = 0;
            // 
            // btImportHistory
            // 
            btImportHistory.BackColor = Color.DarkOrange;
            btImportHistory.FlatAppearance.BorderSize = 0;
            btImportHistory.FlatStyle = FlatStyle.Flat;
            btImportHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btImportHistory.ForeColor = Color.White;
            btImportHistory.Location = new Point(316, 63);
            btImportHistory.Name = "btImportHistory";
            btImportHistory.Size = new Size(169, 49);
            btImportHistory.TabIndex = 15;
            btImportHistory.Text = "Lịch sử nhập thuốc";
            btImportHistory.UseVisualStyleBackColor = false;
            btImportHistory.Click += btImportHistory_Click;
            // 
            // btImport
            // 
            btImport.BackColor = Color.ForestGreen;
            btImport.FlatAppearance.BorderSize = 0;
            btImport.FlatStyle = FlatStyle.Flat;
            btImport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btImport.ForeColor = Color.White;
            btImport.Location = new Point(182, 63);
            btImport.Name = "btImport";
            btImport.Size = new Size(118, 49);
            btImport.TabIndex = 14;
            btImport.Text = "Nhập thuốc";
            btImport.UseVisualStyleBackColor = false;
            btImport.Click += btImport_Click;
            // 
            // cbStatus
            // 
            cbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(671, 81);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(226, 31);
            cbStatus.TabIndex = 13;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(563, 81);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 12;
            label2.Text = "Trạng thái";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(960, 82);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 11;
            label3.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(1063, 82);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(296, 30);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btAdd
            // 
            btAdd.BackColor = SystemColors.HotTrack;
            btAdd.FlatAppearance.BorderSize = 0;
            btAdd.FlatStyle = FlatStyle.Flat;
            btAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btAdd.ForeColor = Color.White;
            btAdd.Image = Properties.Resources.add;
            btAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btAdd.Location = new Point(27, 63);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(134, 49);
            btAdd.TabIndex = 9;
            btAdd.Text = "Thêm mới";
            btAdd.TextAlign = ContentAlignment.MiddleRight;
            btAdd.UseVisualStyleBackColor = false;
            btAdd.Click += btAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(23, 14);
            label1.Name = "label1";
            label1.Size = new Size(207, 32);
            label1.TabIndex = 8;
            label1.Text = "QUẢN LÝ THUỐC";
            // 
            // dgvMedicine
            // 
            dgvMedicine.AllowUserToAddRows = false;
            dgvMedicine.AllowUserToDeleteRows = false;
            dgvMedicine.AllowUserToOrderColumns = true;
            dgvMedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicine.BackgroundColor = Color.White;
            dgvMedicine.BorderStyle = BorderStyle.None;
            dgvMedicine.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMedicine.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMedicine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMedicine.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMedicine.Dock = DockStyle.Fill;
            dgvMedicine.EnableHeadersVisualStyles = false;
            dgvMedicine.GridColor = Color.DarkCyan;
            dgvMedicine.Location = new Point(10, 150);
            dgvMedicine.MultiSelect = false;
            dgvMedicine.Name = "dgvMedicine";
            dgvMedicine.ReadOnly = true;
            dgvMedicine.RowHeadersVisible = false;
            dgvMedicine.RowHeadersWidth = 51;
            dgvMedicine.RowTemplate.Height = 38;
            dgvMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicine.Size = new Size(1386, 396);
            dgvMedicine.TabIndex = 4;
            dgvMedicine.CellContentClick += dgvMedicine_CellContentClick;
            // 
            // UC_Medicine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvMedicine);
            Controls.Add(panel1);
            Name = "UC_Medicine";
            Padding = new Padding(10);
            Size = new Size(1406, 556);
            Load += UC_Medicine_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvMedicine;
        private Label label3;
        private TextBox txtSearch;
        private Button btAdd;
        private Label label1;
        private ComboBox cbStatus;
        private Label label2;
        private Button btImportHistory;
        private Button btImport;
    }
}
