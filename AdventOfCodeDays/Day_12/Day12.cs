using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Advent_Of_Code_2022
{
    public static class Day12
    {
        private static string dataLocation = "Day_12/AdventData.txt";

        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            Vector2 start = new Vector2();
            Vector2 end = new Vector2();
            List<List<char>> map = new List<List<char>>();
            while ((line = reader.ReadLine()) != null)
            {
                List<char> row = new List<char>();
                map.Add(row);
                foreach (char letter in line)
                {
                    row.Add(letter);
                    if(letter == 'E'){end = new Vector2(row.Count - 1,map.Count-1);}
                    if (letter == 'S'){start = new Vector2(row.Count - 1,map.Count-1);}
                }
            }

            int[,] dij = new int[map.Count,map[0].Count];
            for (int i = 0; i < dij.GetLength(0); i++)
            {
                for (int j = 0; j < dij.GetLength(1); j++)
                {
                    dij[i, j] = int.MaxValue;
                }
            }
            Queue<Vector2> queue = new Queue<Vector2>();
            dij[(int)start.Y, (int)start.X] = 0;
            map[(int)start.Y][(int)start.X] = 'a';
            map[(int)end.Y][(int)end.X] = '{';

            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                Vector2 current = queue.Peek();
                int cX = (int)current.X;
                int cY = (int)current.Y;
                Vector2 next = new Vector2(-1, -1);

                if (cY - 1 >= 0 && dij[cY - 1, cX] > dij[cY, cX] + 1 && map[cY - 1][cX] <= map[cY][cX] + 1) { next = new Vector2(cX, cY - 1); }
                if (cY + 1 < map.Count && dij[cY + 1, cX] > dij[cY, cX] + 1 && map[cY + 1][cX] <= map[cY][cX] + 1) { next = new Vector2(cX, cY + 1); }
                if (cX - 1 >= 0 && dij[cY, cX - 1] > dij[cY, cX] + 1 && map[cY][cX - 1] <= map[cY][cX] + 1) { next = new Vector2(cX - 1, cY); }
                if (cX + 1 < map[0].Count && dij[cY, cX + 1] > dij[cY, cX] + 1 && map[cY][cX + 1] <= map[cY][cX] + 1) { next = new Vector2(cX + 1, cY); }

                if (next.X != -1 && next.Y != -1) { queue.Enqueue(next); dij[(int)next.Y, (int)next.X] = dij[cY, cX] + 1; }
                else { queue.Dequeue(); }
            }
            Console.WriteLine($"Day 12 Star 1 Answer: {dij[(int)end.Y, (int)end.X]}");
            reader.Close();
        }

        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            Vector2 end = new Vector2();
            List<List<char>> map = new List<List<char>>();
            List<Vector2> aLocs = new List<Vector2>();
            while ((line = reader.ReadLine()) != null)
            {
                List<char> row = new List<char>();
                map.Add(row);
                foreach (char letter in line)
                {
                    row.Add(letter);
                    if (letter == 'E') { end = new Vector2(row.Count - 1, map.Count - 1); }
                    if (letter == 'S') { row[row.Count - 1] = 'a'; }
                    if(letter == 'a' || letter == 'S'){aLocs.Add(new Vector2(row.Count - 1, map.Count - 1));}
                }
            }

            List<int> distances = new List<int>();
            int[,] dij = new int[map.Count, map[0].Count];
            foreach (Vector2 startLoc in aLocs)
            {
                for (int i = 0; i < dij.GetLength(0); i++)
                {
                    for (int j = 0; j < dij.GetLength(1); j++)
                    {
                        dij[i, j] = int.MaxValue;
                    }
                }

                Queue<Vector2> queue = new Queue<Vector2>();
                dij[(int)startLoc.Y, (int)startLoc.X] = 0;
                map[(int)end.Y][(int)end.X] = '{';
                map[(int)startLoc.Y][(int)startLoc.X] = 'a';

                queue.Enqueue(startLoc);
                while (queue.Count != 0)
                {
                    Vector2 current = queue.Peek();
                    int cX = (int)current.X;
                    int cY = (int)current.Y;
                    Vector2 next = new Vector2(-1, -1);

                    if (cY - 1 >= 0 && dij[cY - 1, cX] > dij[cY, cX] + 1 && map[cY - 1][cX] <= map[cY][cX] + 1){ next = new Vector2(cX, cY - 1);}
                    if (cY + 1 < map.Count && dij[cY + 1, cX] > dij[cY, cX] + 1 && map[cY + 1][cX] <= map[cY][cX] + 1){ next = new Vector2(cX, cY + 1);}
                    if (cX - 1 >= 0 && dij[cY, cX - 1] > dij[cY, cX] + 1 && map[cY][cX - 1] <= map[cY][cX] + 1){next = new Vector2(cX - 1, cY);}
                    if (cX + 1 < map[0].Count && dij[cY, cX + 1] > dij[cY, cX] + 1 && map[cY][cX + 1] <= map[cY][cX] + 1){next = new Vector2(cX + 1, cY);}

                    if (next.X != -1 && next.Y != -1){queue.Enqueue(next); dij[(int)next.Y, (int)next.X] = dij[cY, cX] + 1;}
                    else{queue.Dequeue();}
                }
                distances.Add(dij[(int)end.Y, (int)end.X]);
            }

            Console.WriteLine($"Day 12 Star 2 Answer: {distances.Min()}\n");
            reader.Close();
        }
    }
}
