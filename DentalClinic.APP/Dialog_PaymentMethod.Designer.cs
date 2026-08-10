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
            txtName = new TextBox();
            checkBoxIsCash = new CheckBox();
            btSave = new Button();
            label2 = new Label();
            label3 = new Label();
            btCancel = new Button();
            txtDescription = new TextBox();
            cbStatus = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(168, 28);
            label1.TabIndex = 0;
            label1.Text = "Tên phương thức";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(12, 55);
            txtName.Name = "txtName";
            txtName.Size = new Size(378, 34);
            txtName.TabIndex = 1;
            // 
            // checkBoxIsCash
            // 
            checkBoxIsCash.AutoSize = true;
            checkBoxIsCash.Font = new Font("Segoe UI", 12F);
            checkBoxIsCash.Location = new Point(12, 253);
            checkBoxIsCash.Name = "checkBoxIsCash";
            checkBoxIsCash.Size = new Size(259, 32);
            checkBoxIsCash.TabIndex = 2;
            checkBoxIsCash.Text = "Thanh toán bằng tiền mặt";
            checkBoxIsCash.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.BackColor = Color.DarkCyan;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI Semibold", 12F);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(289, 373);
            btSave.Name = "btSave";
            btSave.Size = new Size(101, 40);
            btSave.TabIndex = 3;
            btSave.Text = "Lưu";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(12, 305);
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
            label3.Location = new Point(12, 101);
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
            btCancel.Location = new Point(182, 373);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(101, 40);
            btCancel.TabIndex = 6;
            btCancel.Text = "Hủy";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(12, 146);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(378, 81);
            txtDescription.TabIndex = 7;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 12F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(120, 305);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(270, 36);
            cbStatus.TabIndex = 8;
            // 
            // Dialog_PaymentMethod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(404, 434);
            ControlBox = false;
            Controls.Add(cbStatus);
            Controls.Add(txtDescription);
            Controls.Add(btCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btSave);
            Controls.Add(checkBoxIsCash);
            Controls.Add(txtName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dialog_PaymentMethod";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private CheckBox checkBoxIsCash;
        private Button btSave;
        private Label label2;
        private Label label3;
        private Button btCancel;
        private TextBox txtDescription;
        private ComboBox cbStatus;
    }
}