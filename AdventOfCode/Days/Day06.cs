using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day06 : ISolution
    {
        public string PartOne(string[] input)
        {
            var commands = ParseCommands(input);
            var lights = CreateLightGrid(false);

            foreach (var command in commands)
            {
                for (var x = command.from.x; x <= command.to.x; x++)
                for (var y = command.from.y; y <= command.to.y; y++)
                {
                    lights[(x, y)] = command.cmd switch
                    {
                        LightCommand.On => true,
                        LightCommand.Off => false,
                        LightCommand.Toggle => !lights[(x, y)],
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
            }

            return lights.Values
                .Count(x => x)
                .ToString();
        }
        
        public string PartTwo(string[] input)
        {
            var commands = ParseCommands(input);
            var lights = CreateLightGrid(0);

            foreach (var command in commands)
            {
                for (var x = command.from.x; x <= command.to.x; x++)
                for (var y = command.from.y; y <= command.to.y; y++)
                {
                    lights[(x, y)] = command.cmd switch
                    {
                        LightCommand.On => lights[(x, y)] + 1,
                        LightCommand.Off =>  lights[(x, y)] == 0 ? 0 : lights[(x, y)] - 1,
                        LightCommand.Toggle => lights[(x, y)] + 2,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
            }

            return lights.Values
                .Sum()
                .ToString();
        }
        
        private static Dictionary<(int, int), T> CreateLightGrid<T>(T startValue) 
        {
            Dictionary<(int, int), T> lights = new();

            for (var x = 0; x < 1000; x++)
            for (var y = 0; y < 1000; y++)
            {
                lights.Add((x, y), startValue);
            }

            return lights;
        }

        private static IEnumerable<(LightCommand cmd, (int x, int y) from, (int x, int y) to)> ParseCommands(string[] input)
        {
            foreach (var str in input)
            {
                var turnOffMatch = Regex.Match(str, "turn off ([0-9]+),([0-9]+) through ([0-9]+),([0-9]+)");
                var turnOnMatch = Regex.Match(str, "turn on ([0-9]+),([0-9]+) through ([0-9]+),([0-9]+)");
                var toggleMatch = Regex.Match(str, "toggle ([0-9]+),([0-9]+) through ([0-9]+),([0-9]+)");
     
                if (turnOnMatch.Success)
                {
                    yield return (LightCommand.On,
                        (Convert.ToInt32(turnOnMatch.Groups[1].Value), Convert.ToInt32(turnOnMatch.Groups[2].Value)),
                        (Convert.ToInt32(turnOnMatch.Groups[3].Value), Convert.ToInt32(turnOnMatch.Groups[4].Value)));
                }
                else if (turnOffMatch.Success)
                {
                    yield return (LightCommand.Off,
                        (Convert.ToInt32(turnOffMatch.Groups[1].Value), Convert.ToInt32(turnOffMatch.Groups[2].Value)),
                        (Convert.ToInt32(turnOffMatch.Groups[3].Value), Convert.ToInt32(turnOffMatch.Groups[4].Value)));
                }
                else if (toggleMatch.Success)
                {
                    yield return (LightCommand.Toggle,
                        (Convert.ToInt32(toggleMatch.Groups[1].Value), Convert.ToInt32(toggleMatch.Groups[2].Value)),
                        (Convert.ToInt32(toggleMatch.Groups[3].Value), Convert.ToInt32(toggleMatch.Groups[4].Value)));
                }
            }
        }
        
        public int Day => 6;
    }
    
    enum LightCommand
    {
        On,
        Off,
        Toggle
    }

}