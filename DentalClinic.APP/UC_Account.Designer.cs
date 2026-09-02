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
            btCreateAdmin = new Button();
            label3 = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            dgvAccount = new DataGridView();
            cbRole = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccount).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbRole);
            panel1.Controls.Add(btCreateAdmin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 130);
            panel1.TabIndex = 0;
            // 
            // btCreateAdmin
            // 
            btCreateAdmin.Font = new Font("Segoe UI", 10F);
            btCreateAdmin.Location = new Point(19, 68);
            btCreateAdmin.Name = "btCreateAdmin";
            btCreateAdmin.Size = new Size(182, 45);
            btCreateAdmin.TabIndex = 12;
            btCreateAdmin.Text = "Tạo tài khoản Admin";
            btCreateAdmin.UseVisualStyleBackColor = true;
            btCreateAdmin.Click += btCreateAdmin_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(613, 84);
            label3.Name = "label3";
            label3.Size = new Size(80, 23);
            label3.TabIndex = 11;
            label3.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(699, 79);
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
            label1.Location = new Point(313, 16);
            label1.Name = "label1";
            label1.Size = new Size(324, 32);
            label1.TabIndex = 8;
            label1.Text = "Quản lý tài khoản hệ thống";
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
            dgvAccount.Location = new Point(10, 140);
            dgvAccount.MultiSelect = false;
            dgvAccount.Name = "dgvAccount";
            dgvAccount.ReadOnly = true;
            dgvAccount.RowHeadersVisible = false;
            dgvAccount.RowHeadersWidth = 51;
            dgvAccount.RowTemplate.Height = 38;
            dgvAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccount.Size = new Size(984, 406);
            dgvAccount.TabIndex = 4;
            dgvAccount.CellContentClick += dgvAccount_CellContentClick;
            // 
            // cbRole
            // 
            cbRole.Font = new Font("Segoe UI", 10F);
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(363, 78);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(186, 31);
            cbRole.TabIndex = 13;
            cbRole.SelectedIndexChanged += cbRole_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(293, 84);
            label2.Name = "label2";
            label2.Size = new Size(64, 23);
            label2.TabIndex = 14;
            label2.Text = "Vai trò:";
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
            Size = new Size(1004, 556);
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
    }
}
