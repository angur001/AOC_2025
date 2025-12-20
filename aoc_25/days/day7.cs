using System.Security;

namespace aoc_25.days
{
    public class day7
    {
        public static void Run()
        {
            System.Console.WriteLine("Running Day 7");
            // Implementation for day 7
            part1();
            part2();
        }

        private static void part2()
        {
            var lines = File.ReadAllLines("files/day7.txt");
            var positions = new Dictionary<int, long>{ [lines[0].IndexOf('S')] = 1 };
            for (int i = 1; i < lines.Length; i++)
            {
                var newPositions = new Dictionary<int, long>(positions);
                foreach (var pos in positions.Keys)
                {
                    if (lines[i][pos] == '^')
                    {
                        newPositions.Remove(pos);
                        if (!newPositions.ContainsKey(pos+1))
                            newPositions.Add(pos+1, positions[pos]);
                        else
                            newPositions[pos+1] += positions[pos];

                        if (!newPositions.ContainsKey(pos-1))
                            newPositions.Add(pos-1, positions[pos]);
                        else
                            newPositions[pos-1] += positions[pos];
                    }
                }
                positions = newPositions;
                // System.Console.WriteLine($"{lines[i]}     ||     Number of beams so far at line {i}: {string.Join(", ", positions.Select(kv => $"{kv.Key}:{kv.Value}"))}");
            }
            long result = positions.Values.Sum();
            System.Console.WriteLine($"Part2: {result}");
        }


        private static void part1()
        {
            var lines = File.ReadAllLines("files/day7.txt");
            var positions = new HashSet<int>{ lines[0].IndexOf('S') };
            var split_count = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                var newPositions = new HashSet<int>();
                foreach (var pos in positions)
                {
                    if (lines[i][pos] == '^')
                    {
                        split_count++;
                        if (!positions.Contains(pos+1))
                            newPositions.Add(pos+1);
                        if (!positions.Contains(pos-1))
                            newPositions.Add(pos-1);                        
                    } else
                    {
                        newPositions.Add(pos);
                    }
                }
                positions = newPositions;
            }
            System.Console.WriteLine($"Part1: {split_count}");
        }
    }
}