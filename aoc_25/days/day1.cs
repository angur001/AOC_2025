namespace aoc_25.days
{
    public class day1
    {
        private static void part1()
        {
            // Part 1 implementation
            var input = File.ReadAllLines("files/day1.txt");
            int zeroCount = 0;
            int currentNumber = 50;
            foreach (var line in input)
            {
                var trimmedLine = line.Trim();
                var rotation = trimmedLine[0];
                var number = int.Parse(trimmedLine[1..]);
                currentNumber = rotation switch
                {
                    'R' => (currentNumber + number) % 100,
                    'L' => (currentNumber - number + 100) % 100,
                    _ => currentNumber
                };

                zeroCount += currentNumber == 0 ? 1 : 0;
            }

            System.Console.WriteLine($"Part1: {zeroCount}");
        }

        private static void part2()
        {
            // Part 2 implementation
            var input = File.ReadAllLines("files/day1.txt");
            int zeroCount = 0;
            int currentNumber = 50;
            foreach (var line in input)
            {
                var trimmedLine = line.Trim();
                var rotation = trimmedLine[0];
                var number = int.Parse(trimmedLine[1..]);
                switch (rotation)
                {
                    case 'R':
                        {
                            var temp = currentNumber + number;
                            zeroCount += temp / 100;
                            currentNumber = temp % 100;
                            break;
                        }
                    case 'L':
                        {
                            var temp = currentNumber - number;
                            if (temp <= 0)
                            {
                                zeroCount += 1 + Math.Abs(temp / 100) - (currentNumber == 0 ? 1 : 0);
                                currentNumber = (temp % 100 + 100) % 100;
                            } else {
                                currentNumber = temp;
                            }
                            break;
                        }
                }
            }

            System.Console.WriteLine($"Part2: {zeroCount}");
        }

        public static void Run()
        {
            // Implementation for day 1
            System.Console.WriteLine("Running Day 1");
            part1();
            part2();
        }
    }
}