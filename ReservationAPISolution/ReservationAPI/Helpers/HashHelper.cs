using System.Security.Cryptography;
using System.Text;

namespace ReservationAPI.Helpers
{
    public static class HashHelper
    {
        private static readonly string _salt = "ymbjxenohhmvohuadbkz";
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltBytes = Encoding.UTF8.GetBytes(_salt);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPasswordBytes = new byte[saltBytes.Length + passwordBytes.Length];
                Array.Copy(saltBytes, saltedPasswordBytes, saltBytes.Length);
                Array.Copy(passwordBytes, 0, saltedPasswordBytes, saltBytes.Length, passwordBytes.Length);

                byte[] hashedBytes = sha256.ComputeHash(saltedPasswordBytes);
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string computedHash = HashPassword(password);
            return computedHash == hashedPassword;
        }
    }
}
