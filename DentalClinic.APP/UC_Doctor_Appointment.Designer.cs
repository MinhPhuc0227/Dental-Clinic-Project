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
            label2 = new Label();
            txtSearch = new TextBox();
            cbAppointmentStatus = new ComboBox();
            label7 = new Label();
            dtpAppointmentDate = new DateTimePicker();
            label4 = new Label();
            label1 = new Label();
            dgvAppointment = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(cbAppointmentStatus);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dtpAppointmentDate);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(14, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(1037, 146);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(616, 66);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 33;
            label2.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(624, 97);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 32;
            // 
            // cbAppointmentStatus
            // 
            cbAppointmentStatus.Font = new Font("Segoe UI", 10F);
            cbAppointmentStatus.FormattingEnabled = true;
            cbAppointmentStatus.Location = new Point(357, 97);
            cbAppointmentStatus.Name = "cbAppointmentStatus";
            cbAppointmentStatus.Size = new Size(200, 31);
            cbAppointmentStatus.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(351, 66);
            label7.Name = "label7";
            label7.Size = new Size(102, 28);
            label7.TabIndex = 30;
            label7.Text = "Trạng thái";
            // 
            // dtpAppointmentDate
            // 
            dtpAppointmentDate.CustomFormat = "dd/MM/yyyy";
            dtpAppointmentDate.Font = new Font("Segoe UI", 10F);
            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.Location = new Point(146, 98);
            dtpAppointmentDate.Name = "dtpAppointmentDate";
            dtpAppointmentDate.Size = new Size(138, 30);
            dtpAppointmentDate.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(140, 66);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 28;
            label4.Text = "Ngày";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(394, 18);
            label1.Name = "label1";
            label1.Size = new Size(288, 32);
            label1.TabIndex = 27;
            label1.Text = "LỊCH HẸN TRONG NGÀY";
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
            dgvAppointment.Location = new Point(14, 160);
            dgvAppointment.MultiSelect = false;
            dgvAppointment.Name = "dgvAppointment";
            dgvAppointment.ReadOnly = true;
            dgvAppointment.RowHeadersVisible = false;
            dgvAppointment.RowHeadersWidth = 51;
            dgvAppointment.RowTemplate.Height = 38;
            dgvAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointment.Size = new Size(1037, 353);
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
            Size = new Size(1065, 527);
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
        private DateTimePicker dtpAppointmentDate;
        private Label label4;
        private Label label1;
        private DataGridView dgvAppointment;
    }
}
