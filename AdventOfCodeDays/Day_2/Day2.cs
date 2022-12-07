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
                string[] split = line.Split(" "); //Split line by space
                char enemyPlay = split[0][0]; //Get enemy input
                char yourPlay = split[1][0]; //Get "my" input

                //A && X == Rock, B && Y == Paper, C && Z == Scissors
                //If -> Tie, add three to total, Else If -> I Win, add six to total
                if (enemyPlay == 'A' && yourPlay == 'X' || enemyPlay == 'B' && yourPlay == 'Y' || enemyPlay == 'C' && yourPlay == 'Z') { total += 3; }
                else if (enemyPlay == 'A' && yourPlay == 'Y' || enemyPlay == 'B' && yourPlay == 'Z' || enemyPlay == 'C' && yourPlay == 'X') { total += 6; }

                //Convert play to num value, add it to total. X = 1, Y = 2, Z = 3
                total += yourPlay - 87;
            }

            Console.WriteLine($"Day 2 Star 1 Answer: {total}"); //Return total of points earned in all games
            reader.Close();
        }
        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            int total = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split(" "); //Split line by space
                char enemyPlay = split[0][0]; //Get enemy input
                char gameResult = split[1][0]; //Get outcome of the game

                //A == Rock, B == Paper, C == Scissors
                //X == Lose, Y == Draw, Z == Win
                //If -> Lose, add Input Score, Else If -> Tie, add Input Score plus 3, Else If -> Win, add Input Score plus 6
                if (gameResult == 'X') { total += (enemyPlay - 63) % 3 + 1; } //A => 3, B => 1, C => 2
                else if (gameResult == 'Y') { total += 3 + enemyPlay - 64; }
                else if (gameResult == 'Z') { total += 6 + (enemyPlay - 61) % 3 + 1; } //A => 2, B => 3, C => 1, plus 6 for Winning
            }

            Console.WriteLine($"Day 2 Star 2 Answer: {total}\n"); //Return total of points earned in all games
            reader.Close();
        }
    }
}
