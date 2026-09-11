namespace DentalClinic.APP
{
    partial class Dialog_Treatment
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnCenter = new Panel();
            dgvTreatmentSession = new DataGridView();
            panel4 = new Panel();
            btAddSession = new Button();
            label9 = new Label();
            pnTop = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            dgvTreatments = new DataGridView();
            panel5 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            btCompleteTreatment = new Button();
            btSave = new Button();
            btCancel = new Button();
            btEditTreatment = new Button();
            nudPlannedSessions = new NumericUpDown();
            textBox1 = new TextBox();
            dtpEndDate = new DateTimePicker();
            lbCompletedSessions = new Label();
            lbProgress = new Label();
            label14 = new Label();
            label13 = new Label();
            label11 = new Label();
            label10 = new Label();
            label12 = new Label();
            lbDoctorName = new Label();
            cbStatus = new ComboBox();
            lbTotalAmount = new Label();
            dtpStartDate = new DateTimePicker();
            cbService = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            panel6 = new Panel();
            label1 = new Label();
            pnCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTreatmentSession).BeginInit();
            panel4.SuspendLayout();
            pnTop.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTreatments).BeginInit();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPlannedSessions).BeginInit();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // pnCenter
            // 
            pnCenter.Controls.Add(dgvTreatmentSession);
            pnCenter.Controls.Add(panel4);
            pnCenter.Dock = DockStyle.Fill;
            pnCenter.Location = new Point(10, 636);
            pnCenter.Name = "pnCenter";
            pnCenter.Size = new Size(1254, 317);
            pnCenter.TabIndex = 0;
            // 
            // dgvTreatmentSession
            // 
            dgvTreatmentSession.AllowUserToAddRows = false;
            dgvTreatmentSession.AllowUserToDeleteRows = false;
            dgvTreatmentSession.AllowUserToOrderColumns = true;
            dgvTreatmentSession.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTreatmentSession.BackgroundColor = Color.WhiteSmoke;
            dgvTreatmentSession.BorderStyle = BorderStyle.None;
            dgvTreatmentSession.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTreatmentSession.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTreatmentSession.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTreatmentSession.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTreatmentSession.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTreatmentSession.Dock = DockStyle.Fill;
            dgvTreatmentSession.EnableHeadersVisualStyles = false;
            dgvTreatmentSession.GridColor = Color.DarkCyan;
            dgvTreatmentSession.Location = new Point(0, 66);
            dgvTreatmentSession.MultiSelect = false;
            dgvTreatmentSession.Name = "dgvTreatmentSession";
            dgvTreatmentSession.ReadOnly = true;
            dgvTreatmentSession.RowHeadersVisible = false;
            dgvTreatmentSession.RowHeadersWidth = 51;
            dgvTreatmentSession.RowTemplate.Height = 38;
            dgvTreatmentSession.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTreatmentSession.Size = new Size(1254, 251);
            dgvTreatmentSession.TabIndex = 7;
            dgvTreatmentSession.CellClick += dgvTreatmentSession_CellClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(btAddSession);
            panel4.Controls.Add(label9);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1254, 66);
            panel4.TabIndex = 0;
            // 
            // btAddSession
            // 
            btAddSession.BackColor = Color.ForestGreen;
            btAddSession.FlatAppearance.BorderSize = 0;
            btAddSession.FlatStyle = FlatStyle.Flat;
            btAddSession.Font = new Font("Segoe UI Semibold", 10F);
            btAddSession.ForeColor = Color.White;
            btAddSession.Location = new Point(1065, 16);
            btAddSession.Name = "btAddSession";
            btAddSession.Size = new Size(152, 36);
            btAddSession.TabIndex = 9;
            btAddSession.Text = "Thêm buổi khám";
            btAddSession.UseVisualStyleBackColor = false;
            btAddSession.Click += btAddSession_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.ForeColor = Color.DarkCyan;
            label9.Location = new Point(15, 18);
            label9.Name = "label9";
            label9.Size = new Size(182, 28);
            label9.TabIndex = 4;
            label9.Text = "TIẾN ĐỘ ĐIỀU TRỊ";
            // 
            // pnTop
            // 
            pnTop.Controls.Add(tableLayoutPanel1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(10, 10);
            pnTop.Name = "pnTop";
            pnTop.Padding = new Padding(0, 0, 0, 5);
            pnTop.Size = new Size(1254, 626);
            pnTop.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.0240746F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.9759254F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel6, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.5771809F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88.42282F));
            tableLayoutPanel1.Size = new Size(1254, 621);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvTreatments);
            panel1.Controls.Add(panel5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 74);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 544);
            panel1.TabIndex = 1;
            // 
            // dgvTreatments
            // 
            dgvTreatments.AllowUserToAddRows = false;
            dgvTreatments.AllowUserToDeleteRows = false;
            dgvTreatments.AllowUserToOrderColumns = true;
            dgvTreatments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTreatments.BackgroundColor = Color.White;
            dgvTreatments.BorderStyle = BorderStyle.None;
            dgvTreatments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTreatments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkCyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTreatments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTreatments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTreatments.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTreatments.Dock = DockStyle.Fill;
            dgvTreatments.EnableHeadersVisualStyles = false;
            dgvTreatments.GridColor = Color.DarkCyan;
            dgvTreatments.Location = new Point(0, 45);
            dgvTreatments.MultiSelect = false;
            dgvTreatments.Name = "dgvTreatments";
            dgvTreatments.ReadOnly = true;
            dgvTreatments.RowHeadersVisible = false;
            dgvTreatments.RowHeadersWidth = 51;
            dgvTreatments.RowTemplate.Height = 38;
            dgvTreatments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTreatments.Size = new Size(546, 499);
            dgvTreatments.TabIndex = 8;
            dgvTreatments.CellClick += dgvTreatments_CellClick;
            // 
            // panel5
            // 
            panel5.Controls.Add(label2);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(546, 45);
            panel5.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(12, 10);
            label2.Name = "label2";
            label2.Size = new Size(237, 28);
            label2.TabIndex = 2;
            label2.Text = "DANH SÁCH KẾ HOẠCH";
            // 
            // panel2
            // 
            panel2.Controls.Add(btCompleteTreatment);
            panel2.Controls.Add(btSave);
            panel2.Controls.Add(btCancel);
            panel2.Controls.Add(btEditTreatment);
            panel2.Controls.Add(nudPlannedSessions);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(dtpEndDate);
            panel2.Controls.Add(lbCompletedSessions);
            panel2.Controls.Add(lbProgress);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(lbDoctorName);
            panel2.Controls.Add(cbStatus);
            panel2.Controls.Add(lbTotalAmount);
            panel2.Controls.Add(dtpStartDate);
            panel2.Controls.Add(cbService);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(555, 74);
            panel2.Name = "panel2";
            panel2.Size = new Size(696, 544);
            panel2.TabIndex = 2;
            // 
            // btCompleteTreatment
            // 
            btCompleteTreatment.BackColor = SystemColors.HotTrack;
            btCompleteTreatment.FlatAppearance.BorderSize = 0;
            btCompleteTreatment.FlatStyle = FlatStyle.Flat;
            btCompleteTreatment.Font = new Font("Segoe UI Semibold", 10F);
            btCompleteTreatment.ForeColor = Color.White;
            btCompleteTreatment.Location = new Point(534, 15);
            btCompleteTreatment.Name = "btCompleteTreatment";
            btCompleteTreatment.Size = new Size(128, 36);
            btCompleteTreatment.TabIndex = 0;
            btCompleteTreatment.Text = "Hoàn thành";
            btCompleteTreatment.UseVisualStyleBackColor = false;
            btCompleteTreatment.Click += btCompleteTreatment_Click;
            // 
            // btSave
            // 
            btSave.BackColor = Color.FromArgb(0, 184, 148);
            btSave.FlatAppearance.BorderSize = 0;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 10F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(549, 490);
            btSave.Name = "btSave";
            btSave.Size = new Size(113, 36);
            btSave.TabIndex = 8;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // btCancel
            // 
            btCancel.BackColor = Color.DimGray;
            btCancel.FlatAppearance.BorderSize = 0;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 10F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(430, 490);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(113, 36);
            btCancel.TabIndex = 7;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // btEditTreatment
            // 
            btEditTreatment.BackColor = Color.DarkOrange;
            btEditTreatment.FlatAppearance.BorderSize = 0;
            btEditTreatment.FlatStyle = FlatStyle.Flat;
            btEditTreatment.Font = new Font("Segoe UI Semibold", 10F);
            btEditTreatment.ForeColor = Color.White;
            btEditTreatment.Location = new Point(408, 15);
            btEditTreatment.Name = "btEditTreatment";
            btEditTreatment.Size = new Size(113, 36);
            btEditTreatment.TabIndex = 26;
            btEditTreatment.Text = "Chỉnh sửa ";
            btEditTreatment.UseVisualStyleBackColor = false;
            btEditTreatment.Click += btEditTreatment_Click;
            // 
            // nudPlannedSessions
            // 
            nudPlannedSessions.Location = new Point(179, 435);
            nudPlannedSessions.Name = "nudPlannedSessions";
            nudPlannedSessions.Size = new Size(59, 30);
            nudPlannedSessions.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(230, 324);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(432, 85);
            textBox1.TabIndex = 5;
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(230, 199);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(432, 30);
            dtpEndDate.TabIndex = 3;
            // 
            // lbCompletedSessions
            // 
            lbCompletedSessions.AutoSize = true;
            lbCompletedSessions.Location = new Point(378, 437);
            lbCompletedSessions.Name = "lbCompletedSessions";
            lbCompletedSessions.Size = new Size(22, 23);
            lbCompletedSessions.TabIndex = 47;
            lbCompletedSessions.Text = "...";
            // 
            // lbProgress
            // 
            lbProgress.AutoSize = true;
            lbProgress.Font = new Font("Segoe UI Semibold", 12F);
            lbProgress.ForeColor = Color.ForestGreen;
            lbProgress.Location = new Point(566, 434);
            lbProgress.Name = "lbProgress";
            lbProgress.Size = new Size(27, 28);
            lbProgress.TabIndex = 46;
            lbProgress.Text = "...";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 10F);
            label14.ForeColor = Color.DarkCyan;
            label14.Location = new Point(489, 437);
            label14.Name = "label14";
            label14.Size = new Size(71, 23);
            label14.TabIndex = 45;
            label14.Text = "Tiến độ:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 10F);
            label13.ForeColor = Color.DarkCyan;
            label13.Location = new Point(269, 437);
            label13.Name = "label13";
            label13.Size = new Size(113, 23);
            label13.TabIndex = 44;
            label13.Text = "Đã thực hiện:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10F);
            label11.ForeColor = Color.DarkCyan;
            label11.Location = new Point(26, 437);
            label11.Name = "label11";
            label11.Size = new Size(147, 23);
            label11.TabIndex = 43;
            label11.Text = "Số buổi (dự kiến):";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10F);
            label10.ForeColor = Color.DarkCyan;
            label10.Location = new Point(26, 199);
            label10.Name = "label10";
            label10.Size = new Size(198, 23);
            label10.TabIndex = 41;
            label10.Text = "Ngày kết thúc (dự kiến):";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10F);
            label12.ForeColor = Color.DarkCyan;
            label12.Location = new Point(26, 324);
            label12.Name = "label12";
            label12.Size = new Size(73, 23);
            label12.TabIndex = 24;
            label12.Text = "Ghi chú:";
            // 
            // lbDoctorName
            // 
            lbDoctorName.AutoSize = true;
            lbDoctorName.Location = new Point(230, 112);
            lbDoctorName.Name = "lbDoctorName";
            lbDoctorName.Size = new Size(22, 23);
            lbDoctorName.TabIndex = 23;
            lbDoctorName.Text = "...";
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(230, 278);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(432, 31);
            cbStatus.TabIndex = 4;
            // 
            // lbTotalAmount
            // 
            lbTotalAmount.AutoSize = true;
            lbTotalAmount.Location = new Point(230, 240);
            lbTotalAmount.Name = "lbTotalAmount";
            lbTotalAmount.Size = new Size(22, 23);
            lbTotalAmount.TabIndex = 21;
            lbTotalAmount.Text = "...";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(230, 150);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(432, 30);
            dtpStartDate.TabIndex = 2;
            // 
            // cbService
            // 
            cbService.FormattingEnabled = true;
            cbService.Location = new Point(230, 66);
            cbService.Name = "cbService";
            cbService.Size = new Size(432, 31);
            cbService.TabIndex = 1;
            cbService.SelectedIndexChanged += cbService_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(26, 154);
            label8.Name = "label8";
            label8.Size = new Size(119, 23);
            label8.TabIndex = 7;
            label8.Text = "Ngày bắt đầu:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(26, 240);
            label7.Name = "label7";
            label7.Size = new Size(109, 23);
            label7.TabIndex = 6;
            label7.Text = "Tổng chi phí:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(26, 282);
            label6.Name = "label6";
            label6.Size = new Size(91, 23);
            label6.TabIndex = 5;
            label6.Text = "Trạng thái:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(26, 112);
            label5.Name = "label5";
            label5.Size = new Size(136, 23);
            label5.TabIndex = 4;
            label5.Text = "Bác sĩ phụ trách:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(26, 70);
            label4.Name = "label4";
            label4.Size = new Size(72, 23);
            label4.TabIndex = 3;
            label4.Text = "Dịch vụ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(15, 10);
            label3.Name = "label3";
            label3.Size = new Size(366, 28);
            label3.TabIndex = 2;
            label3.Text = "THÔNG TIN ĐIỀU TRỊ CỦA KẾ HOẠCH";
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(555, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(696, 65);
            panel3.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(546, 65);
            panel6.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(244, 32);
            label1.TabIndex = 1;
            label1.Text = "KẾ HOẠCH ĐIỀU TRỊ";
            // 
            // Dialog_Treatment
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1274, 963);
            Controls.Add(pnCenter);
            Controls.Add(pnTop);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_Treatment";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Load += Dialog_Treatment_Load;
            pnCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTreatmentSession).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            pnTop.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTreatments).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPlannedSessions).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnCenter;
        private Panel pnTop;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private ComboBox cbService;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label lbDoctorName;
        private Label lbTotalAmount;
        private DateTimePicker dtpStartDate;
        private Panel panel3;
        private Button btAdd;
        private DataGridView dgvTreatmentSession;
        private Panel panel4;
        private Label label9;
        private DataGridView dgvTreatments;
        private Panel panel5;
        private Label label2;
        private TextBox textBox3;
        private Label label12;
        private Label label14;
        private Label label13;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private Label label10;
        private Label lbCompletedSessions;
        private Label lbProgress;
        private ComboBox cbStatus;
        private Label label6;
        private Panel panel6;
        private Label label1;
        private Button btEditTreatment;
        private DateTimePicker dtpEndDate;
        private TextBox textBox1;
        private Button btSave;
        private Button btCancel;
        private NumericUpDown nudPlannedSessions;
        private Button btAddSession;
        private Button btCompleteTreatment;
    }
}