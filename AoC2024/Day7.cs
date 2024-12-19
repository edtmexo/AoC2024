using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day7
    {
        public static long solution(string[] data)
        {
            Console.WriteLine("Day 7 Part 1");
            long totalCalibrationResult = 0;
            foreach (string line in data)
            {
                string[] parts = line.Split(": ");
                long testValue = long.Parse(parts[0]);
                long[] numbers = parts[1].Split(' ').Select(long.Parse).ToArray();

                if (CanBeTrue(testValue, numbers))
                {
                    totalCalibrationResult += testValue;
                }
            }

            return totalCalibrationResult;
        }
        private static bool CanBeTrue(long testValue, long[] numbers)
        {
            int n = numbers.Length;
            int numOperators = n - 1;
            int numCombinations = (int)Math.Pow(2, numOperators);

            for (int i = 0; i < numCombinations; i++)
            {
                long result = numbers[0];
                int combination = i;

                for (int j = 0; j < numOperators; j++)
                {
                    if ((combination & 1) == 0)
                    {
                        result += numbers[j + 1];
                    }
                    else
                    {
                        result *= numbers[j + 1];
                    }
                    combination >>= 1;
                }

                if (result == testValue)
                {
                    return true;
                }
            }

            return false;
        }
        public static long solutionPart2(string[] data)
        {
            Console.WriteLine("Day 7 Part 2");

            long totalCalibrationResult = 0;
            foreach (string line in data)
            {
                string[] parts = line.Split(": ");
                long testValue = long.Parse(parts[0]);
                long[] numbers = parts[1].Split(' ').Select(long.Parse).ToArray();

                if (CanBeTruePart2(testValue, numbers))
                {
                    totalCalibrationResult += testValue;
                }
            }

            return totalCalibrationResult;

            
        }
        private static bool CanBeTruePart2(long testValue, long[] numbers)
        {
            int n = numbers.Length;
            int numOperators = n - 1;
            int numCombinations = (int)Math.Pow(3, numOperators); // 3 operators: +, *, ||

            for (int i = 0; i < numCombinations; i++)
            {
                long result = numbers[0];
                int combination = i;

                for (int j = 0; j < numOperators; j++)
                {
                    int operatorType = combination % 3;
                    combination /= 3;

                    if (operatorType == 0)
                    {
                        result += numbers[j + 1];
                    }
                    else if (operatorType == 1)
                    {
                        result *= numbers[j + 1];
                    }
                    else if (operatorType == 2)
                    {
                        result = long.Parse(result.ToString() + numbers[j + 1].ToString());
                    }
                }

                if (result == testValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
