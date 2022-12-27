namespace advent_of_code_2022;

public static class DayThree
{
    static string[] input() => InputHelper.Read((3));

   
    public static void SolvePartOne()
    {
        var score = 0;
        foreach (var line in input())
        {
            // find the matching character in both first and second half
            // get the integer a-z = 1-26 and A-Z = 27-52
            // add to the score
            var firstHalf = line.Substring(0, (line.Length / 2));
            var secondHalf = line.Substring((line.Length / 2));
            var match = secondHalf.ToCharArray()?.FirstOrDefault(item => firstHalf.ToCharArray().Contains(item));
            // if uppercase, subtract 38
            // observed value for lowercase a
            var charNumber = getCodeForChar(match);
            score += charNumber;
            
        }
        Console.WriteLine($"day three - part one: {score}");
        // too high 27513
        // correct 8515
    }
static int getCodeForChar(char? match)
{
    var charNumber = (int)match;
            if (charNumber < 97)
            {
                charNumber -= 38;
            }
            else
            {
                charNumber -= 96;
            }
            return charNumber;
}
    public static void SolvePartTwo()
    {
        var score = 0;
        foreach (var group in input().Chunk(3))
        {
            var matches = group.First().ToCharArray()?.Where(item => group.Last().ToCharArray().Contains(item));
            var match = matches?.FirstOrDefault(item => group.Skip(1).First().ToCharArray().Contains(item));
score += getCodeForChar(match);
        }
        Console.WriteLine($"day three - part two: {score}");
    }
}