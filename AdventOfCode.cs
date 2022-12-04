using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
            Day4Star2();
        }

        #region Day Four
        static void Day4Star1()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int total = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] splitInput = line.Split(",");

                int range1Low = int.Parse(splitInput[0].Split("-")[0]);
                int range1High = int.Parse(splitInput[0].Split("-")[1]);
                int range2Low = int.Parse(splitInput[1].Split("-")[0]);
                int range2High = int.Parse(splitInput[1].Split("-")[1]);
                if(range1Low >= range2Low && range1High <= range2High){total++;}
                else if(range2Low >= range1Low && range2High <= range1High){total++;}
            }

            Console.WriteLine(total);
        }

        static void Day4Star2()
        {
            StreamReader reader = new StreamReader("../../../AdventData2022.txt");
            string line;

            int total = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] splitInput = line.Split(",");

                int range1Low = int.Parse(splitInput[0].Split("-")[0]);
                int range1High = int.Parse(splitInput[0].Split("-")[1]);
                int range2Low = int.Parse(splitInput[1].Split("-")[0]);
                int range2High = int.Parse(splitInput[1].Split("-")[1]);

                List<int> range1 = Enumerable.Range(range1Low,range1High - range1Low + 1).ToList();
                List<int> range2 = Enumerable.Range(range2Low, range2High - range2Low + 1).ToList();

                bool isOverlapping = false;
                foreach(int num in range1)
                {
                    if (range2.Contains(num))
                    {
                        total++;
                        isOverlapping = true;
                        break;
                    }
                }

                if (!isOverlapping)
                {
                    foreach (int num in range2)
                    {
                        if (range1.Contains(num))
                        {
                            total++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(total);
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
                    if (lasthalf.Contains(letter)){key = letter;}
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
                    if (line2.Contains(letter) && line3.Contains(letter)){key = letter;}
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
                if(line != "")
                {
                    current += int.Parse(line);
                }
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
                if (line != "")
                {
                    current += int.Parse(line);
                }
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
