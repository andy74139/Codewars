using Euler;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [Ignore]
    [TestFixture]
    public class Euler14_Test
    {
        [TestCase(7, 17)]
        [TestCase(8, 4)]
        [TestCase(9, 20)]
        [TestCase(15, 18)]
        [TestCase(16, 5)]
        [TestCase(17, 13)]
        public void StepCountTest(int n, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Euler14(0).StepCount(n));
        }

        [Test]
        public void MaxStepCountTest()
        {
            var o = new Euler14(0);
            var maxCount = 0;
            var maxNumber = 0;
            for (var i = 1; i < 1000000; i++)
            {
                var count = o.StepCount(i);
                if (count > maxCount)
                {
                    maxCount = (int) count;
                    maxNumber = i;
                }
            }

            Assert.AreEqual(837799, maxNumber);
        }
    }
}
