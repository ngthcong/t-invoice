using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TInvoiceWeb.Helpers
{
    public class Hashing
    {

        public static string HashingPassword(string clearText, string salt)
        {
            try
            {
                byte[] hashBytes = ComputeHash(salt + clearText);
                string hashValue = Convert.ToBase64String(hashBytes);
                return hashValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetRandomSalt()
        {
            Random random = new Random();
            int size = random.Next(16, 32);
            StringBuilder builder = new StringBuilder();

            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        // hashing
        public static byte[] ComputeHash(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (HashAlgorithm hash = new SHA384Managed())
            {
                return hash.ComputeHash(plainTextBytes);
            }
        }

    }
}
