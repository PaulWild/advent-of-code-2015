using System;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day12 : ISolution
    {
        public string PartOne(string[] input)
        {
            var matches = Regex.Matches(input.First(), @"[-]?\d+");
            return matches.Select(x => int.Parse(x.Value)).Sum().ToString();
        }

        public string PartTwo(string[] input)
        {
            var str = input.First();

            var blah = JsonSerializer.Deserialize<JsonElement>(str);

            return ParseJsonElement(blah).ToString();
        }

        private static int ParseJsonElement(JsonElement obj)
        {
            var toReturn = 0;
            switch (obj.ValueKind)
            {
                case JsonValueKind.Number:
                    toReturn += obj.GetInt32();
                    break;
                case JsonValueKind.String:
                {
                    if (obj.GetString() == "red")
                        throw new ArgumentException("object has red property");
                    
                    if (int.TryParse(obj.GetString(), out var stringVal))
                    {
                        toReturn += stringVal;
                    }

                    break;
                }
                case JsonValueKind.Object:
                    try
                    {
                        var toAdd = obj.EnumerateObject().Sum(x => ParseJsonElement(x.Value));
                        toReturn += toAdd;
                    }
                    catch (ArgumentException)
                    {
                        
                    }

                    break;
                case JsonValueKind.Array:
                    foreach (var arrayVal in obj.EnumerateArray())
                    {
                        try
                        {
                            toReturn += ParseJsonElement(arrayVal);
                        }
                        catch (ArgumentException)
                        {
                        }
                    }
                   
                    break;
                case JsonValueKind.Undefined:
                    break;
                case JsonValueKind.True:
                    break;
                case JsonValueKind.False:
                    break;
                case JsonValueKind.Null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

                return toReturn;
        }
        
        public int Day => 12;
    }
}