using NuGet.Protocol;
using System.Security.Cryptography;
using System.Text;

namespace CodeCadetsAPI
{
    public static class Secrecy
    {
        public static string Hash(string data)
        {
            byte[] hash = Encoding.UTF8.GetBytes(data);

            using (SHA256 sha256 = SHA256.Create())
            {
                sha256.ComputeHash(hash);
                return Convert.ToBase64String(hash);
            }
            
        }
    }
}
