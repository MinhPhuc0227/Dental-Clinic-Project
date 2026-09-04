namespace DentalClinic.APP
{
    partial class UC_Doctor_MedicalRecord
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            label1 = new Label();
            pnLeft = new Panel();
            dgvExaminedList = new DataGridView();
            panel1 = new Panel();
            cbStatus = new ComboBox();
            label2 = new Label();
            txtSearch = new TextBox();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            pnRight = new Panel();
            pnService = new Panel();
            dgvService = new DataGridView();
            pnMedicine = new Panel();
            dgvMedicine = new DataGridView();
            pnInfo = new Panel();
            lbPatientName = new Label();
            label6 = new Label();
            lbMedicalRecordId = new Label();
            label14 = new Label();
            txtConclusion = new TextBox();
            txtDiagnosis = new TextBox();
            lbExaminationDateTime = new Label();
            label13 = new Label();
            label15 = new Label();
            label18 = new Label();
            txtNote = new TextBox();
            label3 = new Label();
            pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExaminedList).BeginInit();
            panel1.SuspendLayout();
            pnRight.SuspendLayout();
            pnService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvService).BeginInit();
            pnMedicine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicine).BeginInit();
            pnInfo.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(20, 16);
            label1.Name = "label1";
            label1.Size = new Size(215, 32);
            label1.TabIndex = 13;
            label1.Text = "BỆNH ÁN ĐÃ LẬP";
            // 
            // pnLeft
            // 
            pnLeft.Controls.Add(dgvExaminedList);
            pnLeft.Controls.Add(panel1);
            pnLeft.Dock = DockStyle.Left;
            pnLeft.Location = new Point(14, 14);
            pnLeft.Name = "pnLeft";
            pnLeft.Padding = new Padding(0, 0, 10, 0);
            pnLeft.Size = new Size(564, 789);
            pnLeft.TabIndex = 1;
            // 
            // dgvExaminedList
            // 
            dgvExaminedList.AllowUserToAddRows = false;
            dgvExaminedList.AllowUserToDeleteRows = false;
            dgvExaminedList.AllowUserToOrderColumns = true;
            dgvExaminedList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExaminedList.BackgroundColor = Color.White;
            dgvExaminedList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExaminedList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.DarkCyan;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvExaminedList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvExaminedList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvExaminedList.DefaultCellStyle = dataGridViewCellStyle8;
            dgvExaminedList.Dock = DockStyle.Fill;
            dgvExaminedList.EnableHeadersVisualStyles = false;
            dgvExaminedList.GridColor = Color.DarkCyan;
            dgvExaminedList.Location = new Point(0, 153);
            dgvExaminedList.MultiSelect = false;
            dgvExaminedList.Name = "dgvExaminedList";
            dgvExaminedList.ReadOnly = true;
            dgvExaminedList.RowHeadersVisible = false;
            dgvExaminedList.RowHeadersWidth = 51;
            dgvExaminedList.RowTemplate.Height = 38;
            dgvExaminedList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExaminedList.Size = new Size(554, 636);
            dgvExaminedList.TabIndex = 15;
            dgvExaminedList.CellClick += dgvExaminedList_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(dtpEnd);
            panel1.Controls.Add(dtpStart);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(554, 153);
            panel1.TabIndex = 14;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(298, 13);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(151, 36);
            cbStatus.TabIndex = 46;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(23, 106);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 45;
            label2.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(131, 104);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(400, 30);
            txtSearch.TabIndex = 44;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "dd/MM/yyyy";
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(393, 59);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(138, 30);
            dtpEnd.TabIndex = 42;
            dtpEnd.ValueChanged += dtpEnd_ValueChanged;
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "dd/MM/yyyy";
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(131, 59);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(138, 30);
            dtpStart.TabIndex = 41;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(288, 59);
            label5.Name = "label5";
            label5.Size = new Size(99, 28);
            label5.TabIndex = 40;
            label5.Text = "Đến ngày";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(23, 59);
            label4.Name = "label4";
            label4.Size = new Size(85, 28);
            label4.TabIndex = 39;
            label4.Text = "Từ ngày";
            // 
            // pnRight
            // 
            pnRight.Controls.Add(pnService);
            pnRight.Controls.Add(pnMedicine);
            pnRight.Controls.Add(pnInfo);
            pnRight.Dock = DockStyle.Fill;
            pnRight.Location = new Point(578, 14);
            pnRight.Name = "pnRight";
            pnRight.Padding = new Padding(10, 0, 0, 0);
            pnRight.Size = new Size(728, 789);
            pnRight.TabIndex = 2;
            // 
            // pnService
            // 
            pnService.Controls.Add(dgvService);
            pnService.Dock = DockStyle.Fill;
            pnService.Location = new Point(10, 253);
            pnService.Name = "pnService";
            pnService.Padding = new Padding(0, 0, 0, 10);
            pnService.Size = new Size(718, 352);
            pnService.TabIndex = 2;
            // 
            // dgvService
            // 
            dgvService.AllowUserToAddRows = false;
            dgvService.AllowUserToDeleteRows = false;
            dgvService.AllowUserToOrderColumns = true;
            dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvService.BackgroundColor = Color.White;
            dgvService.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvService.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.DarkCyan;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle9.ForeColor = Color.White;
            dataGridViewCellStyle9.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle10.ForeColor = Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = Color.Black;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvService.DefaultCellStyle = dataGridViewCellStyle10;
            dgvService.Dock = DockStyle.Fill;
            dgvService.EnableHeadersVisualStyles = false;
            dgvService.GridColor = Color.DarkCyan;
            dgvService.Location = new Point(0, 0);
            dgvService.MultiSelect = false;
            dgvService.Name = "dgvService";
            dgvService.ReadOnly = true;
            dgvService.RowHeadersVisible = false;
            dgvService.RowHeadersWidth = 51;
            dgvService.RowTemplate.Height = 38;
            dgvService.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvService.Size = new Size(718, 342);
            dgvService.TabIndex = 16;
            // 
            // pnMedicine
            // 
            pnMedicine.Controls.Add(dgvMedicine);
            pnMedicine.Dock = DockStyle.Bottom;
            pnMedicine.Location = new Point(10, 605);
            pnMedicine.Name = "pnMedicine";
            pnMedicine.Padding = new Padding(0, 10, 0, 0);
            pnMedicine.Size = new Size(718, 184);
            pnMedicine.TabIndex = 1;
            // 
            // dgvMedicine
            // 
            dgvMedicine.AllowUserToAddRows = false;
            dgvMedicine.AllowUserToDeleteRows = false;
            dgvMedicine.AllowUserToOrderColumns = true;
            dgvMedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicine.BackgroundColor = Color.White;
            dgvMedicine.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMedicine.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.DarkCyan;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle11.SelectionForeColor = Color.White;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvMedicine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = Color.Black;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dgvMedicine.DefaultCellStyle = dataGridViewCellStyle12;
            dgvMedicine.Dock = DockStyle.Fill;
            dgvMedicine.EnableHeadersVisualStyles = false;
            dgvMedicine.GridColor = Color.DarkCyan;
            dgvMedicine.Location = new Point(0, 10);
            dgvMedicine.MultiSelect = false;
            dgvMedicine.Name = "dgvMedicine";
            dgvMedicine.ReadOnly = true;
            dgvMedicine.RowHeadersVisible = false;
            dgvMedicine.RowHeadersWidth = 51;
            dgvMedicine.RowTemplate.Height = 38;
            dgvMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicine.Size = new Size(718, 174);
            dgvMedicine.TabIndex = 16;
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(txtNote);
            pnInfo.Controls.Add(label3);
            pnInfo.Controls.Add(lbPatientName);
            pnInfo.Controls.Add(label6);
            pnInfo.Controls.Add(lbMedicalRecordId);
            pnInfo.Controls.Add(label14);
            pnInfo.Controls.Add(txtConclusion);
            pnInfo.Controls.Add(txtDiagnosis);
            pnInfo.Controls.Add(lbExaminationDateTime);
            pnInfo.Controls.Add(label13);
            pnInfo.Controls.Add(label15);
            pnInfo.Controls.Add(label18);
            pnInfo.Dock = DockStyle.Top;
            pnInfo.Location = new Point(10, 0);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(718, 253);
            pnInfo.TabIndex = 0;
            // 
            // lbPatientName
            // 
            lbPatientName.AutoSize = true;
            lbPatientName.Font = new Font("Segoe UI", 12F);
            lbPatientName.ForeColor = Color.Black;
            lbPatientName.Location = new Point(141, 59);
            lbPatientName.Name = "lbPatientName";
            lbPatientName.Size = new Size(141, 28);
            lbPatientName.TabIndex = 59;
            lbPatientName.Text = "lbPatientName";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(19, 61);
            label6.Name = "label6";
            label6.Size = new Size(116, 28);
            label6.TabIndex = 58;
            label6.Text = "Bệnh nhân:";
            // 
            // lbMedicalRecordId
            // 
            lbMedicalRecordId.AutoSize = true;
            lbMedicalRecordId.Font = new Font("Segoe UI", 12F);
            lbMedicalRecordId.ForeColor = Color.Black;
            lbMedicalRecordId.Location = new Point(127, 18);
            lbMedicalRecordId.Name = "lbMedicalRecordId";
            lbMedicalRecordId.Size = new Size(176, 28);
            lbMedicalRecordId.TabIndex = 57;
            lbMedicalRecordId.Text = "lbMedicalRecordId";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 12F);
            label14.ForeColor = Color.DarkCyan;
            label14.Location = new Point(19, 20);
            label14.Name = "label14";
            label14.Size = new Size(102, 28);
            label14.TabIndex = 56;
            label14.Text = "Mã hồ sơ:";
            // 
            // txtConclusion
            // 
            txtConclusion.BorderStyle = BorderStyle.FixedSingle;
            txtConclusion.Font = new Font("Segoe UI", 10F);
            txtConclusion.Location = new Point(297, 148);
            txtConclusion.Name = "txtConclusion";
            txtConclusion.ReadOnly = true;
            txtConclusion.Size = new Size(303, 30);
            txtConclusion.TabIndex = 55;
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.BorderStyle = BorderStyle.FixedSingle;
            txtDiagnosis.Font = new Font("Segoe UI", 10F);
            txtDiagnosis.Location = new Point(297, 104);
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.ReadOnly = true;
            txtDiagnosis.Size = new Size(303, 30);
            txtDiagnosis.TabIndex = 54;
            // 
            // lbExaminationDateTime
            // 
            lbExaminationDateTime.AutoSize = true;
            lbExaminationDateTime.Font = new Font("Segoe UI", 12F);
            lbExaminationDateTime.ForeColor = Color.Black;
            lbExaminationDateTime.Location = new Point(486, 18);
            lbExaminationDateTime.Name = "lbExaminationDateTime";
            lbExaminationDateTime.Size = new Size(219, 28);
            lbExaminationDateTime.TabIndex = 53;
            lbExaminationDateTime.Text = "lbExaminationDateTime";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 12F);
            label13.ForeColor = Color.DarkCyan;
            label13.Location = new Point(321, 20);
            label13.Name = "label13";
            label13.Size = new Size(159, 28);
            label13.TabIndex = 52;
            label13.Text = "Thời gian khám:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 12F);
            label15.ForeColor = Color.DarkCyan;
            label15.Location = new Point(23, 150);
            label15.Name = "label15";
            label15.Size = new Size(234, 28);
            label15.TabIndex = 51;
            label15.Text = "Kết luận/Hướng điều trị:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 12F);
            label18.ForeColor = Color.DarkCyan;
            label18.Location = new Point(23, 106);
            label18.Name = "label18";
            label18.Size = new Size(115, 28);
            label18.TabIndex = 50;
            label18.Text = "Chẩn đoán:";
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Font = new Font("Segoe UI", 10F);
            txtNote.Location = new Point(297, 197);
            txtNote.Name = "txtNote";
            txtNote.ReadOnly = true;
            txtNote.Size = new Size(303, 30);
            txtNote.TabIndex = 61;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(23, 199);
            label3.Name = "label3";
            label3.Size = new Size(87, 28);
            label3.TabIndex = 60;
            label3.Text = "Ghi chú:";
            label3.Click += label3_Click;
            // 
            // UC_Doctor_MedicalRecord
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnRight);
            Controls.Add(pnLeft);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Doctor_MedicalRecord";
            Padding = new Padding(14);
            Size = new Size(1320, 817);
            Load += UC_Doctor_MedicalRecord_Load;
            pnLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExaminedList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnRight.ResumeLayout(false);
            pnService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvService).EndInit();
            pnMedicine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedicine).EndInit();
            pnInfo.ResumeLayout(false);
            pnInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel pnLeft;
        private Panel pnRight;
        private Panel panel1;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Label label5;
        private Label label4;
        private Label label2;
        private TextBox txtSearch;
        private DataGridView dgvExaminedList;
        private Panel pnService;
        private DataGridView dgvService;
        private Panel pnMedicine;
        private DataGridView dgvMedicine;
        private Panel pnInfo;
        private Label lbMedicalRecordId;
        private Label label14;
        private TextBox txtConclusion;
        private TextBox txtDiagnosis;
        private Label lbExaminationDateTime;
        private Label label13;
        private Label label15;
        private Label label18;
        private Label lbPatientName;
        private Label label6;
        private ComboBox cbStatus;
        private TextBox txtNote;
        private Label label3;
    }
}
