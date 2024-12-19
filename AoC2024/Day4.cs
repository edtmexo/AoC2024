using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day4
    {
        public static long solution(string[] data)
        {
            Console.WriteLine("Day 4 Part 1");
            string word = "XMAS";
            int count = FindAllOccurrences(data, word);
            Console.WriteLine($"Total occurrences of '{word}': {count}");
            return count;
        }
        static int FindAllOccurrences(string[] grid, string word)
        {
            int count = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            int wordLength = word.Length;
                        
            int[][] directions = new int[][]
            {
                new int[] { 0, 1 }, // Höger
                new int[] { 1, 0 }, // ner
                new int[] { 1, 1 }, // diagonal ner-höger
                new int[] { 1, -1 } // diagonal ner-vänster
            };

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    foreach (var direction in directions)
                    {
                        if (CheckWord(grid, word, row, col, direction[0], direction[1]))
                        {
                            count++;
                        }
                        //kollar i motsatt riktning
                        if (CheckWord(grid, word, row, col, -direction[0], -direction[1]))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        static bool CheckWord(string[] grid, string word, int startRow, int startCol, int rowDir, int colDir)
        {
            int wordLength = word.Length;
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int i = 0; i < wordLength; i++)
            {
                int newRow = startRow + i * rowDir;
                int newCol = startCol + i * colDir;

                if (!IsValidPosition(newRow, newCol, rows, cols) || grid[newRow][newCol] != word[i])
                {
                    return false;
                }
            }
            return true;
        }
        static bool IsValidPosition(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
        
        public static long solutionPart2(string[] data)
        {
            Console.WriteLine("Day 4 Part 2");
            int count = FindXShape(data);
            Console.WriteLine($"Total 'MAS' i X shape rackaren: {count}");
            return count;
        }
        static int FindXShape(string[] data)
        {
            int count = 0;
            int rows = data.Length;
            int cols = data[0].Length;

            //hitta all möjliga X-formade ord
            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    if (IsXShape(data, row, col))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        static bool IsXShape(string[] grid, int row, int col)
        {
            string[] patterns = { "MAS", "SAM" };

            foreach (var pattern in patterns)
            {
                // Check top-left to bottom-right and top-right to bottom-left
                if ((grid[row - 1][col - 1] == pattern[0] && grid[row][col] == pattern[1] && grid[row + 1][col + 1] == pattern[2]) &&
                    (grid[row - 1][col + 1] == pattern[0] && grid[row][col] == pattern[1] && grid[row + 1][col - 1] == pattern[2]))
                {
                    return true;
                }
                // Check top-left to bottom-right and bottom-left to top-right
                if ((grid[row - 1][col - 1] == pattern[0] && grid[row][col] == pattern[1] && grid[row + 1][col + 1] == pattern[2]) &&
                    (grid[row + 1][col - 1] == pattern[0] && grid[row][col] == pattern[1] && grid[row - 1][col + 1] == pattern[2]))
                {
                    return true;
                }
                // Check bottom-left to top-right and top-right to bottom-left
                if ((grid[row + 1][col - 1] == pattern[0] && grid[row][col] == pattern[1] && grid[row - 1][col + 1] == pattern[2]) &&
                    (grid[row - 1][col + 1] == pattern[0] && grid[row][col] == pattern[1] && grid[row + 1][col - 1] == pattern[2]))
                {
                    return true;
                }
                // Check bottom-left to top-right and bottom-right to top-left
                if ((grid[row + 1][col - 1] == pattern[0] && grid[row][col] == pattern[1] && grid[row - 1][col + 1] == pattern[2]) &&
                    (grid[row + 1][col + 1] == pattern[0] && grid[row][col] == pattern[1] && grid[row - 1][col - 1] == pattern[2]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
