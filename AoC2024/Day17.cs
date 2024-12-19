using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    internal class Day17
    {
        //Part 1 fick jag till, men part 2 fick jag inte till och jag har nu förstört koden lite o orkar inte rätta till den :-)
        public static long solution(string[] data)
        {
            Console.WriteLine("Day 17 Part 1");
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - Start");
            // Initial register values part 1, 
            /*
            int A = 21539243;
            int B = 0;
            int C = 0;

            // Program instructions
            int[] program = { 2,4,1,3,7,5,1,5,0,3,4,1,5,5,3,0};
            string output = ExecuteProgram(A, B, C, program);
            Console.WriteLine(output);
            
            */
            //Part 2
            //int A = 2024;
            int B = 0;
            int C = 0;

            // Program instructions
            //int[] program = { 0, 3, 5, 4, 3, 0 };
            int[] program = { 2, 4, 1, 3, 7, 5, 1, 5, 0, 3, 4, 1, 5, 5, 3, 0 };

            int result = FindLowestInitialValue(program, B, C);
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - Stop");
            //117440
            Console.WriteLine(result);
            return 0;
        }
        static int FindLowestInitialValue(int[] program, int B, int C)
        {
            int A = 1;
            while (true)
            {
                string output = ExecuteProgram(A, B, C, program);
                if (output == string.Join(",", program))
                {
                    return A;
                }
                A++;
            }
        }
        static string ExecuteProgram(int A, int B, int C, int[] program)
        {
            int ip = 0; // Instruction pointer
            List<int> output = new List<int>();

            while (ip < program.Length)
            {
                int opcode = program[ip];
                int operand = program[ip + 1];

                switch (opcode)
                {
                    case 0: // adv
                        A = A / (int)Math.Pow(2, GetComboOperandValue(operand, A, B, C));
                        break;
                    case 1: // bxl
                        B ^= operand;
                        break;
                    case 2: // bst
                        B = GetComboOperandValue(operand, A, B, C) % 8;
                        break;
                    case 3: // jnz
                        if (A != 0)
                        {
                            ip = operand;
                            continue;
                        }
                        break;
                    case 4: // bxc
                        B ^= C;
                        break;
                    case 5: // out
                        output.Add(GetComboOperandValue(operand, A, B, C) % 8);
                        break;
                    case 6: // bdv
                        B = A / (int)Math.Pow(2, GetComboOperandValue(operand, A, B, C));
                        break;
                    case 7: // cdv
                        C = A / (int)Math.Pow(2, GetComboOperandValue(operand, A, B, C));
                        break;
                }

                ip += 2;
            }

            return string.Join(",", output);
        }

        static int GetComboOperandValue(int operand, int A, int B, int C)
        {
            return operand switch
            {
                0 => 0,
                1 => 1,
                2 => 2,
                3 => 3,
                4 => A,
                5 => B,
                6 => C,
                _ => throw new ArgumentException("Invalid combo operand")
            };
        }
    }
}

