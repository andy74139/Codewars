using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public partial class Solution
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var orderedNums = nums.Select((x, i) => new NumOrder { num = x, index = i }).OrderBy(x => x, new NumOrderComparer()).ToList();

            for (var i = 0; i < orderedNums.Count - 1; i++)
            {
                if (orderedNums[i].num == orderedNums[i + 1].num && orderedNums[i + 1].index - orderedNums[i].index <= k)
                    return true;
            }

            return false;
        }
    }

    public class NumOrder
    {
        public int num;
        public int index;
    }

    public class NumOrderComparer : IComparer<NumOrder>
    {
        public int Compare(NumOrder x, NumOrder y)
        {
            return x.num != y.num ? x.num - y.num : x.index - y.index;
        }
    }

    public partial class Solution { }
}
