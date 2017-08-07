using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public partial class Kata
    {
        //http://www.codewars.com/kata/string-average/train/csharp
        private static Dictionary<string, int> _StrToInt = new Dictionary<string, int>()
        {
            {"zero", 0},
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };

        private static Dictionary<int, string> _IntToStr = new Dictionary<int, string>()
        {
            {0, "zero"},
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"}
        };


        public static string AverageString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "n/a";

            var sum = 0;
            var numberStrs = str.Split(' ');
            foreach (var s in numberStrs)
            {
                var result = NumberStringToInt(s);
                if (result == -1)
                    return "n/a";
                sum += result;
            }

            return _IntToStr[sum / numberStrs.Length];
        }

        private static int NumberStringToInt(string str)
        {
            if (_StrToInt.ContainsKey(str))
                return _StrToInt[str];
            return -1;
        }
    }
}
