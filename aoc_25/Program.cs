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
    case "3": day3.Run(); break;
    case "4": day4.Run(); break;
    case "5": day5.Run(); break;
    default:
        Console.WriteLine($"Unknown day {day}");
        break;
}