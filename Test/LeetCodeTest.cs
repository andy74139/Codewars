using System;
using System.Collections;
using System.Collections.Generic;
using LeetCode;
using M4Lib;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class LeetCodeTest
    {
        [TestCase(new[] {2, 7, 11, 15}, 9, ExpectedResult = new[] {0, 1})]
        [TestCase(new[] {15, 2, 5, 11, 7}, 9, ExpectedResult = new[] {1, 4})]
        public int[] Leetcode1(int[] nums, int target)
        {
            return new Solution().TwoSum(nums, target);
        }

        private IEnumerable<TestCaseData> TestDataFor174()
        {
            return new[]
            {
                new TestCaseData(new [,]{{-10}}, 11).SetName("OneRoomHasDemon_ShouldHas11"), 
                new TestCaseData(new [,]{{0}}, 1).SetName("OneRoomHasNothing_ShouldHas1"), 
                new TestCaseData(new [,]{{15}}, 1).SetName("OneRoomHasOrb_ConsiderGainHpWithoutLoss_ShouldHas1"), 
                new TestCaseData(new [,]{{-2, -6}, {-5, 1}, {-10, -5}}, 12).SetName("MultipleRoomsToFindMinLoss_ShouldHas12"), 
                new TestCaseData(new [,]{{-2, -6}, {-5, 1}, {-10, 50}}, 8).SetName("MultipleRoomsToFindMinLoss_ConsiderNotDieInMiddle_ShouldHas8"), 
                new TestCaseData(new [,]{{0,-1,3,-100},{0,0,0,-1},{-100,-100,-1,0}}, 2).SetName("RecordMinTotalLossForEachRoom_ShouldHas2"), 
                new TestCaseData(new [,]{{0,-1,3,-100},{0,0,0,0},{-100,-100,0,0}}, 1).SetName("RecordMinMaxLossForEachRoom_ShouldHas1"), 
                new TestCaseData(new [,]{{1,-3,3},{0,-2,0},{-3,-3,-3}}, 3).SetName("TestCase"), 
            };
        }

        [TestCaseSource("TestDataFor174")]
        public void Leetcode174Test(int[,] dungeon, int expected )
        {
            var target = new Solution();

            var actual = target.CalculateMinimumHP(dungeon);
            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestCase("()", ExpectedResult = true)]
        [TestCase("()[]{}", ExpectedResult = true)]
        [TestCase("(]", ExpectedResult = false)]
        [TestCase("([)]", ExpectedResult = false)]
        [TestCase("(", ExpectedResult = false)]
        [TestCase("]", ExpectedResult = false)]
        public bool Leetcode20Test(string s )
        {
            var target = new Solution();

            var actual = target.IsValid(s);
            return actual;
        }

        [Ignore]
        [TestCase(new[] { 3, 3, 3 }, ExpectedResult = false, TestName = "AllSelfLoop_ShouldFalse")]
        [TestCase(new[] { 1, -1 }, ExpectedResult = false, TestName = "HasDiffDirectionLoop_ShouldFalse")]
        [TestCase(new[] { 1, 1, 1 }, ExpectedResult = true, TestName = "AllCircularLoop_ShouldTrue")]
        [TestCase(new[] { 2, 1, 1, 2, 2 }, ExpectedResult = true, TestName = "HasLoopAndOthersGoToTheLoop_ShouldTrue")]
        [TestCase(new[] { 2, -1, 1, 2, -2 }, ExpectedResult = true, TestName = "HasLoopAndOthersGoToTheLoopInDiffDirection_ShouldTrue")]
        [TestCase(new[] {-1,-1,  3}, ExpectedResult = false, TestName = "HasSelfLoopAndOthersGoToTheLoopInDiffDirection_ShouldFalse")]
        [TestCase(new[] { 1, 1, 1, 8 }, ExpectedResult = false, TestName = "HasSelfLoopAndOthersGoToTheLoop_ShouldFalse")]
        [TestCase(new[] {1, 6, -1, 1, 5, 2}, ExpectedResult = true, TestName = "HasLoopAndSelfLoopAndOthersGoToSelfLoop_ShouldTrue")]
        [TestCase(new[] {1, 6, -1, 1, -1, 2}, ExpectedResult = false, TestName = "HasDiffDirectionLoopAndSelfLoop_ShouldFalse")]
        [TestCase(new[] {-5, -1, -2, -3, -8, -7}, ExpectedResult = true, TestName = "HasBackwardLoop_ShouldTrue")]
        public bool Leetcode457Test(int[] nums)
        {
            var target = new Solution();

            var actual = target.CircularArrayLoop(nums);
            return actual;
        }

        [Ignore]
        [TestCase(new[] { 197, 130, 1 }, ExpectedResult = true)]
        [TestCase(new[] { 235, 140, 4 }, ExpectedResult = false)]
        [TestCase(new int[] {  }, ExpectedResult = true)]
        [TestCase(new[] { 127 }, ExpectedResult = true)]
        [TestCase(new[] { 0 }, ExpectedResult = true)]
        [TestCase(new[] { 130 }, ExpectedResult = false)]
        public bool Leetcode393Test(int[] data)
        {
            var target = new Solution();

            var actual = target.ValidUtf8(data);
            return actual;
        }

        [Ignore]
        [TestCase("WRRBBW", "RB", ExpectedResult = -1)]
        [TestCase("WWRRBBWW", "WRBRW", ExpectedResult = 2)]
        [TestCase("G", "GGGGG", ExpectedResult = 2)]
        [TestCase("RBYYBBRRB", "YRBGB", ExpectedResult = 3)]
        [TestCase("RYWWYYWYYR", "GRY", ExpectedResult = 2)]
        //[TestCase("RRWWRRBBRR", "WB", ExpectedResult = 2)]
        public int Leetcode488Test(string board, string hand )
        {
            var target = new Solution();

            var actual = target.FindMinStep(board, hand);

            return actual;
        }

        private IEnumerable<TestCaseData> TestDataFor39()
        {
            return new[]
            {
                new TestCaseData(new[] {2, 3, 6, 7}, 7, new[] {new[] {7}, new[] {2, 2, 3}}).SetName("NormalCase"),
                new TestCaseData(new[] {2, 3, 6, 7}, 1, new int[][] {}).SetName("EmptyCase"),
                new TestCaseData(new[] {7, 3, 2, 6}, 7, new[] {new[] {7}, new[] {2, 2, 3}}).SetName("RandomOrderCase"),
                new TestCaseData(new[] {1, 2}, 4, new[] {new[] {2, 2}, new []{ 1, 1, 2}, new []{1, 1, 1, 1}}).SetName("MayDuplicateCase"),
                new TestCaseData(new[] {1, 2}, 1, new[] {new[] {1}}).SetName("OneCase"),
            };
        }

        [Ignore]
        [Test]
        [TestCaseSource("TestDataFor39")]
        public void LeetCode39Test(int[] candidates, int target, int[][] expected)
        {
            var actaul = new Solution().CombinationSum(candidates, target);

            CollectionAssert.AreEquivalent(expected, actaul);
        }

        [Ignore]
        [TestCase(3, new[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
        [TestCase(2, new[] { "(())","()()"})]
        [TestCase(1, new[] { "()" })]
        [TestCase(0, new string[] {})]
        public void LeetCode22Test(int n, string[] expected)
        {
            var actaul = new Solution().GenerateParenthesis(n);
            CollectionAssert.AreEquivalent(expected, actaul);
        }

        [Ignore]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void LeetCode51Test(int n)
        {
            var actaul = new Solution().SolveNQueens(n);
            var expected = new List<List<string>>();

            CollectionAssert.AreEquivalent(expected, actaul);
        }

        [Ignore]
        [TestCase(new int[] {  }, ExpectedResult = 0)]
        [TestCase(new[] { 5 }, ExpectedResult = 1)]
        [TestCase(new[] { 5, 5, 5, 5 }, ExpectedResult = 16)]
        //[TestCase(new[] { 5, 5, 5, 5, 9, 9, 9, 9, 9 }, ExpectedResult = 41)]
        //[TestCase(new[] { 1, 3, 2, 2, 2, 3, 4, 3, 1 }, ExpectedResult = 23)]
        //[TestCase(new[] { 1, 1, 2, 1, 2, 2 }, ExpectedResult = 14)]
        //[TestCase(new[] { 1, 2, 3, 1, 2, 3, 3 }, ExpectedResult = 13)]
        //[TestCase(new[] { 1, 2, 2, 1, 2, 2, 1 }, ExpectedResult = 21)]
        public int LeetCode546Test(int[] boxes)
        {
            var actaul = new Solution().RemoveBoxes(boxes);
            return actaul;
        }

        [Ignore]
        [TestCase("abbbba", "a**a*?", ExpectedResult = false)]
        [TestCase("aabddffgggkllmmm", "aab?d*ffggg***kllmmm", ExpectedResult = true)]
        [TestCase("aabcdviksejffggghhhhhvjjekjjjjklmm", "aab?d*ffggg***kllmmm", ExpectedResult = false)]
        public bool LeetCode44Test(string str, string wm)
        {
            var actaul = new Leetcode44().IsMatch(str, wm);
            return actaul;
        }

        [Ignore]
        [TestCase("aabc", "abc", ExpectedResult = false, TestName = "Leetcode10_RE_LackFirstCharInRegExp_ShouldNotMatch")]
        [TestCase("aabc", "aab", ExpectedResult = false, TestName = "Leetcode10_RE_LackLastCharInRegExp_ShouldNotMatch")]
        [TestCase("aabc", "aac", ExpectedResult = false, TestName = "Leetcode10_RE_LackMiddleCharInRegExp_ShouldNotMatch")]
        [TestCase("aabc", "aabc", ExpectedResult = true, TestName = "Leetcode10_RE_ExactString_ShouldMatch")]
        [TestCase("", "a*", ExpectedResult = true, TestName = "Leetcode10_RE_OneStarAndEmptyString_ShouldMatch")]
        [TestCase("a", "a*", ExpectedResult = true, TestName = "Leetcode10_RE_OneStarAndOneWordString_ShouldMatch")]
        [TestCase("aaaaaa", "a*", ExpectedResult = true, TestName = "Leetcode10_RE_OneStarAndMultipleSameWordsString_ShouldMatch")]
        [TestCase("aabaaaa", "a*", ExpectedResult = false, TestName = "Leetcode10_RE_OneStarAndHasWrongCharStringn_ShouldNotMatch")]
        [TestCase("", "a*b*", ExpectedResult = true, TestName = "Leetcode10_RE_MultipleStarAndEmptyString_ShouldMatch")]
        [TestCase("aaaa", "a*b*", ExpectedResult = true, TestName = "Leetcode10_RE_MultipleStarAndMultipleSameWordsStringOfFirstStar_ShouldMatch")]
        [TestCase("bbbb", "a*b*", ExpectedResult = true, TestName = "Leetcode10_RE_MultipleStarAndMultipleSameWordsStringOfSecondStar_ShouldMatch")]
        [TestCase("aabbb", "a*b*", ExpectedResult = true, TestName = "Leetcode10_RE_MultipleStarAndMultipleSameWordsStringOfAllStars_ShouldMatch")]
        [TestCase("ab", "a*b*", ExpectedResult = true, TestName = "Leetcode10_RE_MultipleStarAndOneWordStringOfAllStars_ShouldMatch")]
        [TestCase("a", "a*b*", ExpectedResult = true, TestName = "Leetcode10_RE_MultipleStarAndOneWordStringOfFirstStar_ShouldMatch")]
        [TestCase("b", "a*b*", ExpectedResult = true, TestName = "Leetcode10_RE_MultipleStarAndOneWordStringOfSecondStar_ShouldMatch")]
        [TestCase("caabbb", "a*b*", ExpectedResult = false, TestName = "Leetcode10_RE_MultipleStarAndMultipleSameWordsStringOfAllStarsAndWrongWordAtFirst_ShouldNotMatch")]
        [TestCase("acabbb", "a*b*", ExpectedResult = false, TestName = "Leetcode10_RE_MultipleStarAndMultipleSameWordsStringOfAllStarsAndWrongWordInFirstStar_ShouldNotMatch")]
        [TestCase("aacbbb", "a*b*", ExpectedResult = false, TestName = "Leetcode10_RE_MultipleStarAndMultipleSameWordsStringOfAllStarsAndWrongWordBetweenFirstStarAndSecondStar_ShouldNotMatch")]
        [TestCase("aabcbb", "a*b*", ExpectedResult = false, TestName = "Leetcode10_RE_MultipleStarAndMultipleSameWordsStringOfAllStarsAndWrongWordInSecondStar_ShouldNotMatch")]
        [TestCase("aabbbc", "a*b*", ExpectedResult = false, TestName = "Leetcode10_RE_MultipleStarAndMultipleSameWordsStringOfAllStarsAndWrongWordAtLast_ShouldNotMatch")]
        [TestCase("aabeffhhi", "aabc*d*effg*hhi", ExpectedResult = true)]
        [TestCase("aabcdeffghhi", "aabc*d*effg*hhi", ExpectedResult = true)]
        [TestCase("aabcccdddddeffgggggghhi", "aabc*d*effg*hhi", ExpectedResult = true)]
        [TestCase("abcccdddddeffgggggghhi", "aabc*d*effg*hhi", ExpectedResult = false)]
        [TestCase("aabcccdddddefgggggghhi", "aabc*d*effg*hhi", ExpectedResult = false)]
        [TestCase("aabcccdddddeffgggggghi", "aabc*d*effg*hhi", ExpectedResult = false)]
        [TestCase("acb", "a.b", ExpectedResult = true)]
        [TestCase("aab", "a.b", ExpectedResult = true)]
        [TestCase("aaa", "a*.b*", ExpectedResult = true)]
        [TestCase("aaabb", "a*.b*", ExpectedResult = true)]
        [TestCase("bb", "a*.b*", ExpectedResult = true)]
        [TestCase("aabb", ".*b", ExpectedResult = true)]
        [TestCase("aabbbcccd", ".*b.*c.*", ExpectedResult = true)]
        [TestCase("aabbbdd", ".*b.*c.*", ExpectedResult = false)]
        [TestCase("aabcdeffggghijkllmmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = true)]
        [TestCase("aabcdffgggkllmmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = true)]
        [TestCase("aabddffgggkllmmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = true)]
        [TestCase("aabcdejivmifffgggvuidkkllmmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = true)]
        [TestCase("aabcdviksejffggghhhhhvjjekjjjjkllmmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = true)]
        [TestCase("adbcdviksejffggghhhhhvjjekjjjjkllmmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = false)]
        [TestCase("abcdviksejffggghhhhhvjjekjjjjkllmmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = false)]
        [TestCase("aabcdviksejffegghhhhhvjjekjjjjkllmmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = false)]
        [TestCase("aabcdviksejffggghhhhhvjjekjjjjklmm", "aab.d.*ffgggh*.*j*kllmmm", ExpectedResult = false)]
        public bool LeetCode10Test(string str, string regExp)
        {
            var actaul = new Solution().IsMatch(str, regExp);
            return actaul;
        }


        [Ignore]
        [TestCase("23", new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
        [TestCase("593", new[]
        {
            "jwd", "jwe", "jwf", "jxd", "jxe", "jxf", "jyd", "jye", "jyf", "jzd", "jze", "jzf",
            "kwd", "kwe", "kwf", "kxd", "kxe", "kxf", "kyd", "kye", "kyf", "kzd", "kze", "kzf",
            "lwd", "lwe", "lwf", "lxd", "lxe", "lxf", "lyd", "lye", "lyf", "lzd", "lze", "lzf",
        })]
        [TestCase("111", new string[] {})]
        [TestCase("", new string[] {})]
        public void LeetCode17Test(string digits, string[] expected)
        {
            var actaul = new Solution().LetterCombinations(digits);
            CollectionAssert.AreEquivalent(expected, actaul);
        }

        [Ignore]
        [TestCase("", ExpectedResult = 0)]
        [TestCase("9", ExpectedResult = 9)]
        [TestCase("2147483647", ExpectedResult = 2147483647)]
        [TestCase("-2147483648", ExpectedResult = -2147483648)]
        [TestCase("   81    ", ExpectedResult = 81)]
        [TestCase("   8 1    ", ExpectedResult = 0)]
        public int LeetCode9Test(string str)
        {
            return new Solution().MyAtoi(str);
        }

        [Ignore]
        [TestCase(1, 1)]
        [TestCase(3, 1)]
        [TestCase(6, 3)]
        [TestCase(9, 3)]
        [TestCase(32, 2)]
        [TestCase(0, 3)]
        [TestCase(2, 3)]
        [TestCase(4, 3)]
        [TestCase(3, 0)]
        [TestCase(-3, 3)]
        [TestCase(-60, 3)]
        [TestCase(-2, 3)]
        [TestCase(-4, 3)]
        [TestCase(3, -3)]
        [TestCase(2, -3)]
        [TestCase(4, -3)]
        [TestCase(60, -3)]
        [TestCase(-3, -3)]
        [TestCase(-2, -3)]
        [TestCase(-4, -3)]
        [TestCase(-60, -3)]
        [TestCase(int.MaxValue, 1)]
        [TestCase(int.MaxValue, -1)]
        [TestCase(int.MinValue, 1)]
        [TestCase(int.MinValue, -1)]
        [TestCase(int.MaxValue, 2)]
        [TestCase(int.MaxValue, -2)]
        [TestCase(int.MinValue, 2)]
        [TestCase(int.MinValue, -2)]
        [TestCase(int.MaxValue, int.MaxValue)]
        [TestCase(int.MaxValue, int.MinValue)]
        [TestCase(int.MinValue, int.MaxValue)]
        [TestCase(int.MinValue, int.MinValue)]
        [TestCase(1, int.MaxValue)]
        [TestCase(-1, int.MaxValue)]
        [TestCase(1, int.MinValue)]
        [TestCase(1, int.MinValue)]
        public void LeetCode29Test(int dividend, int divisor)
        {
            var target = new Solution();
            var actual = target.Divide(dividend, divisor);

            int expected;
            if (divisor == 0)
                expected = int.MaxValue;
            else if (dividend == int.MinValue && divisor == -1)
                expected = int.MaxValue;
            else
                expected = dividend/divisor;
            
            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestCase(new[] { 1, 1, 0, 1, 1, 1 }, ExpectedResult = 3)]
        public int LeetCode485Test(int[] nums)
        {
            var result = new Solution().FindMaxConsecutiveOnes(nums);
            return result;
        }

        [Ignore]
        [Test]
        public void LeetCode609Test()
        {
            var paths = new[]{"root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)"};
            var expectedResult = new List<List<string>>
            {
                new List<string> {"root/a/1.txt", "root/c/3.txt"},
                new List<string> {"root/a/2.txt", "root/c/d/4.txt", "root/4.txt"},
            };

            var result = new Solution().FindDuplicate(paths);
            Assert.AreEqual(expectedResult, result);
        }

        [Ignore]
        [TestCase(new[] { 0 }, 1, ExpectedResult = true)]
        [TestCase(new[] { 0 }, 2, ExpectedResult = false)]
        [TestCase(new[] { 1, 0, 0, 1 }, 0, ExpectedResult = true)]
        [TestCase(new[] { 1, 0, 0, 1 }, 1, ExpectedResult = false)]
        [TestCase(new[] { 1, 0, 0, 0, 1 }, 1, ExpectedResult = true)]
        [TestCase(new[] { 1, 0, 0, 0, 1 }, 2, ExpectedResult = false)]
        [TestCase(new[] { 1, 0, 1, 0, 1 }, 1, ExpectedResult = false)]
        [TestCase(new[] { 1, 0, 1, 0, 1 }, 0, ExpectedResult = true)]
        [TestCase(new[] { 1, 0, 0, 1, 0, 1, 0, 1 }, 1, ExpectedResult = false)]
        [TestCase(new[] { 1, 0, 0, 0, 1, 0, 1, 0, 1 }, 1, ExpectedResult = true)]
        [TestCase(new[] { 1, 0, 0, 0, 1 }, 2, ExpectedResult = false)]
        public bool LeetCode605Test(int[] flowerbed, int n)
        {
            var result = new Solution().CanPlaceFlowers(flowerbed, n);
            return result;
        }

        [Ignore]
        [TestCase(new int[] { }, new[] { 1 }, 1)]
        [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
        [TestCase(new int[] { }, new[] { 2, 3 }, 2.5)]
        [TestCase(new[] { 1, 1 }, new[] { 1, 1 }, 1)]
        [TestCase(new[] { 1, 2 }, new[] { 1, 2, 3 }, 2)]
        [TestCase(new[] { 1 }, new[] { 2, 3, 4 }, 2.5)]
        [TestCase(new[] { 2 }, new[] { 1, 3, 4 }, 2.5)]
        [TestCase(new[] { 1, 3 }, new[] { 2, 4 }, 2.5)]
        public void LeetCode4Test(int[] nums1, int[] nums2, double expectedResult)
        {
            var result = new Solution().FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(expectedResult, result);
        }

        [Ignore]
        [TestCase(0, 0)]
        [TestCase(123, 321)]
        [TestCase(-123, -321)]
        [TestCase(1111111119, 0)]
        [TestCase(-1111111119, 0)]
        public void LeetCode7Test(int x, double expectedResult)
        {
            var result = new Solution().Reverse(x);
            Assert.AreEqual(expectedResult, result);
        }

        [Ignore]
        [TestCase(new[] { 1, 2, 1, 3, 0, 0, 2, 2, 1, 3, 3 }, true)]
        [TestCase(new []{3, 2, 2, 3, 2, 1, 3, 3, 3, -2, 0, 3, 2, 1, 0, 3, 1, 0, 1, 3, 0, 3, 3}, true)]
        [TestCase(new[] { 0, 3, 1, 3, 3, 3, 0, 1, 0, 2, 0, 3, 1, 3, -3, 2, 0, 3, 1, 2, 2, -3, 2, 2, 3, 3 }, true)]
        [TestCase(new[] { 1,2,3,4,6,5,-5,10,-1,-2,5,4,4,-1,7 }, true)]
        [TestCase(new[] { -1, -2, -1, -3, 0, 0, -2, -2, -1, -3, -3 }, true)]
        public void LeetCode548Test(int[] nums, bool expectedResult)
        {
            var result = new Solution().SplitArray(nums);
            Assert.AreEqual(expectedResult, result);
        }

        [Ignore]
        [TestCase(new[] { "aaa", "aaa", "a" }, -1)]
        [TestCase(new[] { "aaa", "abc", "a", "b", "bac" }, 3)]
        [TestCase(new[] { "aaa", "abc" }, 3)]
        [TestCase(new[] { "aabbcc", "aabbcc", "cb" }, 2)]
        [TestCase(new[] { "aabbcc", "aabbcc", "bc" }, -1)]
        [TestCase(new[] { "aabbcc", "ab" }, 6)]
        [TestCase(new[] { "aabbcc", "aabbcc","cb","abc" }, 2)]
        [TestCase(new[] { "a", "b", "a", "b" }, -1)]
        [TestCase(new[] { "aabbcc", "aabbcc","c","e","aabbcd"}, 6)]
        public void LeetCode522Test(string[] strs, int expectedResult)
        {
            var result = new Solution().FindLUSlength(strs);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
