using DentalClinic.App;
using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly Account_BLL _accountBll;
        private readonly IServiceProvider _serviceProvider;

        public Form_Login(
    Account_BLL accountBll,
    IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _accountBll = accountBll;
            _serviceProvider = serviceProvider;

            txtPassword.UseSystemPasswordChar = true;
        }

        // chkShowPassword
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
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
            OpenMainFormByRole(result.Data); // Truyền result.Data vào đây
        }

        // Open form by role
        private void OpenMainFormByRole(AccountDto userSession)
        {
            Form? mainForm = null;

            // Lúc này userSession.Role là AccountRole enum nên switch case sẽ không bị lỗi nữa
            switch (userSession.Role)
            {
                case AccountRole.Admin:
                    mainForm = ActivatorUtilities.CreateInstance<Form_Admin>(
    _serviceProvider,
    userSession.AccountId);
                    break;

                case AccountRole.Doctor:
                    // Dùng AccountId và UserName có sẵn trong AccountDto truyền sang
                    mainForm = ActivatorUtilities.CreateInstance<Form_Doctor>(
    _serviceProvider,
    userSession.AccountId,
    userSession.UserName);
                    break;

                case AccountRole.Receptionist:
                    // Dùng AccountId và UserName có sẵn trong AccountDto truyền sang
                    mainForm = ActivatorUtilities.CreateInstance<Form_Receptionist>(
    _serviceProvider,
    userSession.AccountId,
    userSession.UserName);
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

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
