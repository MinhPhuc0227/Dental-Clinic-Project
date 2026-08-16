namespace DentalClinic.APP
{
    partial class UC_Receptionist_Invoice
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
            label1 = new Label();
            button1 = new Button();
            dgvInvoice = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(959, 92);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(22, 27);
            label1.Name = "label1";
            label1.Size = new Size(244, 32);
            label1.TabIndex = 13;
            label1.Text = "Thanh toán hóa đơn";
            // 
            // button1
            // 
            button1.Location = new Point(352, 27);
            button1.Name = "button1";
            button1.Size = new Size(165, 42);
            button1.TabIndex = 14;
            button1.Text = "Lập hóa đơn";
            button1.UseVisualStyleBackColor = true;
            // 
            // dgvInvoice
            // 
            dgvInvoice.AllowUserToAddRows = false;
            dgvInvoice.AllowUserToDeleteRows = false;
            dgvInvoice.AllowUserToOrderColumns = true;
            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoice.BackgroundColor = Color.White;
            dgvInvoice.BorderStyle = BorderStyle.None;
            dgvInvoice.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInvoice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvInvoice.DefaultCellStyle = dataGridViewCellStyle2;
            dgvInvoice.Dock = DockStyle.Fill;
            dgvInvoice.EnableHeadersVisualStyles = false;
            dgvInvoice.GridColor = Color.DarkCyan;
            dgvInvoice.Location = new Point(0, 92);
            dgvInvoice.MultiSelect = false;
            dgvInvoice.Name = "dgvInvoice";
            dgvInvoice.ReadOnly = true;
            dgvInvoice.RowHeadersVisible = false;
            dgvInvoice.RowHeadersWidth = 51;
            dgvInvoice.RowTemplate.Height = 38;
            dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoice.Size = new Size(959, 412);
            dgvInvoice.TabIndex = 6;
            // 
            // UC_Receptionist_Invoice
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvInvoice);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "UC_Receptionist_Invoice";
            Size = new Size(959, 504);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private DataGridView dgvInvoice;
    }
}
