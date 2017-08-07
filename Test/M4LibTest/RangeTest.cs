using M4Lib;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [Ignore]
    [TestFixture]
    public class RangeTest
    {
        [TestCase(false, -100)]
        [TestCase(false, 0)]
        [TestCase(false, 1)]
        [TestCase(true, 2)]
        [TestCase(true, 6)]
        [TestCase(false, 100)]
        public void OpenCloseCase(bool result, int num)
        {
            var range = new Range(false, true, 1, 6);
            Assert.AreEqual(result, range.Contains(num));
        }

        [TestCase(false, -100)]
        [TestCase(false, 0)]
        [TestCase(true, 1)]
        [TestCase(true, 2)]
        [TestCase(true, 6)]
        [TestCase(false, 100)]
        public void CloseCloseCase(bool result, int num)
        {
            var range = new Range(true, true, 1, 6);
            Assert.AreEqual(result, range.Contains(num));
        }

        [TestCase(false, -100)]
        [TestCase(false, 0)]
        [TestCase(false, 1)]
        [TestCase(true, 2)]
        [TestCase(false, 6)]
        [TestCase(false, 100)]
        public void OpenOpenCase(bool result, int num)
        {
            var range = new Range(false, false, 1, 6);
            Assert.AreEqual(result, range.Contains(num));
        }

        [TestCase(false, -100)]
        [TestCase(false, 0)]
        [TestCase(true, 1)]
        [TestCase(true, 2)]
        [TestCase(false, 6)]
        [TestCase(false, 100)]
        public void CloseOpenCase(bool result, int num)
        {
            var range = new Range(true, false, 1, 6);
            Assert.AreEqual(result, range.Contains(num));
        }

        [TestCase(false, true, 1, 6, 2, true)]
        [TestCase(false, true, 1, 6, 6, true)]
        [TestCase(false, true, 1, 6, 1, false)]
        [TestCase(false, true, 1, 6, 0, false)]
        [TestCase(false, true, 1, 6, -100, false)]
        [TestCase(false, true, 1, 6, 100, false)]
        [TestCase(true, true, 1, 3, 1, true)]
        [TestCase(true, true, 1, 3, 2, true)]
        [TestCase(true, true, 1, 3, 3, true)]
        [TestCase(true, true, 1, 3, 4, false)]
        [TestCase(true, true, 1, 3, -1, false)]
        [TestCase(false, false, 1, 3, 1, false)]
        [TestCase(false, false, 1, 3, 3, false)]
        [TestCase(false, false, 1, 3, 2, true)]
        [TestCase(false, false, 1, 3, 0, false)]
        [TestCase(true, true, -2147483648, 2147483647, -100, true)]
        [TestCase(true, true, -2147483648, 2147483647, 10033535, true)]
        public void Test(bool includeLeft, bool includeRight, int left, int right, int num, bool result)
        {
            var range = new Range(includeLeft, includeRight, left, right);
            Assert.AreEqual(result, range.Contains(num));
        }
    }
}
