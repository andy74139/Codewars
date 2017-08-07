using System.Numerics;
using NUnit.Framework;
using M4Lib;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [Ignore]
    [TestFixture]
    public class M4NumberTest
    {
        [TestCase(5435.78, 0.78)]
        [TestCase(134.193533, 0.193533)]
        public void FractionalPartTest(decimal originNum, decimal expectedNum)
        {
            Assert.AreEqual(expectedNum, M4Number.FractionalPart(originNum));
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(3, 3, 1)]
        [TestCase(4, 1, 4)]
        [TestCase(4, 2, 6)]
        [TestCase(5, 2, 10)]
        [TestCase(100, 1, 100)]
        [TestCase(10, 5, 252)]
        public void nCrTest(int n, int r, int expectedResult)
        {
            var result = M4Number.nCr(n, r);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(3, 3, 1)]
        [TestCase(4, 1, 4)]
        [TestCase(4, 2, 6)]
        [TestCase(5, 2, 10)]
        [TestCase(100, 1, 100)]
        [TestCase(10, 5, 252)]
        public void nCrBigIntegerTest(int n, int r, int expectedResult)
        {
            var result = M4Number.nCr(new BigInteger(n), new BigInteger(r));
            Assert.AreEqual(new BigInteger(expectedResult), result);
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(3, 3, 1)]
        [TestCase(4, 1, 4)]
        [TestCase(4, 2, 6)]
        [TestCase(5, 2, 10)]
        [TestCase(100, 1, 100)]
        [TestCase(10, 5, 252)]
        public void nCrBigIntegerNoOverTest(int n, int r, int expectedResult)
        {
            var result = M4Number.nCr_NoOver(n, r);
            Assert.AreEqual(new BigInteger(expectedResult), result);
        }

        [TestCase(2, 2, 4)]
        [TestCase(4, 4, 16)]
        [TestCase(4, 2, 11)]
        [TestCase(5, 5, 32)]
        [TestCase(5, 0, 1)]
        [TestCase(5, 1, 6)]
        [TestCase(5, 2, 16)]
        public void Sum_nCr_Test(int n, int r, int expectedResult)
        {
            var result = M4Number.Sum_nCr(n, r);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
