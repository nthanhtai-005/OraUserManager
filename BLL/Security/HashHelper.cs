using System;
using System.Text;
using System.Security.Cryptography;

namespace BLL.Security
{
    public static class HashHelper
    {
        // Hàm tạo ra một chuỗi Salt ngẫu nhiên (sinh ra lúc tạo tài khoản mới)
        public static string GenerateSalt(int size = 16)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(size);
            return Convert.ToBase64String(saltBytes);
        }

        // Hàm băm Mật khẩu + Salt bằng SHA-256
        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Trộn Password và Salt lại với nhau
                string saltedPassword = password + salt;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}