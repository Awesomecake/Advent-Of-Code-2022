using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_2022
{
    public static class Day1
    {
        private static string dataLocation = "Day_1/AdventData.txt";
        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation); //Get all data
            string line;

            int max = 0;
            int current = 0;
            while ((line = reader.ReadLine()) != null) //Read it in, line by line
            {
                if (line != "") { current += int.Parse(line); } //If line isn't empty, add its value to the current sum
                else //If line is empty
                {
                    if (current > max) //Compare current to max, save current if it is the new max
                    {
                        max = current;
                    }
                    current = 0; //Reset current
                }
            }

            Console.WriteLine($"Day 1 Star 1 Answer: {max}"); //Output largest total
            reader.Close();
        }
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation); //Get all data
            string line;

            List<int> sums = new List<int>();
            int current = 0;

            while ((line = reader.ReadLine()) != null) //Read it in, line by line
            {
                if (line != "") { current += int.Parse(line); } //If line isn't empty, add its value to the current sum
                else //If line is empty, add the current to the list of sums
                {
                    sums.Add(current);
                    current = 0; //Reset current
                }
            }
            sums.Sort(); //Sort list by smallest -> largest
            sums.Reverse(); //Reverse list

            Console.WriteLine($"Day 1 Star 2 Answer: {sums[0] + sums[1] + sums[2]}\n"); //Output sum of three largest totals
            reader.Close();
        }
    }
}
