using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_Of_Code_2022
{
    public static class Day11
    {
        private static string dataLocation = "Day_11/AdventData.txt";

        public static void Star1()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            List<Monkey> monkeys = new List<Monkey>();
            while ((line = reader.ReadLine()) != null)
            {
                if(line != "")
                {
                    monkeys.Add(new Monkey(reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine()));
                }
            }

            for (int i = 0; i < monkeys.Count*20; i++){monkeys[i%monkeys.Count].Star1Action(monkeys);}

            List<long> inspects = monkeys.Select(x => x.numInspects).OrderByDescending(x => x).ToList();
            Console.WriteLine($"Day 11 Star 1 Answer: {inspects[0] * inspects[1]}");
            reader.Close();
        }

        class Monkey
        {
            public List<long> items = new List<long>();
            public string operationAction = "";
            public int operationNumber;

            public int testRuleNum;

            public int testTrueLoc;
            public int testFalseLoc;

            public long numInspects = 0;
            public Monkey(string startingItems, string operation, string testRule, string testTrue, string testFalse)
            {
                string[] startItems = Array.FindAll(Regex.Split(startingItems.Trim(), @"\D"), c => c != "");
                foreach (string item in startItems){items.Add(int.Parse(item));}

                string[] operationSplit = operation.Split(" ");
                operationAction = operationSplit[6];
                if(operationSplit[7] == "old"){operationNumber = -1;}
                else{operationNumber = int.Parse(operationSplit[7]);}

                testRuleNum = int.Parse(testRule.Split("divisible by ")[1]);
                testTrueLoc = int.Parse(testTrue.Split("throw to monkey ")[1]);
                testFalseLoc = int.Parse(testFalse.Split("throw to monkey ")[1]);
            }

            public void Star1Action(List<Monkey> monkeys)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    numInspects++;

                    if(operationNumber != -1)
                    {
                        if (operationAction == "+") { items[i] += operationNumber; }
                        else if (operationAction == "*") { items[i] *= operationNumber; }
                    }
                    else
                    {
                        if (operationAction == "+") { items[i] += items[i]; }
                        else if (operationAction == "*") { items[i] *= items[i]; }
                    }
                    
                    items[i] /= 3;

                    if (items[i]%testRuleNum == 0)
                    {
                        monkeys[testTrueLoc].items.Add(items[i]);
                        items.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        monkeys[testFalseLoc].items.Add(items[i]);
                        items.RemoveAt(i);
                        i--;
                    }
                }
            }

            public void Star2Action(List<Monkey> monkeys, int lcm)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    numInspects++;

                    if (operationNumber != -1)
                    {
                        if (operationAction == "+") { items[i] += operationNumber; }
                        else if (operationAction == "*") { items[i] *= operationNumber; }
                    }
                    else
                    {
                        if (operationAction == "+") { items[i] += items[i]; }
                        else if (operationAction == "*") { items[i] *= items[i]; }
                    }

                    items[i] %= lcm;

                    if (items[i] % testRuleNum == 0)
                    {
                        monkeys[testTrueLoc].items.Add(items[i]);
                        items.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        monkeys[testFalseLoc].items.Add(items[i]);
                        items.RemoveAt(i);
                        i--;
                    }
                }
            }

        }

        public static void Star2()
        {
            StreamReader reader = new StreamReader(dataLocation);
            string line;

            List<Monkey> monkeys = new List<Monkey>();
            while ((line = reader.ReadLine()) != null)
            {
                if (line != "")
                {
                    monkeys.Add(new Monkey(reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine()));
                }
            }
            int lcm = LCM(monkeys.Select(x => x.testRuleNum).ToList().ToArray());
            for (int j = 1; j <= 10000; j++)
            {
                for (int i = 0; i < monkeys.Count; i++)
                { 
                    monkeys[i].Star2Action(monkeys,lcm);
                }
            }

            List<long> inspects = monkeys.Select(x => x.numInspects).OrderByDescending(x => x).ToList();
            Console.WriteLine($"Day 11 Star 2 Answer: {inspects[0] * inspects[1]}\n");
            reader.Close();
        }

        static int GCD(int n1, int n2)
        {
            if (n2 == 0){return n1;}
            else{return GCD(n2, n1 % n2);}
        }

        static int LCM(int[] numbers){return numbers.Aggregate((S, val) => S * val / GCD(S, val));}
    }
}
