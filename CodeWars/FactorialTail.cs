using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public class FactorialTail
    {

        public static int zeroes(int radix, int number)
        {
            var pfd = Prime.Instance.PrimeFactorDecomposition(radix);

            var min = int.MaxValue;
            foreach (var prime in pfd.Keys)
            {
                var primeNum = PrimeNum(number, (int)prime, pfd[prime]);
                if (primeNum < min)
                    min = primeNum;
            }

            return min;
        }

        private static int PrimeNum(int number, int prime, int primeDivisor)
        {
            var primeNum = 0;
            var count = number/prime;
            while (count > 0)
            {
                primeNum += count;
                count /= prime;
            }
            return primeNum/primeDivisor;
        }

        internal class Prime
        {
            private readonly List<long> PrimesCache = new List<long> { 2, 3 };
            private long LastPrimeInCache { get { return PrimesCache[PrimesCache.Count - 1]; } }
            private int CountInCache { get { return PrimesCache.Count; } }

            public static Prime Instance = new Prime();

            private Prime()
            {
            }

            public bool IsPrime(long n)
            {
                if (n <= 1) return false;
                var primesLessThanSqrt = GetPrimes_MaxNumber((long)Math.Sqrt(n));
                return primesLessThanSqrt.All(prime => n % prime != 0);
            }

            public List<long> GetPrimes_MaxNumber(long maxNumber)
            {
                if (maxNumber < 2) return new List<long>();
                if (LastPrimeInCache < maxNumber)
                {
                    for (var p = LastPrimeInCache + 2; p <= maxNumber; p += 2)
                    {
                        if (_IsPrime(p))
                            PrimesCache.Add(p);
                    }
                    return PrimesCache;
                }

                int count = 0;
                while (count + 1 < CountInCache && PrimesCache[count + 1] <= maxNumber)
                    count++;

                return PrimesCache.GetRange(0, count + 1);
            }

            private bool _IsPrime(long p)
            {
                var sqrtNum = (long)Math.Sqrt(p);
                var prime = true;
                for (var i = 0; PrimesCache[i] <= sqrtNum; i++)
                {
                    if (p % PrimesCache[i] != 0) continue;
                    prime = false;
                    break;
                }
                return prime;
            }

            public Dictionary<long, int> PrimeFactorDecomposition(long n)
            {
                var result = new Dictionary<long, int>();
                var primesLessThanSqrt = GetPrimes_MaxNumber((long)Math.Sqrt(n));
                foreach (var prime in primesLessThanSqrt)
                {
                    if (n == 1) break;
                    var count = 0;
                    while (n % prime == 0)
                    {
                        count++;
                        n /= prime;
                    }
                    if (count > 0)
                        result[prime] = count;
                }
                if (n > 1) result[n] = 1;

                return result;
            }
        }

    }

}
