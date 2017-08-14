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
    }
}
