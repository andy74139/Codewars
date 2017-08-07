using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public partial class Kata
    {
        //https://www.codewars.com/kata/compute-the-largest-sum-of-all-contiguous-subsequences/train/csharp
        public static int LargestSum(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            var max = 0;
            var maxSums = new int[nums.Length];

            maxSums[0] = nums[0] > 0 ? nums[0] : 0;
            for (var i = 1; i < nums.Length; i++)
            {
                var r1 = nums[i];
                var r2 = maxSums[i - 1] + nums[i];
                maxSums[i] = Max(r1, r2, 0);

                if (maxSums[i] > max)
                    max = maxSums[i];
            }

            return max;
        }

        private static int Max(int a, int b, int c)
        {
            if (b > c)
                return a > b ? a : b;
            return a > c ? a : c;
        }
    }
}
