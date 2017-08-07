using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Euler;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class Euler377_Test
    {
        [Ignore]
        [TestCase(1, 1)]
        [TestCase(2, 13)]
        [TestCase(3, 147)]
        [TestCase(4, 1625)]
        [TestCase(5, 17891)]
        [TestCase(6, 196833)]
        [TestCase(7, 2165227)]
        [TestCase(8, 23817625)]
        [TestCase(9, 261994131)]
        [TestCase(100000, 284765625)]
        [TestCase(1000000, 634765625)]
        [TestCase(10000000, 134765625)]
        [TestCase(8650415919381337933, 123611171)]
        public void RunTest(long n, long expectedResult)
        {
            var result = new Euler377(n).Run();
            Assert.AreEqual(new BigInteger(expectedResult), result);
        }

        [Ignore]
        [Test]
        public void SumTest()
        {
            var ns = new List<long>();
            long product = 1;
            for (var i = 1; i <= 17; i++)
            {
                product *= 13;
                ns.Add(product);
            }

            var result = new BigInteger(0);
            foreach (var n in ns)
                result = (result + (BigInteger)(new Euler377(n).Run()))/*%1000000000*/;
            Assert.AreEqual(0, result % 1000000000);
        }
    }
}
