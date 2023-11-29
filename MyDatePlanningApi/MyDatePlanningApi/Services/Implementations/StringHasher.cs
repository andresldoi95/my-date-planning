using MyDatePlanningApi.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MyDatePlanningApi.Services.Implementations
{
    public class StringHasher: IStringHasher
    {
        public string Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }
        public bool CheckPassword(string input, string hashedPassword)
        {
            var hashedInput = Hash(input);
            return hashedInput == hashedPassword;
        }
    }
}
