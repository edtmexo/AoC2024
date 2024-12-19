using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day16
    {
        // East, South, West, North
        private static readonly (int dx, int dy)[] Directions = { (1, 0), (0, 1), (-1, 0), (0, -1) }; 
        public static long solution(string[] data)
        {
            Console.WriteLine("Day 16 Part 1");
            var labyrint = ParseInput(data);
            var start = FindPosition(labyrint, 'S');
            var end = FindPosition(labyrint, 'E');
            long result = FindShortestPath(labyrint, start, end);
            Console.WriteLine($"Lowest score: {result}");
            return result;
        }
        //Gör om till en char array, så att vi får en labyrint så att vi kan nyttja den i BFS
        private static char[,] ParseInput(string[] input)
        {
            int rows = input.Length;
            int cols = input[0].Length;
            var labyrint = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    labyrint[i, j] = input[i][j];
                }
            }
            return labyrint;
        }

        private static (int x, int y) FindPosition(char[,] labyrint, char target)
        {
            for (int i = 0; i < labyrint.GetLength(0); i++)
            {
                for (int j = 0; j < labyrint.GetLength(1); j++)
                {
                    if (labyrint[i, j] == target)
                    {
                        return (j, i);
                    }
                }
            }
    
            throw new Exception($"{target} not found in");
        }

        private static long FindShortestPath(char[,] labyrint, (int x, int y) start, (int x, int y) end)
        {
            var pq = new PriorityQueue<(int x, int y, int dir, int cost), int>();
            var visited = new HashSet<(int x, int y, int dir)>();
            for (int i = 0; i < 4; i++)
            {
                pq.Enqueue((start.x, start.y, i, 0), 0);
            }

            while (pq.Count > 0)
            {
                var (x, y, dir, cost) = pq.Dequeue();

                if ((x, y) == end)
                {
                    return cost;
                }
                if (!visited.Add((x, y, dir)))
                {
                    continue;
                }

                // Gå framåt
                var (dx, dy) = Directions[dir];
                int nx = x + dx;
                int ny = y + dy;

                if (nx >= 0 && nx < labyrint.GetLength(1) && ny >= 0 && ny < labyrint.GetLength(0) && labyrint[ny, nx] != '#')
                {
                    pq.Enqueue((nx, ny, dir, cost + 1), cost + 1);
                }

                // Rotera medsols
                int newDir = (dir + 1) % 4;
                pq.Enqueue((x, y, newDir, cost + 1000), cost + 1000);

                // Rotera moturs
                newDir = (dir + 3) % 4;
                pq.Enqueue((x, y, newDir, cost + 1000), cost + 1000);
            }
            throw new Exception("Path not found.");
        }
    }

    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private readonly SortedDictionary<TPriority, Queue<TElement>> _dictionary = new();        
        public int Count { get; private set; }
        public void Enqueue(TElement element, TPriority priority)
        {
            if (!_dictionary.TryGetValue(priority, out var queue))
            {
                queue = new Queue<TElement>();
                _dictionary[priority] = queue;
            }

            queue.Enqueue(element);
            Count++;
        }

        public TElement Dequeue()
        {
            var pair = _dictionary.First();
            var element = pair.Value.Dequeue();
            if (pair.Value.Count == 0)
            {
                _dictionary.Remove(pair.Key);
            }
            Count--;
            return element;
        }
    }

}
