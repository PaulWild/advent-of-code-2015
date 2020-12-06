using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day16 : ISolution
    {
        public string PartOne(string[] input)
        {
            var sues = input.Select(x => Regex.Match(x,
                    @"Sue \d+: (?'fst'[a-zA-Z]+): (?'fstVal'[0-9]+), (?'snd'[a-zA-Z]+): (?'sndVal'[0-9]+), (?'thd'[a-zA-Z]+): (?'thdVal'[0-9]+)"))
                .Select(x => new Dictionary<string, int>()
                {
                    {x.Groups["fst"].Value, int.Parse(x.Groups["fstVal"].Value)},
                    {x.Groups["snd"].Value, int.Parse(x.Groups["sndVal"].Value)},
                    {x.Groups["thd"].Value, int.Parse(x.Groups["thdVal"].Value)},
                }).ToList();

            var mfcsamOutput = new Dictionary<string, int>()
            {
                {"children", 3},
                {"cats", 7},
                {"samoyeds", 2},
                {"pomeranians", 3},
                {"akitas", 0},
                {"vizslas", 0},
                {"goldfish", 5},
                {"trees", 3},
                {"cars", 2},
                {"perfumes", 1},
            };

            for(var sue = 0; sue< sues.Count; sue++)
            {
                var match = true;
                foreach (var (key, value) in sues[sue])
                {
                    if (mfcsamOutput[key] != value) 
                    {
                        match = false;
                    }
                }

                if (match)
                {
                    return (sue + 1).ToString();
                }
            }

            return "-1";
        }

        public string PartTwo(string[] input)
        {
            var sues = input.Select(x => Regex.Match(x,
                    @"Sue \d+: (?'fst'[a-zA-Z]+): (?'fstVal'[0-9]+), (?'snd'[a-zA-Z]+): (?'sndVal'[0-9]+), (?'thd'[a-zA-Z]+): (?'thdVal'[0-9]+)"))
                .Select(x => new Dictionary<string, int>()
                {
                    {x.Groups["fst"].Value, int.Parse(x.Groups["fstVal"].Value)},
                    {x.Groups["snd"].Value, int.Parse(x.Groups["sndVal"].Value)},
                    {x.Groups["thd"].Value, int.Parse(x.Groups["thdVal"].Value)},
                }).ToList();

            var mfcsamOutput = new Dictionary<string, int>()
            {
                {"children", 3},
                {"cats", 7},
                {"samoyeds", 2},
                {"pomeranians", 3},
                {"akitas", 0},
                {"vizslas", 0},
                {"goldfish", 5},
                {"trees", 3},
                {"cars", 2},
                {"perfumes", 1},
            };

            for(var sue = 0; sue< sues.Count; sue++)
            {
                var match = true;
                foreach (var (key, value) in sues[sue])
                {
                    switch (key)
                    {
                        case "cats":
                        {
                            if (mfcsamOutput[key] >= value)
                                match = false;
                            break;
                        }
                        case "trees":
                        {
                            if (mfcsamOutput[key] >= value)
                                match = false;
                            break;
                        }
                        case "pomeranians":
                        {
                            if (mfcsamOutput[key] <= value)
                                match = false;
                            break;
                        }
                        case "goldfish":
                        {
                            if (mfcsamOutput[key] <= value)
                                match = false;
                            break;
                        }
                        default:
                        {
                            if (mfcsamOutput[key] != value)
                            {
                                match = false;
                            }
                            break;
                        }
                    }
                }

                if (match)
                {
                    return (sue + 1).ToString();
                }
            }

            return "-1";
        }

        public int Day => 16;
    }
}