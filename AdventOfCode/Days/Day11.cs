using System;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day11 : ISolution
    {
        public string PartOne(string[] input)
        {
            var password = input.First();

            return NextPassword(password);
        }

        private string NextPassword(string password)
        {
            do
            {
                var asChars = password.ToCharArray();
                for (var i = asChars.Length - 1; i >= 0; i--)
                {
                    if (asChars[i] == 122)
                    {
                        asChars[i] = (char) 97;
                    }
                    else
                    {
                        asChars[i] += (char) 1;
                        break;
                    }
                }

                password = string.Join("", asChars);
            } while (!IsValid(password));
            

            return password;
        }

        private bool IsValid(string password)
        {
            return _allowedDoubles.Count(password.Contains) >= 2 &&
                   _allowedTriples.Any(password.Contains) &&
                   _invalidCharacters.All(x => !password.Contains(x));
        }

        public string PartTwo(string[] input)
        {
            var password = input.First();

            return NextPassword(NextPassword(password));
        }

        public int Day => 11;
        
        private readonly string[] _allowedDoubles =
        {
            "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp", "qq", "rr",
            "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"
        };
        
        private readonly string[] _allowedTriples =
        {
            "abc", "bcd", "cde", "def", "efg", "fgh", "ghi", "hij", "ijk", "jkl", "klm", "lmn", "mno", "nop", "opq", "pqr", "qrs", "rst",
            "stu", "tuv", "uvw", "vwx", "wxy", "xyz"
        };
        
        private readonly string[] _invalidCharacters = 
        {
            "i", "o", "l"
        };
    }
}