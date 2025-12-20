using System.Security;
using System.Security.AccessControl;

namespace aoc_25.days
{
    public class day3 : abstractDay
    {
        public static void Run()
        {
            // Implementation for day 3
            System.Console.WriteLine("Running Day 3");
            part1();
            part2();
        }

        private static void part2()
        {
            var lines = File.ReadAllLines("files/day3.txt");
            long count = 0;
            int CODE_LENGHT = 12;
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                var myints = trimmedLine.Select(c => int.Parse(c.ToString())).ToArray();
                int[] result = new int[CODE_LENGHT];
                int ind = 0;
                for (int i = 0; i < CODE_LENGHT; i++)
                {
                    var bse = myints[ind..(myints.Length-CODE_LENGHT+i+1)];
                    var num = bse.Max();
                    ind += 1 + Array.IndexOf(bse, num);
                    result[i] = num;
                }

                long joltage = result.Aggregate(0, (long acc,int val) => acc * 10 + val);
                count += joltage;

            }
            System.Console.WriteLine($"Part2: {count}");
        }


        private static void part1()
        {
            var lines = File.ReadAllLines("files/day3.txt");
            int count = 0;
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                var myints = trimmedLine.Select(c => int.Parse(c.ToString())).ToArray();
                var left = myints[..(myints.Length-1)].Max();
                var ind = Array.IndexOf(myints, left);
                var right = myints[(ind+1)..].Max();
                int joltage = left*10 + right;
                count += left*10 + right;
            }
            System.Console.WriteLine($"Part1: {count}");
        }
    }
}