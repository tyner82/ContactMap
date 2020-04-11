using System;
namespace ContactMap3.Behaviors
{
    public delegate string Filter(string message);
    public partial class FilterFunctions
    {
        public static bool IsNum(char c)
        {
            int strInt = (int)c;
            return (strInt >= 48 & strInt <= 57);
        }

        public static bool ValidLetter(char l)
        {
            return ((((int)l) > 64) && (((int)l) < 91) || (((int)l) > 96) && (((int)l) < 123));
        }
        public static bool NotEscape(char l, char prev)
        {
            return (((int)l == 44 || (int)l == 46 || (int)l == 32) && !((int)prev == 32 || (int)prev == 44 || (int)prev == 46));
        }

    }
}
