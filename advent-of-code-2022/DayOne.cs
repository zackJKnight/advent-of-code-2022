namespace advent_of_code_2022;

public static class DayOne
{
    public static void Solve()
    {
        var input = InputHelper.Read(1);
        var elves = new List<int>();
        var elf = 0; 
        foreach (var inputString in input)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                elf += int.Parse(inputString);
                //Console.WriteLine(elf);
            }
            else
            {
                elves.Add(elf);
                elf = 0;
            }
    
        }
// day 1 part 1 answer:
 Console.WriteLine($"day one - part one: {elves.Max()}");

// day 1 part 2:
        elves.Sort();
        elves.Reverse();
        var top3 = elves.Take(3);
        Console.WriteLine($"day one - part two: {top3.Sum()}");
        //208180 correct
    }
}