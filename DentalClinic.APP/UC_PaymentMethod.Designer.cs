namespace DentalClinic.App
{
    partial class UC_PaymentMethod
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
            dgvPaymentMethod = new DataGridView();
            panel1 = new Panel();
            label4 = new Label();
            cbSort = new ComboBox();
            label3 = new Label();
            cbStatus = new ComboBox();
            btAdd = new Button();
            label2 = new Label();
            label1 = new Label();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPaymentMethod).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPaymentMethod
            // 
            dgvPaymentMethod.AllowUserToAddRows = false;
            dgvPaymentMethod.AllowUserToDeleteRows = false;
            dgvPaymentMethod.AllowUserToOrderColumns = true;
            dgvPaymentMethod.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaymentMethod.BackgroundColor = Color.White;
            dgvPaymentMethod.BorderStyle = BorderStyle.None;
            dgvPaymentMethod.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPaymentMethod.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPaymentMethod.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPaymentMethod.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPaymentMethod.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPaymentMethod.Dock = DockStyle.Fill;
            dgvPaymentMethod.EnableHeadersVisualStyles = false;
            dgvPaymentMethod.GridColor = Color.DarkCyan;
            dgvPaymentMethod.Location = new Point(10, 149);
            dgvPaymentMethod.MultiSelect = false;
            dgvPaymentMethod.Name = "dgvPaymentMethod";
            dgvPaymentMethod.ReadOnly = true;
            dgvPaymentMethod.RowHeadersVisible = false;
            dgvPaymentMethod.RowHeadersWidth = 51;
            dgvPaymentMethod.RowTemplate.Height = 38;
            dgvPaymentMethod.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaymentMethod.Size = new Size(1206, 320);
            dgvPaymentMethod.TabIndex = 0;
            dgvPaymentMethod.CellContentClick += dgvPaymentMethod_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbSort);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(btAdd);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1206, 139);
            panel1.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(302, 56);
            label4.Name = "label4";
            label4.Size = new Size(84, 28);
            label4.TabIndex = 18;
            label4.Text = "Sắp xếp";
            // 
            // cbSort
            // 
            cbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSort.Font = new Font("Segoe UI", 10F);
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(302, 87);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(268, 31);
            cbSort.TabIndex = 17;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(614, 56);
            label3.Name = "label3";
            label3.Size = new Size(102, 28);
            label3.TabIndex = 16;
            label3.Text = "Trạng thái";
            // 
            // cbStatus
            // 
            cbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(614, 87);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(268, 31);
            cbStatus.TabIndex = 15;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // btAdd
            // 
            btAdd.BackColor = SystemColors.HotTrack;
            btAdd.FlatAppearance.BorderSize = 0;
            btAdd.FlatStyle = FlatStyle.Flat;
            btAdd.Font = new Font("Segoe UI Semibold", 10F);
            btAdd.ForeColor = Color.White;
            btAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btAdd.Location = new Point(21, 68);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(118, 49);
            btAdd.TabIndex = 3;
            btAdd.Text = "Thêm mới";
            btAdd.UseVisualStyleBackColor = false;
            btAdd.Click += btAdd_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(921, 56);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 2;
            label2.Text = "Tìm kiếm";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(21, 14);
            label1.Name = "label1";
            label1.Size = new Size(472, 32);
            label1.TabIndex = 1;
            label1.Text = "QUẢN LÝ PHƯƠNG THỨC THANH TOÁN";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(921, 87);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // UC_PaymentMethod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvPaymentMethod);
            Controls.Add(panel1);
            Name = "UC_PaymentMethod";
            Padding = new Padding(10);
            Size = new Size(1226, 479);
            Load += UC_Payment_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPaymentMethod).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPaymentMethod;
        private Panel panel1;
        private TextBox txtSearch;
        private Label label2;
        private Label label1;
        private Button btAdd;
        private Label label3;
        private ComboBox cbStatus;
        private Label label4;
        private ComboBox cbSort;
    }
}
