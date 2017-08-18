using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public partial class Kata
    {
        public static int DuplicateCount(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            var singleOccurs = new Dictionary<char, bool>();
            var dupliOccurs = new Dictionary<char, bool>();
            foreach (var c in str)
            {
                var lowerC = c.ToString().ToLower().First();
                if (!singleOccurs.ContainsKey(lowerC))
                    singleOccurs[lowerC] = true;
                else
                    dupliOccurs[lowerC] = true;
            }

            return dupliOccurs.Count;
        }
    }
}
