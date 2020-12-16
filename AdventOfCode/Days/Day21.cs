using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day21 : ISolution
    {
        public string PartOne(string[] input)
        {
            var items = ItemCombinations();

            return (from itemCol in items 
                let myDamage = itemCol.Select(x => x.Damage).Sum() 
                let myArmour = itemCol.Select(x => x.Armor).Sum() 
                let cost = itemCol.Select(x => x.Cost).Sum() 
                where WinFight(100, myDamage, myArmour) 
                select cost).Min().ToString();
            
        }

        private IEnumerable<List<Item>> ItemCombinations()
        {
            return (from weapon in _weapons 
                from pieceOfArmor in _armor 
                from ring in _rings
                from otherRing in _rings 
                where ring != otherRing 
                select new List<Item> {weapon, pieceOfArmor, ring, otherRing})
                .Distinct();
        }

        bool WinFight(int myHp, int myDamage, int myArmour)
        {
            var bossHp = 109;
            var bossDamage = 8;
            var bossArmour = 2;
            
            while (myHp > 0)
            {
                bossHp = myDamage - bossArmour > 0 ? bossHp - (myDamage - bossArmour) : bossHp - 1;

                if (bossHp <= 0)
                    return true;
                
                myHp = bossDamage - myArmour > 0 ? myHp - (bossDamage - myArmour) : myHp - 1;
            }

            return false;
        }

        public string PartTwo(string[] input)
        {
            var items = ItemCombinations();

            return (
                from itemCol in items 
                let myDamage = itemCol.Select(x => x.Damage).Sum() 
                let myArmour = itemCol.Select(x => x.Armor).Sum() 
                let cost = itemCol.Select(x => x.Cost).Sum() 
                where !WinFight( 100, myDamage, myArmour) 
                select cost).Max().ToString();
        }
        
        record Item
        {
            public string Name { get; set; }
            public int Cost { get; set; }
            public int Damage { get; set; }
            public int Armor { get; set; }
        }
        
        private readonly List<Item> _weapons = new()
        {
            new Item
            {
                Name = "Dagger",
                Cost = 8,
                Damage = 4,
                Armor = 0,
            },
            new Item
            {
                Name = "Shortsword",
                Cost = 10,
                Damage = 5,
                Armor = 0,
            },
            new Item
            {
                Name = "Warhammer",
                Cost = 25,
                Damage = 6,
                Armor = 0,
            },
            new Item
            {
                Name = "Longsword",
                Cost = 40,
                Damage = 7,
                Armor = 0,
            },
            new Item
            {
                Name = "Greataxe",
                Cost = 74,
                Damage = 8,
                Armor = 0,
            }
        };
        
        private readonly List<Item> _armor = new()
        {
            new Item
            {
                Name = "None",
                Cost = 0,
                Damage = 0,
                Armor = 0,
            },
            new Item
            {
                Name = "Leather",
                Cost = 13,
                Damage = 0,
                Armor = 1,
            },
            new Item
            {
                Name = "Chainmail",
                Cost = 31,
                Damage = 0,
                Armor = 2,
            },
            new Item
            {
                Name = "Splintmail",
                Cost = 53,
                Damage = 0,
                Armor = 3,
            },
            new Item
            {
                Name = "Bandedmail",
                Cost = 75,
                Damage = 0,
                Armor = 4,
            },
            new Item
            {
                Name = "Platemail",
                Cost = 102,
                Damage = 0,
                Armor = 5,
            }
        };
        
        private readonly List<Item> _rings = new()
        {
            new Item
            {
                Name = "None",
                Cost = 0,
                Damage = 0,
                Armor = 0,
            },
            new Item
            {
                Name = "None_2",
                Cost = 0,
                Damage = 0,
                Armor = 0,
            },
            new Item
            {
                Name = "Damage +1 ",
                Cost = 25,
                Damage = 1,
                Armor = 0,
            },
            new Item
            {
                Name = "Damage +2",
                Cost = 50,
                Damage = 2,
                Armor = 0,
            },
            new Item
            {
                Name = "Damage +3",
                Cost = 100,
                Damage = 3,
                Armor = 0,
            },
            new Item
            {
                Name = "Defense +1",
                Cost = 20,
                Damage = 0,
                Armor = 1,
            },
            new Item
            {
                Name = "Defense +2",
                Cost = 40,
                Damage = 0,
                Armor = 2,
            },
            new Item
            {
                Name = "Defense +3",
                Cost = 80,
                Damage = 0,
                Armor = 3,
            }
        };

        public int Day => 21;
    }
}