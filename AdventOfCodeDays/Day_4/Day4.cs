using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2022
{
    public static class Day4
    {
        private static string dataLocation = "Day_4/AdventData.txt";
        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int total = 0;
            while ((line = reader.ReadLine()) != null)
            {
                int[] input = Array.ConvertAll(Regex.Split(line, @"\D"), int.Parse);

                if ((input[0] >= input[2] && input[1] <= input[3]) || (input[2] >= input[0] && input[3] <= input[1])) { total++; } //If one range is entirely within the other, total++
            }

            Console.WriteLine($"Day 4 Star 1 Answer: {total}");
            reader.Close();
        }
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int total = 0;

            while ((line = reader.ReadLine()) != null)
            {
                int[] input = Array.ConvertAll(Regex.Split(line, @"\D"), int.Parse);

                if ((input[1] <= input[3] && input[1] >= input[2]) || (input[0] <= input[3] && input[0] >= input[2])) { total++; } //If the ends of range1 are within range2, total++
                else if ((input[3] <= input[1] && input[3] >= input[0]) || (input[2] <= input[1] && input[2] >= input[0])) { total++; } //If the ends of range2 are within range1, total++
            }

            Console.WriteLine($"Day 4 Star 2 Answer: {total}\n");
            reader.Close();
        }
    }
}
