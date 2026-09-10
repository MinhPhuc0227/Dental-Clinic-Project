namespace DentalClinic.APP
{
    partial class UC_Account
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
            cbStatus = new ComboBox();
            label2 = new Label();
            cbRole = new ComboBox();
            btCreateAdmin = new Button();
            label3 = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            dgvAccount = new DataGridView();
            labell = new Label();
            cbSort = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccount).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labell);
            panel1.Controls.Add(cbSort);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbStatus);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbRole);
            panel1.Controls.Add(btCreateAdmin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1442, 167);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(857, 69);
            label4.Name = "label4";
            label4.Size = new Size(102, 28);
            label4.TabIndex = 16;
            label4.Text = "Trạng thái";
            // 
            // cbStatus
            // 
            cbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(860, 101);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(268, 31);
            cbStatus.TabIndex = 15;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(554, 69);
            label2.Name = "label2";
            label2.Size = new Size(71, 28);
            label2.TabIndex = 14;
            label2.Text = "Vai trò";
            // 
            // cbRole
            // 
            cbRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbRole.Font = new Font("Segoe UI", 10F);
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(560, 100);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(268, 31);
            cbRole.TabIndex = 13;
            cbRole.SelectedIndexChanged += cbRole_SelectedIndexChanged;
            // 
            // btCreateAdmin
            // 
            btCreateAdmin.BackColor = SystemColors.HotTrack;
            btCreateAdmin.FlatAppearance.BorderSize = 0;
            btCreateAdmin.FlatStyle = FlatStyle.Flat;
            btCreateAdmin.Font = new Font("Segoe UI Semibold", 10F);
            btCreateAdmin.ForeColor = Color.White;
            btCreateAdmin.Location = new Point(19, 86);
            btCreateAdmin.Name = "btCreateAdmin";
            btCreateAdmin.Size = new Size(182, 45);
            btCreateAdmin.TabIndex = 12;
            btCreateAdmin.Text = "Tạo tài khoản Admin";
            btCreateAdmin.UseVisualStyleBackColor = false;
            btCreateAdmin.Click += btCreateAdmin_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(1160, 70);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 11;
            label3.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(1160, 101);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(19, 18);
            label1.Name = "label1";
            label1.Size = new Size(389, 32);
            label1.TabIndex = 8;
            label1.Text = "QUẢN LÝ TÀI KHOẢN HỆ THỐNG";
            // 
            // dgvAccount
            // 
            dgvAccount.AllowUserToAddRows = false;
            dgvAccount.AllowUserToDeleteRows = false;
            dgvAccount.AllowUserToOrderColumns = true;
            dgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccount.BackgroundColor = Color.White;
            dgvAccount.BorderStyle = BorderStyle.None;
            dgvAccount.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAccount.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAccount.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAccount.Dock = DockStyle.Fill;
            dgvAccount.EnableHeadersVisualStyles = false;
            dgvAccount.GridColor = Color.DarkCyan;
            dgvAccount.Location = new Point(10, 177);
            dgvAccount.MultiSelect = false;
            dgvAccount.Name = "dgvAccount";
            dgvAccount.ReadOnly = true;
            dgvAccount.RowHeadersVisible = false;
            dgvAccount.RowHeadersWidth = 51;
            dgvAccount.RowTemplate.Height = 38;
            dgvAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccount.Size = new Size(1442, 369);
            dgvAccount.TabIndex = 4;
            dgvAccount.CellContentClick += dgvAccount_CellContentClick;
            // 
            // labell
            // 
            labell.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labell.AutoSize = true;
            labell.Font = new Font("Segoe UI Semibold", 12F);
            labell.ForeColor = Color.DarkCyan;
            labell.Location = new Point(260, 70);
            labell.Name = "labell";
            labell.Size = new Size(84, 28);
            labell.TabIndex = 18;
            labell.Text = "Sắp xếp";
            // 
            // cbSort
            // 
            cbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSort.Font = new Font("Segoe UI", 10F);
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(260, 101);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(268, 31);
            cbSort.TabIndex = 17;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // UC_Account
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvAccount);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Account";
            Padding = new Padding(10);
            Size = new Size(1462, 556);
            Load += UC_Account_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvAccount;
        private Label label3;
        private TextBox txtSearch;
        private Label label1;
        private Button btCreateAdmin;
        private Label label2;
        private ComboBox cbRole;
        private Label label4;
        private ComboBox cbStatus;
        private Label labell;
        private ComboBox cbSort;
    }
}
