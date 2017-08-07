using System;
using System.Collections.Generic;
using System.Linq;
using M4Lib;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [Ignore]
    [TestFixture]
    public class SpecificOrderedListTest
    {
        [Test]
        public void SpecificOrderedListTest_Correct()
        {
            var list = new SpecificOrderedList<TestClass>();
            list.Add(new TestClass("1", 1));
            list.Add(new TestClass("2", 3.13m));
            list.Add(new TestClass("3", 2));
            list.Add(new TestClass("4", 1.1m));
            list.Add(new TestClass("5", 5));
            list.Add(new TestClass("6", 4));
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("1", list[0].str);
            Assert.AreEqual("4", list[1].str);
            Assert.AreEqual("3", list[2].str);
            Assert.AreEqual("2", list[3].str);
            Assert.AreEqual("6", list[4].str);
            Assert.AreEqual("5", list[5].str);
        }
    }

    internal class TestClass : ISpecificOrderedClass<decimal>
    {
        public string str;
        private decimal order;

        public TestClass(string s, decimal o)
        {
            str = s;
            order = o;
        }

        public decimal GetOrder()
        {
            return order;
        }
    }
}
