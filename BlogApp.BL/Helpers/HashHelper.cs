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
<<<<<<< HEAD
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
=======
        public static bool VerifyPassword(string password, string storedHash)
        {
>>>>>>> 992ec70df5002e5ddb18cd9825de4e5b23c5103b
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
<<<<<<< HEAD
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return buffer3.SequenceEqual(buffer4);
        }
=======

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


>>>>>>> 992ec70df5002e5ddb18cd9825de4e5b23c5103b
    }

}
