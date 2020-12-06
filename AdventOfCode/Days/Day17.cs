using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day17 : ISolution
    {
        public string PartOne(string[] input)
        {
            var numbers = input.Select(int.Parse).ToList();

            return Combinations(new List<int>(), numbers).Count().ToString();
        }
        
        public string PartTwo(string[] input)
        {
            var numbers = input.Select(int.Parse).ToList();

            var combos = Combinations(new List<int>(), numbers).ToList();
            var minLength = combos.Select(x => x.Count).Min();

            return combos.Count(x => x.Count == minLength).ToString();
        }

        private static IEnumerable<List<int>> Combinations(List<int> foo, IList<int> rest)
        {
            if (foo.Sum() == 150)
            {
                yield return foo;           
            }
            else if (rest.Any() && foo.Sum() < 150)
            {
                var first = rest.First();
                var tail = rest.Skip(1).ToList();

                var blah = foo.Select(x => x).ToList();
                blah.Add(first);
                
                foreach (var combo in Combinations(blah, tail))
                {
                    yield return combo;
                }
                foreach (var combo in Combinations(foo, tail))
                {
                    yield return combo;
                }
            }
        } 
        
        public int Day => 17;
    }
}