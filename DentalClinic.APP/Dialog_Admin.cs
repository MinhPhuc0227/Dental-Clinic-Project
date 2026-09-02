using DentalClinic.BLL;
using DentalClinic.MODEL;
using System;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_Admin : Form
    {
        private readonly Account_BLL _bll = new Account_BLL();

        public Dialog_Admin()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;

            this.Text = "Tạo tài khoản Admin";

            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            // Vai trò: chỉ có Admin
            cbRole.DataSource = new[]
            {
                new
                {
                    Value = AccountRole.Admin,
                    Display = "Quản trị viên"
                }
            };

            cbRole.DisplayMember = "Display";
            cbRole.ValueMember = "Value";

            cbRole.SelectedIndex = 0;
            cbRole.Enabled = false;

            // Trạng thái
            cbStatus.DataSource = new[]
            {
                new
                {
                    Value = AccountStatus.Active,
                    Display = "Hoạt động"
                },
                new
                {
                    Value = AccountStatus.Inactive,
                    Display = "Ngừng hoạt động"
                },
                new
                {
                    Value = AccountStatus.Locked,
                    Display = "Đã khóa"
                }
            };

            cbStatus.DisplayMember = "Display";
            cbStatus.ValueMember = "Value";

            // Mặc định tài khoản mới là Hoạt động
            cbStatus.SelectedValue = AccountStatus.Active;
        }

        private void Dialog_Admin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

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

            var result = _bll.CreateAdmin(
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

        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }
    }
}