using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    public static class DayEnumerableExtensions
    {
        public static IEnumerable<List<string>> Permutations(this IEnumerable<string> items) 
        {
            if (items.Count() == 1)
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