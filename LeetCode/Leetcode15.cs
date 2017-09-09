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
            var orderedNums = nums.OrderBy(x => x).ToArray();
            return ThreeSumWithOrderedNums(orderedNums).ToList();
        }

        private static IEnumerable<IList<int>> ThreeSumWithOrderedNums(IReadOnlyList<int> orderedNums)
        {
            for (var leftIndex = 0; leftIndex < orderedNums.Count - 2; leftIndex++)
            {
                if (DuplicateWithPreviousIndex(orderedNums, leftIndex))
                    continue;

                var midIndex = leftIndex + 1;
                for (var rightIndex = orderedNums.Count - 1; rightIndex > midIndex; rightIndex--)
                {
                    if (DuplicateWithNextIndex(orderedNums, rightIndex))
                        continue;

                    var sumLeftRight = orderedNums[leftIndex] + orderedNums[rightIndex];
                    while (sumLeftRight + orderedNums[midIndex] < 0 && midIndex < rightIndex)
                        midIndex++;

                    if (midIndex < rightIndex && sumLeftRight + orderedNums[midIndex] == 0)
                        yield return new[] {orderedNums[leftIndex], orderedNums[midIndex], orderedNums[rightIndex]};
                }
            }
        }

        private static bool DuplicateWithNextIndex(IReadOnlyList<int> orderedNums, int index)
        {
            return index != orderedNums.Count - 1 && orderedNums[index] == orderedNums[index + 1];
        }

        private static bool DuplicateWithPreviousIndex(IReadOnlyList<int> orderedNums, int index)
        {
            return index != 0 && orderedNums[index] == orderedNums[index - 1];
        }


        /* Fast Non-Refactor Version
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
         */
    }

    public partial class Solution { }
}
