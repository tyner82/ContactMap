using System;
using System.Collections.Generic;

namespace ContactMap3.Behaviors
{
    public partial class FilterFunctions
    {
        public static string ZipCodesFilter(string message)
        {
            message = AsStrictNum(message);
            List<char> mList = new List<char>(message.ToCharArray());

            if (message.Length > 5)
            {
                mList.RemoveRange(5, mList.Count - 5);
                message = new string(mList.ToArray());
            }
            return message;
        }
    }
}
