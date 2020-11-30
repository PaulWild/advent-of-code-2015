using System;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOfCode.Days
{
    public class Day04 : ISolution
    {
        public string PartOne(string[] input)
        {
            return Process(input, "00000");
        }
        
        public string PartTwo(string[] input)
        {
            return Process(input, "000000");
        }
        
        private static string Process(string[] input, string startsWith)
        {
            var parsed = input.First();

            int value = 0;
            while (true)
            {
                var toHash = parsed + value;
                var blah = MD5.HashData(System.Text.Encoding.ASCII.GetBytes(toHash));

                var result = Convert.ToHexString(blah);
                if (result.StartsWith(startsWith))
                    return value.ToString();

                value++;
            }
        }


        public int Day => 4;
    }
}