using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day1
    {
        public static long solutionDay1Part2(string[] data)
        {
            Console.WriteLine("Day 1 Part 2");
            List<long> left = new List<long>();
            List<long> right = new List<long>();
            foreach (string rows in data)
            {
                string[] row = rows.Split("   ");
                left.Add(long.Parse(row[0]));
                right.Add(long.Parse(row[1]));
            }

            long sum = 0;
            for (int counter = 0; counter < left.Count; counter++)
            {
                long number = left[counter];
                int count = right.Count(n => n == number);
                sum += number * count;
            }
            return sum;
        }
        public static long solutionDay1(string[] data)
        {
            Console.WriteLine("Day 1 Part 1");

            List<long> left = new List<long>();
            List<long> right = new List<long>();
            foreach (string rows in data)
            {
                string[] row = rows.Split("   ");
                left.Add(long.Parse(row[0]));
                right.Add(long.Parse(row[1]));
            }

            left.Sort();
            right.Sort();
            long sum = 0;
            for (int counter = 0; counter < left.Count; counter++)
            {
                long difference = Math.Abs(left[counter] - right[counter]);
                sum += difference;
            }
            return sum;
        }
    }
}
