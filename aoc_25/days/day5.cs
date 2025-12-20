
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace aoc_25.days
{
    public class day5 : abstractDay
    {
        public static void Run()
        {
            System.Console.WriteLine("Running Day 5");
            // Implementation for day 5
            part1();
            part2();
        }

        private static void part2()
        {
            long count = 0;
            var lines = File.ReadAllLines("files/day5.txt");
            var ranges = lines[..200].Select(line =>
            {
                var trimmedLine = line.Trim();
                var parts = trimmedLine.Split('-');
                return (Int64.Parse(parts[0]), Int64.Parse(parts[1]));
            }).ToList();

            var myRanges = new List<(Int64, Int64)>();
            foreach (var range in ranges)
            {
                var toAdd = range;
                var indexesToRemove = new List<int>();
                for (int i = 0; i < myRanges.Count; i++)
                {
                    if (myRanges[i].Item2 < toAdd.Item1 || myRanges[i].Item1 > toAdd.Item2)
                    {
                        continue;
                    }
                    
                    var newStart = Math.Min(myRanges[i].Item1, toAdd.Item1);
                    var newEnd = Math.Max(myRanges[i].Item2, toAdd.Item2);
                    
                    toAdd = (newStart, newEnd);
                    indexesToRemove.Add(i);
                }
                for (int i = indexesToRemove.Count - 1; i >= 0; i--)
                {
                    myRanges.RemoveAt(indexesToRemove[i]);
                }
                myRanges.Add(toAdd);
            }

            count = myRanges.Aggregate(0L, (acc, range) => acc + (range.Item2 - range.Item1 + 1));

            System.Console.WriteLine($"Part2: {count}");
        }

        // private static bool isContained((long, long) value, (long, long) range)
        // {
        //     if (value.Item1 >= range.Item1 && value.Item2 <= range.Item2) return true;
        //     return false;
        // }


        // private static bool contains((long, long) value, (long, long) range)
        // {
        //     if (value.Item1 <= range.Item1 && value.Item2 >= range.Item2) return true;
        //     return false;
        // }

        // private static bool intersects((long, long) value, (long, long) range)
        // {
        //     if (value.Item2 > range.Item1 && value.Item2 < range.Item2 || range.Item2 > value.Item1 && range.Item2 < value.Item2) return true;
        //     return false;
        // }

        private static void part1()
        {
            int count = 0;
            var lines = File.ReadAllLines("files/day5.txt");
            var ranges = lines[..200].Select(line =>
            {
                var trimmedLine = line.Trim();
                var parts = trimmedLine.Split('-');
                return (Int64.Parse(parts[0]), Int64.Parse(parts[1]));
            }).ToList();

            var numbers = lines[201..].Select(line => Int64.Parse(line.Trim())).ToList();

            foreach (var number in numbers)
            {
                var inRange = ranges.Any(range => number >= range.Item1 && number <= range.Item2);
                if (inRange)
                {
                    count++;
                }
            }

            System.Console.WriteLine($"Part1: {count}");
        }
    }
}