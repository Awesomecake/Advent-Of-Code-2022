using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2022
{
    public static class Day8
    {
        private static string dataLocation = "Day_8/AdventData.txt";

        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            List<List<char>> array = new List<List<char>>();
            while ((line = reader.ReadLine()) != null)
            {
                List<char> row = new List<char>();
                array.Add(row);
                foreach (char letter in line){ row.Add(letter); }
            }

            int sum = 0;
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array[i].Count; j++)
                {
                    if (i == 0 || i == array.Count-1){ sum++; }
                    else if (j == 0 || j == array[i].Count - 1) { sum++; }
                    else if (isTreeVisible(array, i, j)){ sum++; }
                }
            }

            Console.WriteLine($"Day 8 Star 1 Answer: {sum}");
            reader.Close();
        }

        static bool isTreeVisible(List<List<char>> array, int i, int j)
        {
            int height = array.Count;
            int width = array[0].Count;

            bool canSee = true;
            for (int l = i+1; l < width; l++)
            {
                if(array[l][j] >= array[i][j]){canSee = false;}
            }
            if (canSee) { return canSee; }

            canSee = true;
            for (int l = i - 1; l >= 0; l--)
            {
                if (array[l][j] >= array[i][j]){canSee = false;}
            }
            if (canSee) { return canSee; }

            canSee = true;
            for (int l = j + 1; l < height; l++)
            {
                if (array[i][l] >= array[i][j]){canSee = false;}
            }
            if (canSee) { return canSee; }
            
            canSee= true;
            for (int l = j - 1; l >= 0; l--)
            {
                if (array[i][l] >= array[i][j]){canSee = false;}
            }

            return canSee;
        }

        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            List<List<char>> array = new List<List<char>>();
            while ((line = reader.ReadLine()) != null)
            {
                List<char> row = new List<char>();
                array.Add(row);
                foreach (char letter in line){ row.Add(letter); }
            }

            int max = 0;
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array[i].Count; j++)
                {
                    int sightValue = numTreesVisible(array,i,j);
                    if(sightValue > max) { max = sightValue; }
                }
            }

            Console.WriteLine($"Day 8 Star 2 Answer: {max}\n");
            reader.Close();
        }

        static int numTreesVisible(List<List<char>> array, int i, int j)
        {
            int height = array.Count;
            int width = array[0].Count;

            int sum1 = 0; int sum2 = 0; int sum3 = 0; int sum4 = 0;
            for (int l = i + 1; l < width; l++)
            {
                if (array[l][j] >= array[i][j]) { sum1++; break; }
                else { sum1++; }
            }

            for (int l = i - 1; l >= 0; l--)
            {
                if (array[l][j] >= array[i][j]) { sum2++; break; }
                else { sum2++; }
            }

            for (int l = j + 1; l < height; l++)
            {
                if (array[i][l] >= array[i][j]) { sum3++; break; }
                else { sum3++; }
            }

            for (int l = j - 1; l >= 0; l--)
            {
                if (array[i][l] >= array[i][j]) { sum4++; break; }
                else { sum4++; }
            }

            return sum1 *sum2*sum3*sum4;
        }
    }
}
