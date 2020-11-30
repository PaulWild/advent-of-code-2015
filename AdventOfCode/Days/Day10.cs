using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AdventOfCode.Days
{
    public class Day10 : ISolution
    {
        public string PartOne(string[] input)
        {
            var str = input.First();

            for (var i = 0; i < 40; i++)
            {
                str = Process(str);
            }
            return str.Length.ToString();
        }

        private static string Process(string input)
        {
            var str = input.ToCharArray();
            List<(int number, int count)> counts = new();
            foreach (var num in str)
            {
                var number = Convert.ToInt32(num.ToString());
                if (counts.Count == 0)
                {
                    counts.Add((number, 1));
                    continue;
                }

                if (number == counts.Last().number)
                {
                    var (lastNumber, lastCount) = counts.Last();
                    counts[^1] = (lastNumber, ++lastCount);
                }
                else
                {
                    counts.Add((number, 1));
                }
            }

            var sb = new StringBuilder();
            foreach (var (number, count) in counts)
            {
                sb.Append($"{count}{number}");
            }

            return sb.ToString();
        }

        public string PartTwo(string[] input)
        {
        
            var str = input.First();

            for (var i = 0; i < 50; i++)
            {
                str = Process(str);
            }
            return str.Length.ToString(); }

        public int Day => 10;
    }
}