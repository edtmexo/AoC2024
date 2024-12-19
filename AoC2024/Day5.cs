using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    //Del 1 löste sig galant, men för del 2 så fuska jag och nyttja AI.
    internal class Day5
    {
        public static long solution(string[] data)
        {
            Console.WriteLine("Day 5 Part 1");
            List<string> rules = new List<string>();
            List<string> updates = new List<string>();
            bool isPartRule = true;
            foreach (string rows in data)
            {
                if (string.IsNullOrWhiteSpace(rows))
                    isPartRule = false;
                if (isPartRule)
                    rules.Add(rows);
                if (!isPartRule && !string.IsNullOrWhiteSpace(rows))
                    updates.Add(rows);
            }
            List<int> middlePages = new List<int>();

            foreach (var update in updates)
            {
                var pages = update.Split(',').Select(int.Parse).ToList();
                if (IsInCorrectOrder(pages, rules))
                {
                    middlePages.Add(pages[pages.Count / 2]);
                }
            }

            int sumOfMiddlePages = middlePages.Sum();
            Console.WriteLine("Sum of middle pages: " + sumOfMiddlePages);
            return sumOfMiddlePages;
        }
        private static bool IsInCorrectOrder(List<int> pages, List<string> rules)
        {
            Dictionary<int, int> pageIndex = new Dictionary<int, int>();
            for (int index = 0; index < pages.Count; index++)
            {
                pageIndex[pages[index]] = index;
            }
            foreach (var rule in rules)
            {
                var parts = rule.Split('|').Select(int.Parse).ToArray();
                if (pageIndex.ContainsKey(parts[0]) && pageIndex.ContainsKey(parts[1]))
                {
                    if (pageIndex[parts[0]] > pageIndex[parts[1]])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public static long solutionPart2(string[] data)
        {
            Console.WriteLine("Day 5 Part 2");
            List<string> rules = new List<string>();
            List<string> updates = new List<string>();
            bool isPartRule = true;
            foreach (string rows in data)
            {
                if (string.IsNullOrWhiteSpace(rows))
                    isPartRule = false;
                if (isPartRule)
                    rules.Add(rows);
                if (!isPartRule && !string.IsNullOrWhiteSpace(rows))
                    updates.Add(rows);


            }
            List<int> correctMiddlePages = new List<int>();
            List<int> incorrectMiddlePages = new List<int>();

            foreach (var update in updates)
            {
                var pages = update.Split(',').Select(int.Parse).ToList();
                if (!IsInCorrectOrder(pages, rules))
                {
                    var sortedPages = SortPages(pages, rules);
                    incorrectMiddlePages.Add(sortedPages[sortedPages.Count / 2]);
                }
            }

            int sumOfIncorrectMiddlePages = incorrectMiddlePages.Sum();

            Console.WriteLine("Sum of middle pages for incorrectly ordered updates: " + sumOfIncorrectMiddlePages);
            return sumOfIncorrectMiddlePages;
        }
        
        
       private static List<int> SortPages(List<int> pages, List<string> rules)
        {
            var pageIndex = pages.Select((page, index) => new { page, index }).ToDictionary(x => x.page, x => x.index);
            var dependencies = new Dictionary<int, List<int>>();

            foreach (var rule in rules)
            {
                var parts = rule.Split('|').Select(int.Parse).ToArray();
                if (pageIndex.ContainsKey(parts[0]) && pageIndex.ContainsKey(parts[1]))
                {
                    if (!dependencies.ContainsKey(parts[1]))
                    {
                        dependencies[parts[1]] = new List<int>();
                    }
                    dependencies[parts[1]].Add(parts[0]);
                }
            }

            var sortedPages = new List<int>();
            var visited = new HashSet<int>();

            foreach (var page in pages)
            {
                TopologicalSort(page, dependencies, visited, sortedPages);
            }

            sortedPages.Reverse();
            return sortedPages;
        }
        
        private static void TopologicalSort(int page, Dictionary<int, List<int>> dependencies, HashSet<int> visited, List<int> sortedPages)
        {
            if (!visited.Contains(page))
            {
                visited.Add(page);

                if (dependencies.ContainsKey(page))
                {
                    foreach (var dependency in dependencies[page])
                    {
                        TopologicalSort(dependency, dependencies, visited, sortedPages);
                    }
                }
                sortedPages.Add(page);
            }
        }
    }
}
