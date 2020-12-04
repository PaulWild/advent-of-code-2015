using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day13 : ISolution
    {
        public string PartOne(string[] input)
        {
            var happinessMaps = ParseInput(input);

            var people = happinessMaps
                .SelectMany(x => new[] {x.Person, x.To})
                .Distinct().ToList();
            
            return CalculateHappinessTotals(people, happinessMaps).Max().ToString();      
        }
        
        public string PartTwo(string[] input)
        {
            var happinessMaps = ParseInput(input);

            var people = happinessMaps
                .SelectMany(x => new[] {x.Person, x.To})
                .Distinct().ToList();

            happinessMaps.AddRange(people.SelectMany(person => new [] {
                new DayHappinessMap {Person = "PaulW", To = person, HappinessPoints = 0},
                new DayHappinessMap {Person = person, To = "PaulW", HappinessPoints = 0}}));
            
            return CalculateHappinessTotals(people, happinessMaps).Max().ToString();
        }

        private static List<DayHappinessMap> ParseInput(string[] input)
        {
            var happinessMaps = (from str in input
                select Regex.Match(str,
                    @"(?'from'[a-zA-Z]+) would (?'posneg'gain|lose) (?'amount'[0-9]+) happiness units by sitting next to (?'to'[a-zA-Z]+)\.")
                into match
                let posNeg = match.Groups["posneg"].Value == "gain" ? 1 : -1
                select new DayHappinessMap()
                {
                    Person = match.Groups["from"].Value,
                    To = match.Groups["to"].Value,
                    HappinessPoints = int.Parse(match.Groups["amount"].Value) * posNeg
                }).ToList();
            return happinessMaps;
        }

        private record DayHappinessMap
        {
            public string Person { get; init; }
            public string To { get; init; }
            public int HappinessPoints { get; init; }
        }

        private static IEnumerable<int> CalculateHappinessTotals(IReadOnlyCollection<string> people, IReadOnlyCollection<DayHappinessMap> happinessMaps)
        {
            List<int> happinessTotals = new();
            var numberPeople = people.Count;
            
            foreach (var seats in people.Permutations())
            {
                var happinessTotal = 0;
                for (var i = 0; i < numberPeople; i++)
                {
                    var left = i - 1 < 0 ? numberPeople - 1 : i - 1;
                    var right = i + 1 == numberPeople ? 0 : i + 1;

                    happinessTotal += happinessMaps.Single(x => x.Person == seats[i] && x.To == seats[left])
                        .HappinessPoints;

                    happinessTotal += happinessMaps.Single(x => x.Person == seats[i] && x.To == seats[right])
                        .HappinessPoints;
                }

                happinessTotals.Add(happinessTotal);
            }

            return happinessTotals;
        }

        public int Day => 13;
    }
}