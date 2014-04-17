using System;
using System.Security.Cryptography;
using System.Text;

namespace Solyanka.Domain
{
    public static class CreatePassword
    {
        #region Api Methods

        public static string CreateRandomPassword(int passwordLength)
        {
            String allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];

            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];

            return new string(chars);
        }

        public static string GetHashPassword(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            SHA1CryptoServiceProvider CSP = new SHA1CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            String hash = String.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += String.Format("{0:x2}", b);

            return hash;
        }

        #endregion
    }
}