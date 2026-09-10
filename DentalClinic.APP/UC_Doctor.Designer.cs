namespace DentalClinic.APP
{
    partial class UC_Doctor
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
            label4 = new Label();
            cbSort = new ComboBox();
            label2 = new Label();
            cbStatus = new ComboBox();
            label3 = new Label();
            txtSearch = new TextBox();
            btAdd = new Button();
            label1 = new Label();
            dgvDoctor = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoctor).BeginInit();
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
            panel1.Size = new Size(1259, 148);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(337, 64);
            label4.Name = "label4";
            label4.Size = new Size(84, 28);
            label4.TabIndex = 25;
            label4.Text = "Sắp xếp";
            // 
            // cbSort
            // 
            cbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSort.Font = new Font("Segoe UI", 10F);
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(337, 94);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(274, 31);
            cbSort.TabIndex = 24;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(652, 62);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 19;
            label2.Text = "Trạng thái";
            // 
            // cbStatus
            // 
            cbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(650, 93);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(274, 31);
            cbStatus.TabIndex = 18;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(963, 63);
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
            txtSearch.Location = new Point(963, 94);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(274, 30);
            txtSearch.TabIndex = 14;
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
            btAdd.Location = new Point(19, 76);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(118, 49);
            btAdd.TabIndex = 13;
            btAdd.Text = "Thêm mới";
            btAdd.UseVisualStyleBackColor = false;
            btAdd.Click += btAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(19, 20);
            label1.Name = "label1";
            label1.Size = new Size(282, 32);
            label1.TabIndex = 12;
            label1.Text = "QUẢN LÝ HỒ SƠ BÁC SĨ";
            // 
            // dgvDoctor
            // 
            dgvDoctor.AllowUserToAddRows = false;
            dgvDoctor.AllowUserToDeleteRows = false;
            dgvDoctor.AllowUserToOrderColumns = true;
            dgvDoctor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoctor.BackgroundColor = Color.White;
            dgvDoctor.BorderStyle = BorderStyle.None;
            dgvDoctor.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDoctor.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkCyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDoctor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDoctor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvDoctor.DefaultCellStyle = dataGridViewCellStyle4;
            dgvDoctor.Dock = DockStyle.Fill;
            dgvDoctor.EnableHeadersVisualStyles = false;
            dgvDoctor.GridColor = Color.DarkCyan;
            dgvDoctor.Location = new Point(10, 158);
            dgvDoctor.MultiSelect = false;
            dgvDoctor.Name = "dgvDoctor";
            dgvDoctor.ReadOnly = true;
            dgvDoctor.RowHeadersVisible = false;
            dgvDoctor.RowHeadersWidth = 51;
            dgvDoctor.RowTemplate.Height = 38;
            dgvDoctor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctor.Size = new Size(1259, 388);
            dgvDoctor.TabIndex = 5;
            dgvDoctor.CellContentClick += dgvDoctor_CellContentClick;
            // 
            // UC_Doctor
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvDoctor);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Doctor";
            Padding = new Padding(10);
            Size = new Size(1279, 556);
            Load += UC_Doctor_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoctor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvDoctor;
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
