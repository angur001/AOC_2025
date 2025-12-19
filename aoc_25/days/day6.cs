using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security;

namespace aoc_25.days
{
    public class day6
    {
        public static void Run()
        {
            System.Console.WriteLine("Running Day 6");
            // Implementation for day 6
            part1();
            part2();
        }

        private static void part2()
        {
            var lines = File.ReadAllLines("files/day6.txt");
            long result = 0;
            var numberToAdd = lines[..(lines.Length - 1)];
            var ops = lines[lines.Length - 1];
            var currentOp = ' ';
            var myNums = new List<string>();

            void ProcessCurrentGroup()
            {
                if (myNums.Count == 0) return;
                
                if (currentOp == '+')
                    result += myNums.Aggregate(0L, (acc, num) => acc + int.Parse(num));
                else if (currentOp == '*')
                    result += myNums.Aggregate(1L, (acc, num) => acc * int.Parse(num));
                    
                myNums.Clear();
            }

            for (int i=0; i< numberToAdd.First().Count(); i++)
            {
                if (ops[i] != ' ')
                {
                    currentOp = ops[i];
                }

                var num = new string(numberToAdd.Select(line => line[i]).Where(c => c != ' ').ToArray());
                if (num == "")
                {
                    ProcessCurrentGroup();
                    continue;
                }
                myNums.Add(num);
            }

            ProcessCurrentGroup();
            System.Console.WriteLine($"Part2: {result}");
        }

        private static void part1()
        {
            var lines = File.ReadAllLines("files/day6.txt");
            long result = 0;
            var numberToAdd = lines[..(lines.Length - 1)].Select(line => line.Split(' ').Where(numStr => numStr != "").Select(numStr => Int32.Parse(numStr))).ToList();
            var ops = lines[lines.Length - 1].Trim().Split(" ").Where(opStr => opStr != "");
            for (int i = 0; i < numberToAdd.First().Count(); i++)
            {
                if (ops.ElementAt(i) == "+")
                {
                    long toAdd = numberToAdd.Aggregate(0L, (acc, nums) => acc + nums.ElementAt(i));
                    result += toAdd;
                }
                else if (ops.ElementAt(i) == "*")
                {
                    long toMultiply = numberToAdd.Aggregate(1L, (acc, nums) => acc * nums.ElementAt(i));
                    result += toMultiply;
                }
            }
            System.Console.WriteLine($"Part1: {result}");
        }

    }
}