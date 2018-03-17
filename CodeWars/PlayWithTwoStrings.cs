using System.Linq;
using System.Text;

namespace CodeWars
{
    public partial class Kata
    {
        private const int _DiffCapitalLower = 'A' - 'a';

        public string workOnStrings(string a, string b)
        {
            var aOccurences = GetOccurences(a);
            var bOccurences = GetOccurences(b);
            return SwapCharByOccurence(a, bOccurences) + SwapCharByOccurence(b, aOccurences);
        }

        private string SwapCharByOccurence(string str, bool[] occurences)
        {
            var sb = new StringBuilder();
            foreach (var ch in str)
            {
                var chResult = occurences[GetLower(ch) - 'a'] ? Swap(ch) : ch;
                sb.Append(chResult);
            }
            return sb.ToString();
        }

        private char Swap(char ch)
        {
            return (char)(char.IsLower(ch) ? ch + _DiffCapitalLower : ch - _DiffCapitalLower);
        }

        private char GetLower(char ch)
        {
            return ch.ToString().ToLower().First();
        }

        private bool[] GetOccurences(string str)
        {
            var result = new bool[26];
            foreach (var ch in str.ToLower())
            {
                var charNumber = ch - 'a';
                result[charNumber] = !result[charNumber];
            }
            return result;
        }
    }
}