using System;
using System.IO;

namespace Advent_Of_Code_2022
{
    public static class Day2
    {
        private static string dataLocation = "Day_2/AdventData.txt";
        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int total = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split(" ");
                char enemyPlay = split[0][0];
                char yourPlay = split[1][0];

                //A && X == Rock, B && Y == Paper, C && Z == Scissors
                if (enemyPlay == 'A' && yourPlay == 'X' || enemyPlay == 'B' && yourPlay == 'Y' || enemyPlay == 'C' && yourPlay == 'Z') { total += 3; }
                else if (enemyPlay == 'A' && yourPlay == 'Y' || enemyPlay == 'B' && yourPlay == 'Z' || enemyPlay == 'C' && yourPlay == 'X') { total += 6; }

                total += yourPlay - 87;
            }

            Console.WriteLine($"Day 2 Star 1 Answer: {total}");
            reader.Close();
        }
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
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

            Console.WriteLine($"Day 2 Star 2 Answer: {total}\n");
            reader.Close();
        }
    }
}
