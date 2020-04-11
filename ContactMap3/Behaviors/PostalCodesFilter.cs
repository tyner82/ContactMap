using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactMap3.Behaviors
{
    public partial class FilterFunctions
    {
        public static string PostalCodesFilter(string message)
        {
            message = String.Join("", message.ToUpper().Split(" "[0]));
            string temp = message;
            List<char> mList = new List<char>(message.ToCharArray());
            if (message.Length > 3)
            {
                mList.Insert(3, " "[0]);
            }
            if (message.Length > 6)
            {
                mList.RemoveRange(7, mList.Count - 7);
            }
            message = new string(mList.ToArray());

            return message;
        }
        public static bool ValidLetter(char l)
        {
            return ((((int)l) > 64) && (((int)l) < 91));
        }

        public static bool MatchesPostalCode(string message)
        {
            message = String.Join("", message.ToUpper().Split(" "[0]));
            bool condition = true;
            for (int i = 0; i < message.Length; i++)
            {
                if (i % 2 == 0) condition = (condition && ValidLetter(message[i]));
                else condition = (condition && IsNum(message[i]));
            }
            return condition;
        }
    }
}
