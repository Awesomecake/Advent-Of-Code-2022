using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Numerics;
using System.Threading;

namespace Advent_Of_Code_2022
{
    public static class Day9
    {
        private static string dataLocation = "Day_9/AdventData.txt";

        public static void Star1()
        {
            Vector2 head = new Vector2(0,4);
            Vector2 tail = new Vector2(0, 4);
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            HashSet<Vector2> locations = new HashSet<Vector2>();

            while ((line = reader.ReadLine()) != null)
            {
                char direction = line.Split(" ")[0][0];
                int moves = int.Parse(line.Split(" ")[1]);
                for (int i = 0; i < moves; i++)
                {
                    if (direction == 'R'){head.X++;}
                    if (direction == 'L'){head.X--;}
                    if (direction == 'U'){head.Y--;}
                    if (direction == 'D'){head.Y++;}

                    if(head.X > tail.X+1 || head.X < tail.X -1)
                    {
                        tail.X += (head.X - tail.X) / 2;
                        if (head.Y > tail.Y || head.Y < tail.Y){tail.Y += (head.Y - tail.Y);}
                    }

                    if (head.Y > tail.Y + 1 || head.Y < tail.Y - 1)
                    {
                        tail.Y += (head.Y - tail.Y) / 2;
                        if (head.X > tail.X || head.X < tail.X){tail.X += (head.X - tail.X);}
                    }
                    locations.Add(new Vector2(tail.X, tail.Y));
                }
            }

            Console.WriteLine($"Day 9 Star 1 Answer: {locations.Count}");
            reader.Close();
        }

        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            List<Vector2> tails = new List<Vector2>();
            for (int i = 0; i < 10; i++){tails.Add(new Vector2(0, 4));}
            HashSet<Vector2> locations = new HashSet<Vector2>();

            while ((line = reader.ReadLine()) != null)
            {
                char direction = line.Split(" ")[0][0];
                int moves = int.Parse(line.Split(" ")[1]);
                for (int i = 0; i < moves; i++)
                {
                    Vector2 head = tails[0];
                    if (direction == 'R'){head.X++;}
                    if (direction == 'L'){head.X--;}
                    if (direction == 'U'){head.Y--;}
                    if (direction == 'D'){head.Y++;}

                    tails[0] = head;
                    for (int f = 0; f < tails.Count-1; f++)
                    {
                        Vector2 tail = new Vector2(tails[f + 1].X, tails[f + 1].Y);
                        if (tails[f].X > tail.X + 1 || tails[f].X < tail.X - 1)
                        {
                            tail.X += (tails[f].X - tail.X) / 2;
                            if (tails[f].Y > tail.Y){tail.Y += 1;}
                            else if (tails[f].Y < tail.Y){tail.Y -= 1;}
                        }

                        if (tails[f].Y > tail.Y + 1 || tails[f].Y < tail.Y - 1)
                        {
                            tail.Y += (tails[f].Y - tail.Y) / 2;
                            if (tails[f].X > tail.X){tail.X += 1;}
                            else if (tails[f].X < tail.X){tail.X -= 1;}
                        }

                        tails[f + 1] = new Vector2(tail.X, tail.Y);
                    }
                    locations.Add(new Vector2(tails[9].X, tails[9].Y));
                }
            }
            Console.WriteLine($"Day 9 Star 2 Answer: {locations.Count}\n");
            reader.Close();
        }
    }
}
