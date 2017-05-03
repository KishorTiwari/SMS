using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SMS.Data.Validations
{
    public static class Encryption
    {
        public static string SHA1(this string input)
        {
            byte[] hash;
            using(var sha1 = new SHA1CryptoServiceProvider())
            {
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
            }
            var sb = new StringBuilder();
            foreach (var b in hash) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }
    }
}
