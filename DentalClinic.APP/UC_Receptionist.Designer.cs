namespace DentalClinic.APP
{
    partial class UC_Receptionist
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label2 = new Label();
            cbStatus = new ComboBox();
            label3 = new Label();
            txtSearch = new TextBox();
            btAdd = new Button();
            label1 = new Label();
            dgvReceptionist = new DataGridView();
            label4 = new Label();
            cbSort = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceptionist).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbSort);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btAdd);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1265, 147);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(638, 61);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 21;
            label2.Text = "Trạng thái";
            // 
            // cbStatus
            // 
            cbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(638, 92);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(268, 31);
            cbStatus.TabIndex = 20;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(967, 62);
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
            txtSearch.Location = new Point(967, 93);
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
            btAdd.Location = new Point(19, 74);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(122, 49);
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
            label1.Size = new Size(288, 32);
            label1.TabIndex = 16;
            label1.Text = "QUẢN LÝ HỒ SƠ LỄ TÂN";
            // 
            // dgvReceptionist
            // 
            dgvReceptionist.AllowUserToAddRows = false;
            dgvReceptionist.AllowUserToDeleteRows = false;
            dgvReceptionist.AllowUserToOrderColumns = true;
            dgvReceptionist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceptionist.BackgroundColor = Color.White;
            dgvReceptionist.BorderStyle = BorderStyle.None;
            dgvReceptionist.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReceptionist.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkCyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvReceptionist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvReceptionist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvReceptionist.DefaultCellStyle = dataGridViewCellStyle4;
            dgvReceptionist.Dock = DockStyle.Fill;
            dgvReceptionist.EnableHeadersVisualStyles = false;
            dgvReceptionist.GridColor = Color.DarkCyan;
            dgvReceptionist.Location = new Point(10, 157);
            dgvReceptionist.MultiSelect = false;
            dgvReceptionist.Name = "dgvReceptionist";
            dgvReceptionist.ReadOnly = true;
            dgvReceptionist.RowHeadersVisible = false;
            dgvReceptionist.RowHeadersWidth = 51;
            dgvReceptionist.RowTemplate.Height = 38;
            dgvReceptionist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceptionist.Size = new Size(1265, 389);
            dgvReceptionist.TabIndex = 6;
            dgvReceptionist.CellContentClick += dgvReceptionist_CellContentClick;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(320, 62);
            label4.Name = "label4";
            label4.Size = new Size(84, 28);
            label4.TabIndex = 23;
            label4.Text = "Sắp xếp";
            // 
            // cbSort
            // 
            cbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSort.Font = new Font("Segoe UI", 10F);
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(320, 92);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(268, 31);
            cbSort.TabIndex = 22;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // UC_Receptionist
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvReceptionist);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Receptionist";
            Padding = new Padding(10);
            Size = new Size(1285, 556);
            Load += UC_Receptionist_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceptionist).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvReceptionist;
        private Label label3;
        private TextBox txtSearch;
        private Button btAdd;
        private Label label1;
        private Label label2;
        private ComboBox cbStatus;
        private Label label4;
        private ComboBox cbSort;
    }
}
