namespace DentalClinic.APP
{
    partial class Dialog_VisitHistory
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            dgvVisitHistory = new DataGridView();
            panel4 = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            panel5 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgvMedicine = new DataGridView();
            dgvService = new DataGridView();
            panel7 = new Panel();
            txtNote = new TextBox();
            txtConclusion = new TextBox();
            txtDiagnosis = new TextBox();
            lbExaminationDate = new Label();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel6 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitHistory).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvService).BeginInit();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1406, 64);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(292, 37);
            label1.TabIndex = 0;
            label1.Text = "LỊCH SỬ KHÁM BỆNH";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 74);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1406, 793);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvVisitHistory);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(415, 787);
            panel2.TabIndex = 0;
            // 
            // dgvVisitHistory
            // 
            dgvVisitHistory.AllowUserToAddRows = false;
            dgvVisitHistory.AllowUserToDeleteRows = false;
            dgvVisitHistory.AllowUserToOrderColumns = true;
            dgvVisitHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisitHistory.BackgroundColor = Color.White;
            dgvVisitHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVisitHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVisitHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVisitHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvVisitHistory.DefaultCellStyle = dataGridViewCellStyle2;
            dgvVisitHistory.Dock = DockStyle.Fill;
            dgvVisitHistory.EnableHeadersVisualStyles = false;
            dgvVisitHistory.GridColor = Color.DarkCyan;
            dgvVisitHistory.Location = new Point(0, 56);
            dgvVisitHistory.MultiSelect = false;
            dgvVisitHistory.Name = "dgvVisitHistory";
            dgvVisitHistory.ReadOnly = true;
            dgvVisitHistory.RowHeadersVisible = false;
            dgvVisitHistory.RowHeadersWidth = 51;
            dgvVisitHistory.RowTemplate.Height = 38;
            dgvVisitHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisitHistory.Size = new Size(415, 731);
            dgvVisitHistory.TabIndex = 8;
            dgvVisitHistory.CellClick += dgvVisitHistory_CellClick;
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(415, 56);
            panel4.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(11, 12);
            label3.Name = "label3";
            label3.Size = new Size(243, 28);
            label3.TabIndex = 2;
            label3.Text = "DANH SÁCH LẦN KHÁM";
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel6);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(424, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(979, 787);
            panel3.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(tableLayoutPanel2);
            panel5.Controls.Add(panel7);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 56);
            panel5.Name = "panel5";
            panel5.Size = new Size(979, 731);
            panel5.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(dgvMedicine, 0, 1);
            tableLayoutPanel2.Controls.Add(dgvService, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 202);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(979, 529);
            tableLayoutPanel2.TabIndex = 1;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkCyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMedicine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvMedicine.DefaultCellStyle = dataGridViewCellStyle4;
            dgvMedicine.Dock = DockStyle.Fill;
            dgvMedicine.EnableHeadersVisualStyles = false;
            dgvMedicine.GridColor = Color.DarkCyan;
            dgvMedicine.Location = new Point(3, 267);
            dgvMedicine.MultiSelect = false;
            dgvMedicine.Name = "dgvMedicine";
            dgvMedicine.ReadOnly = true;
            dgvMedicine.RowHeadersVisible = false;
            dgvMedicine.RowHeadersWidth = 51;
            dgvMedicine.RowTemplate.Height = 38;
            dgvMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicine.Size = new Size(973, 259);
            dgvMedicine.TabIndex = 10;
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.DarkCyan;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvService.DefaultCellStyle = dataGridViewCellStyle6;
            dgvService.Dock = DockStyle.Fill;
            dgvService.EnableHeadersVisualStyles = false;
            dgvService.GridColor = Color.DarkCyan;
            dgvService.Location = new Point(3, 3);
            dgvService.MultiSelect = false;
            dgvService.Name = "dgvService";
            dgvService.ReadOnly = true;
            dgvService.RowHeadersVisible = false;
            dgvService.RowHeadersWidth = 51;
            dgvService.RowTemplate.Height = 38;
            dgvService.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvService.Size = new Size(973, 258);
            dgvService.TabIndex = 9;
            // 
            // panel7
            // 
            panel7.Controls.Add(txtNote);
            panel7.Controls.Add(txtConclusion);
            panel7.Controls.Add(txtDiagnosis);
            panel7.Controls.Add(lbExaminationDate);
            panel7.Controls.Add(label8);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(label5);
            panel7.Controls.Add(label4);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(979, 202);
            panel7.TabIndex = 0;
            // 
            // txtNote
            // 
            txtNote.BackColor = Color.White;
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Location = new Point(120, 149);
            txtNote.Name = "txtNote";
            txtNote.ReadOnly = true;
            txtNote.Size = new Size(837, 30);
            txtNote.TabIndex = 22;
            // 
            // txtConclusion
            // 
            txtConclusion.BackColor = Color.White;
            txtConclusion.BorderStyle = BorderStyle.FixedSingle;
            txtConclusion.Location = new Point(120, 104);
            txtConclusion.Name = "txtConclusion";
            txtConclusion.ReadOnly = true;
            txtConclusion.Size = new Size(837, 30);
            txtConclusion.TabIndex = 21;
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.BackColor = Color.White;
            txtDiagnosis.BorderStyle = BorderStyle.FixedSingle;
            txtDiagnosis.Location = new Point(120, 59);
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.ReadOnly = true;
            txtDiagnosis.Size = new Size(837, 30);
            txtDiagnosis.TabIndex = 20;
            // 
            // lbExaminationDate
            // 
            lbExaminationDate.AutoSize = true;
            lbExaminationDate.Location = new Point(120, 21);
            lbExaminationDate.Name = "lbExaminationDate";
            lbExaminationDate.Size = new Size(55, 23);
            lbExaminationDate.TabIndex = 18;
            lbExaminationDate.Text = "label6";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10F);
            label8.ForeColor = Color.DarkCyan;
            label8.Location = new Point(11, 63);
            label8.Name = "label8";
            label8.Size = new Size(98, 23);
            label8.TabIndex = 16;
            label8.Text = "Chẩn đoán:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F);
            label7.ForeColor = Color.DarkCyan;
            label7.Location = new Point(11, 108);
            label7.Name = "label7";
            label7.Size = new Size(77, 23);
            label7.TabIndex = 15;
            label7.Text = "Kết luận:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F);
            label5.ForeColor = Color.DarkCyan;
            label5.Location = new Point(15, 153);
            label5.Name = "label5";
            label5.Size = new Size(73, 23);
            label5.TabIndex = 14;
            label5.Text = "Ghi chú:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(11, 21);
            label4.Name = "label4";
            label4.Size = new Size(103, 23);
            label4.TabIndex = 13;
            label4.Text = "Ngày khám:";
            // 
            // panel6
            // 
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(label2);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(979, 56);
            panel6.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(17, 12);
            label2.Name = "label2";
            label2.Size = new Size(237, 28);
            label2.TabIndex = 1;
            label2.Text = "THÔNG TIN LẦN KHÁM";
            // 
            // Dialog_VisitHistory
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1426, 877);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_VisitHistory";
            Padding = new Padding(10);
            ShowIcon = false;
            Load += Dialog_VisitHistory_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVisitHistory).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedicine).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvService).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private Panel panel6;
        private Panel panel5;
        private DataGridView dgvVisitHistory;
        private Label label3;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dgvMedicine;
        private DataGridView dgvService;
        private Panel panel7;
        private TextBox txtNote;
        private TextBox txtConclusion;
        private TextBox txtDiagnosis;
        private Label lbExaminationDate;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
    }
}