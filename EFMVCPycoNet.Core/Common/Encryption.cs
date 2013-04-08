using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EFMVCPycoNet.Core.Common
{
    public static class Encryption
    {
        public static string MD5EncryptPassword(string password)
        {
            var encoding = new ASCIIEncoding();
            var bytes = encoding.GetBytes(password);
            var hashed = MD5.Create().ComputeHash(bytes);
            return Encoding.UTF8.GetString(hashed);
        }
    }
}
