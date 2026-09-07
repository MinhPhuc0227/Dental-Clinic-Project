namespace DentalClinic.APP
{
    partial class UC_Receptionist_Appointment
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
            cbStatus = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            cbDoctor = new ComboBox();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtSearch = new TextBox();
            btAdd = new Button();
            label1 = new Label();
            dgvAppointment = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cbDoctor);
            panel1.Controls.Add(dtpEnd);
            panel1.Controls.Add(dtpStart);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btAdd);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1364, 228);
            panel1.TabIndex = 0;
            // 
            // cbStatus
            // 
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(741, 157);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(200, 31);
            cbStatus.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(741, 112);
            label7.Name = "label7";
            label7.Size = new Size(102, 28);
            label7.TabIndex = 23;
            label7.Text = "Trạng thái";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(465, 112);
            label6.Name = "label6";
            label6.Size = new Size(63, 28);
            label6.TabIndex = 22;
            label6.Text = "Bác sĩ";
            // 
            // cbDoctor
            // 
            cbDoctor.Font = new Font("Segoe UI", 10F);
            cbDoctor.FormattingEnabled = true;
            cbDoctor.Location = new Point(465, 155);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(190, 31);
            cbDoctor.TabIndex = 21;
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "dd/MM/yyyy";
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(246, 154);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(138, 30);
            dtpEnd.TabIndex = 20;
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "dd/MM/yyyy";
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(13, 155);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(138, 30);
            dtpStart.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(246, 112);
            label5.Name = "label5";
            label5.Size = new Size(99, 28);
            label5.TabIndex = 18;
            label5.Text = "Đến ngày";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(10, 112);
            label4.Name = "label4";
            label4.Size = new Size(85, 28);
            label4.TabIndex = 17;
            label4.Text = "Từ ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(13, 63);
            label2.Name = "label2";
            label2.Size = new Size(257, 23);
            label2.TabIndex = 16;
            label2.Text = "Quản lý lịch khám của bệnh nhân";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(1064, 112);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 15;
            label3.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(1064, 156);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 14;
            // 
            // btAdd
            // 
            btAdd.FlatAppearance.BorderSize = 0;
            btAdd.Image = Properties.Resources.add;
            btAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btAdd.Location = new Point(329, 20);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(162, 49);
            btAdd.TabIndex = 13;
            btAdd.Text = "Tạo lịch hẹn";
            btAdd.TextAlign = ContentAlignment.MiddleRight;
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(13, 19);
            label1.Name = "label1";
            label1.Size = new Size(108, 32);
            label1.TabIndex = 12;
            label1.Text = "Lịch hẹn";
            // 
            // dgvAppointment
            // 
            dgvAppointment.AllowUserToAddRows = false;
            dgvAppointment.AllowUserToDeleteRows = false;
            dgvAppointment.AllowUserToOrderColumns = true;
            dgvAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointment.BackgroundColor = Color.White;
            dgvAppointment.BorderStyle = BorderStyle.None;
            dgvAppointment.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAppointment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAppointment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAppointment.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAppointment.Dock = DockStyle.Fill;
            dgvAppointment.EnableHeadersVisualStyles = false;
            dgvAppointment.GridColor = Color.DarkCyan;
            dgvAppointment.Location = new Point(10, 238);
            dgvAppointment.MultiSelect = false;
            dgvAppointment.Name = "dgvAppointment";
            dgvAppointment.ReadOnly = true;
            dgvAppointment.RowHeadersVisible = false;
            dgvAppointment.RowHeadersWidth = 51;
            dgvAppointment.RowTemplate.Height = 38;
            dgvAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointment.Size = new Size(1364, 386);
            dgvAppointment.TabIndex = 5;
            dgvAppointment.CellContentClick += DgvAppointment_CellClick;
            // 
            // UC_Receptionist_Appointment
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvAppointment);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Receptionist_Appointment";
            Padding = new Padding(10);
            Size = new Size(1384, 634);
            Load += UC_Receptionist_Appointment_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvAppointment;
        private Label label3;
        private TextBox txtSearch;
        private Button btAdd;
        private Label label1;
        private Label label2;
        private ComboBox cbStatus;
        private Label label7;
        private Label label6;
        private ComboBox cbDoctor;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Label label5;
        private Label label4;
    }
}
