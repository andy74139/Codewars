using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    public partial class Kata
    {
        public static long NextBiggerNumber(long n)
        {
            if (n < 12) return -1;

            string numReversed = ReverseNum(n);
            for (var indexReversed = 0; indexReversed < numReversed.Length; indexReversed++)
            {
                var digit = numReversed[indexReversed];
                var lastDigit = indexReversed > 0 ? numReversed[indexReversed - 1] : '0';

                if (digit < lastDigit)
                    return GetResult(n, indexReversed, numReversed);
            }

            return -1;
        }

        private static long GetResult(long n, int indexReversed, string numReversed)
        {
            var frontUnchangePart = GetFrontUnchangePart(n, indexReversed + 1);
            var backChangePart = GetBackChangePart(numReversed, indexReversed);

            return CombineFrontAndBackPart(frontUnchangePart, backChangePart);
        }

        private static string GetBackChangePart(string numReversed, int indexReversed)
        {
            var digit = (int)char.GetNumericValue(numReversed, indexReversed);

            var backPartDigitCounts = GetBackPartDigitCounts(numReversed, indexReversed);
            var nextBiggerDigit = GetNextBiggerDigit(digit, backPartDigitCounts);
            backPartDigitCounts[nextBiggerDigit]--;

            return nextBiggerDigit + SmallestNum(backPartDigitCounts);
        }

        private static string GetFrontUnchangePart(long number, int removeDigitAmount)
        {
            for (var i = 0; i < removeDigitAmount; i++)
                number /= 10;
            return number.ToString();
        }

        private static string SmallestNum(IList<int> digitCounts)
        {
            var sb = new StringBuilder();
            for (var digit = 0; digit < 10; digit++)
            {
                for (var i = 0; i < digitCounts[digit]; i++)
                    sb.Append(digit);
            }
            return sb.ToString();
        }

        private static int GetNextBiggerDigit(int digit, IList<int> backPartDigitCounts)
        {
            var nextBiggerThisDigit = digit + 1;
            while (backPartDigitCounts[nextBiggerThisDigit] == 0)
                nextBiggerThisDigit++;
            return nextBiggerThisDigit;
        }

        // These functions also used in NextSmaller function

        //private static IList<int> GetBackPartDigitCounts(string numReversed, int iReversed)
        //{
        //    var digitCounts = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //    for (var i = 0; i <= iReversed; i++)
        //    {
        //        var digit = (int)char.GetNumericValue(numReversed, i);
        //        digitCounts[digit]++;
        //    }
        //    return digitCounts;
        //}

        //private static string ReverseNum(long n)
        //{
        //    var sb = new StringBuilder();
        //    var num = n.ToString();
        //    for (var i = num.Length - 1; i > -1; i--)
        //        sb.Append(num[i]);

        //    return sb.ToString();
        //}

        //private static long CombineFrontAndBackPart(string frontUnchangePart, string backChangePart)
        //{
        //    var result = frontUnchangePart != "0" ? frontUnchangePart + backChangePart : backChangePart;
        //    return System.Convert.ToInt64(result);
        //}
    }

}
