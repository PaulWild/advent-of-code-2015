using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day5 : ISolution
    {
        public string PartOne(string[] input)
        {
            var count = (from str in input 
                let numberOfVowels = str.ToCharArray().Count(x => _vowels.Contains(x)) 
                let hasNiceDoubles = _niceDoubles.Any(str.Contains) 
                let hasNaughtyDoubles = _naughtyDoubles.Any(str.Contains)
                where numberOfVowels >= 3 && hasNiceDoubles && !hasNaughtyDoubles 
                select numberOfVowels).Count();

            return count.ToString();
        }

        public string PartTwo(string[] input)
        {
            var count = 0; 
            foreach (var inputString in input)
            {
                List<(string str, int pos)> twoLetterCombos = new();
                var hasThreeLetterCombos = false;

                for (var i = 0; i < inputString.Length - 1; i++)
                {
                    (string str, int pos) two = (inputString.Substring(i, 2), i);
                    if (!twoLetterCombos.Any(x => x.str == two.str && Math.Abs(x.pos - two.pos) == 1))
                    {
                        twoLetterCombos.Add(two);                     
                    } 
                    
                    if ( inputString.Length - i > 2)
                    {
                        if (inputString.Substring(i, 1) == inputString.Substring(i + 2, 1))
                        {
                            hasThreeLetterCombos = true;
                        }
                    }
                } 
                
                var hasTwoLetterCombos = twoLetterCombos
                    .Select(x => x.str)
                    .GroupBy(x => x)
                    .ToDictionary(x => x.Key, x=> x.Count())
                    .Values.
                    Any(x => x >= 2);
 

                if (hasThreeLetterCombos && hasTwoLetterCombos)
                {
                    count++;
                }
                
            }

            return count.ToString();

        }

        private readonly char[] _vowels =  {'a', 'e', 'i', 'o', 'u'};

        private readonly string[] _niceDoubles =
        {
            "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp", "qq", "rr",
            "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"
        };
        
        private readonly string[] _naughtyDoubles =
        {
            "ab", "cd", "pq", "xy"
        };

        public int Day => 5;
    }
}