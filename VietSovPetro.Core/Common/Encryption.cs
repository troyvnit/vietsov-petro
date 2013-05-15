using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace VietSovPetro.Core.Common
{
    public static class Encryption
    {
        public static string MD5EncryptPassword(string password)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();

            byte[] bs = Encoding.UTF8.GetBytes(password);

            bs = x.ComputeHash(bs);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in bs)
            {

                sb.Append(b.ToString("x2").ToUpper());

            }

            return sb.ToString();
        }
    }
}
