using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day15 : ISolution
    {
        public string PartOne(string[] input)
        {
            var ingredients = ParseIngredients(input);

            var results = (from variation in Variations() 
                let capacity = ingredients[0].Capacity * variation[0] + ingredients[1].Capacity * variation[1] + ingredients[2].Capacity * variation[2] + ingredients[3].Capacity * variation[3] 
                let durability = ingredients[0].Durability * variation[0] + ingredients[1].Durability * variation[1] + ingredients[2].Durability * variation[2] + ingredients[3].Durability * variation[3] 
                let flavor = ingredients[0].Flavor * variation[0] + ingredients[1].Flavor * variation[1] + ingredients[2].Flavor * variation[2] + ingredients[3].Flavor * variation[3] 
                let texture = ingredients[0].Texture * variation[0] + ingredients[1].Texture * variation[1] + ingredients[2].Texture * variation[2] + ingredients[3].Texture * variation[3] 
                let calories = ingredients[0].Calories * variation[0] + ingredients[1].Calories * variation[1] + ingredients[2].Calories * variation[2] + ingredients[3].Calories * variation[3] 
                select (capacity < 0 ? 0 : capacity) 
                    * (durability < 0 ? 0 : durability)
                    * (flavor < 0 ? 0 : flavor)
                    * (texture < 0 ? 0 : texture)).ToList();

            return results.Max().ToString();
        }
        
        public string PartTwo(string[] input)
        {
            var ingredients = ParseIngredients(input);
            
            var results = (from variation in Variations() 
                let capacity = ingredients[0].Capacity * variation[0] + ingredients[1].Capacity * variation[1] + ingredients[2].Capacity * variation[2] + ingredients[3].Capacity * variation[3] 
                let durability = ingredients[0].Durability * variation[0] + ingredients[1].Durability * variation[1] + ingredients[2].Durability * variation[2] + ingredients[3].Durability * variation[3] 
                let flavor = ingredients[0].Flavor * variation[0] + ingredients[1].Flavor * variation[1] + ingredients[2].Flavor * variation[2] + ingredients[3].Flavor * variation[3] 
                let texture = ingredients[0].Texture * variation[0] + ingredients[1].Texture * variation[1] + ingredients[2].Texture * variation[2] + ingredients[3].Texture * variation[3] 
                let calories = ingredients[0].Calories * variation[0] + ingredients[1].Calories * variation[1] + ingredients[2].Calories * variation[2] + ingredients[3].Calories * variation[3] 
                where calories == 500
                select (capacity < 0 ? 0 : capacity) 
                    * (durability < 0 ? 0 : durability)
                    * (flavor < 0 ? 0 : flavor)
                    * (texture < 0 ? 0 : texture)).ToList();

            return results.Max().ToString();
        }
        
        private static List<Ingredient> ParseIngredients(string[] input)
        {
            var ingredients = input
                .Select(x => Regex.Match(x,
                    @"(?'ingredient'[a-zA-Z]+): capacity (?'capacity'[-]?\d+), durability (?'durability'[-]?\d+), flavor (?'flavor'[-]?\d+), texture (?'texture'[-]?\d+), calories (?'calories'[-]?\d+)"))
                .Select(x => new Ingredient
                {
                    Name = x.Groups["ingredient"].Value,
                    Capacity = int.Parse(x.Groups["capacity"].Value),
                    Durability = int.Parse(x.Groups["durability"].Value),
                    Flavor = int.Parse(x.Groups["flavor"].Value),
                    Texture = int.Parse(x.Groups["texture"].Value),
                    Calories = int.Parse(x.Groups["calories"].Value)
                })
                .ToList();
            return ingredients;
        }

        private IEnumerable<long[]> Variations()
        {
            for (long i = 1; i <= 97; i++)
            for (long j = 1; j <= 97; j++)
            for (long k = 1; k <= 97; k++)
            for (long l = 1; l <= 97; l++)
            {
                if (i + j + k + l == 100)
                    yield return new[] {i, j, k, l};
            }
        }


        record Ingredient
        {
            public string Name { get; init; }    
            public int Capacity { get; init; }    
            public int Durability { get; init; }    
            public int Flavor { get; init; }    
            public int Texture { get; init; }    
            public int Calories { get; init; }    
        }
        
        public int Day => 15;
    }
}