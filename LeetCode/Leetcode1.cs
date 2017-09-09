using System;
using System.Linq;

namespace LeetCode
{
    public struct ArrayOrder
    {
        public int Value;
        public int Order;
    }

    public partial class Solution
    {
        //Leetcode 1
        public int[] TwoSum(int[] nums, int target)
        {
            var numsWithOrder = nums.Select((v, i) => new ArrayOrder { Value = v, Order = i });
            var orderedNums = numsWithOrder.OrderBy(x => x.Value).ToArray();

            var leftIndex = 0;
            var rightIndex = orderedNums.Length - 1;
            while (rightIndex > leftIndex)
            {
                var leftNum = orderedNums[leftIndex];
                var rightNum = orderedNums[rightIndex];
                var sum = leftNum.Value + rightNum.Value;

                if (sum > target)
                    rightIndex--;
                else if (sum < target)
                    leftIndex++;
                else
                    return new[] { leftNum.Order, rightNum.Order };
            }

            throw new InvalidOperationException("No Answer");
        }

    }

    public partial class Solution { }
}
