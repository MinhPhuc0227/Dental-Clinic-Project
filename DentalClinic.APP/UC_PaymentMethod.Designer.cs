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
            dgvPaymentMethod.Location = new Point(10, 85);
            dgvPaymentMethod.MultiSelect = false;
            dgvPaymentMethod.Name = "dgvPaymentMethod";
            dgvPaymentMethod.ReadOnly = true;
            dgvPaymentMethod.RowHeadersVisible = false;
            dgvPaymentMethod.RowHeadersWidth = 51;
            dgvPaymentMethod.RowTemplate.Height = 38;
            dgvPaymentMethod.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaymentMethod.Size = new Size(1045, 384);
            dgvPaymentMethod.TabIndex = 0;
            dgvPaymentMethod.CellContentClick += dgvPaymentMethod_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btAdd);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1045, 75);
            panel1.TabIndex = 1;
            // 
            // btAdd
            // 
            btAdd.FlatAppearance.BorderSize = 0;
            btAdd.Image = APP.Properties.Resources.add;
            btAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btAdd.Location = new Point(320, 10);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(118, 49);
            btAdd.TabIndex = 3;
            btAdd.Text = "Thêm mới";
            btAdd.TextAlign = ContentAlignment.MiddleRight;
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(660, 17);
            label2.Name = "label2";
            label2.Size = new Size(91, 28);
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
            label1.Size = new Size(293, 32);
            label1.TabIndex = 1;
            label1.Text = "Phương thức thanh toán";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(757, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 34);
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
            Size = new Size(1065, 479);
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
    }
}
