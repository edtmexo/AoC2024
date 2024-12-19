using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day18
    {
        public static long solution(string[] data)
        {
            Console.WriteLine("Day 18 Part 1"); 
            int gridSize = 71;
            //int gridSize = 7;
            bool[,] grid = new bool[gridSize, gridSize];
            
            //Lägg in datat i en lista
            List<(int, int)> bytePositions = data
    .Select(item => item.Split(','))
    .Select(parts => (int.Parse(parts[0]), int.Parse(parts[1])))
    .ToList();

            //Simulera de första 1024 positionerna i listan, Sätt dom cellerna som korrupta
            for (int i = 0; i < 1024; i++)
            {
                var (x, y) = bytePositions[i];
                grid[x, y] = true; 
            }
            // Debug
            PrintGrid(grid, gridSize);
            
            // Leta kortaste vägen genom att använda BFS
            int steps = FindShortestPath(grid, gridSize);
            Console.WriteLine(steps);
            return 0;
        }
        static int FindShortestPath(bool[,] grid, int gridSize)
        {
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };
            bool[,] visited = new bool[gridSize, gridSize];
            // (x, y, steps)
            Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
            
            queue.Enqueue((0, 0, 0)); 
            visited[0, 0] = true;

            while (queue.Count > 0)
            {
                var (x, y, steps) = queue.Dequeue();
                //Längst ned i högra hörnet
                if (x == gridSize - 1 && y == gridSize - 1)
                {
                    return steps;
                }

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (nx >= 0 && ny >= 0 && nx < gridSize && ny < gridSize && !grid[nx, ny] && !visited[nx, ny])
                    {
                        queue.Enqueue((nx, ny, steps + 1));
                        visited[nx, ny] = true;
                    }
                }
            }

            return -1; // No path found
        }
        static void PrintGrid(bool[,] grid, int gridSize)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    Console.Write(grid[x, y] ? '#' : '.');
                }
                Console.WriteLine();
            }
        }
    }
}
