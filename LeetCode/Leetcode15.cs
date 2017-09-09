using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public partial class Solution
    {
        //Leetcode 15
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            var orderedNums = nums.OrderBy(x => x).ToArray();

            for (var leftIndex = 0; leftIndex < orderedNums.Length - 2; leftIndex++)
            {
                if (leftIndex != 0 && orderedNums[leftIndex] == orderedNums[leftIndex - 1]) continue;
                var midIndex = leftIndex + 1;
                for (var rightIndex = orderedNums.Length - 1; rightIndex > midIndex; rightIndex--)
                {
                    if (rightIndex != orderedNums.Length - 1 && orderedNums[rightIndex] == orderedNums[rightIndex + 1]) continue;

                    var sumLeftRight = orderedNums[leftIndex] + orderedNums[rightIndex];
                    while (sumLeftRight + orderedNums[midIndex] < 0 && midIndex < rightIndex) midIndex++;
                    if (midIndex < rightIndex && sumLeftRight + orderedNums[midIndex] == 0)
                        result.Add(new[] { orderedNums[leftIndex], orderedNums[midIndex], orderedNums[rightIndex] });
                }
            }
            return result;
        }

    }

    public partial class Solution { }
}
