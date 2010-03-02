using System;
using System.Security.Cryptography;
using System.Text;

namespace AndyPike.Castlecasts.Website.Extensions
{
    public static class StringExtensions
    {
        public static string ToMD5(this string input)
        {
            if (input == string.Empty) return string.Empty;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

            var hashAsHex = new StringBuilder();
            Array.ForEach(hash, b => hashAsHex.Append(b.ToString("X2")));

            return hashAsHex.ToString();
        }
    }
}
