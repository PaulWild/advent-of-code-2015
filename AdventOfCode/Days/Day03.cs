using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day03 : ISolution
    {
        public string PartOne(string[] input)
        {
            var directions = input.First().ToCharArray();

            (int x, int y) pos = (0, 0);
            var visited = new HashSet<(int, int)> {pos};

            foreach (var direction in  directions)
            {
                pos = Move(direction, pos.x, pos.y);

                visited.Add(pos);
            }

            return visited.Count.ToString();
        }

        public string PartTwo(string[] input)
        {
            var directions = input.First().ToCharArray();

            (int x, int y) pos = (0, 0);
            (int x, int y) roboPos = (0, 0);
            var visited = new HashSet<(int, int)> {pos};

            var santa = true;
            foreach (var direction in  directions)
            {
                var (x, y) = santa ? pos : roboPos;
                
                var newPos = Move(direction, x, y);

                visited.Add(newPos);

                if (santa)
                {
                    pos = newPos;
                }
                else
                {
                    roboPos = newPos;
                }

                santa = !santa;
            }

            return visited.Count.ToString();
        }

        private static (int, int) Move(char direction, int x, int y)
        {
            return direction switch
            {
                '^' => (x, y + 1),
                '>' => (x + 1, y),
                '<' => (x - 1, y),
                'v' => (x, y - 1),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public int Day => 3;
    }
}