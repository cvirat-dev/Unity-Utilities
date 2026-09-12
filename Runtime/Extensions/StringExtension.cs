using System.Collections;
using System.Collections.Generic;

namespace UUP.Extensions
{
    public static class StringExtension
    {
        public static bool IsNumeric(this string str)
        {
            float output;
            return float.TryParse(str, out output);
        }

        public static string RemoveSpaces(this string str)
        {
            return str.Replace(" ", "");
        }

        public static string ReplaceCharAtIndex(this string str, int index, char newChar)
        {
            char[] charArray = str.ToCharArray();
            charArray[index] = newChar;
            return new string(charArray);
        }

        public static string AddQuotes(this string str)
        {
            return "\"" + str + "\"";
        }

        public static string RemoveQuotes(this string str)
        {
            return str.Replace("\"", "");
        }
    }
}
