using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace AoC2024
{
    //Part 1 fungerar
    internal class Day11
    {
        private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public static long solution(string data)
        {
            Console.WriteLine("Day 11 Part 1");
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - Start");
            string[] split = data.Split(" ");
            List<string> stones = new List<string>();
            // Lägg till stenarna i listan
            foreach (string stone in split)
                stones.Add(stone);

            // Antal blinks
            int blinks = 25;

            // Nu kör vi blinksen
            for (int i = 0; i < blinks; i++)
            {
                stones = Blink(stones);
            }
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - Stop: resultat="+stones.Count());
            return stones.Count();
        }
        private static List<string> Blink(List<string> stones)
        {
            var newStones = new List<string>();
            foreach (var stone in stones)
            {
                if (stone == "0")
                    newStones.Add("1");
                // Om längden på talet är jämt, t.ex 17 eller 12 eller 2257
                else if (stone.Length % 2 == 0)
                {
                    int mid = stone.Length / 2;
                    // Dela stenen i två delar
                    string left = stone.Substring(0, mid).TrimStart('0');
                    string right = stone.Substring(mid).TrimStart('0');
                    if (left == "") left = "0";
                    if (right == "") right = "0";
                    newStones.Add(left);
                    newStones.Add(right);
                }
                else
                 newStones.Add((long.Parse(stone) * 2024).ToString());
                
            }
            return newStones;
        }

     
    }

}
