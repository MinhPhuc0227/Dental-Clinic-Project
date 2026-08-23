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
            dtpDate = new DateTimePicker();
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
            panel1.Controls.Add(dtpDate);
            panel1.Controls.Add(btCreateVisit);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1043, 153);
            panel1.TabIndex = 0;
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "dd/MM/yyyy";
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(344, 89);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(130, 30);
            dtpDate.TabIndex = 22;
            // 
            // btCreateVisit
            // 
            btCreateVisit.Location = new Point(30, 85);
            btCreateVisit.Name = "btCreateVisit";
            btCreateVisit.Size = new Size(253, 38);
            btCreateVisit.TabIndex = 21;
            btCreateVisit.Text = "Tiếp nhận bệnh nhân";
            btCreateVisit.UseVisualStyleBackColor = true;
            btCreateVisit.Click += btCreateVisit_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(609, 19);
            label3.Name = "label3";
            label3.Size = new Size(91, 28);
            label3.TabIndex = 19;
            label3.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(706, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 34);
            txtSearch.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(28, 16);
            label1.Name = "label1";
            label1.Size = new Size(255, 32);
            label1.TabIndex = 17;
            label1.Text = "Tiếp nhận bệnh nhân";
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
            dgvVisit.Location = new Point(10, 163);
            dgvVisit.MultiSelect = false;
            dgvVisit.Name = "dgvVisit";
            dgvVisit.ReadOnly = true;
            dgvVisit.RowHeadersVisible = false;
            dgvVisit.RowHeadersWidth = 51;
            dgvVisit.RowTemplate.Height = 38;
            dgvVisit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisit.Size = new Size(1043, 429);
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
            Size = new Size(1063, 602);
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
        private DateTimePicker dtpDate;
    }
}
