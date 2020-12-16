using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day19 : ISolution
    {
        public string PartOne(string[] input)
        {
            var (maps, molecule) = ParseInput(input);

            var newMolecules = CreateNewMolecules(maps, molecule);

            return newMolecules.Distinct().Count().ToString();
        }

        private static List<string> CreateNewMolecules(List<(string @from, string to)> maps, string molecule)
        {
            var newMolecules = (
                from map in maps
                let matches = Regex.Matches(molecule, map.@from).Select(x => x.Index)
                from match in matches
                let start = molecule.Substring(0, match)
                let end = molecule.Substring(match + map.@from.Length)
                select start + map.to + end).ToList();
            return newMolecules;
        }

        private static (List<(string @from, string to)>, string molecule) ParseInput(string[] input)
        {
            List<(string from, string to)> maps = new();
            var molecule = "";
            bool finished = false;
            foreach (var row in input)
            {
                if (finished)
                {
                    molecule = row;
                }
                else if (string.IsNullOrWhiteSpace(row))
                {
                    finished = true;
                }
                else
                {
                    var items = row.Split(" => ");
                    maps.Add((items[0], items[1]));
                }
            }

            return (maps, molecule);
        }
        
        //I couldn't solve this myself - all brute force attempts failed.
        //This is based on the solution from reddit by askalski
        public string PartTwo(string[] input)
        {
            var (_, molecule) = ParseInput(input);

            var lb = new Regex("Rn");
            var comma = new Regex("Y");
            var rb = new Regex("Ar");
            
            //Get number of molecules by removed lower case and counting. 
            var numberOfMolecules = molecule.Length- Regex.Matches(molecule, "[a-z]").Count();
            
            return (numberOfMolecules- (lb.Matches(molecule).Count + rb.Matches(molecule).Count) -
                    (comma.Matches(molecule).Count * 2) - 1).ToString();
            
        }
        
        public int Day => 19;
    }
}