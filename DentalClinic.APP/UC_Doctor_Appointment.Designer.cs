namespace DentalClinic.APP
{
    partial class UC_Doctor_Appointment
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
            dtpEnd = new DateTimePicker();
            label5 = new Label();
            dtpStart = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            cbAppointmentStatus = new ComboBox();
            label7 = new Label();
            label1 = new Label();
            dgvAppointment = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpEnd);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dtpStart);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(cbAppointmentStatus);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(14, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(1273, 168);
            panel1.TabIndex = 0;
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "dd/MM/yyyy";
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(214, 115);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(152, 30);
            dtpEnd.TabIndex = 37;
            dtpEnd.ValueChanged += dtpEnd_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(24, 83);
            label5.Name = "label5";
            label5.Size = new Size(85, 28);
            label5.TabIndex = 36;
            label5.Text = "Từ ngày";
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "dd/MM/yyyy";
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(24, 115);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(152, 30);
            dtpStart.TabIndex = 35;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(214, 83);
            label3.Name = "label3";
            label3.Size = new Size(99, 28);
            label3.TabIndex = 34;
            label3.Text = "Đến ngày";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(980, 83);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 33;
            label2.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(980, 115);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 32;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cbAppointmentStatus
            // 
            cbAppointmentStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbAppointmentStatus.Font = new Font("Segoe UI", 10F);
            cbAppointmentStatus.FormattingEnabled = true;
            cbAppointmentStatus.Location = new Point(678, 114);
            cbAppointmentStatus.Name = "cbAppointmentStatus";
            cbAppointmentStatus.Size = new Size(268, 31);
            cbAppointmentStatus.TabIndex = 31;
            cbAppointmentStatus.SelectedIndexChanged += cbAppointmentStatus_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(678, 83);
            label7.Name = "label7";
            label7.Size = new Size(102, 28);
            label7.TabIndex = 30;
            label7.Text = "Trạng thái";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(24, 18);
            label1.Name = "label1";
            label1.Size = new Size(226, 32);
            label1.TabIndex = 27;
            label1.Text = "LỊCH HẸN CỦA TÔI";
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
            dgvAppointment.Location = new Point(14, 182);
            dgvAppointment.MultiSelect = false;
            dgvAppointment.Name = "dgvAppointment";
            dgvAppointment.ReadOnly = true;
            dgvAppointment.RowHeadersVisible = false;
            dgvAppointment.RowHeadersWidth = 51;
            dgvAppointment.RowTemplate.Height = 38;
            dgvAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointment.Size = new Size(1273, 331);
            dgvAppointment.TabIndex = 6;
            // 
            // UC_Doctor_Appointment
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvAppointment);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Doctor_Appointment";
            Padding = new Padding(14);
            Size = new Size(1301, 527);
            Load += UC_Doctor_Appointment_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private TextBox txtSearch;
        private ComboBox cbAppointmentStatus;
        private Label label7;
        private Label label1;
        private DataGridView dgvAppointment;
        private DateTimePicker dtpEnd;
        private Label label5;
        private DateTimePicker dtpStart;
        private Label label3;
    }
}
