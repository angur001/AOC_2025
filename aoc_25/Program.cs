using aoc_25.days;

var day = args.FirstOrDefault();

if (day == null)
{
    Console.WriteLine("Specify a day: dotnet run -- 1");
    return;
}

switch (day)
{
    case "1": day1.Run(); break;
    case "2": day2.Run(); break;
    default:
        Console.WriteLine($"Unknown day {day}");
        break;
}