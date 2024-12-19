using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day9
    {
        public static long solution(string map)
        {
            Console.WriteLine("Day 9 Part 1");
            StringBuilder result = new StringBuilder();
            int fileId = 0;

            //bygger upp indivuella blocken
            for (int i = 0; i < map.Length; i += 2)
            {
                int fileLength = int.Parse(map[i].ToString());
                int freeSpaceLength = countFreeSpace(map, i);

                // Lägg till filblock
                for (int j = 0; j < fileLength; j++)
                {
                    result.Append(fileId);
                }

                // Lägg till lediga block
                for (int j = 0; j < freeSpaceLength; j++)
                {
                    result.Append('.');
                }

                fileId++;
            }
            //00...111...2...333.44.5555.6666.777.888899
            //00...111...2...333.44.5555.6666.777.888899
            //
            Console.WriteLine(result.ToString());
            //remove gaps           
            StringBuilder resultWithoutGasp = new StringBuilder();            
            int rightIndex = result.Length - 1;

            // Iterera genom strängen från vänster till höger
            for (int readIndex = 0; readIndex < result.Length; readIndex++)
            {
                
                if (result[readIndex] == '.')
                {
                    // Flytta filblocket till den första lediga platsen
                    char c   = result[rightIndex];
                    while (c == '.')
                    {
                        result[rightIndex]= '-';
                        rightIndex--;
                        c = result[rightIndex];
                    }
                    resultWithoutGasp.Append(c);
                    result[rightIndex] = '-';
                    rightIndex--;
                }
                else
                    resultWithoutGasp.Append(result[readIndex]);

            }
            // Ta bort alla '-' från result
            resultWithoutGasp.Replace("-", "");
            Console.WriteLine(resultWithoutGasp.ToString()); // 
            // Beräkna checksumman
            //0099811188827773336446555566..............
            //0099811188827773337446555566..............

            // Ersätt slutet av resultWithoutGaps med punkter
            /*for (int i = resultWithoutGasp.Length - counter; i < resultWithoutGasp.Length; i++)
            {
                resultWithoutGasp[i] = '.';
            }*/
            Console.WriteLine(resultWithoutGasp.ToString()); 
            long checksum = 0;
            for (int i = 0; i < resultWithoutGasp.Length; i++)
            {
               
                    long fileBlockId = long.Parse(resultWithoutGasp[i].ToString());
                    checksum += i * fileBlockId;
                
            }
            //88217448737 - för lågt 88217448737, 88217448737
            Console.WriteLine("Checksum: " + checksum); // Förväntat resultat: 1928

            return checksum;


            
        }

        private static int countFreeSpace(string map, int i)
        {
            int freeSpaceLength;
            //räkna ut lediga block
            if ((i + 1 < map.Length))
            {
                freeSpaceLength = int.Parse(map[i + 1].ToString());
            }
            else
            {
                freeSpaceLength = 0;
            }
            return freeSpaceLength;
        }

        public static long solutionPart2(string[] data)
        {
            Console.WriteLine("Day 9 Part 2");
            return 0;
        }
    }
}
