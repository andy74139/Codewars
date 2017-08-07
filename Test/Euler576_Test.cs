using System;
using System.Linq;
using Euler;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class Euler576_Test
    {
        [Ignore]
        [TestCase(3, 0.06, 29.5425)]
        [TestCase(10, 0.01, 266.9010)]
        [TestCase(100, 0.00002, 0)]
        public void RunTest(int n, decimal g, decimal expectedResult)
        {
            var result = new Euler576_IrrationalJumps(n, g).Run();
            Assert.AreEqual(expectedResult, result);
        }

        [Ignore]
        [TestCase(2, 0.06, 0.7, 0.7071)]
        [TestCase(2, 0.06, 0.3543, 1.4142)]
        [TestCase(2, 0.06, 0.2427, 16.2635)]  //16.2634
        [TestCase(3, 0.06, 0.2427, 29.5425-16.2634)]
        [TestCase(2, 0.01, 0.98, 28.9914)]
        [TestCase(3, 0.01, 0.99, 40.9919)]
        [TestCase(5, 0.01, 0.99, 16.9941)]
        [TestCase(7, 0.01, 0.99, 30.9931)]
        public void SPrimeTest(int p, decimal g, decimal d, decimal expectedResult)
        {
            var result = (decimal)Math.Round(new Euler576_IrrationalJumps().SPrime(p, g, d), 4);
            Assert.AreEqual(expectedResult, result);
        }

        [Ignore]
        [TestCase(new[] { 0.35 }, 1)]
        [TestCase(new[] { 0.0, 0.25 }, 0.75)]
        [TestCase(new[] { 0.0, 0.25, 0.75 }, 0.5)]
        [TestCase(new[] { 0.1, 0.2, 0.5, 0.9 }, 0.4)]
        [TestCase(new[] { 0.36, 0.72, 1.08, 1.44 }, 0.36)]
        [TestCase(new[] { 0.36, 0.72, 1.08, 1.44, 1.8, 2.16, 2.52, 2.88 }, 0.2)]
        public void SortedCircleList_MaxDistance_Test(double[] array, decimal expectedResult)
        {
            var list = new SortedCircleList();
            array.ToList().ForEach(item => list.Add((decimal)item));
            Assert.AreEqual(expectedResult, list.MaxDistance());
        }
    }
}
