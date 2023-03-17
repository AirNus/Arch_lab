using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Arch_lab.Crypto
{
    public class HashPassword
    {
        public static string GetHash(string password)
        {
            var passwordBytes = Encoding.Default.GetBytes(password);

            var hash = SHA256.Create().ComputeHash(passwordBytes);


            return BitConverter.ToString(hash).Replace("-","").ToLower();
        }
    }
}
