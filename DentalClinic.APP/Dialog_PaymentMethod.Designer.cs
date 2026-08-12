namespace DentalClinic.APP
{
    partial class Dialog_PaymentMethod
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
            txtPaymentMethodName = new TextBox();
            chkIsCash = new CheckBox();
            btSave = new Button();
            label2 = new Label();
            label3 = new Label();
            btCancel = new Button();
            txtDescription = new TextBox();
            cbStatus = new ComboBox();
            label4 = new Label();
            lbPaymentMethodId = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(14, 61);
            label1.Name = "label1";
            label1.Size = new Size(168, 28);
            label1.TabIndex = 0;
            label1.Text = "Tên phương thức";
            // 
            // txtPaymentMethodName
            // 
            txtPaymentMethodName.BorderStyle = BorderStyle.FixedSingle;
            txtPaymentMethodName.Font = new Font("Segoe UI", 12F);
            txtPaymentMethodName.Location = new Point(14, 101);
            txtPaymentMethodName.Name = "txtPaymentMethodName";
            txtPaymentMethodName.Size = new Size(378, 34);
            txtPaymentMethodName.TabIndex = 1;
            // 
            // chkIsCash
            // 
            chkIsCash.AutoSize = true;
            chkIsCash.Font = new Font("Segoe UI", 12F);
            chkIsCash.Location = new Point(14, 299);
            chkIsCash.Name = "chkIsCash";
            chkIsCash.Size = new Size(259, 32);
            chkIsCash.TabIndex = 3;
            chkIsCash.Text = "Thanh toán bằng tiền mặt";
            chkIsCash.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.DarkCyan;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(291, 419);
            btSave.Name = "btSave";
            btSave.Size = new Size(101, 40);
            btSave.TabIndex = 6;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(14, 351);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 4;
            label2.Text = "Trạng thái";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(14, 147);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 5;
            label3.Text = "Mô tả";
            // 
            // btCancel
            // 
            btCancel.AutoSize = true;
            btCancel.BackColor = Color.Red;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Segoe UI Semibold", 12F);
            btCancel.ForeColor = Color.White;
            btCancel.Location = new Point(184, 419);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 5;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(14, 192);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(378, 81);
            txtDescription.TabIndex = 2;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 12F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(122, 351);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(270, 36);
            cbStatus.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(14, 18);
            label4.Name = "label4";
            label4.Size = new Size(45, 28);
            label4.TabIndex = 7;
            label4.Text = "Mã:";
            // 
            // lbPaymentMethodId
            // 
            lbPaymentMethodId.AutoSize = true;
            lbPaymentMethodId.Font = new Font("Segoe UI Semibold", 12F);
            lbPaymentMethodId.ForeColor = Color.DarkCyan;
            lbPaymentMethodId.Location = new Point(65, 18);
            lbPaymentMethodId.Name = "lbPaymentMethodId";
            lbPaymentMethodId.Size = new Size(89, 28);
            lbPaymentMethodId.TabIndex = 8;
            lbPaymentMethodId.Text = "Tự động";
            // 
            // Dialog_PaymentMethod
            // 
            AcceptButton = btSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btCancel;
            ClientSize = new Size(404, 482);
            ControlBox = false;
            Controls.Add(lbPaymentMethodId);
            Controls.Add(label4);
            Controls.Add(cbStatus);
            Controls.Add(txtDescription);
            Controls.Add(btCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btSave);
            Controls.Add(chkIsCash);
            Controls.Add(txtPaymentMethodName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_PaymentMethod";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Phương thức thanh toán";
            Load += Dialog_PaymentMethod_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPaymentMethodName;
        private CheckBox chkIsCash;
        private Button btSave;
        private Label label2;
        private Label label3;
        private Button btCancel;
        private TextBox txtDescription;
        private ComboBox cbStatus;
        private Label label4;
        private Label lbPaymentMethodId;
    }
}