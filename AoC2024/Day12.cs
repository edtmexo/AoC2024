using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day12
    {
        public static long solution(string[] map)
        {
            Console.WriteLine("Day 12 Part 1");
            // Konvertera string[] map till char[,]
            char[,] garden = ConvertToCharArray(map);
            // Beräkna den totala kostnaden för stängslet
            int totalCost = CalculateTotalFenceCost(garden);
            Console.WriteLine("Part 1="+totalCost);
            return totalCost;
        }
        static char[,] ConvertToCharArray(string[] map)
        {
            int rows = map.Length;
            int cols = map[0].Length;
            char[,] garden = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    garden[r, c] = map[r][c];
                }
            }

            return garden;
        }
        static int CalculateTotalFenceCost(char[,] garden)
        {
            int rows = garden.GetLength(0);
            int cols = garden.GetLength(1);
            bool[,] visited = new bool[rows, cols];
            int totalCost = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (!visited[r, c])
                    {
                        (int area, int perimeter) = CalculateRegionAreaAndPerimeter(garden, visited, r, c);
                        totalCost += area * perimeter;
                    }
                }
            }

            return totalCost;
        }
        static (int, int) CalculateRegionAreaAndPerimeter(char[,] garden, bool[,] visited, int startRow, int startCol)
        {
            int rows = garden.GetLength(0);
            int cols = garden.GetLength(1);
            char plantType = garden[startRow, startCol];
            int area = 0;
            int perimeter = 0;

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((startRow, startCol));
            visited[startRow, startCol] = true;

            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            while (queue.Count > 0)
            {
                (int r, int c) = queue.Dequeue();
                area++;

                for (int i = 0; i < 4; i++)
                {
                    int nr = r + dr[i];
                    int nc = c + dc[i];

                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                    {
                        if (garden[nr, nc] == plantType && !visited[nr, nc])
                        {
                            visited[nr, nc] = true;
                            queue.Enqueue((nr, nc));
                        }
                        else if (garden[nr, nc] != plantType)
                        {
                            perimeter++;
                        }
                    }
                    else
                    {
                        perimeter++;
                    }
                }
            }

            return (area, perimeter);
        }
    }
}
