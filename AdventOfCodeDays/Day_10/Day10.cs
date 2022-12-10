using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Advent_Of_Code_2022
{
    public static class Day10
    {
        private static string dataLocation = "Day_10/AdventData.txt";

        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int cycle = 0;
            int x = 1;

            Dictionary<int,int> cycles = new Dictionary<int,int>();

            while ((line = reader.ReadLine()) != null)
            {
                if(line == "noop")
                {
                    cycle++;
                    cycles.Add(cycle, x);
                }
                if (line.Contains("addx"))
                {
                    cycle++;
                    cycles.Add(cycle, x);
                    cycle++;
                    cycles.Add(cycle, x);
                    x += int.Parse(line.Split(" ")[1]);
                }
            }

            int sum = 0;
            for (int i = 20; i <= 240; i += 40){sum += cycles[i]*i;}
            Console.WriteLine(sum);
            reader.Close();
        }

        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int cycle = 0;
            int x = 1;

            List<char> output = new List<char>();
            char display = Char.ConvertFromUtf32(0x00002588)[0];
            output.Add(display); output.Add(display); output.Add(display);
            for (int i = 0; i < 237; i++){output.Add('.');}

            while ((line = reader.ReadLine()) != null)
            {
                if (line == "noop")
                {
                    cycle++;
                    if(output[(cycle - 1) % 40] == display){Console.ForegroundColor = ConsoleColor.White;}
                    else{ Console.ForegroundColor = ConsoleColor.Black; }
                    Console.Write(output[(cycle - 1) % 40]);
                }
                if (line.Contains("addx"))
                {
                    cycle++;
                    if (output[(cycle - 1) % 40] == display) { Console.ForegroundColor = ConsoleColor.White; }
                    else { Console.ForegroundColor = ConsoleColor.Black; }
                    Console.Write(output[(cycle-1)%40]);

                    cycle++;
                    if (output[(cycle - 1) % 40] == display) { Console.ForegroundColor = ConsoleColor.White; }
                    else { Console.ForegroundColor = ConsoleColor.Black; }
                    Console.Write(output[(cycle - 1) % 40]);

                    if (Enumerable.Range(0, 239).Contains(x - 1)) { output[x - 1] = '.'; }
                    if (Enumerable.Range(0, 239).Contains(x)) { output[x] = '.'; }
                    if (Enumerable.Range(0, 239).Contains(x + 1)) { output[x + 1] = '.'; }

                    x += int.Parse(line.Split(" ")[1]);

                    if (Enumerable.Range(0, 239).Contains(x - 1)) { output[x - 1] = display; }
                    if (Enumerable.Range(0, 239).Contains(x)) { output[x] = display; }
                    if (Enumerable.Range(0, 239).Contains(x + 1)) { output[x + 1] = display; }
                }
            }

            Console.SetWindowSize(39, 40);
            reader.Close();
        }
    }
}
