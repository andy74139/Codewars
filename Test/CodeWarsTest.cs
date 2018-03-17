using CodeWars;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class CodeWarsTest
    {
        [TestCase("abc", "cde", ExpectedResult = "abCCde")]
        [TestCase("abab", "bababa", ExpectedResult = "ABABbababa")]
        [TestCase("abcdeFgtrzw", "defgGgfhjkwqe", ExpectedResult = "abcDeFGtrzWDEFGgGFhjkWqE")]
        [TestCase("abcdeFg", "defgG", ExpectedResult = "abcDEfgDEFGg")]
        [TestCase("ab", "aba", ExpectedResult = "aBABA")]
        public string smile67KataTest(string a, string b)
        {
            var actual = new Kata().workOnStrings(a, b);
            return actual;
        }

        [TestCase(21, Result = 12)]
        [TestCase(907, Result = 790)]
        [TestCase(531, Result = 513)]
        [TestCase(2071, Result = 2017)]
        [TestCase(1027, Result = -1)]
        [TestCase(9, Result = -1)]
        [TestCase(111, Result = -1)]
        [TestCase(135, Result = -1)]
        [TestCase(441, Result = 414)]
        [TestCase(123456798, Result = 123456789)]
        public long FixedTests(long n)
        {
            return Kata.NextSmaller(n);
        }

        [TestCase("EBG13 rknzcyr.", ExpectedResult = "ROT13 example.")]
        [TestCase("This is my first ROT13 excercise!", ExpectedResult = "Guvf vf zl svefg EBG13 rkprepvfr!")]
        public string Rot13Tests(string input)
        {
            return Kata.Rot13(input);
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(683658261, ExpectedResult = 683658612)]
        [TestCase(683658162, ExpectedResult = 683658216)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(9, ExpectedResult = -1)]
        [TestCase(111, ExpectedResult = -1)]
        [TestCase(531, ExpectedResult = -1)]
        [TestCase(1234567890, ExpectedResult = 1234567908)]
        public long NextBiggerNumberTest(long n)
        {
            //return Kata.NextBiggerNumber(n);
            return 0;
        }

        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("The Knife", Kata.BandNameGenerator("knife"));
            Assert.AreEqual("Tartart", Kata.BandNameGenerator("tart"));
            Assert.AreEqual("Sandlesandles", Kata.BandNameGenerator("sandles"));
            Assert.AreEqual("The Bed", Kata.BandNameGenerator("bed"));
        }

        //[Test]
        //public void SolvePuzzle1()
        //{
        //    var clues = new[]{ 3, 2, 2, 3, 2, 1,
        //                       1, 2, 3, 3, 2, 2,
        //                       5, 1, 2, 2, 4, 3,
        //                       3, 2, 1, 2, 2, 4};

        //    var expected = new[]{new []{ 2, 1, 4, 3, 5, 6}, 
        //                         new []{ 1, 6, 3, 2, 4, 5}, 
        //                         new []{ 4, 3, 6, 5, 1, 2}, 
        //                         new []{ 6, 5, 2, 1, 3, 4}, 
        //                         new []{ 5, 4, 1, 6, 2, 3}, 
        //                         new []{ 3, 2, 5, 4, 6, 1 }};

        //    var actual = Skyscrapers.SolvePuzzle(clues);
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //[Test]
        //public void SolvePuzzle2()
        //{
        //    var clues = new[]{ 0, 0, 0, 2, 2, 0,
        //                    0, 0, 0, 6, 3, 0,
        //                    0, 4, 0, 0, 0, 0,
        //                    4, 4, 0, 3, 0, 0};

        //    var expected = new[]{new []{ 5, 6, 1, 4, 3, 2 }, 
        //                     new []{ 4, 1, 3, 2, 6, 5 }, 
        //                     new []{ 2, 3, 6, 1, 5, 4 }, 
        //                     new []{ 6, 5, 4, 3, 2, 1 }, 
        //                     new []{ 1, 2, 5, 6, 4, 3 }, 
        //                     new []{ 3, 4, 2, 5, 1, 6 }};

        //    var actual = Skyscrapers.SolvePuzzle(clues);
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //[Test]
        //public void SolvePuzzle3()
        //{
        //    var clues = new[] { 0, 3, 0, 5, 3, 4, 
        //                        0, 0, 0, 0, 0, 1,
        //                        0, 3, 0, 3, 2, 3,
        //                        3, 2, 0, 3, 1, 0};

        //    var expected = new[]{new []{ 5, 2, 6, 1, 4, 3 }, 
        //                         new []{ 6, 4, 3, 2, 5, 1 }, 
        //                         new []{ 3, 1, 5, 4, 6, 2 }, 
        //                         new []{ 2, 6, 1, 5, 3, 4 }, 
        //                         new []{ 4, 3, 2, 6, 1, 5 }, 
        //                         new []{ 1, 5, 4, 3, 2, 6 }};

        //    var actual = Skyscrapers.SolvePuzzle(clues);
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        Kata k = new Kata();
        [Test]
        public void BetweenNumeralSystems()
        {
            var result = k.Convert("15", Alphabet.DECIMAL, Alphabet.BINARY);
            Assert.AreEqual("1111", result, "\"15\" dec -> bin");
            Assert.AreEqual("17", k.Convert("15", Alphabet.DECIMAL, Alphabet.OCTAL), "\"15\" dec -> oct");
            Assert.AreEqual("10", k.Convert("1010", Alphabet.BINARY, Alphabet.DECIMAL), "\"1010\" bin -> dec");
            Assert.AreEqual("a", k.Convert("1010", Alphabet.BINARY, Alphabet.HEXA_DECIMAL), "\"1010\" bin -> hex");
        }

        [Test]
        public void BetweenOtherBases()
        {
            Assert.AreEqual("a", k.Convert("0", Alphabet.DECIMAL, Alphabet.ALPHA), "\"0\" dec -> alpha");
            Assert.AreEqual("bb", k.Convert("27", Alphabet.DECIMAL, Alphabet.ALPHA_LOWER), "\"27\" dec -> alpha lower");
            Assert.AreEqual("320048", k.Convert("hello", Alphabet.ALPHA_LOWER, Alphabet.HEXA_DECIMAL), "\"hello\" alpha lower -> hex");
            Assert.AreEqual("SAME", k.Convert("SAME", Alphabet.ALPHA_UPPER, Alphabet.ALPHA_UPPER), "\"SAME\" alpha upper -> alpha upper");
        }

        public class Alphabet
        {
            public const string BINARY = "01";
            public const string OCTAL = "01234567";
            public const string DECIMAL = "0123456789";
            public const string HEXA_DECIMAL = "0123456789abcdef";
            public const string ALPHA_LOWER = "abcdefghijklmnopqrstuvwxyz";
            public const string ALPHA_UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public const string ALPHA = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public const string ALPHA_NUMERIC = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }


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
