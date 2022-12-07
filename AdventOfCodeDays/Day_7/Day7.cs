using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2022
{
    public static class Day7
    {
        private static string dataLocation = "Day_7/AdventData.txt";

        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            List<string> currentDir = new List<string>();
            List<string> data = new List<string>();
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("$ ls") || line.Contains("dir")) { continue; }
                if(line.Contains("$ cd "))
                {
                    if(line.Contains("$ cd ..")){currentDir.RemoveAt(currentDir.Count - 1);}
                    else {currentDir.Add(line.Substring(5));}
                    continue;
                }

                string dir = "";
                foreach (string directory in currentDir){dir += directory + " ";}
                data.Add(dir + " " + line.Split(" ")[0]);
            }

            Dictionary<string,int> sums = new Dictionary<string,int>();
            foreach (string file in data)
            {
                string[] split = file.Split(" ");
                string location = "";
                for (int i = 0; i < split.Length-2; i++)
                {
                    location += split[i] + " ";
                    sums.TryAdd(location, 0);
                    sums[location] += int.Parse(split[split.Length - 1]);
                }
            }

            int total = 0;
            foreach (string key in sums.Keys){if (sums[key] <= 100000){total += sums[key];}}

            Console.WriteLine($"Day 7 Star 1 Answer: {total}");
            reader.Close();
        }
       
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            List<string> currentDir = new List<string>();
            List<string> data = new List<string>();
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("$ ls") || line.Contains("dir")) { continue; }
                if (line.Contains("$ cd "))
                {
                    if (line.Contains("$ cd ..")) { currentDir.RemoveAt(currentDir.Count - 1); }
                    else { currentDir.Add(line.Substring(5)); }
                    continue;
                }

                string dir = "";
                foreach (string directory in currentDir) { dir += directory + " "; }
                data.Add(dir + " " + line.Split(" ")[0]);
            }

            Dictionary<string, int> sums = new Dictionary<string, int>();
            foreach (string file in data)
            {
                string[] split = file.Split(" ");
                string location = "";
                for (int i = 0; i < split.Length - 2; i++)
                {
                    location += split[i] + " ";
                    sums.TryAdd(location, 0);
                    sums[location] += int.Parse(split[split.Length - 1]);
                }
            }

            int min = int.MaxValue;
            int target = 30000000 - (70000000 - sums["/ "]);
            foreach (string key in sums.Keys){if (sums[key] >= target && sums[key] < min){min = sums[key];}}

            Console.WriteLine($"Day 7 Star 2 Answer: {min}");
            reader.Close();
        }
    }
}
