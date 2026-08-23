namespace DentalClinic.APP
{
    partial class UC_Receptionist_WaitingQueue
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
            label3 = new Label();
            txtSearch = new TextBox();
            cbStatus = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            cbDoctor = new ComboBox();
            dtpDate = new DateTimePicker();
            label1 = new Label();
            dgvWaitingQueue = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaitingQueue).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cbDoctor);
            panel1.Controls.Add(dtpDate);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(998, 153);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(286, 24);
            label3.Name = "label3";
            label3.Size = new Size(91, 28);
            label3.TabIndex = 30;
            label3.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(383, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 34);
            txtSearch.TabIndex = 29;
            // 
            // cbStatus
            // 
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(711, 68);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(200, 31);
            cbStatus.TabIndex = 28;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(603, 68);
            label7.Name = "label7";
            label7.Size = new Size(102, 28);
            label7.TabIndex = 27;
            label7.Text = "Trạng thái";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F);
            label6.ForeColor = Color.DarkCyan;
            label6.Location = new Point(263, 84);
            label6.Name = "label6";
            label6.Size = new Size(63, 28);
            label6.TabIndex = 26;
            label6.Text = "Bác sĩ";
            // 
            // cbDoctor
            // 
            cbDoctor.Font = new Font("Segoe UI", 10F);
            cbDoctor.FormattingEnabled = true;
            cbDoctor.Location = new Point(332, 87);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(190, 31);
            cbDoctor.TabIndex = 25;
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "dd/MM/yyyy";
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(52, 88);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(138, 30);
            dtpDate.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(33, 23);
            label1.Name = "label1";
            label1.Size = new Size(192, 32);
            label1.TabIndex = 13;
            label1.Text = "Hàng chờ khám";
            // 
            // dgvWaitingQueue
            // 
            dgvWaitingQueue.AllowUserToAddRows = false;
            dgvWaitingQueue.AllowUserToDeleteRows = false;
            dgvWaitingQueue.AllowUserToOrderColumns = true;
            dgvWaitingQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWaitingQueue.BackgroundColor = Color.White;
            dgvWaitingQueue.BorderStyle = BorderStyle.None;
            dgvWaitingQueue.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvWaitingQueue.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvWaitingQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvWaitingQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvWaitingQueue.DefaultCellStyle = dataGridViewCellStyle2;
            dgvWaitingQueue.Dock = DockStyle.Fill;
            dgvWaitingQueue.EnableHeadersVisualStyles = false;
            dgvWaitingQueue.GridColor = Color.DarkCyan;
            dgvWaitingQueue.Location = new Point(10, 163);
            dgvWaitingQueue.MultiSelect = false;
            dgvWaitingQueue.Name = "dgvWaitingQueue";
            dgvWaitingQueue.ReadOnly = true;
            dgvWaitingQueue.RowHeadersVisible = false;
            dgvWaitingQueue.RowHeadersWidth = 51;
            dgvWaitingQueue.RowTemplate.Height = 38;
            dgvWaitingQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWaitingQueue.Size = new Size(998, 386);
            dgvWaitingQueue.TabIndex = 6;
            // 
            // UC_Receptionist_WaitingQueue
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvWaitingQueue);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Receptionist_WaitingQueue";
            Padding = new Padding(10);
            Size = new Size(1018, 559);
            Load += UC_Receptionist_WaitingQueue_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaitingQueue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DateTimePicker dtpDate;
        private ComboBox cbStatus;
        private Label label7;
        private Label label6;
        private ComboBox cbDoctor;
        private DataGridView dgvWaitingQueue;
        private Label label3;
        private TextBox txtSearch;
    }
}
