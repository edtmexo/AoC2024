using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day19
    {
        public static long solution(string[] data)
        {
            Console.WriteLine("Day 19 Part 1");
            // Parse the input
            var towelPatterns = data[0].Split(new[] { ", " }, StringSplitOptions.None);
            var designs = new List<string>();
            for (int i = 2; i < data.Length; i++)//från rad 2 och framåt
            {
                designs.Add(data[i]);
            }

            int possibleDesignsCount = 0;
            long totalWays = 0;
            // Part 1
            foreach (var design in designs)
            {
                if (CanDesign(design, towelPatterns))
                {
                    possibleDesignsCount++;
                }
            }

            Console.WriteLine(possibleDesignsCount);

            //Part 2
            foreach (var design in designs)
            {
                totalWays += CountPart2(design, towelPatterns);
            }            
            Console.WriteLine(totalWays);
            return possibleDesignsCount;
        }

        private static bool CanDesign(string design, string[] towelPatterns)
        {
            int designLength = design.Length;
            bool[] canForm = new bool[designLength + 1];
            canForm[0] = true; 

            for (int i = 1; i <= designLength; i++)
            {
                foreach (var pattern in towelPatterns)
                {
                    int patternLength = pattern.Length;
                    if (i >= patternLength && design.Substring(i - patternLength, patternLength) == pattern)
                    {
                        canForm[i] = canForm[i] || canForm[i - patternLength];
                    }
                }
            }

            return canForm[designLength];
        }
        private static long CountPart2(string design, string[] towelPatterns)
        {
            int designLength = design.Length;
            long[] ways = new long[designLength + 1];
            ways[0] = 1; 
            for (int i = 1; i <= designLength; i++)
            {
                foreach (var pattern in towelPatterns)
                {
                    int patternLength = pattern.Length;
                    if (i >= patternLength && design.Substring(i - patternLength, patternLength) == pattern)
                    {
                        ways[i] += ways[i - patternLength];
                    }
                }
            }
            return ways[designLength];
        }
    }
}
