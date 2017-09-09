using System;
using Euler;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class Euler_Test
    {
        //[TestCase("Euler.Euler71, Euler", 428570)]
        //[TestCase("Euler.Euler7, Euler", 23514624000)]
        //[TestCase("Euler.Euler11, Euler", 70600674)]
        //[TestCase("Euler.Euler4, Euler", 906609)]
        //[TestCase("Euler.Euler12, Euler", 76576500)]
        //[TestCase("Euler.Euler13, Euler", "5537376230")]
        //[TestCase("Euler.Euler14, Euler", 837799)]
        //[TestCase("Euler.Euler15, Euler", "137846528820")]
        //[TestCase("Euler.Euler16, Euler", 1366)]
        //[TestCase("Euler.Euler17, Euler", 21124)]
        //[TestCase("Euler.Euler18, Euler", 1074)]
        //[TestCase("Euler.Euler67, Euler", 7273)]
        //[TestCase("Euler.Euler19, Euler", 171)]
        //[TestCase("Euler.Euler20, Euler", 648)]
        //[TestCase("Euler.Euler21, Euler", 31626)]
        //[TestCase("Euler.Euler22, Euler", 871198282)]
        //[TestCase("Euler.Euler23, Euler", 4179871)]
        //[TestCase("Euler.Euler25, Euler", 4782)]
        //[TestCase("Euler.Euler26, Euler", 983)]
        //[TestCase("Euler.Euler27, Euler", -59231)]
        [TestCase("Euler.Euler250, Euler", (long)0)]
        public void EulerTest(string eulerClass, object expectedResult)
        {
            Type type = Type.GetType(eulerClass);
            IEuler instance = (IEuler)Activator.CreateInstance(type);
            Assert.AreEqual(expectedResult, instance.Run());
        }
    }
}
