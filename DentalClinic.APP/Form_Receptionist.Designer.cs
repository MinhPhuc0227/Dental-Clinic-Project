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
            btLogout = new Button();
            SuspendLayout();
            // 
            // btLogout
            // 
            btLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btLogout.Font = new Font("Segoe UI", 12F);
            btLogout.Location = new Point(625, 369);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(120, 41);
            btLogout.TabIndex = 1;
            btLogout.Text = "Đăng xuất";
            btLogout.UseVisualStyleBackColor = true;
            btLogout.Click += btLogout_Click;
            // 
            // Form_Receptionist
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btLogout);
            Name = "Form_Receptionist";
            Text = "Form_Receptionist";
            ResumeLayout(false);
        }

        #endregion

        private Button btLogout;
    }
}