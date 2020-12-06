using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace AdventOfCode.Days
{
    public class Day14 : ISolution
    {
        private const int time = 2503;
        public string PartOne(string[] input)
        {
            var reindeers = ParseInput(input);

            return reindeers
                .Select(reindeer => CalculateDistance(reindeer, time))
                .Max()
                .ToString();
        }

        public string PartTwo(string[] input)
        {
            var reindeers = ParseInput(input).ToList();

            var array = new int[reindeers.Count, time];
            for (var i = 1; i <= time; i++)
            for (var j = 0; j < reindeers.Count; j++)
            {
                array[j, i - 1] = CalculateDistance(reindeers[j], i);
            }

            for (var i = 0; i < time; i++)
            {
                var max = Enumerable.Range(0, reindeers.Count).Select(x => array[x, i]).Max();

                for (var arrJ = 0; arrJ < reindeers.Count; arrJ++)
                {
                    array[arrJ, i] = array[arrJ, i] == max ? 1 : 0;
                }
            }

            var points = new List<int>();
            for (var j = 0; j < reindeers.Count; j++)
            {
                points.Add(Enumerable.Range(0, time).Select(x => array[j, x]).Sum());
            }

            return points.Max().ToString();
        }
        
        
        private static IEnumerable<DayReindeer> ParseInput(string[] input)
        {
            return input
                .Select(str => Regex.Match(str,
                    @"(?'deer'[a-zA-Z]+) can fly (?'flySpeed'[0-9]+) km\/s for (?'flyTime'[0-9]+) seconds, but then must rest for (?'restTime'[0-9]+) seconds\."))
                .Select(match => new DayReindeer
                {
                    Speed = int.Parse(match.Groups["flySpeed"].Value),
                    FlightTime = int.Parse(match.Groups["flyTime"].Value),
                    RestTime = int.Parse(match.Groups["restTime"].Value)
                });
        }

        private static int CalculateDistance(DayReindeer reindeer, int timeToCheck)
        {
            var cycleTIme = reindeer.FlightTime + reindeer.RestTime;
            var fullCycles = timeToCheck / cycleTIme;
            var partCycle = timeToCheck % cycleTIme;

            var distance = fullCycles * reindeer.FlightTime * reindeer.Speed +
                           ((partCycle < reindeer.FlightTime ? partCycle : reindeer.FlightTime) * reindeer.Speed);
            return distance;
        }

        private record DayReindeer
        {
            public int Speed { get; init; }
            public int FlightTime { get; init; }
            public int RestTime { get; init; }
        }

        public int Day => 14;
    }
}