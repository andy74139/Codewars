using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CodeWars;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class CodeWarsTest
    {
        [Test]
        public void DeadAntCountTest()
        {
            Assert.AreEqual(0, Kata.DeadAntCount("ant ant ant ant"));
            Assert.AreEqual(0, Kata.DeadAntCount(null));
            Assert.AreEqual(2, Kata.DeadAntCount("ant anantt aantnt"));
            Assert.AreEqual(1, Kata.DeadAntCount("ant ant .... a nt"));
        }

        [Test]
        public void Can_Be_Solved_With_Basic_Computations()
        {
            Assert.AreEqual(2, FactorialTail.zeroes(10, 10));
            Assert.AreEqual(3, FactorialTail.zeroes(16, 16));
            Assert.AreEqual(8, FactorialTail.zeroes(2, 10));
            Assert.AreEqual(1, FactorialTail.zeroes(997, 997));
            Assert.AreEqual(0, FactorialTail.zeroes(192, 3));
        }

        [TestCase(new[] { -1, -2, -3 }, Result = 0)]
        [TestCase(new int[0], Result = 0)]
        [TestCase(new[] { 1, 2, 3, 4 }, Result = 10)]
        [TestCase(new[] { 31, -41, 59, 26, -53, 58, 97, -93, -23, 84 }, Result = 187)]
        public int LargestSumTest(int[] arr)
        {
            return Kata.LargestSum(arr);
        }

        [Test]
        public void StringAverageTest()
        {
            Assert.AreEqual("four", Kata.AverageString("zero nine five two"));
            Assert.AreEqual("three", Kata.AverageString("four six two three"));
            Assert.AreEqual("three", Kata.AverageString("one two three four five"));
            Assert.AreEqual("four", Kata.AverageString("five four"));
            Assert.AreEqual("zero", Kata.AverageString("zero zero zero zero zero"));
            Assert.AreEqual("two", Kata.AverageString("one one eight one"));
            Assert.AreEqual("two", Kata.AverageString("two"));
            Assert.AreEqual("n/a", Kata.AverageString("ten"));
            Assert.AreEqual("n/a", Kata.AverageString("one ten"));
            Assert.AreEqual("n/a", Kata.AverageString(""));
        }
    }

}
