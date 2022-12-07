using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2022
{
    public static class Day1
    {
        private static string dataLocation = "Day_1/AdventData.txt";
        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int max = 0;
            int current = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (line != "") { current += int.Parse(line); }
                else
                {
                    if (current > max)
                    {
                        max = current;
                    }
                    current = 0;
                }
            }

            Console.WriteLine($"Day 1 Star 1 Answer: {max}");
            reader.Close();
        }
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            List<int> sums = new List<int>();
            int current = 0;

            while ((line = reader.ReadLine()) != null)
            {
                if (line != "") { current += int.Parse(line); }
                else
                {
                    sums.Add(current);
                    current = 0;
                }
            }
            sums.Sort();
            sums.Reverse();

            Console.WriteLine($"Day 1 Star 2 Answer: {sums[0] + sums[1] + sums[2]}\n");
            reader.Close();
        }
    }
}
