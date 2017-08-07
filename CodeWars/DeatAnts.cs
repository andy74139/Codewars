using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public partial class Kata
    {
        public static int DeadAntCount(string park)
        {
            if (string.IsNullOrEmpty(park))
                return 0;

            const string ant = "ant";
            var parkWithoutAliveAnt = park.Replace(ant, "");
            
            return MaxCountOfAnt(ant, parkWithoutAliveAnt);
        }

        private static int MaxCountOfAnt(string ant, string parkWithoutAliveAnt)
        {
            var counts = new Dictionary<char, int>();
            foreach (var c in ant)
                counts[c] = 0;

            foreach (var place in parkWithoutAliveAnt.Where(ant.Contains))
                counts[place]++;

            return counts.Values.Max();
        }
    }

}
