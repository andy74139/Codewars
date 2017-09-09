using System;
using System.Collections.Generic;
using System.Linq;
using Euler;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class Euler576_Test
    {
        [TestCase(3, 0.06, 29.5425)]  //29.5425
        [TestCase(10, 0.01, 266.9010)]  //266.9010
        [TestCase(2, 0.00002, 47321.0000)]     //6s      -> 4.8s  -> 4.578s
        [TestCase(2, 0.00003, 33461.0000)]     //?       -> 2.2s  -> 2.233s
        [TestCase(3, 0.00002, 87866.0000)]     //25s     -> 13.6s -> 9.404s
        [TestCase(10, 0.00002, 156788.0312)]   //157s    -> 1xxs  -> 30.515s
        [TestCase(100, 0.00002, 344457.5871)]  //2hrs up -> ??    -> 343.515s
        public void RunTest(int n, decimal g, decimal expectedResult)
        {
            var result = new Euler576_IrrationalJumps(n, g).Run();
            Assert.AreEqual(expectedResult, result);
        }

        //[Ignore]
        //[TestCase(2, 0.06, 0.7, 0.7071)]
        //[TestCase(2, 0.06, 0.3543, 1.4142)]
        //[TestCase(2, 0.06, 0.2427, 16.2635)]  //16.2634
        //[TestCase(3, 0.06, 0.2427, 29.5425-16.2634)]
        //[TestCase(2, 0.01, 0.98, 28.9914)]
        //[TestCase(3, 0.01, 0.99, 40.9919)]
        //[TestCase(5, 0.01, 0.99, 16.9941)]
        //[TestCase(7, 0.01, 0.99, 30.9931)]
        //public void SPrimeTest(int p, decimal g, decimal d, decimal expectedResult)
        //{
        //    var result = (decimal)Math.Round(new Euler576_IrrationalJumps().SPrime(p, g, d), 4);
        //    Assert.AreEqual(expectedResult, result);
        //}

        //[TestCase(new[] { 0.35 }, 1)]
        //[TestCase(new[] { 0.0, 0.25 }, 0.25)]
        //[TestCase(new[] { 0.0, 0.25, 0.75 }, 0.25)]
        //[TestCase(new[] { 0.1, 0.2, 0.5, 0.9 }, 0.1)]
        //[TestCase(new[] { 0.36, 0.72, 1.08, 1.44 }, 0.08)]
        //[TestCase(new[] { 0.36, 0.72, 1.08, 1.44, 1.8, 2.16, 2.52, 2.88 }, 0.08)]
        //public void SortedCircleList_MinDistance_Test(double[] array, decimal expectedResult)
        //{
        //    var list = new SortedCircleList();
        //    array.ToList().ForEach(item => list.Add((decimal)item, (decimal) TODO));
        //    Assert.AreEqual(expectedResult, list.MinDistance());
        //}

        //private IEnumerable<TestCaseData> SortedCircle_MaxSum_Source()
        //{
        //    return new[]
        //    {
        //        new TestCaseData(0.39m, new[]{new []{0.3m, 0.6m, 0.9m, 1.2m}}).Returns(1.2m).SetName("Basic"), 
        //        new TestCaseData(0.39m, new[]{new []{0.3m, 0.6m, 0.9m, 1.2m, 1.5m, 1.8m, 2.1m, 2.4m}}).Returns(1.2m).SetName("Basic1"), 
        //        new TestCaseData(0.21m, new[]{new []{0.3m, 0.6m, 0.9m, 1.2m, 1.5m, 1.8m, 2.1m}}).Returns(2.1m).SetName("Basic2"), 
        //    };
        //}

        //[TestCaseSource("SortedCircle_MaxSum_Source")]
        //public decimal SortedCircle_MaxSum_Test(decimal length, decimal[][] circles)
        //{
        //    var target = new SortedCircles();
        //    foreach (var circle in circles)
        //    {
        //        var c = new SortedCircleList();
        //        foreach(var value in circle)
        //            c.Add(value, (decimal) TODO);
        //        target.AddCircle(c);
        //    }
        //    var actual = target.MaxSum(length);
        //    return actual;
        //}
    }
}
