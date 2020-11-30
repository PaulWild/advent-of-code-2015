using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day9 : ISolution
    {
        public string PartOne(string[] input)
        {
            var distances = Distances(input);

            return distances.Min().ToString();
        }
        
        public string PartTwo(string[] input)
        {
            var distances = Distances(input);

            return distances.Max().ToString();
        }

        private IEnumerable<int> Distances(IEnumerable<string> input)
        {
            var edges = input
                .Select(str => Regex.Match(str, @"(?'from'[a-zA-Z]+) to (?'to'[a-zA-Z]+) = (?'distance'[0-9]+)"))
                .SelectMany(hexCharacters => new Edge[]
                {
                    new()
                    {
                        From = hexCharacters.Groups["from"].Value,
                        To = hexCharacters.Groups["to"].Value,
                        Distance = Convert.ToInt32(hexCharacters.Groups["distance"].Value)
                    },
                    new()
                    {
                        From = hexCharacters.Groups["to"].Value,
                        To = hexCharacters.Groups["from"].Value,
                        Distance = Convert.ToInt32(hexCharacters.Groups["distance"].Value)
                    }
                }).ToList();

            var vertices = edges.SelectMany(x => new[] {x.From, x.To}).Distinct().ToList();

            var permutations = Permutations(vertices);

            var distances = new List<int>();
            foreach (var permutation in permutations)
            {
                var distance = 0;
                for (var i = 0; i < permutation.Count - 1; i++)
                {
                    var edge = edges.FirstOrDefault(x => x.From == permutation[i] && x.To == permutation[i + 1]);
                    if (edge == null)
                    {
                        distances.Add(int.MaxValue);
                        break;
                    }

                    distance += edge.Distance;
                }

                distances.Add(distance);
            }

            return distances;
        }
        
        public int Day => 9;

        private record Edge
        {
            public string From { get; init; }
            
            public string To { get; init; }
            
            public int Distance { get; init; }
        }

        private IEnumerable<List<string>> Permutations(List<string> items) 
        {
            if (items.Count == 1)
            {
                yield return new [] {items.First()}.ToList();
            }
            
            foreach (var item in  items)
            {
                var remaining = items.Where(x => x != item);
                var other = Permutations(remaining.ToList());

                foreach (var foo in other)
                {
                    yield return new[] {item}.Concat(foo).ToList();
                }
            }

        }
    }
}