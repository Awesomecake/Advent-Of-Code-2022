using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2022
{
    public static class Day6
    {
        private static string dataLocation = "Day_6/AdventData.txt";
        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line = reader.ReadLine();

            for (int i = 0; i < line.Length - 3; i++)
            {
                string subline = line.Substring(i, 4);

                if (subline.IndexOf(subline[0]) == 0 && subline.IndexOf(subline[1]) == 1 && subline.IndexOf(subline[2]) == 2 && subline.IndexOf(subline[3]) == 3)
                {
                    Console.WriteLine($"Day 6 Star 1 Answer: {i + 4}");
                    break;
                }
            }

            reader.Close();
        }
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line = reader.ReadLine();

            for (int i = 0; i < line.Length - 13; i++)
            {
                string subline = line.Substring(i, 14);

                bool found = true;
                for (int j = 0; j < subline.Length; j++)
                {
                    if (subline.IndexOf(subline[j]) != j)
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    Console.WriteLine($"Day 6 Star 2 Answer: {i + 14}");
                    break;
                }
            }

            reader.Close();
        }
    }
}
