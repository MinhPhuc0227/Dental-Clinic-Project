namespace DentalClinic.APP
{
    partial class Dialog_CancelInvoice
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtOtherReason = new TextBox();
            lbCancelledDate = new Label();
            lbCancelledBy = new Label();
            btConfirm = new Button();
            btClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(178, 21);
            label1.Name = "label1";
            label1.Size = new Size(367, 37);
            label1.TabIndex = 13;
            label1.Text = "THÔNG TIN HỦY HÓA ĐƠN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(23, 128);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 14;
            label2.Text = "Lý do hủy:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(311, 85);
            label3.Name = "label3";
            label3.Size = new Size(113, 28);
            label3.TabIndex = 15;
            label3.Text = "Người hủy:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(23, 83);
            label4.Name = "label4";
            label4.Size = new Size(142, 28);
            label4.TabIndex = 16;
            label4.Text = "Thời gian hủy:";
            // 
            // txtOtherReason
            // 
            txtOtherReason.BorderStyle = BorderStyle.FixedSingle;
            txtOtherReason.Location = new Point(21, 182);
            txtOtherReason.Multiline = true;
            txtOtherReason.Name = "txtOtherReason";
            txtOtherReason.Size = new Size(654, 131);
            txtOtherReason.TabIndex = 3;
            // 
            // lbCancelledDate
            // 
            lbCancelledDate.AutoSize = true;
            lbCancelledDate.Font = new Font("Segoe UI", 10F);
            lbCancelledDate.Location = new Point(168, 86);
            lbCancelledDate.Name = "lbCancelledDate";
            lbCancelledDate.Size = new Size(22, 23);
            lbCancelledDate.TabIndex = 21;
            lbCancelledDate.Text = "...";
            // 
            // lbCancelledBy
            // 
            lbCancelledBy.AutoSize = true;
            lbCancelledBy.Font = new Font("Segoe UI", 10F);
            lbCancelledBy.Location = new Point(423, 88);
            lbCancelledBy.Name = "lbCancelledBy";
            lbCancelledBy.Size = new Size(22, 23);
            lbCancelledBy.TabIndex = 22;
            lbCancelledBy.Text = "...";
            // 
            // btConfirm
            // 
            btConfirm.BackColor = Color.FromArgb(0, 184, 148);
            btConfirm.FlatAppearance.BorderSize = 0;
            btConfirm.FlatStyle = FlatStyle.Flat;
            btConfirm.Font = new Font("Segoe UI Semibold", 10F);
            btConfirm.ForeColor = Color.White;
            btConfirm.Location = new Point(534, 338);
            btConfirm.Name = "btConfirm";
            btConfirm.Size = new Size(141, 38);
            btConfirm.TabIndex = 23;
            btConfirm.Text = "Xác nhận Hủy";
            btConfirm.UseVisualStyleBackColor = false;
            btConfirm.Click += btConfirm_Click;
            // 
            // btClose
            // 
            btClose.BackColor = Color.Red;
            btClose.FlatAppearance.BorderSize = 0;
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI Semibold", 10F);
            btClose.ForeColor = Color.White;
            btClose.Location = new Point(426, 338);
            btClose.Name = "btClose";
            btClose.Size = new Size(91, 38);
            btClose.TabIndex = 24;
            btClose.Text = "Hủy";
            btClose.UseVisualStyleBackColor = false;
            btClose.Click += btClose_Click;
            // 
            // Dialog_CancelInvoice
            // 
            AcceptButton = btConfirm;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btClose;
            ClientSize = new Size(701, 423);
            Controls.Add(btClose);
            Controls.Add(btConfirm);
            Controls.Add(lbCancelledBy);
            Controls.Add(lbCancelledDate);
            Controls.Add(txtOtherReason);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_CancelInvoice";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtOtherReason;
        private Label lbCancelledDate;
        private Label lbCancelledBy;
        private Button btConfirm;
        private Button btClose;
    }
}