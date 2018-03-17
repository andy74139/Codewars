using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    public partial class Kata
    {
        /// <summary>
        /// Algorithm: From ten digit to the greatest digit of the number, 
        /// find the first one where the digit greater than its last digit (e.g. 51324, hundred digit is the digit, due to 3 > 2.)
        /// Then, using the digits from the digit to unit digit, take next smaller digit to the position, and biggest number using last digits followed.
        /// For example: 81624
        /// The first digit who greater than its last digit is hundred digit 6.
        /// Next, take the next smaller digit in 624, which is 4.
        /// Then, get the greatest number using last digits, which is 26.
        /// So, the result combines from 81, 4, 26 -> result is 81426.
        /// </summary>
        public static long NextSmaller(long n)
        {
            if (n < 12) return -1;

            string numReversed = ReverseNum(n);
            for (var indexReversed = 1; indexReversed < numReversed.Length; indexReversed++)
            {
                var digit = numReversed[indexReversed];
                var lastDigit = indexReversed > 0 ? numReversed[indexReversed - 1] : '0';

                if (digit > lastDigit)
                {
                    var result = GetResultSmaller(n, indexReversed, numReversed);
                    return IsSameLength(n, result) ? result : -1;
                }
            }

            return -1;
        }

        private static bool IsSameLength(long n, long result)
        {
            return result.ToString().Length == n.ToString().Length;
        }

        private static long GetResultSmaller(long n, int indexReversed, string numReversed)
        {
            var frontUnchangedPart = GetFrontUnchangedPart(n, indexReversed + 1);
            var backChangePart = GetBackChangePartSmaller(numReversed, indexReversed);

            return CombineFrontAndBackPart(frontUnchangedPart, backChangePart);
        }

        private static long CombineFrontAndBackPart(string frontUnchangedPart, string backChangePart)
        {
            var result = frontUnchangedPart != "0" ? frontUnchangedPart + backChangePart : backChangePart;
            return System.Convert.ToInt64(result);
        }

        private static string GetBackChangePartSmaller(string numReversed, int indexReversed)
        {
            var digit = (int)char.GetNumericValue(numReversed, indexReversed);

            var backPartDigitCounts = GetBackPartDigitCounts(numReversed, indexReversed);
            var nextSmallerDigit = GetNextSmallerDigit(digit, backPartDigitCounts);
            backPartDigitCounts[nextSmallerDigit]--;

            return nextSmallerDigit + BiggestNum(backPartDigitCounts);
        }

        private static IList<int> GetBackPartDigitCounts(string numReversed, int iReversed)
        {
            var digitCounts = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (var i = 0; i <= iReversed; i++)
            {
                var digit = (int)char.GetNumericValue(numReversed, i);
                digitCounts[digit]++;
            }
            return digitCounts;
        }

        private static string GetFrontUnchangedPart(long number, int removeDigitAmount)
        {
            for (var i = 0; i < removeDigitAmount; i++)
                number /= 10;
            return number.ToString();
        }

        private static string BiggestNum(IList<int> digitCounts)
        {
            var sb = new StringBuilder();
            for (var digit = 9; digit > -1; digit--)
            {
                for (var i = 0; i < digitCounts[digit]; i++)
                    sb.Append(digit);
            }
            return sb.ToString();
        }

        private static int GetNextSmallerDigit(int digit, IList<int> backPartDigitCounts)
        {
            var nextSmallerThisDigit = digit - 1;
            while (backPartDigitCounts[nextSmallerThisDigit] == 0)
                nextSmallerThisDigit--;
            return nextSmallerThisDigit;
        }

        private static string ReverseNum(long n)
        {
            var sb = new StringBuilder();
            var num = n.ToString();
            for (var i = num.Length - 1; i > -1; i--)
                sb.Append(num[i]);

            return sb.ToString();
        }
    }
}