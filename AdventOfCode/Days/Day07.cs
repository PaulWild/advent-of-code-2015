using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day07 : ISolution
    {
        public string PartOne(string[] input)
        {
            var parsed = ParseInput(input).ToList();
            var cache = new ConcurrentDictionary<string, int>();

            var foo = new List<(string wire, int signal)>();
            foreach (var (wire,_) in parsed)
            {
                var res = GetValue(wire, parsed, cache);
                foo.Add((wire, res));
            }

            return string.Join(",", foo.OrderBy(x => x.wire).Select(x => $"{x.wire} = {(ushort)x.signal}").ToList());

        }

        public int GetValue(string wire, List<(string wire, Operation operation)> operations, ConcurrentDictionary<string, int> cache)
        {
            var (_, operation) = operations.Single(x => x.wire == wire);

            return cache.GetOrAdd(wire, x =>

                operation.Command switch
                {
                    "VALUE" => int.TryParse(operation.L, out _)
                        ? Convert.ToInt32(operation.L)
                        : GetValue(operation.L, operations, cache),
                    "AND" => (int.TryParse(operation.L, out _)
                        ? Convert.ToInt32(operation.L)
                        : GetValue(operation.L, operations, cache)) & GetValue(operation.R, operations, cache),
                    "OR" => GetValue(operation.L, operations, cache) | GetValue(operation.R, operations, cache),
                    "LSHIFT" => GetValue(operation.L, operations, cache) << Convert.ToInt32(operation.R),
                    "RSHIFT" => GetValue(operation.L, operations, cache) >> Convert.ToInt32(operation.R),
                    "NOT" => ~GetValue(operation.R, operations, cache),
                    _ => throw new ArgumentOutOfRangeException()

                });
        }
        
        public string PartTwo(string[] input)
        {
            var parsed = ParseInput(input).ToList();
            var cache = new ConcurrentDictionary<string, int>();
            cache.GetOrAdd("b", 3176);

            var foo = new List<(string wire, int signal)>();
            foreach (var (wire,_) in parsed)
            {
                var res = GetValue(wire, parsed, cache);
                foo.Add((wire, res));
            }

            return string.Join(",", foo.OrderBy(x => x.wire).Select(x => $"{x.wire} = {(ushort)x.signal}").ToList());
        }

        public IEnumerable<(string wire, Operation operation)> ParseInput(string[] input)
        {
            foreach (var str in input)
            {
                var operation = Regex.Match(str, "(?'left'[0-9a-z]+) (?'op'OR|AND|RSHIFT|LSHIFT) (?'right'[0-9a-z]+) -> (?'wire'[a-z]+)");
                var not = Regex.Match(str, "NOT (?'right'[a-z]+) -> (?'wire'[a-z]+)");
                var value = Regex.Match(str, "(?'left'[0-9a-z]+) -> (?'wire'[a-z]+)");

                if (operation.Success)
                {
                    yield return (operation.Groups["wire"].Value, new Operation()
                    {
                        Command = operation.Groups["op"].Value,
                        L = operation.Groups["left"].Value,
                        R = operation.Groups["right"].Value
                    });
                }
                else if (not.Success)
                {
                    yield return (not.Groups["wire"].Value ,new Operation()
                    {
                        Command = "NOT",
                        R = not.Groups["right"].Value
                    });
                }
                else if (value.Success)
                {
                    yield return (value.Groups["wire"].Value ,new Operation()
                    {
                        Command = "VALUE",
                        L = value.Groups["left"].Value
                    });
                }
                else
                {
                    throw new Exception($"Fuck you: {str}");
                }
                
            }
        }

        public int Day => 7;
        public record Operation
        {
            public string Command { get; init; }
            public string L { get; init; }
            public string R { get; init; }
            
        }
    }
}