namespace DentalClinic.APP
{
    partial class UC_Patient
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
            label4 = new Label();
            cbSort = new ComboBox();
            label3 = new Label();
            txtSearch = new TextBox();
            btAdd = new Button();
            label1 = new Label();
            dgvPatient = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatient).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbSort);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btAdd);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 143);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(395, 57);
            label4.Name = "label4";
            label4.Size = new Size(84, 28);
            label4.TabIndex = 21;
            label4.Text = "Sắp xếp";
            // 
            // cbSort
            // 
            cbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSort.Font = new Font("Segoe UI", 10F);
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(395, 88);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(274, 31);
            cbSort.TabIndex = 20;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(704, 57);
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
            txtSearch.Location = new Point(704, 88);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 18;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btAdd
            // 
            btAdd.BackColor = SystemColors.HotTrack;
            btAdd.FlatAppearance.BorderSize = 0;
            btAdd.FlatStyle = FlatStyle.Flat;
            btAdd.Font = new Font("Segoe UI Semibold", 10F);
            btAdd.ForeColor = Color.White;
            btAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btAdd.Location = new Point(19, 72);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(125, 46);
            btAdd.TabIndex = 17;
            btAdd.Text = "Thêm mới";
            btAdd.UseVisualStyleBackColor = false;
            btAdd.Click += btAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(19, 21);
            label1.Name = "label1";
            label1.Size = new Size(352, 32);
            label1.TabIndex = 16;
            label1.Text = "QUẢN LÝ HỒ SƠ BỆNH NHÂN";
            // 
            // dgvPatient
            // 
            dgvPatient.AllowUserToAddRows = false;
            dgvPatient.AllowUserToDeleteRows = false;
            dgvPatient.AllowUserToOrderColumns = true;
            dgvPatient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatient.BackgroundColor = Color.White;
            dgvPatient.BorderStyle = BorderStyle.None;
            dgvPatient.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPatient.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPatient.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPatient.Dock = DockStyle.Fill;
            dgvPatient.EnableHeadersVisualStyles = false;
            dgvPatient.GridColor = Color.DarkCyan;
            dgvPatient.Location = new Point(10, 153);
            dgvPatient.MultiSelect = false;
            dgvPatient.Name = "dgvPatient";
            dgvPatient.ReadOnly = true;
            dgvPatient.RowHeadersVisible = false;
            dgvPatient.RowHeadersWidth = 51;
            dgvPatient.RowTemplate.Height = 38;
            dgvPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatient.Size = new Size(984, 393);
            dgvPatient.TabIndex = 6;
            dgvPatient.CellContentClick += dgvPatient_CellContentClick;
            // 
            // UC_Patient
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvPatient);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Patient";
            Padding = new Padding(10);
            Size = new Size(1004, 556);
            Load += UC_Patient_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatient).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvPatient;
        private Label label3;
        private TextBox txtSearch;
        private Button btAdd;
        private Label label1;
        private Label label4;
        private ComboBox cbSort;
    }
}
