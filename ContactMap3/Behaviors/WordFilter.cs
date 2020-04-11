using System;
namespace ContactMap3.Behaviors
{
    public partial class FilterFunctions
    {

        public static string WordFilter(string message)
        {
            string filter = "";
            char prev = " "[0];
            foreach (char l in message)
            {
                if (IsNum(l) || ValidLetter(l) || l == " "[0] || NotEscape(l, prev)) filter += l;
                prev = l;
            }
            return filter;
        }
    }
}
