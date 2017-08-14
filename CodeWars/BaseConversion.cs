using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public partial class Kata
    {
        public string Convert(string input, string source, string target)
        {
            var value = ConvertLong(input, source);
            return ConvertOutput(value, target);
        }

        private static string ConvertOutput(long value, string baseString)
        {
            if (value == 0)
                return baseString[0].ToString();

            var outputReverse = new StringBuilder();
            while (value > 0)
            {
                var v = (int) (value%baseString.Length);
                outputReverse.Append(baseString[v]);

                value /= baseString.Length;
            }

            var output = new StringBuilder();
            for (var i = outputReverse.Length - 1; i >= 0; i--)
                output.Append(outputReverse[i]);

            return output.ToString();
        }

        private long ConvertLong(string input, string baseString)
        {
            long value = 0;

            var dynamicMultiplyBase = Pow(baseString.Length, input.Length - 1);
            foreach (var c in input)
            {
                value += ConvertBaseValue(c, baseString)*dynamicMultiplyBase;
                dynamicMultiplyBase /= baseString.Length;
            }
            return value;
        }

        private long ConvertBaseValue(char c, string baseString)
        {
            for (var i = 0; i < baseString.Length; i++)
                if (c == baseString[i])
                    return i;
            throw new InvalidOperationException();
        }

        private long Pow(int @base, int exp)
        {
            long result = 1;
            for (var i = 0; i < exp; i++)
                result *= @base;
            return result;
        }
    }

}
