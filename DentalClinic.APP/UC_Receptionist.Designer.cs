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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label3 = new Label();
            txtSearch = new TextBox();
            btAdd = new Button();
            label1 = new Label();
            dgvReceptionist = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceptionist).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btAdd);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 75);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(600, 24);
            label3.Name = "label3";
            label3.Size = new Size(91, 28);
            label3.TabIndex = 19;
            label3.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(697, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 34);
            txtSearch.TabIndex = 18;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btAdd
            // 
            btAdd.FlatAppearance.BorderSize = 0;
            btAdd.Image = Properties.Resources.add;
            btAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btAdd.Location = new Point(120, 13);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(140, 49);
            btAdd.TabIndex = 17;
            btAdd.Text = "Thêm mới";
            btAdd.TextAlign = ContentAlignment.MiddleRight;
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(19, 21);
            label1.Name = "label1";
            label1.Size = new Size(83, 32);
            label1.TabIndex = 16;
            label1.Text = "Lễ tân";
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReceptionist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReceptionist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvReceptionist.DefaultCellStyle = dataGridViewCellStyle2;
            dgvReceptionist.Dock = DockStyle.Fill;
            dgvReceptionist.EnableHeadersVisualStyles = false;
            dgvReceptionist.GridColor = Color.DarkCyan;
            dgvReceptionist.Location = new Point(10, 85);
            dgvReceptionist.MultiSelect = false;
            dgvReceptionist.Name = "dgvReceptionist";
            dgvReceptionist.ReadOnly = true;
            dgvReceptionist.RowHeadersVisible = false;
            dgvReceptionist.RowHeadersWidth = 51;
            dgvReceptionist.RowTemplate.Height = 38;
            dgvReceptionist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceptionist.Size = new Size(984, 461);
            dgvReceptionist.TabIndex = 6;
            dgvReceptionist.CellContentClick += dgvReceptionist_CellContentClick;
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
            Size = new Size(1004, 556);
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
    }
}
