using System.Collections.Generic;
using System.Linq;

namespace ContactMap3.Behaviors
{
    public partial class FilterFunctions
    {


        static string AsStrictNum(string message)
        {
            char[] temp = new char[0];
            List<char> mList = new List<char>(message.ToCharArray());
            foreach (char c in mList)
            {
                temp = IsNum(c) ? temp.Concat(c.ToString()).ToArray() : temp;
            }
            return new string(temp);
        }

        public static string PhoneFilter(string message)
        {

            if (message == null) return "";
            else if ((message.Length < 5)|| ((message.Length < 7)&&message[0]=="+"[0])) return message;
            bool hasCountryCode = message[0] == "+"[0];
            int lenCountryCode = hasCountryCode ? 11 : 10;
            message = AsStrictNum(message);
            List<char> mList = new List<char>(message.ToCharArray());
            List<char> countryCode = new List<char>();

            if (message.Length > lenCountryCode)
            {
                mList.RemoveRange(lenCountryCode, mList.Count - lenCountryCode);
            }

            if (hasCountryCode && message.Length > 1)
            {
                countryCode = new List<char>(mList);
                mList.RemoveRange(0, 1);
                countryCode.RemoveRange(1, countryCode.Count - 1);
                countryCode.Insert(0, "+"[0]);
            }

            List<char> areaCode = new List<char>(mList);
            List<char> firstPart = new List<char>();
            List<char> secondPart = new List<char>();
            List<char> temp = new List<char>();

            if (message.Length > 3)
            {
                areaCode.RemoveRange(3, areaCode.Count - 3);
                firstPart = new List<char>(mList);
                firstPart.RemoveRange(0, 3);
            }
            if (message.Length > 6)
            {
                secondPart = new List<char>(firstPart);
                firstPart.RemoveRange(3, firstPart.Count - 3);
                secondPart.RemoveRange(0, 3);
            }
            temp.Add("("[0]);
            temp.InsertRange(1, areaCode);
            temp.Add(")"[0]);
            if (firstPart.Count > 0) temp.InsertRange(5, firstPart);
            if (secondPart.Count > 0)
            {
                temp.Add("-"[0]);
                temp.InsertRange(9, secondPart);
            }
            mList = new List<char>(temp);

            string a = new string(countryCode.ToArray());
            string b = new string(mList.ToArray());
            return (a + b);
        }

        /*
        public static string FuturePhoneFilter(string message)
        {

            static string AsStrictNum(string message)
            {
                char[] temp = new char[0];
                foreach (char c in message)
                {
                    temp = IsNum(c) ? temp.Concat(c.ToString()).ToArray() : temp;
                }
                return new string(temp);
            }
            bool hasCountryCode = message[0] == "+"[0];
            int lenCountryCode = hasCountryCode ? 11 : 10;
            message = AsStrictNum(message);
            if (message.Length > lenCountryCode)
            {
                message = message[..^(message.Length - lenCountryCode)];
            }
            char[] builder = new char[0];
            string countryCode = "";
            if (hasCountryCode && message.Length > 1)
            {
                countryCode = "+" + message[..^(message.Length - 1)];
                message = message[1..];
            }
            if (message.Length < 4)
            {
                message = ("(" + message + ")");
            }
            else if (message.Length < 6)
            {
                message = ("(" + message[..^(message.Length - 3)] + ")" + message[3..] + "-");
            }
            else
            {
                message = ("(" + message[..^(message.Length - 3)] + ")" + message[3..^(message.Length - 6)] + "-" + message[6..]);
            }
            return (countryCode + message);
        }*/
    }
}

