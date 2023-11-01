using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ShortUrl.Service
{
    public static class ShortUrl
    {
        private static int RevokePwdLength = 8;
        public static char[] alphaBet = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };
        public static string GetShorted(long id)
        {
            var rest = id;
            Stack<char> stack = new Stack<char>();
            StringBuilder result = new StringBuilder(0);
            while (rest != 0)
            {
                stack.Push(alphaBet[rest - (rest / 62) * 62]);
                rest = rest / 62;
            }
            for (; stack.Count() != 0;)
            {
                result.Append(stack.Pop());
            }
            return result.ToString();

        }

        static public string GenerateRevokePwd()
        {
            var randomNumber = new byte[32];
            string refreshToken = "";
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken = Convert.ToBase64String(randomNumber);
            }
            return refreshToken.Substring(0,RevokePwdLength);
        }
    }
}
