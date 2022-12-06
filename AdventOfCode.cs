using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_Of_Code_2022
{
    class AdventOfCode
    {
        static void Main(string[] args)
        {
            //Day1Star1();
            //Day1Star2();

            //Day2Star1();
            //Day2Star2();

            //Day3Star1();
            //Day3Star2();

            //Day4Star1();
            //Day4Star2();

            //Day5Star1();
            //Day5Star2();

            //Day6Star1();
            Day6Star2();
        }

        #region Day Six
        static void Day6Star1()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line = reader.ReadLine();

            for (int i = 0; i < line.Length-3; i++)
            {
                string subline = line.Substring(i, 4);

                if (subline.IndexOf(subline[0]) == 0 && subline.IndexOf(subline[1]) == 1 && subline.IndexOf(subline[2]) == 2 && subline.IndexOf(subline[3]) == 3)
                {
                    Console.WriteLine(i + 4);
                    break;
                }
            }
        }

        static void Day6Star2()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
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
                    Console.WriteLine(i+14);
                    break;
                }
            }
        }
        #endregion
        #region Day Five
        static void Day5Star1()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line = reader.ReadLine();

            List<List<char>> list = new List<List<char>>();
            for(int i = 0; i < (line.Length+1)/4; i++){list.Add(new List<char>());}

            do
            {
                for (int i = 0; i < (line.Length+1)/4; i++)
                {
                    if(line.Substring(i * 4 + 1, 1) != " "){list[i].Insert(0,line.Substring(i * 4 + 1, 1)[0]);}
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
                    char item = list[loc1][list[loc1].Count-1];

                    list[loc1].RemoveAt(list[loc1].Count - 1);
                    list[loc2].Insert(list[loc2].Count,item);
                }
            }

            foreach (List<char> item in list){Console.Write(item[item.Count - 1]);}
            Console.WriteLine();
        }

        static void Day5Star2()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line = reader.ReadLine();

            List<List<char>> list = new List<List<char>>();
            for (int i = 0; i < (line.Length + 1) / 4; i++){list.Add(new List<char>());}

            do
            {
                for (int i = 0; i < (line.Length + 1) / 4; i++)
                {
                    if (line.Substring(i * 4 + 1, 1) != " "){list[i].Insert(0,line.Substring(i * 4 + 1, 1)[0]);}
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
                    char item = list[loc1][list[loc1].Count - 1 - (moves-1-i)];

                    list[loc1].RemoveAt(list[loc1].Count - 1 - (moves-1 - i));
                    list[loc2].Insert(list[loc2].Count, item);
                }
            }

            foreach (List<char> item in list){Console.Write(item[item.Count - 1]);}
            Console.WriteLine();
        }
        #endregion
        #region Day Four
        static void Day4Star1()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int total = 0;
            while ((line = reader.ReadLine()) != null)
            {
                int[] input = Array.ConvertAll(Regex.Split(line, @"\D"), int.Parse);

                if((input[0] >= input[2] && input[1] <= input[3]) || (input[2] >= input[0] && input[3] <= input[1])){total++;} //If one range is entirely within the other, total++
            }

            Console.WriteLine($"Day 4 Star 1 Answer: {total}");
        }

        static void Day4Star2()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int total = 0;

            while ((line = reader.ReadLine()) != null)
            {
                int[] input = Array.ConvertAll(Regex.Split(line, @"\D"), int.Parse);

                if((input[1] <= input[3] && input[1] >= input[2]) || (input[0] <= input[3] && input[0] >= input[2])) { total++; } //If the ends of range1 are within range2, total++
                else if ((input[3] <= input[1] && input[3] >= input[0]) || (input[2] <= input[1] && input[2] >= input[0])) { total++; } //If the ends of range2 are within range1, total++
            }

            Console.WriteLine($"Day 4 Star 2 Answer: {total}");
        }
        #endregion
        #region Day Three
        static void Day3Star1()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int sum = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string firsthalf = line.Substring(0, line.Length / 2);
                string lasthalf = line.Substring(line.Length / 2);

                char key = ' ';
                foreach(char letter in firsthalf)
                {
                    if (lasthalf.Contains(letter)){key = letter; break; }
                }

                if(key > 96){sum += key - 96;}
                else{sum += key - 38;}
            }

            Console.WriteLine($"Day 3 Star 1 Answer: {sum}");
        }

        static void Day3Star2()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int sum = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string line2 = reader.ReadLine();
                string line3 = reader.ReadLine();

                char key = ' ';
                foreach (char letter in line)
                {
                    if (line2.Contains(letter) && line3.Contains(letter)){key = letter; break; }
                }

                if (key > 96){sum += key - 96;}
                else{sum += key - 38;}
            }

            Console.WriteLine($"Day 3 Star 2 Answer: {sum}");
        }
        #endregion
        #region Day Two
        static void Day2Star1()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int total = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split(" ");
                char enemyPlay = split[0][0];
                char yourPlay = split[1][0];

                //A && X == Rock, B && Y == Paper, C && Z == Scissors
                if ((enemyPlay == 'A' && yourPlay == 'X') || (enemyPlay == 'B' && yourPlay == 'Y') || (enemyPlay == 'C' && yourPlay == 'Z')) { total += 3; }
                else if ((enemyPlay == 'A' && yourPlay == 'Y') || (enemyPlay == 'B' && yourPlay == 'Z') || (enemyPlay == 'C' && yourPlay == 'X')) { total += 6; }

                total += (int)yourPlay - 87;
            }

            Console.WriteLine($"Day 2 Star 1 Answer: {total}");
        }

        static void Day2Star2()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int total = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split(" ");
                char enemyPlay = split[0][0];
                char gameResult = split[1][0];

                //A == Rock, B == Paper, C == Scissors
                //X == Lose, Y == Draw, Z == Win
                if (gameResult == 'X') { total += (enemyPlay - 63) % 3 + 1; } //A => 3, B => 1, C => 2
                if (gameResult == 'Y') { total += 3 + enemyPlay - 64; }
                if (gameResult == 'Z') { total += 6 + (enemyPlay - 61) % 3 + 1; } //A => 2, B => 3, C => 1, plus 6 for Winning
            }

            Console.WriteLine($"Day 2 Star 2 Answer: {total}");
        }
        #endregion
        #region Day One
        static void Day1Star1()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int max = 0;
            int current = 0;

            while ((line = reader.ReadLine()) != null)
            {
                if(line != ""){current += int.Parse(line);}
                else
                {
                    if(current > max)
                    {
                        max = current;
                    }
                    current = 0;
                }
            }

            Console.WriteLine($"Day 1 Star 1 Answer: {max}");
        }

        static void Day1Star2()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            List<int> sums = new List<int>();
            int current = 0;

            while ((line = reader.ReadLine()) != null)
            {
                if (line != ""){current += int.Parse(line);}
                else
                {
                    sums.Add(current);
                    current = 0;
                }
            }

            sums.Sort();
            sums.Reverse();

            Console.WriteLine($"Day 1 Star 2 Answer: {sums[0] + sums[1] + sums[2]}");
        }
        #endregion
    }
}
