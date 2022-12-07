using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2022
{
    public static class Day3
    {
        private static string dataLocation = "Day_3/AdventData.txt";
        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int sum = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string firsthalf = line.Substring(0, line.Length / 2);
                string lasthalf = line.Substring(line.Length / 2);

                char key = ' ';
                foreach (char letter in firsthalf)
                {
                    if (lasthalf.Contains(letter)) { key = letter; break; }
                }

                if (key > 96) { sum += key - 96; }
                else { sum += key - 38; }
            }

            Console.WriteLine($"Day 3 Star 1 Answer: {sum}");
            reader.Close();
        }
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int sum = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string line2 = reader.ReadLine();
                string line3 = reader.ReadLine();

                char key = ' ';
                foreach (char letter in line)
                {
                    if (line2.Contains(letter) && line3.Contains(letter)) { key = letter; break; }
                }

                if (key > 96) { sum += key - 96; }
                else { sum += key - 38; }
            }

            Console.WriteLine($"Day 3 Star 2 Answer: {sum}\n");
            reader.Close();
        }
    }
}
