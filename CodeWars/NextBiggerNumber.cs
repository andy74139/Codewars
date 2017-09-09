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
            
            var backDigitCounts = new [] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var lastDigit = -1;
            var frontNum = n;
            while (frontNum > 0)
            {
                var thisDigit = (int)(frontNum % 10);
                backDigitCounts[thisDigit]++;
                frontNum /= 10;

                if (thisDigit < lastDigit)
                {
                    // find smallest num which greater than thisDigit
                    var nextBiggerThisDigit = GetNextBiggerThisDigit(thisDigit, backDigitCounts);

                    // then, put digits in backDigitCounts from small to big
                    var backNum = GetBackNum(nextBiggerThisDigit, backDigitCounts);

                    return System.Convert.ToInt64(frontNum > 0 ? frontNum + backNum : backNum);
                }

                lastDigit = thisDigit;
            }
            return -1;
        }

        private static string GetBackNum(int nextBiggerThisDigit, IList<int> backDigitCounts)
        {
            var backNum = new StringBuilder(nextBiggerThisDigit.ToString());
            backDigitCounts[nextBiggerThisDigit]--;
            for (var digit = 0; digit < 10; digit++)
            {
                for (var i = 0; i < backDigitCounts[digit]; i++)
                    backNum.Append(digit);
            }
            return backNum.ToString();
        }

        private static int GetNextBiggerThisDigit(int thisDigit, IList<int> backDigitCounts)
        {
            var nextBiggerThisDigit = thisDigit + 1;
            while (backDigitCounts[nextBiggerThisDigit] == 0)
                nextBiggerThisDigit++;
            return nextBiggerThisDigit;
        }
    }

}
