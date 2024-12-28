using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Helpers
{
    public static class HashHelper
    {
        
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (storedHash == null)
            {
                throw new ArgumentNullException("storedHash");
            }

            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[0x10];
            byte[] storedPasswordHash = new byte[0x20];

            Buffer.BlockCopy(hashBytes, 1, salt, 0, 0x10);
            Buffer.BlockCopy(hashBytes, 0x11, storedPasswordHash, 0, 0x20);

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt, 1000))
            {
                byte[] computedHash = bytes.GetBytes(0x20);
                return computedHash.SequenceEqual(storedPasswordHash);
            }
        }


    }

}
