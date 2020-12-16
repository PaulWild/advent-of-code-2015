using System;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day20 : ISolution
    {
        //Brute Force
        public string PartOne(string[] input)
        {
            var minimumPresents = int.Parse(input.Single());
            
            var currentHigh = 0;
            for (int i = 700000;; i++)
            {
                if (i % 10000 == 0)
                    Console.WriteLine($"At house number: {i}. Highest Present Count {currentHigh}");
                
                var numberPresents = PresentsForHouse(i);
            
                if (numberPresents > currentHigh)
                    currentHigh = numberPresents;
                
                if (numberPresents > minimumPresents)
                    return i.ToString();
            }
        }

        public int PresentsForHouse(int houseNumber)
        {
            var presents = 0;
            for (int elf = 1; elf <= houseNumber/2; elf++)
            {
                if (houseNumber % elf == 0)
                    presents += elf * 10;
            }

            return presents + (houseNumber * 10);
        }

        public int PresentsForHousePartTwo(int houseNumber)
        {
            var presents = 0;
            for (int elf = 1; elf <= houseNumber/2; elf++)
            {
                if (houseNumber % elf == 0 && houseNumber / elf <= 50)
                    presents += elf * 11;
            }

            return presents + (houseNumber * 11);
        }
        
        //Brute Force
        public string PartTwo(string[] input)
        {
            var minimumPresents = int.Parse(input.Single());

            var currentHigh = 0;
            for (int i = 700000;; i++)
            {
                if (i % 10000 == 0)
                    Console.WriteLine($"At house number: {i}. Highest Present Count {currentHigh}");
                
                var numberPresents = PresentsForHousePartTwo(i);

                if (numberPresents > currentHigh)
                    currentHigh = numberPresents;
                
                if (numberPresents > minimumPresents)
                    return i.ToString();
            }
        }

        public int Day => 20;
    }
}