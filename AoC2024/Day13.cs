using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2024
{
    //part 1 fungerar
    //Part 2 fungerar inte  
    internal class Day13
    {
        public static long solution(string[] data)
        {
            Console.WriteLine("Day 13 Part 1");
            var machines = ParseClawMachines(data);
            int totalPrizes = 0;
            int totalTokens = 0;

            foreach (var machine in machines)
            {
                var result = machine.FindMinimumTokens();
                if (result != null)
                {
                    totalPrizes++;
                    totalTokens += result.Value;
                }
            }
            Console.WriteLine($"Total Prizes: {totalPrizes}");
            Console.WriteLine($"Total Tokens: {totalTokens}");

            Console.WriteLine("Day 13 Part 2");
            var machinesPart2 = ParseClawMachinesPart2(data);
            int totalPrizesPart2 = 0;
            int totalTokensPart2 = 0;

            foreach (var machine in machinesPart2)
            {
                var result = machine.FindMinimumTokens();
                if (result != null)
                {
                    totalPrizesPart2++;
                    totalTokensPart2 += result.Value;
                }
            }

            return totalTokens;
        }
        private static List<ClawMachinePart2> ParseClawMachinesPart2(string[] map)
        {
            var machines = new List<ClawMachinePart2>();
            for (int i = 4; i < map.Length; i += 8)// börjar på block 2 och kör varannan
            {
                var aMatch = Regex.Match(map[i], @"Button A: X\+(\d+), Y\+(\d+)");
                var bMatch = Regex.Match(map[i + 1], @"Button B: X\+(\d+), Y\+(\d+)");
                var prizeMatch = Regex.Match(map[i + 2], @"Prize: X=(\d+), Y=(\d+)");

                if (aMatch.Success && bMatch.Success && prizeMatch.Success)
                {
                    int ax = int.Parse(aMatch.Groups[1].Value);
                    int ay = int.Parse(aMatch.Groups[2].Value);
                    int bx = int.Parse(bMatch.Groups[1].Value);
                    int by = int.Parse(bMatch.Groups[2].Value);
                    String x = "10000000000000" + prizeMatch.Groups[1].Value;
                    long prizeX = long.Parse(x);
                    String y = "10000000000000" + prizeMatch.Groups[2].Value;
                    long prizeY = long.Parse(y);
                    machines.Add(new ClawMachinePart2(ax, ay, bx, by, prizeX, prizeY));
                }
            }
            return machines;
        }
        private static List<ClawMachine> ParseClawMachines(string[] map)
        {
            var machines = new List<ClawMachine>();
            for (int i = 0; i < map.Length; i += 4)// 4 hoppar till nästa block
            {
                var aMatch = Regex.Match(map[i], @"Button A: X\+(\d+), Y\+(\d+)");
                var bMatch = Regex.Match(map[i + 1], @"Button B: X\+(\d+), Y\+(\d+)");
                var prizeMatch = Regex.Match(map[i + 2], @"Prize: X=(\d+), Y=(\d+)");

                if (aMatch.Success && bMatch.Success && prizeMatch.Success)
                {
                    int ax = int.Parse(aMatch.Groups[1].Value);
                    int ay = int.Parse(aMatch.Groups[2].Value);
                    int bx = int.Parse(bMatch.Groups[1].Value);
                    int by = int.Parse(bMatch.Groups[2].Value);
                    int prizeX=int.Parse(prizeMatch.Groups[1].Value);
                    int prizeY = int.Parse(prizeMatch.Groups[2].Value);
                    machines.Add(new ClawMachine(ax, ay, bx, by, prizeX, prizeY));
                }
            }
            return machines;
        }
    }
    internal class ClawMachine
    {
        public int AX { get; }
        public int AY { get; }
        public int BX { get; }
        public int BY { get; }
        public int PrizeX { get; }
        public int PrizeY { get; }

        public ClawMachine(int ax, int ay, int bx, int by, int prizeX, int prizeY)
        {
            AX = ax;
            AY = ay;
            BX = bx;
            BY = by;
            PrizeX = prizeX;
            PrizeY = prizeY;
        }

        public int? FindMinimumTokens()
        {
            int minTokens = int.MaxValue;
            bool foundSolution = false;
            for (int a = 0; a <= 100; a++)
            {
                for (int b = 0; b <= 100; b++)
                {
                    int x = a * AX + b * BX;
                    int y = a * AY + b * BY;
                    if (x == PrizeX && y == PrizeY)
                    {
                        int tokens = a * 3 + b;
                        if (tokens < minTokens)
                        {
                            minTokens = tokens;
                            foundSolution = true;
                        }
                    }
                }
            }
            return foundSolution ? minTokens : (int?)null;
        }
    }
    internal class ClawMachinePart2
    {
        public int AX { get; }
        public int AY { get; }
        public int BX { get; }
        public int BY { get; }
        public long PrizeX { get; }
        public long PrizeY { get; }

        public ClawMachinePart2(int ax, int ay, int bx, int by, long prizeX, long prizeY)
        {
            AX = ax;
            AY = ay;
            BX = bx;
            BY = by;
            PrizeX = prizeX;
            PrizeY = prizeY;
        }

        public int? FindMinimumTokens()
        {
            var queue = new Queue<(int a, int b, int tokens)>();
            var visited = new HashSet<(int, int)>();

            queue.Enqueue((0, 0, 0));
            visited.Add((0, 0));

            while (queue.Count > 0)
            {
                var (a, b, tokens) = queue.Dequeue();
                int x = a * AX + b * BX;
                int y = a * AY + b * BY;

                if (x == PrizeX && y == PrizeY)
                {
                    return tokens;
                }

                var nextStates = new List<(int, int, int)>
                {
                    (a + 1, b, tokens + 3),
                    (a, b + 1, tokens + 1)
                };

                foreach (var (nextA, nextB, nextTokens) in nextStates)
                {
                    if (!visited.Contains((nextA, nextB)))
                    {
                        queue.Enqueue((nextA, nextB, nextTokens));
                        visited.Add((nextA, nextB));
                    }
                }
            }

            return null;
        }
    }
}
