
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

Console.WriteLine("Advent of Code 2024");

string[] prodData = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day1.txt");
string[] testDataDay1 = new string[]
{
"3   4",
"4   3",
"2   5",
"1   3",
"3   9",
"3   3",
};
var sum = solutionDay1Part2(prodData);
Console.WriteLine("Sum: " + sum);

long solutionDay1Part2(string[] data)
{
    Console.WriteLine("Day 1 part2");

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
        int count=right.Count(n => n == number);
        sum+=number* count;
    }
    return sum;
}
long solutionDay1(string[] testData) {
    Console.WriteLine("Day 1 part1");

    List<long> left = new List<long>();
    List<long> right = new List<long>();
    foreach (string rows in testData)
    {
        string[] row= rows.Split("   ");
        left.Add(long.Parse(row[0]));
        right.Add(long.Parse(row[1]));  
    }
    
    left.Sort();
    right.Sort();
    long sum = 0;
    for (int counter= 0; counter < left.Count; counter++)
    {
        long difference=Math.Abs(left[counter] - right[counter]);
        sum += difference;
    }
    return sum;   
}



