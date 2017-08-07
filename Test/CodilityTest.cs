using System;
using System.Collections.Generic;
using Codility;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class CodilityTest
    {
        [Ignore]
        [Test]
        public void Task2Test()
        {
            var A = new int[6];
            A[0] = 4;
            A[1] = 6;
            A[2] = 7;
            A[3] = 3;
            A[4] = 2;
            A[5] = 7;
            var target = new Task2();

            var actual = target.solution(A);
            var expected = 9;

            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [Test]
        public void Task21Test()
        {
            var A = new int[6];
            A[0] = 4;
            A[1] = 6;
            A[2] = 7;
            A[3] = 3;
            A[4] = 2;
            A[5] = 7;
            var target = new Task2();

            var actual = target.solution(A);
            var expected = 22;

            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [Test]
        public void Task1Test()
        {
            var A = new int[4][];
            for (var i = 0; i < 4; i++)
            {
                A[i] = new int[5];
            }
            A[0][0] = 7;  A[0][1] = -2; A[0][2] = 0; A[0][3] = 4;  A[0][4] = 2;
            A[1][0] = -1; A[1][1] = 0;  A[1][2] = 2; A[1][3] = 3;  A[1][4] = 1;
            A[2][0] = 1;  A[2][1] = 2;  A[2][2] = 1; A[2][3] = -1; A[2][4] = 2;
            A[3][0] = 4;  A[3][1] = 0;  A[3][2] = 0; A[3][3] = -3; A[3][4] = 2;

            var target = new Task1_Refactor();

            var actual = target.solution(A);
            var expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestCase(new[] { -1, 3, -4, 5, 1, -6, 2, 1 }, new[] { 1, 3, 7 }, TestName = "Sample")]
        [TestCase(new[] { 2147483647, 2147483647, 2147483647, 2147483647, 2147483647 }, new[] { 2 }, TestName = "Max")]
        [TestCase(new[] { -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, }, new[] { 2 }, TestName = "Min")]
        [TestCase(new[] { 0 }, new[] { 0 }, TestName = "Zero")]
        [TestCase(new[] { 1, 1 }, new[] { -1 }, TestName = "No")]
        public void EquiTest(int[] array, IEnumerable<int> expected)
        {
            var target = new Equi();
            var actual = target.solution(array);

            CollectionAssert.Contains(expected, actual);
        }


        public int? ToNumber(string str)
        {
            try
            {
                var number = Convert.ToInt32(str);
                if (number > 1000000000 || number < -1000000000)
                    return null;
                return number;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [Ignore]
        [TestCase(8, ExpectedResult = 0)]
        [TestCase(1041, ExpectedResult = 5)]
        [TestCase(529, ExpectedResult = 4)]
        [TestCase(9, ExpectedResult = 2)]
        [TestCase(20, ExpectedResult = 1)]
        [TestCase(15, ExpectedResult = 0)]
        [TestCase(int.MaxValue, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 0)]
        public int BinaryGapTest(int n)
        {
            var actual = new BinaryGap().solution(n);
            return actual;
        }

        [Ignore]
        [TestCase("137", ExpectedResult = 137)]
        [TestCase("-104", ExpectedResult = -104)]
        [TestCase("2 58", ExpectedResult = null)]
        [TestCase("+0", ExpectedResult = 0)]
        [TestCase("++3", ExpectedResult = null)]
        [TestCase("+1", ExpectedResult = 1)]
        [TestCase("23.9", ExpectedResult = null)]
        [TestCase("2000000000", ExpectedResult = null)]
        [TestCase("-0", ExpectedResult = 0)]
        [TestCase("five", ExpectedResult = null)]
        [TestCase("-1", ExpectedResult = -1)]
        [TestCase("1000000000", ExpectedResult = 1000000000)]
        [TestCase("1000000001", ExpectedResult = null)]
        public int? ToNumberTest(string str)
        {
            var actual = ToNumber(str);
            return actual;
        }

        [Ignore]
        [Test]
        public void CalendarTest1()
        {
            var TestData = 
@"Sun 10:00-20:00
Fri 05:00-10:00
Fri 16:30-23:50
Sat 10:00-24:00
Sun 01:00-04:00
Sat 02:00-06:00
Tue 03:30-18:15
Tue 19:00-20:00
Wed 04:25-15:14
Wed 15:14-22:40
Thu 00:00-23:59
Mon 05:00-13:00
Mon 15:00-21:00";

            var actual = new Calendar().solution(TestData);
            var expected = 505;

            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [Test]
        public void CalendarTest2()
        {
            var TestData = 
@"Mon 01:00-23:00
Tue 01:00-23:00
Wed 01:00-23:00
Thu 01:00-23:00
Fri 01:00-23:00
Sat 01:00-23:00
Sun 01:00-21:00";
            
            var actual = new Calendar().solution(TestData);
            var expected = 180;

            Assert.AreEqual(expected, actual);
        }

    }
}
