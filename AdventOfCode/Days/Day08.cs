using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day08 : ISolution
    {
        public string PartOne(string[] input)
        {
            var totalNumberOfCharacters = 0;
            var totalNumberOfMemoryCharacters = 0;
            foreach (var str in input)
            {
                var hexCharacters = Regex.Matches(str,@"\\x[0-9a-g]{2}");
                var escapedCharacters = Regex.Matches(str, @"\\""|\\\\");

                var specialCharacters = (hexCharacters.Count * 4) + (escapedCharacters.Count * 2) + 2;

                var numberOfMemoryCharacters = (str.Length - specialCharacters) + hexCharacters.Count + escapedCharacters.Count;

                totalNumberOfMemoryCharacters += numberOfMemoryCharacters;
                totalNumberOfCharacters += (str.Length);
            }

            return (totalNumberOfCharacters - totalNumberOfMemoryCharacters).ToString();
        }

        public string PartTwo(string[] input)
        {
            var totalNumberOfCharacters = 0;
            var totalNumberOfEncodedCharacters = 0;
            foreach (var str in input)
            {
                var hexCharacters = Regex.Matches(str,@"\\x[0-9a-g]{2}");
                var escapedCharacters = Regex.Matches(str, @"\\""|\\\\");

                totalNumberOfEncodedCharacters += str.Length + (hexCharacters.Count) + (escapedCharacters.Count * 2) + 4;
                totalNumberOfCharacters += (str.Length);
            }

            return (totalNumberOfEncodedCharacters - totalNumberOfCharacters).ToString();
        }

        public int Day => 8;
    }
}