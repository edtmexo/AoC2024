using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day3
    {
        public static long solutionDay3_Part2(String data)
        {
            Console.WriteLine("Day 3 Part 2");
            long sum = 0;
            bool isEnabled = true;
            string patternDo = @"do\(\)";
            string patternDont = @"don't\(\)";           
            string patternMul = @"mul\((\d{1,3}),(\d{1,3})\)";
            string combinedPattern = $@"{patternDo}|{patternDont}|{patternMul}";
            Regex regex = new Regex(combinedPattern);
            MatchCollection matches = regex.Matches(data);
            foreach (Match match in matches)
            {
                if (match.Value == "do()")
                {
                    isEnabled = true;
                }
                else if (match.Value == "don't()")
                {
                    isEnabled = false;
                }
                else if (isEnabled && match.Value.StartsWith("mul("))
                {
                    int firstDigit = int.Parse(match.Groups[1].Value);
                    int secondDigit = int.Parse(match.Groups[2].Value);
                    sum += firstDigit * secondDigit;
                }
            }
            return sum;
        }
        public static long solutionDay3_Part1(String data)
        {
            Console.WriteLine("Day 3 Part1");
            long sum = 0;
            string patternMul = @"mul\((\d{1,3}),(\d{1,3})\)";
            Regex regex = new Regex(patternMul);
            MatchCollection matches = regex.Matches(data);
            foreach (Match match in matches)
            {

                int firstDigit = int.Parse(match.Groups[1].Value);
                int secondDigit = int.Parse(match.Groups[2].Value);
                sum += firstDigit * secondDigit;
            }
            return sum;
        }
    }
}
