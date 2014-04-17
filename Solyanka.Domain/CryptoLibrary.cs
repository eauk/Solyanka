using System;
using System.Security.Cryptography;
using System.Text;

namespace Solyanka.Domain
{
    public static class CryptoLibrary
    {
        public static string Md5(string input)
        {
            MD5 md5 = MD5.Create();
            string hash = Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(input)));
            return hash;
        } 
    }
}