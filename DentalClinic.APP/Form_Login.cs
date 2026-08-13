using DentalClinic.App;
using DentalClinic.BLL;
using DentalClinic.DTO.Account;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Form_Login : Form
    {
        private readonly Account_BLL _accountBll = new Account_BLL();

        public Form_Login()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        // chkShowPassword
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        // Exit button
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Login button
        private void btLogin_Click(object sender, EventArgs e)
        {
            var loginDto = new LoginRequestDto
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            var result = _accountBll.Login(loginDto);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            OpenMainFormByRole(result.Data);
        }

        // Open form by role
        private void OpenMainFormByRole(AccountDto userSession)
        {
            Form? mainForm = null;

            switch (userSession.Role)
            {
                case AccountRole.Admin:
                    mainForm = new Form_Admin(); 
                    break;

                case AccountRole.Doctor:
                    mainForm = new Form_Doctor();
                    break;

                case AccountRole.Receptionist:
                    mainForm = new Form_Receptionist();
                    break;

                default:
                    MessageBox.Show("Vai trò của tài khoản không có quyền truy cập hệ thống này.", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Show();
                    return;
            }

            if (mainForm != null)
            {
                mainForm.FormClosed += (s, args) =>
                {
                    txtPassword.Clear();
                    this.Show();
                };

                mainForm.Show();
            }
        }
    }
}
