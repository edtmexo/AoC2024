
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AoC2024.AoC2024;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;
using AoC2024;

Console.WriteLine("Advent of Code 2024");
string[] prodDataDay20 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day20.txt");
string[] testDataDay20 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay20.txt");
var sum = Day20.solution(prodDataDay20);
Console.WriteLine("Summma: " + sum);

/*
string[] prodDataDay19 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day19.txt");
string[] testDataDay19 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay19.txt");
var sum = Day19.solution(prodDataDay19);
Console.WriteLine("Summma: " + sum);
*/
/*string[] prodDataDay18 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day18.txt");
var sum = Day18.solution(prodDataDay18);
Console.WriteLine("Summma: " + sum);*/


/* 
 string[] prodDataDay16 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day16.txt");
string[] testDataDay16 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay16.txt");
var sum = Day16.solution(prodDataDay16);
Console.WriteLine("Summma: " + sum);
*/

/*
string[] prodDataDay13 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day13.txt");
string[] testDataDay13 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay13.txt");
var sum = Day13.solution(prodDataDay13);
Console.WriteLine("Summma: " + sum);
*/
/*
string[] prodDataDay12 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day12.txt");
string[] testDataDay12 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay12.txt");
var sum = Day12.solution(testDataDay12);
Console.WriteLine("Summma: " + sum);
*/
//199946
//var sum = Day9.Solve(prodDataDay9,1);

//string[] prodDataDay10 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day10.txt");
//string[] testDataDay10 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay10.txt");

//convert string to string[]S
/*
string prodDataDay11 = "872027 227 18 9760 0 4 67716 9245696";
string[] prodDataDay11Array = prodDataDay11.Split(' ');
string testdataDay11 = "125 17"; 
var sum2 = Day11.Solve(prodDataDay11Array, 2);
Console.WriteLine("Summma day11: " + sum2);
*/
//199946
//var sum = Day9.Solve(prodDataDay9,1);

//string[] prodDataDay9 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day9.txt");
//string fileContent = File.ReadAllText(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay9.txt");
//string fileContent2 = File.ReadAllText(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day9.txt");
//string[] testDataDay9 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay9.txt");

//6200294120911
//
//string[] prodDataDay8 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day8.txt");
//string[] testDataDay8 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay8.txt");
//var sum = Day8.solution(testDataDay8);
//Console.WriteLine("Summma: " + sum);


//Day5
//string[] prodDataDay5 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day5.txt");
//string[] testDataDay5 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay5.txt");
//var sum = Day5.solutionPart2(prodDataDay5);
//var sum = Day5.solutionPart2(testDataDay5);
//6897
//Console.WriteLine("Sum: " + sum);

//int nrOfOccurs = HelperAoC.CountOccurrences(new List<int> { 1, 2, 3, 4, 5, 6, 3, 4, 3, 5, 3, 7, 8, 9, 10 }, 3);
//string[] prodDataDay1 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day1.txt");
/*string[] testDataDay1 = new string[]
{
"3   4",
"4   3",
"2   5",
"1   3",
"3   9",
"3   3",
};*/

//Day 7
//string[] prodDataDay7 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day7.txt");
//string[] testDataDay7= System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay7.txt");
//var sum = Day7.solutionPart2(prodDataDay7);
//var sum = Day5.solutionPart2(testDataDay5);
//6897
//Console.WriteLine("Summma: " + sum);
//Day1
//string[] prodDataDay1 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day1.txt");
//var sum=Day1.solutionDay1(prodDataDay1);

//Day2
//string[] prodDataDay2 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day2.txt");
//string[] testDataDay2 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay2.txt");
//var r=Day2.Solve2_2(prodDataDay2);
//Console.WriteLine("Result: " + r);

//Day3
//string[] testDataDay3 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay3.txt");
//string fileContent = File.ReadAllText(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day3.txt");
//var summa=Day3.solutionDay3_Part1(fileContent);
//Console.WriteLine("Sum: " + summa);

//Day4
//string[] prodDataDay4 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day4.txt");
//string[] testDataDay4 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay4.txt");
//var sum = Day4.solution(testDataDay4);
//var sum = Day4.solutionPart2(prodDataDay4);
//Console.WriteLine("Sum: " + sum);

// Day5
//string[] prodDataDay5 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\Day5.txt");
//string[] testDataDay5 = System.IO.File.ReadAllLines(@"C:\Users\mexposit\source\repos\AoC2024\AoC2024\AoC2024\testDataDay5.txt");
//var summa = Day5.solutionPart2(prodDataDay5);
//var sum = Day5.solutionPart2(testDataDay5);
//6897
//Console.WriteLine("Sum: " + summa);
//var sum = solutionDay2Part2(prodDataDay2);
//var sum = Solve2_2(prodDataDay2);
//var sum = Solve(prodDataDay2, 2);
//var sum = solutionDay3(fileContent);

//var sum = Solve(prodDataDay3, 2);









