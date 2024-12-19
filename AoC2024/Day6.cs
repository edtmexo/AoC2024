using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day6
    {
        public static long solution(string[] map)
        {
            int rows = map.Length;
            int cols = map[0].Length;
            char[,] grid = new char[rows, cols];
            int guardRow = 0;
            int guardCol = 0;
            char direction = '^';

            // sätter upp rutnätet och hitta vaktens start position 
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    grid[r, c] = map[r][c];
                    if (map[r][c] == '^' || map[r][c] == 'v' || map[r][c] == '<' || map[r][c] == '>')
                    {
                        guardRow = r;
                        guardCol = c;
                        direction = map[r][c];
                        grid[r, c] = '.'; // NollStäller vaktens start position
                    }
                }
            }

            // Directions: up, right, down, left
            int[] dRow = { -1, 0, 1, 0 };
            int[] dCol = { 0, 1, 0, -1 };
            Dictionary<char, int> dirMap = new Dictionary<char, int>
            {
                { '^', 0 },
                { '>', 1 },
                { 'v', 2 },
                { '<', 3 }
            };

            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            visited.Add((guardRow, guardCol));//Lägger till start positionen som besökt

            while (true)
            {   
                //nuvarande riktning
                int dirIndex = dirMap[direction];
                int newRow = guardRow + dRow[dirIndex];
                int newCol = guardCol + dCol[dirIndex];

                //vakten lämnar kartan  
                if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
                    break;
                //Vakten hamnar på ett hinder
                if (grid[newRow, newCol] == '#')
                {
                    // Sväng höger 90 grader
                    dirIndex = (dirIndex + 1) % 4;
                    direction = dirMap.FirstOrDefault(x => x.Value == dirIndex).Key;
                }
                else//Gå framåt, Lägg till positionen som besökt
                {
                    guardRow = newRow;
                    guardCol = newCol;
                    visited.Add((guardRow, guardCol));
                }
            }

            /*
            // Markera besökt positioner med ett X
            foreach (var pos in visited)
            {
                grid[pos.Item1, pos.Item2] = 'X';
            }

            // Print the final map
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(grid[r, c]);
                }
                Console.WriteLine();
            */
            return visited.Count;
        }


        public static long solutionPart2(string[] map)
        {
            Console.WriteLine("Day 6 Part 2");
            int rows = map.Length;
            int cols = map[0].Length;
            char[,] grid = new char[rows, cols];
            int guardRow = 0;
            int guardCol = 0;
            char direction = '^';

            // sätter upp rutnätet och hitta vaktens start position 
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    grid[r, c] = map[r][c];
                    if (map[r][c] == '^' || map[r][c] == 'v' || map[r][c] == '<' || map[r][c] == '>')
                    {
                        guardRow = r;
                        guardCol = c;
                        direction = map[r][c];
                        grid[r, c] = '.'; // NollStäller vaktens start position
                    }
                }
            }

            // Directions: up, right, down, left
            int[] dRow = { -1, 0, 1, 0 };
            int[] dCol = { 0, 1, 0, -1 };
            Dictionary<char, int> dirMap = new Dictionary<char, int>
        {
            { '^', 0 },
            { '>', 1 },
            { 'v', 2 },
            { '<', 3 }
        };

            List<(int, int)> possibleObstructions = new List<(int, int)>();

            // Check each empty position for potential obstruction
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r, c] == '.' && !(r == guardRow && c == guardCol))
                    {
                        // Simulera placering av #
                        grid[r, c] = '#';
                        if (CausesLoop(grid, guardRow, guardCol, direction, rows, cols, dRow, dCol, dirMap))
                        {
                            possibleObstructions.Add((r, c));
                        }
                        grid[r, c] = '.'; // ta bort #
                    }
                }
            }

            
            foreach (var pos in possibleObstructions)
            {
                Console.WriteLine($"({pos.Item1}, {pos.Item2})");
            }
            return possibleObstructions.Count;
        }

        static bool CausesLoop(char[,] grid, int guardRow, int guardCol, char direction, int rows, int cols, int[] dRow, int[] dCol, Dictionary<char, int> dirMap)
        {
            HashSet<(int, int, char)> visited = new HashSet<(int, int, char)>();
            int startRow = guardRow, startCol = guardCol;
            char startDirection = direction;

            while (true)
            {
                if (visited.Contains((guardRow, guardCol, direction)))
                {
                    return true; 
                }
                visited.Add((guardRow, guardCol, direction));

                int dirIndex = dirMap[direction];
                int newRow = guardRow + dRow[dirIndex];
                int newCol = guardCol + dCol[dirIndex];

                if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
                    return false; // Vakten lämnar kartan

                if (grid[newRow, newCol] == '#')
                {
                    // sväng höger 90 grader
                    dirIndex = (dirIndex + 1) % 4;
                    direction = dirMap.FirstOrDefault(x => x.Value == dirIndex).Key;
                }
                else
                {
                    // Gå framåt
                    guardRow = newRow;
                    guardCol = newCol;
                }
            }
        }
    }
}
