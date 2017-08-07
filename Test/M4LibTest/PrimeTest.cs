using System.Collections.Generic;
using System.Linq;
using M4Lib;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [Ignore]
    [TestFixture]
    public class PrimeTest
    {
        [TestCase(1, false)]
        [TestCase(0, false)]
        [TestCase(-2, false)]
        [TestCase(3, true)]
        [TestCase(38, false)]
        [TestCase(97, true)]
        [TestCase(123456789, false)]
        [TestCase(6, false)]
        [TestCase(19, true)]
        public void Prime_IsPrime(int n, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Prime.Instance.IsPrime(n));
        }

        [TestCase(0, new int[] { })]
        [TestCase(1, new int[] { })]
        [TestCase(2, new[] { 2 })]
        [TestCase(3, new[] { 2, 3 })]
        [TestCase(4, new[] { 2, 3 })]
        [TestCase(5, new[] { 2, 3, 5 })]
        [TestCase(6, new[] { 2, 3, 5 })]
        [TestCase(7, new[] { 2, 3, 5, 7 })]
        [TestCase(100, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        [TestCase(97, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        public void Prime_GetPrimes_MaxNumber(int n, int[] expectedResult)
        {
            var primes = Prime.Instance.GetPrimes_MaxNumber(n);
            Assert.AreEqual(expectedResult.ToList(), primes);
        }

        [TestCase(100, 25)]
        [TestCase(1000, 168)]
        public void Prime_GetPrimes_MaxNumber_Count(int n, int expectedCount)
        {
            var primes = Prime.Instance.GetPrimes_MaxNumber(n);
            Assert.AreEqual(expectedCount, primes.Count);
        }

        private readonly Dictionary<int, List<long>> _testGetPrimesCountPrimes = new Dictionary<int, List<long>>
        {
            {0, new List<long>()},
            {1, new List<long> {2}},
            {2, new List<long> {2, 3}},
            {3, new List<long> {2, 3, 5}},
            {4, new List<long> {2, 3, 5, 7}}, 
            {5, new List<long> {2, 3, 5, 7, 11}}, 
            {25, new List<long> {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97}}, 
        };

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(25)]
        public void Prime_GetPrimes_Count(int count)
        {
            var primes = Prime.Instance.GetPrimes_Count(count);
            Assert.AreEqual(count, primes.Count);
            Assert.AreEqual(_testGetPrimesCountPrimes[count], primes);
        }

        private readonly Dictionary<long, Dictionary<long, int>> _testPrimeFactorDecompositionDictionarys = new Dictionary<long, Dictionary<long, int>>
        {
            {1, new Dictionary<long, int>()},
            {2, new Dictionary<long, int> {{2, 1}}},
            {97, new Dictionary<long, int> {{97, 1}}},
            {512, new Dictionary<long, int> {{2, 9}}},
            {20, new Dictionary<long, int> {{2, 2}, {5, 1}}},
            {24990, new Dictionary<long, int> {{2, 1}, {3, 1}, {5, 1}, {7, 2}, {17, 1}}}
        };

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(97)]
        [TestCase(512)]
        [TestCase(20)]
        [TestCase(24990)]
        public void Prime_PrimeFactorDecomposition(long n)
        {
            var primeFactorDecomposition = Prime.Instance.PrimeFactorDecomposition(n);
            Assert.AreEqual(_testPrimeFactorDecompositionDictionarys[n], primeFactorDecomposition);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(97, 2)]
        [TestCase(512, 10)]
        [TestCase(20, 6)]
        [TestCase(24990, 48)]
        public void Prime_PrimeAmount(long n, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Prime.Instance.PrimeAmount(n));
        }
    }
}
