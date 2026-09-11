namespace DentalClinic.APP
{
    partial class UC_Receptionist_Visit
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
            label2 = new Label();
            cbSort = new ComboBox();
            cbStatus = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            cbDoctor = new ComboBox();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            btCreateVisit = new Button();
            label3 = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            dgvVisit = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisit).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbSort);
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cbDoctor);
            panel1.Controls.Add(dtpEnd);
            panel1.Controls.Add(dtpStart);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btCreateVisit);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1595, 170);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(583, 82);
            label2.Name = "label2";
            label2.Size = new Size(84, 28);
            label2.TabIndex = 34;
            label2.Text = "Sắp xếp";
            // 
            // cbSort
            // 
            cbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSort.Font = new Font("Segoe UI", 10F);
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(583, 113);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(213, 31);
            cbSort.TabIndex = 33;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // cbStatus
            // 
            cbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(1049, 113);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(213, 31);
            cbStatus.TabIndex = 32;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(1049, 82);
            label7.Name = "label7";
            label7.Size = new Size(102, 28);
            label7.TabIndex = 31;
            label7.Text = "Trạng thái";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(816, 82);
            label6.Name = "label6";
            label6.Size = new Size(63, 28);
            label6.TabIndex = 30;
            label6.Text = "Bác sĩ";
            // 
            // cbDoctor
            // 
            cbDoctor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbDoctor.Font = new Font("Segoe UI", 10F);
            cbDoctor.FormattingEnabled = true;
            cbDoctor.Location = new Point(816, 113);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(213, 31);
            cbDoctor.TabIndex = 29;
            cbDoctor.SelectedIndexChanged += cbDoctor_SelectedIndexChanged;
            // 
            // dtpEnd
            // 
            dtpEnd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpEnd.CustomFormat = "dd/MM/yyyy";
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(334, 113);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(138, 30);
            dtpEnd.TabIndex = 28;
            dtpEnd.ValueChanged += dtpEnd_ValueChanged;
            // 
            // dtpStart
            // 
            dtpStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpStart.CustomFormat = "dd/MM/yyyy";
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(168, 113);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(138, 30);
            dtpStart.TabIndex = 27;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(334, 82);
            label5.Name = "label5";
            label5.Size = new Size(99, 28);
            label5.TabIndex = 26;
            label5.Text = "Đến ngày";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(168, 82);
            label4.Name = "label4";
            label4.Size = new Size(85, 28);
            label4.TabIndex = 25;
            label4.Text = "Từ ngày";
            // 
            // btCreateVisit
            // 
            btCreateVisit.BackColor = SystemColors.HotTrack;
            btCreateVisit.FlatAppearance.BorderSize = 0;
            btCreateVisit.FlatStyle = FlatStyle.Flat;
            btCreateVisit.Font = new Font("Segoe UI Semibold", 10F);
            btCreateVisit.ForeColor = Color.White;
            btCreateVisit.Location = new Point(28, 99);
            btCreateVisit.Name = "btCreateVisit";
            btCreateVisit.Size = new Size(116, 44);
            btCreateVisit.TabIndex = 21;
            btCreateVisit.Text = "Tiếp nhận ";
            btCreateVisit.UseVisualStyleBackColor = false;
            btCreateVisit.Click += btCreateVisit_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(1282, 82);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 19;
            label3.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(1282, 113);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 18;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(28, 16);
            label1.Name = "label1";
            label1.Size = new Size(424, 32);
            label1.TabIndex = 17;
            label1.Text = "TIẾP NHẬN BỆNH NHÂN TRỰC TIẾP";
            // 
            // dgvVisit
            // 
            dgvVisit.AllowUserToAddRows = false;
            dgvVisit.AllowUserToDeleteRows = false;
            dgvVisit.AllowUserToOrderColumns = true;
            dgvVisit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisit.BackgroundColor = Color.White;
            dgvVisit.BorderStyle = BorderStyle.None;
            dgvVisit.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVisit.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVisit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVisit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvVisit.DefaultCellStyle = dataGridViewCellStyle2;
            dgvVisit.Dock = DockStyle.Fill;
            dgvVisit.EnableHeadersVisualStyles = false;
            dgvVisit.GridColor = Color.DarkCyan;
            dgvVisit.Location = new Point(10, 180);
            dgvVisit.MultiSelect = false;
            dgvVisit.Name = "dgvVisit";
            dgvVisit.ReadOnly = true;
            dgvVisit.RowHeadersVisible = false;
            dgvVisit.RowHeadersWidth = 51;
            dgvVisit.RowTemplate.Height = 38;
            dgvVisit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisit.Size = new Size(1595, 412);
            dgvVisit.TabIndex = 7;
            // 
            // UC_Receptionist_Visit
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvVisit);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Receptionist_Visit";
            Padding = new Padding(10);
            Size = new Size(1615, 602);
            Load += UC_Receptionist_Visit_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private TextBox txtSearch;
        private Button btCreateVisit;
        private DataGridView dgvVisit;
        private ComboBox cbStatus;
        private Label label7;
        private Label label6;
        private ComboBox cbDoctor;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Label label5;
        private Label label4;
        private Label label2;
        private ComboBox cbSort;
    }
}
