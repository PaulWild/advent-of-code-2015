using System;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day2 : ISolution
    {
        public string PartOne(string[] input)
        {
            var parsedInput = input.Select(x => x.Split("x").Select(y => Convert.ToInt32(y)).ToArray());
            
            return (from present in parsedInput 
                let edgeOne = 2 * present[0] * present[1] 
                let edgeTwo = 2 * present[1] * present[2] 
                let edgeThree = 2 * present[0] * present[2] 
                let slack = Math.Min(edgeOne, Math.Min(edgeTwo, edgeThree)) / 2 
                select edgeOne + edgeTwo + edgeThree + slack).Sum().ToString();
        }

        public string PartTwo(string[] input)
        {
            var parsedInput = input.Select(x => x.Split("x").Select(y => Convert.ToInt32(y)).ToArray());
            
            return (from present in parsedInput 
                let perimeterOne = present[0] * 2 + present[1] * 2 
                let perimeterTwo = present[0] * 2 + present[2] * 2 
                let perimeterThree = present[1] * 2 + present[2] * 2 
                let volume = present[0] * present[1] * present[2] 
                select Math.Min(perimeterOne, Math.Min(perimeterTwo, perimeterThree)) + volume).Sum().ToString();
        }

        public int Day => 2;
    }
}