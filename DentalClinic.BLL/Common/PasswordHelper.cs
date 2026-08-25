using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.BLL.Common
{
    public static class PasswordHelper
    {
        // Tạo mới hoặc đổi mật khẩu 
        public static string HashPassword(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        // Xác thực mật khẩu khi đăng nhập
        public static bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
        }
    }
}
