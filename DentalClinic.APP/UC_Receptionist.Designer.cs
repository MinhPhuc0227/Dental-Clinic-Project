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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dgvReceptionist = new DataGridView();
            label3 = new Label();
            txtSearch = new TextBox();
            btAdd = new Button();
            label1 = new Label();
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.DarkCyan;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvReceptionist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvReceptionist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvReceptionist.DefaultCellStyle = dataGridViewCellStyle6;
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
