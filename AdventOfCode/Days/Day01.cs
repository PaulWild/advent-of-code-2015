using System;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day01 : ISolution
    {
        public string PartOne(string[] input)
        {
            var parsedInput = input.First();
            var parsedInputSplit = parsedInput.ToCharArray();

            var pos = parsedInputSplit.Sum(command => command switch
            {
                '(' => 1,
                ')' => -1,
                _ => throw new ArgumentOutOfRangeException(nameof(command), command, null)
            });

            return pos.ToString();
        }

        public string PartTwo(string[] input)
        {
            var parsedInput = input.First();
            var parsedInputSplit = parsedInput.ToCharArray();

            var pos = 0;
            var index = 0;

            foreach (var command in parsedInputSplit)
            {
                index++;
                pos += command switch
                {
                    '(' => 1,
                    ')' => -1,
                    _ => throw new ArgumentOutOfRangeException(nameof(command), command, null)
                };

                if (pos == -1) return index.ToString();
            }

            throw new Exception("finished without stopping");

        }

        public int Day => 1;
    }
}