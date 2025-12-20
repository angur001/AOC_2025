
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace aoc_25.days
{
    public class day2 : abstractDay
    {
        static IDictionary<int, int[]> divisors = new Dictionary<int, int[]>
    {
        { 2, new[] { 2 } }, // Split into 2 parts of len 1
        { 3, new[] { 3 } }, // Split into 3 parts of len 1
        { 4, new[] { 2, 4 } }, // Split into 2 parts of len 2, or 4 parts of len 1
        { 5, new[] { 5 } }, 
        { 6, new[] { 2, 3, 6 } }, 
        { 7, new[] { 7 } },
        { 8, new[] { 2, 4, 8 } },
        { 9, new[] { 3, 9 } },
        { 10, new[] { 2, 5, 10 } },
        { 11, new[] { 11 } },
        { 12, new[] { 2, 3, 4, 6, 12 } },
        { 13, new[] { 13 } },
        { 14, new[] { 2, 7, 14 } },
        { 15, new[] { 3, 5, 15 } }
    };
        public static void Run()
        {
            // Implementation for day 1
            System.Console.WriteLine("Running Day 2");
            part1();
            part2();
        }

        private static void part2()
        {
            var input = File.ReadAllLines("files/day2.txt");
            if (input.Length > 1) throw new Exception("Unexpected multiple lines in input : found " + input.Length);

            var ranges = input[0].Trim().Split(",");
            long count = 0;
            foreach (var range in ranges)
            {
                var lower = Int64.Parse(range.Split("-")[0]);
                var upper = Int64.Parse(range.Split("-")[1]);

                for (long i = lower; i <= upper; i++)
                {
                    var mynum = i.ToString();
                    if(!divisors.ContainsKey(mynum.Length)) continue;
                    var candidates = divisors[mynum.Length];
                    foreach (var cand in candidates)
                    {
                        var div = mynum.Length / cand;
                        bool allMatch = true;
                        for (int ind = 0; ind < cand - 1; ind++)
                        {
                            int start1 = ind * div;
                            int end1 = start1 + div;
                            int start2 = end1;
                            int end2 = start2 + div;

                            if (mynum[start1..end1] != mynum[start2..end2])
                            {
                                allMatch = false;
                                break;
                            }
                        }

                        if (allMatch)
                        {
                            count += i;
                            break;
                        }
                    }
                }
            }
                System.Console.WriteLine($"Part2: {count}");
        }


        private static void part1()
        {
            var input = File.ReadAllLines("files/day2.txt");
            if (input.Length > 1) throw new Exception("Unexpected multiple lines in input : found " + input.Length);

            var ranges = input[0].Trim().Split(",");
            long count = 0;
            foreach (var range in ranges)
            {
                var lower = Int64.Parse(range.Split("-")[0]);
                var upper = Int64.Parse(range.Split("-")[1]);

                for (long i = lower; i <= upper; i++)
                {
                    var mynum = i.ToString();
                    var half = mynum.Length / 2;
                    if (mynum[..half] == mynum[half..])
                    {
                        count += i;
                        // System.Console.WriteLine($"Found matching number: {i}");
                    }
                }
            }
            System.Console.WriteLine($"Part1: {count}");
        }
    }
}