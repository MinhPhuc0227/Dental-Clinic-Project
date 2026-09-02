using DentalClinic.BLL;
using DentalClinic.MODEL;
using System;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_Admin : Form
    {
        private readonly Account_BLL _accountBLL =
            new Account_BLL();

        public Dialog_Admin()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
        }

        private void Dialog_Admin_Load(object sender, EventArgs e)
        {
            // Vai trò: chỉ có Admin
            cbRole.DataSource = new[]
            {
                new
                {
                    Value = AccountRole.Admin,
                    Text = "Quản trị viên"
                }
            };

            cbRole.DisplayMember = "Text";
            cbRole.ValueMember = "Value";
            cbRole.SelectedIndex = 0;
            cbRole.Enabled = false;

            // Trạng thái mặc định: Hoạt động
            cbStatus.DataSource = Enum.GetValues<AccountStatus>();
            cbStatus.SelectedItem = AccountStatus.Active;

            // Mật khẩu được che
            txtPassword.UseSystemPasswordChar = true;
        }

        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        private void btCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btSave_Click(
            object sender,
            EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra cơ bản
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên đăng nhập.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Vui lòng nhập mật khẩu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            var result =
                _accountBLL.CreateAdmin(
                    userName,
                    password);

            if (!result.IsSuccess)
            {
                MessageBox.Show(
                    result.Message,
                    "Không thể tạo tài khoản",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                result.Message,
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}