using System.Diagnostics;
using System.Runtime.Versioning;

namespace aoc_25.days
{
    public class day8 : abstractDay
    {

        readonly struct Box
        {
            public readonly long X;
            public readonly long Y;
            public readonly long Z;

            public Box(long x, long y, long z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }
        public static void Run()
        {
            System.Console.WriteLine("Running Day 8");
            // Implementation for day 8
            part1();
            part2();
        }

        private static void part1()
        {
            var lines = File.ReadAllLines("files/day8.txt");
            var boxes = new Box[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var p = lines[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                boxes[i] = new Box(
                    int.Parse(p[0]),
                    int.Parse(p[1]),
                    int.Parse(p[2])
                );
            }
            var results = new List<(int I, int J, long Dist2)>(lines.Length * lines.Length / 2);

            for (int i = 0; i < boxes.Length; i++)
            {
                for (int j = i + 1; j < boxes.Length; j++)
                {
                    long d2 = SquaredDistance(boxes[i], boxes[j]);
                    results.Add((i, j, d2));
                }
            }

            results.Sort((a, b) => a.Dist2.CompareTo(b.Dist2));
            var best = results.Take(1000).ToArray();
            var circuits = new List<HashSet<int>>();

            foreach (var (I, J, Dist2) in best)
            {
                HashSet<int>? setI = null;
                HashSet<int>? setJ = null;

                foreach (var set in circuits)
                {
                    if (set.Contains(I))
                        setI = set;
                    if (set.Contains(J))
                        setJ = set;
                }

                if (setI == null && setJ == null)
                {
                    var newSet = new HashSet<int> { I, J };
                    circuits.Add(newSet);
                }
                else if (setI != null && setJ == null)
                {
                    setI.Add(J);
                }
                else if (setI == null && setJ != null)
                {
                    setJ.Add(I);
                }
                else if (setI != setJ)
                {
                    foreach (var item in setJ!)
                    {
                        setI!.Add(item);
                    }
                    circuits.Remove(setJ);
                }
            }
            circuits.Sort((a, b) => b.Count.CompareTo(a.Count));
            var res = circuits.Take(3).Aggregate(1, (long acc, HashSet<int> set) => acc * set.Count);
            Console.WriteLine($"Part1: {res}");
        }

        private static long SquaredDistance(Box a, Box b)
        {
            long dx = a.X - b.X;
            long dy = a.Y - b.Y;
            long dz = a.Z - b.Z;
            return dx * dx + dy * dy + dz * dz;
        }

        private static void part2()
        {
            var lines = File.ReadAllLines("files/day8.txt");
            var boxes = new Box[lines.Length];
            var res = 0L;
            for (int i = 0; i < lines.Length; i++)
            {
                var p = lines[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                boxes[i] = new Box(
                    int.Parse(p[0]),
                    int.Parse(p[1]),
                    int.Parse(p[2])
                );
            }
            var results = new List<(int I, int J, long Dist2)>(lines.Length * lines.Length / 2);

            for (int i = 0; i < boxes.Length; i++)
            {
                for (int j = i + 1; j < boxes.Length; j++)
                {
                    long d2 = SquaredDistance(boxes[i], boxes[j]);
                    results.Add((i, j, d2));
                }
            }

            results.Sort((a, b) => a.Dist2.CompareTo(b.Dist2));
            var circuits = new List<HashSet<int>>();

            foreach (var (I, J, Dist2) in results)
            {
                HashSet<int>? setI = null;
                HashSet<int>? setJ = null;

                foreach (var set in circuits)
                {
                    if (set.Contains(I))
                        setI = set;
                    if (set.Contains(J))
                        setJ = set;
                }

                if (setI == null && setJ == null)
                {
                    var newSet = new HashSet<int> { I, J };
                    circuits.Add(newSet);
                }
                else if (setI != null && setJ == null)
                {
                    setI.Add(J);
                }
                else if (setI == null && setJ != null)
                {
                    setJ.Add(I);
                }
                else if (setI != setJ)
                {
                    foreach (var item in setJ!)
                    {
                        setI!.Add(item);
                    }
                    circuits.Remove(setJ);
                }

                // System.Console.WriteLine($"After processing ({I},{J}) - Dist2={Dist2}, we have {circuits.Count} circuits.");

                if ((circuits.Count == 1) && (circuits[0].Count == boxes.Length))
                {
                    res = boxes[I].X * boxes[J].X;
                    break;
                }
            }
            Console.WriteLine($"Part2: {res}");
        }
    }
}