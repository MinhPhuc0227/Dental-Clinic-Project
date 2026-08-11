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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dgvPatient = new DataGridView();
            label3 = new Label();
            txtSearch = new TextBox();
            btAdd = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatient).BeginInit();
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
            panel1.TabIndex = 0;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkCyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvPatient.DefaultCellStyle = dataGridViewCellStyle4;
            dgvPatient.Dock = DockStyle.Fill;
            dgvPatient.EnableHeadersVisualStyles = false;
            dgvPatient.GridColor = Color.DarkCyan;
            dgvPatient.Location = new Point(10, 85);
            dgvPatient.MultiSelect = false;
            dgvPatient.Name = "dgvPatient";
            dgvPatient.ReadOnly = true;
            dgvPatient.RowHeadersVisible = false;
            dgvPatient.RowHeadersWidth = 51;
            dgvPatient.RowTemplate.Height = 38;
            dgvPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatient.Size = new Size(984, 461);
            dgvPatient.TabIndex = 6;
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
            btAdd.Location = new Point(172, 14);
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
            label1.Size = new Size(135, 32);
            label1.TabIndex = 16;
            label1.Text = "Bệnh nhân";
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
    }
}
