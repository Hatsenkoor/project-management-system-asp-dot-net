using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
   public static class Encryption
    {
        public static String sign(String data, String secretKey)
        {
            UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secretKey);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(data);
            return Convert.ToBase64String(hmacsha256.ComputeHash(messageBytes));
        }
    }
}
