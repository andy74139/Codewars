using NUnit.Framework;

namespace CodeWars.Tests
{
    [TestFixture]
    public class KataTests
    {
        [TestCase("knife", ExpectedResult = "The Knife")]
        [TestCase("tart", ExpectedResult = "Tartart")]
        [TestCase("sandles", ExpectedResult = "Sandlesandles")]
        [TestCase("bed", ExpectedResult = "The Bed")]
        public string BandNameGeneratorTest(string str)
        {
            return Kata.BandNameGenerator(str);
        }

        [Test]
        public void CountingDuplicatesTest()
        {
            Assert.AreEqual(0, Kata.DuplicateCount(""));
            Assert.AreEqual(0, Kata.DuplicateCount("abcde"));
            Assert.AreEqual(2, Kata.DuplicateCount("aabbcde"));
            Assert.AreEqual(2, Kata.DuplicateCount("aabBcde"), "should ignore case");
            Assert.AreEqual(1, Kata.DuplicateCount("Indivisibility"));
            Assert.AreEqual(2, Kata.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
        }
    }
}
