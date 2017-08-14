using System.Linq;

namespace CodeWars
{
    public partial class Kata
    {
        public static string BandNameGenerator(string str)
        {
            var firstCapital = str.First().ToString().ToUpper();
            var strWithoutFirst = str.Substring(1);

            if (str.First() == str.Last())
                return firstCapital + strWithoutFirst + strWithoutFirst;
            return "The " + firstCapital + strWithoutFirst;
        }
    }
}
