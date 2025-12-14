

using System.Reflection.Metadata;

namespace aoc_25.days
{
    public class day4
    {
        public static void Run()
        {
            // Implementation for day 4
            System.Console.WriteLine("Running Day 4");
            part1();
            part2();
        }

        private static void part1()
        {
            var lines = File.ReadAllLines("files/day4.txt");
            char[][] map = lines.Select(line => line.Trim().ToCharArray()).ToArray();
            int count = 0;
            for (int row = 0; row < map.Length; row++)
            {
                for (int col = 0; col < map[row].Length; col++)
                {
                    if (map[row][col] == '.') continue;
                    var neighborCount = getNeighborCount(map, row, col);
                    if (neighborCount < 4)
                    {

                        count++;
                    }
                }
            }
            System.Console.WriteLine($"Part1: {count}");
        }

        private static int getNeighborCount(char[][] map, int row, int col)
        {
            var deltas = new (int, int)[]
            {
                (-1, -1), (-1, 0), (-1, 1),
                (0, -1),          (0, 1),
                (1, -1),  (1, 0),  (1, 1)
            };
            int count = 0;
            foreach (var (dr, dc) in deltas)
            {
                int newRow = row + dr;
                int newCol = col + dc;
                if (newRow >= 0 && newRow < map.Length && newCol >= 0 && newCol < map[newRow].Length)
                {
                    if (map[newRow][newCol] == '@')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static void part2()
        {
            var lines = File.ReadAllLines("files/day4.txt");
            char[][] map = lines.Select(line => line.Trim().ToCharArray()).ToArray();
            int count = 0;
            while (true)
            {
                var positions = new List<(int,int)>();
                for (int row = 0; row < map.Length; row++)
                {
                    for (int col = 0; col < map[row].Length; col++)
                    {
                        if (map[row][col] == '.') continue;
                        var neighborCount = getNeighborCount(map, row, col);
                        if (neighborCount < 4)
                        {
                            positions.Add((row, col));
                            count++;
                        }
                    }
                }

                if (positions.Count == 0) break;

                foreach (var (r,c) in positions)
                {
                    map[r][c] = '.';
                }
                positions.Clear();
            }
            
            System.Console.WriteLine($"Part2: {count}");
        }
    }
}