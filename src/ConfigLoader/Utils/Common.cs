using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigLoader.Utils
{
    internal class Common
    {
        //Remove Chars/Strings from a string object
        public static string RemoveFromString(string str, string[] n)
        {
            string line = str;
            for (int i = 0; i < n.Length; i++)
            {
                line = line.Replace(n[i], "");
            }
            return line;
        }
    }
}
