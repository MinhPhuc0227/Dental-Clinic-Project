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
            rbPermanent = new RadioButton();
            rbModifyMedicalRecord = new RadioButton();
            label5 = new Label();
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
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(109, 29);
            label1.Name = "label1";
            label1.Size = new Size(187, 32);
            label1.TabIndex = 13;
            label1.Text = "HỦY HÓA ĐƠN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(20, 118);
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
            label3.Location = new Point(20, 323);
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
            label4.Location = new Point(20, 376);
            label4.Name = "label4";
            label4.Size = new Size(142, 28);
            label4.TabIndex = 16;
            label4.Text = "Thời gian hủy:";
            // 
            // rbPermanent
            // 
            rbPermanent.AutoSize = true;
            rbPermanent.Font = new Font("Segoe UI", 10F);
            rbPermanent.Location = new Point(185, 119);
            rbPermanent.Name = "rbPermanent";
            rbPermanent.Size = new Size(214, 27);
            rbPermanent.TabIndex = 17;
            rbPermanent.TabStop = true;
            rbPermanent.Text = "Hủy hoàn toàn hóa đơn";
            rbPermanent.UseVisualStyleBackColor = true;
            // 
            // rbModifyMedicalRecord
            // 
            rbModifyMedicalRecord.AutoSize = true;
            rbModifyMedicalRecord.Font = new Font("Segoe UI", 10F);
            rbModifyMedicalRecord.Location = new Point(185, 166);
            rbModifyMedicalRecord.Name = "rbModifyMedicalRecord";
            rbModifyMedicalRecord.Size = new Size(212, 27);
            rbModifyMedicalRecord.TabIndex = 18;
            rbModifyMedicalRecord.TabStop = true;
            rbModifyMedicalRecord.Text = "Thay đổi thuốc/dịch vụ ";
            rbModifyMedicalRecord.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(185, 214);
            label5.Name = "label5";
            label5.Size = new Size(51, 23);
            label5.TabIndex = 19;
            label5.Text = "Khác:";
            // 
            // txtOtherReason
            // 
            txtOtherReason.BorderStyle = BorderStyle.FixedSingle;
            txtOtherReason.Location = new Point(185, 251);
            txtOtherReason.Name = "txtOtherReason";
            txtOtherReason.Size = new Size(208, 30);
            txtOtherReason.TabIndex = 20;
            // 
            // lbCancelledDate
            // 
            lbCancelledDate.AutoSize = true;
            lbCancelledDate.Font = new Font("Segoe UI", 10F);
            lbCancelledDate.Location = new Point(185, 379);
            lbCancelledDate.Name = "lbCancelledDate";
            lbCancelledDate.Size = new Size(111, 23);
            lbCancelledDate.TabIndex = 21;
            lbCancelledDate.Text = "thời gian hủy";
            // 
            // lbCancelledBy
            // 
            lbCancelledBy.AutoSize = true;
            lbCancelledBy.Font = new Font("Segoe UI", 10F);
            lbCancelledBy.Location = new Point(185, 326);
            lbCancelledBy.Name = "lbCancelledBy";
            lbCancelledBy.Size = new Size(87, 23);
            lbCancelledBy.TabIndex = 22;
            lbCancelledBy.Text = "người hủy";
            // 
            // btConfirm
            // 
            btConfirm.Location = new Point(252, 450);
            btConfirm.Name = "btConfirm";
            btConfirm.Size = new Size(141, 38);
            btConfirm.TabIndex = 23;
            btConfirm.Text = "Xác nhận Hủy";
            btConfirm.UseVisualStyleBackColor = true;
            btConfirm.Click += btConfirm_Click;
            // 
            // btClose
            // 
            btClose.Location = new Point(144, 450);
            btClose.Name = "btClose";
            btClose.Size = new Size(91, 38);
            btClose.TabIndex = 24;
            btClose.Text = "Hủy";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // Dialog_CancelInvoice
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(416, 518);
            Controls.Add(btClose);
            Controls.Add(btConfirm);
            Controls.Add(lbCancelledBy);
            Controls.Add(lbCancelledDate);
            Controls.Add(txtOtherReason);
            Controls.Add(label5);
            Controls.Add(rbModifyMedicalRecord);
            Controls.Add(rbPermanent);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_CancelInvoice";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Xác nhận hủy hóa đơn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RadioButton rbPermanent;
        private RadioButton rbModifyMedicalRecord;
        private Label label5;
        private TextBox txtOtherReason;
        private Label lbCancelledDate;
        private Label lbCancelledBy;
        private Button btConfirm;
        private Button btClose;
    }
}