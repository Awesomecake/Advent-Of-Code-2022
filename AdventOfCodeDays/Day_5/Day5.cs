using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2022
{
    public static class Day5
    {
        private static string dataLocation = "Day_5/AdventData.txt";
        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line = reader.ReadLine();

            List<List<char>> list = new List<List<char>>();
            for (int i = 0; i < (line.Length + 1) / 4; i++) { list.Add(new List<char>()); }

            do
            {
                for (int i = 0; i < (line.Length + 1) / 4; i++)
                {
                    if (line.Substring(i * 4 + 1, 1) != " ") { list[i].Insert(0, line.Substring(i * 4 + 1, 1)[0]); }
                }
            } while ((line = reader.ReadLine()) != null && line[1] != '1');
            reader.ReadLine();

            while ((line = reader.ReadLine()) != null)
            {
                string[] split = Array.FindAll(Regex.Split(line, @"\D"), c => c != "");

                int moves = int.Parse(split[0]);
                int loc1 = int.Parse(split[1]) - 1;
                int loc2 = int.Parse(split[2]) - 1;

                for (int i = 0; i < moves; i++)
                {
                    char item = list[loc1][list[loc1].Count - 1];

                    list[loc1].RemoveAt(list[loc1].Count - 1);
                    list[loc2].Insert(list[loc2].Count, item);
                }
            }

            Console.Write("Day 5 Star 1 Answer: ");
            foreach (List<char> item in list) { Console.Write(item[item.Count - 1]); }
            Console.WriteLine();
            reader.Close();
        }
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line = reader.ReadLine();

            List<List<char>> list = new List<List<char>>();
            for (int i = 0; i < (line.Length + 1) / 4; i++) { list.Add(new List<char>()); }

            do
            {
                for (int i = 0; i < (line.Length + 1) / 4; i++)
                {
                    if (line.Substring(i * 4 + 1, 1) != " ") { list[i].Insert(0, line.Substring(i * 4 + 1, 1)[0]); }
                }
            } while ((line = reader.ReadLine()) != null && line[1] != '1');
            reader.ReadLine();

            while ((line = reader.ReadLine()) != null)
            {
                string[] split = Array.FindAll(Regex.Split(line, @"\D"), c => c != "");

                int moves = int.Parse(split[0]);
                int loc1 = int.Parse(split[1]) - 1;
                int loc2 = int.Parse(split[2]) - 1;

                for (int i = 0; i < moves; i++)
                {
                    char item = list[loc1][list[loc1].Count - 1 - (moves - 1 - i)];

                    list[loc1].RemoveAt(list[loc1].Count - 1 - (moves - 1 - i));
                    list[loc2].Insert(list[loc2].Count, item);
                }
            }

            Console.Write("Day 5 Star 1 Answer: ");
            foreach (List<char> item in list) { Console.Write(item[item.Count - 1]); }
            Console.WriteLine("\n");
            reader.Close();
        }
    }

}
