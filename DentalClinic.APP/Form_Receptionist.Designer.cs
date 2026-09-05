namespace DentalClinic.APP
{
    partial class Form_Receptionist
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Receptionist));
            btLogout = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            rbInvoiceList = new RadioButton();
            rbInvoice = new RadioButton();
            rbVisit = new RadioButton();
            rbWaitingQueue = new RadioButton();
            rbAppointment = new RadioButton();
            pnContent = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btLogout
            // 
            btLogout.BackColor = Color.White;
            btLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btLogout.Image = Properties.Resources.logout;
            btLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btLogout.Location = new Point(12, 10);
            btLogout.Margin = new Padding(4);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(156, 41);
            btLogout.TabIndex = 1;
            btLogout.Text = "Đăng Xuất";
            btLogout.TextAlign = ContentAlignment.MiddleRight;
            btLogout.UseVisualStyleBackColor = false;
            btLogout.Click += btLogout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkCyan;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1062, 56);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkCyan;
            panel2.Controls.Add(rbInvoiceList);
            panel2.Controls.Add(rbInvoice);
            panel2.Controls.Add(rbVisit);
            panel2.Controls.Add(rbWaitingQueue);
            panel2.Controls.Add(rbAppointment);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(10, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 489);
            panel2.TabIndex = 3;
            // 
            // rbInvoiceList
            // 
            rbInvoiceList.Appearance = Appearance.Button;
            rbInvoiceList.FlatAppearance.BorderSize = 0;
            rbInvoiceList.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbInvoiceList.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbInvoiceList.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbInvoiceList.FlatStyle = FlatStyle.Flat;
            rbInvoiceList.Font = new Font("Segoe UI Semibold", 12F);
            rbInvoiceList.ForeColor = Color.White;
            rbInvoiceList.Location = new Point(0, 224);
            rbInvoiceList.Name = "rbInvoiceList";
            rbInvoiceList.Size = new Size(200, 60);
            rbInvoiceList.TabIndex = 10;
            rbInvoiceList.Text = "Hóa Đơn";
            rbInvoiceList.UseVisualStyleBackColor = true;
            rbInvoiceList.CheckedChanged += rbInvoiceList_CheckedChanged;
            // 
            // rbInvoice
            // 
            rbInvoice.Appearance = Appearance.Button;
            rbInvoice.FlatAppearance.BorderSize = 0;
            rbInvoice.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbInvoice.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbInvoice.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbInvoice.FlatStyle = FlatStyle.Flat;
            rbInvoice.Font = new Font("Segoe UI Semibold", 12F);
            rbInvoice.ForeColor = Color.White;
            rbInvoice.Location = new Point(0, 168);
            rbInvoice.Name = "rbInvoice";
            rbInvoice.Size = new Size(200, 60);
            rbInvoice.TabIndex = 9;
            rbInvoice.Text = "Thanh Toán";
            rbInvoice.UseVisualStyleBackColor = true;
            rbInvoice.CheckedChanged += rbInvoice_CheckedChanged;
            // 
            // rbVisit
            // 
            rbVisit.Appearance = Appearance.Button;
            rbVisit.Checked = true;
            rbVisit.FlatAppearance.BorderSize = 0;
            rbVisit.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbVisit.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbVisit.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbVisit.FlatStyle = FlatStyle.Flat;
            rbVisit.Font = new Font("Segoe UI Semibold", 12F);
            rbVisit.ForeColor = Color.White;
            rbVisit.Location = new Point(0, 0);
            rbVisit.Name = "rbVisit";
            rbVisit.Size = new Size(200, 60);
            rbVisit.TabIndex = 8;
            rbVisit.TabStop = true;
            rbVisit.Text = "Tiếp Nhận";
            rbVisit.UseVisualStyleBackColor = true;
            rbVisit.CheckedChanged += rbVisit_CheckedChanged;
            // 
            // rbWaitingQueue
            // 
            rbWaitingQueue.Appearance = Appearance.Button;
            rbWaitingQueue.FlatAppearance.BorderSize = 0;
            rbWaitingQueue.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbWaitingQueue.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbWaitingQueue.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbWaitingQueue.FlatStyle = FlatStyle.Flat;
            rbWaitingQueue.Font = new Font("Segoe UI Semibold", 12F);
            rbWaitingQueue.ForeColor = Color.White;
            rbWaitingQueue.Location = new Point(0, 112);
            rbWaitingQueue.Name = "rbWaitingQueue";
            rbWaitingQueue.Size = new Size(200, 60);
            rbWaitingQueue.TabIndex = 5;
            rbWaitingQueue.Text = "Hàng Chờ";
            rbWaitingQueue.UseVisualStyleBackColor = true;
            rbWaitingQueue.CheckedChanged += rbWaitingQueue_CheckedChanged;
            // 
            // rbAppointment
            // 
            rbAppointment.Appearance = Appearance.Button;
            rbAppointment.FlatAppearance.BorderSize = 0;
            rbAppointment.FlatAppearance.CheckedBackColor = Color.LightSeaGreen;
            rbAppointment.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            rbAppointment.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            rbAppointment.FlatStyle = FlatStyle.Flat;
            rbAppointment.Font = new Font("Segoe UI Semibold", 12F);
            rbAppointment.ForeColor = Color.White;
            rbAppointment.Location = new Point(0, 56);
            rbAppointment.Name = "rbAppointment";
            rbAppointment.Size = new Size(200, 60);
            rbAppointment.TabIndex = 4;
            rbAppointment.Text = "Lịch Hẹn";
            rbAppointment.UseVisualStyleBackColor = true;
            rbAppointment.CheckedChanged += rbAppointment_CheckedChanged;
            // 
            // pnContent
            // 
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(210, 66);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(806, 489);
            pnContent.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkCyan;
            panel3.Controls.Add(btLogout);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(10, 555);
            panel3.Name = "panel3";
            panel3.Size = new Size(1062, 56);
            panel3.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkCyan;
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1016, 66);
            panel4.Name = "panel4";
            panel4.Size = new Size(56, 489);
            panel4.TabIndex = 6;
            // 
            // Form_Receptionist
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1082, 621);
            Controls.Add(pnContent);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form_Receptionist";
            Padding = new Padding(10);
            Text = "Nha Khoa Gia An - Lễ tân";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btLogout;
        private Panel panel1;
        private Panel panel2;
        private RadioButton rbAppointment;
        private RadioButton rbWaitingQueue;
        private Panel pnContent;
        private RadioButton rbVisit;
        private RadioButton rbInvoice;
        private RadioButton rbInvoiceList;
        private Panel panel3;
        private Panel panel4;
    }
}