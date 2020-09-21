using System;
using System.Collections.Generic;

namespace RandomPasscode.Models
{
    public class PasswordGen
    {
        private const string _chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random rand = new Random();
        private static int _count = 0;

        public PasswordGen()
        {
            _count += 1;
        }

        public string GetPassword(int length)
        {
            var charArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                charArray[i] = _chars[rand.Next(_chars.Length)];
            }

            return string.Join("", charArray);
            
        }

        public static int GetCount()
        {
            return _count;
        }
    }
}
