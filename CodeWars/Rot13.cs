using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public partial class Kata
    {
        private static Dictionary<char, char> _Rot13Dictionary = new Dictionary<char, char>()
        {
            {'a', 'n' },
            {'n', 'a' },
            {'b', 'o' },
            {'o', 'b' },
            {'c', 'p' },
            {'p', 'c' },
            {'d', 'q' },
            {'q', 'd' },
            {'e', 'r' },
            {'r', 'e' },
            {'f', 's' },
            {'s', 'f' },
            {'g', 't' },
            {'t', 'g' },
            {'h', 'u' },
            {'u', 'h' },
            {'i', 'v' },
            {'v', 'i' },
            {'j', 'w' },
            {'w', 'j' },
            {'k', 'x' },
            {'x', 'k' },
            {'l', 'y' },
            {'y', 'l' },
            {'m', 'z' },
            {'z', 'm' },
        };
        public static string Rot13(string input)
        {
            var sb = new StringBuilder();
            foreach (var ch in input)
            {

                var substitutedChar = char.IsLetter(ch)
                    ? char.IsUpper(ch)
                        ? ToUpperChar(_Rot13Dictionary[ToLowerChar(ch)])
                        : _Rot13Dictionary[ch]
                    : ch;
                sb.Append(substitutedChar);
            }
            return sb.ToString();
        }

        private static char ToUpperChar(char ch)
        {
            return ch.ToString().ToUpper()[0];
        }

        private static char ToLowerChar(char ch)
        {
            return ch.ToString().ToLower()[0];
        }
    }
}
