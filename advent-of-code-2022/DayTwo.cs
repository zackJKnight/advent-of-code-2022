namespace advent_of_code_2022;

public static class DayTwo
{
    static string[] input() => InputHelper.Read((2));

    static Dictionary<char, int> getKey() => new()
    {
        { 'A', 1 },
        { 'B', 2 },
        { 'C', 3 },
        { 'X', 1 },
        { 'Y', 2 },
        { 'Z', 3 }
    };

    static List<List<Char>> getLoseDrawWin() => new List<List<Char>>()
    {
        new() { 'C', 'A', 'B' },
        new() {'A', 'B', 'C' },
        new() { 'B', 'C','A'}
    };
    public static void SolvePartOne()
    {
        var score = 0;
        var key = getKey();

        foreach (var line in input())
        {
            // tie if equal. 
            // 1 wins over 3
            // 2 wins over 1
            // 3 wins over 2
            if (key[line[0]] == key[line[2]])
            {
                score += (3 + key[line[2]]);
                continue;
            }
            if(key[line[2]] == 1 && key[line[0]] == 3)
            {
                score += (6 + key[line[2]]);
                continue;
            }
            if(key[line[2]] == 2 && key[line[0]] == 1)
            {
                score += (6 + key[line[2]]);
                continue;
            }
            if(key[line[2]] == 3 && key[line[0]] == 2)
            {
                score += (6 + key[line[2]]);
                continue;
            }
            if(true)
            {
                score += key[line[2]];
                continue;
            }
            
        }
        Console.WriteLine(score);
        // 15623 - too high
        // 8933 correct
    }

    public static void SolvePartTwo()
    {
        var score = 0;
        var key = getKey();
        var loseDrawWin = getLoseDrawWin();
        foreach (var line in input())
        {
            // need to lose
            if(key[line[2]] == 1)
            {
                int theirPlay = key[line[0]];
                score += key[loseDrawWin.ElementAt(theirPlay - 1).ElementAt(0)];
                continue;
            }
            // need to draw
            if(key[line[2]] == 2)
            {
                int theirPlay = key[line[0]];
                score += key[loseDrawWin.ElementAt(theirPlay - 1).ElementAt(1)] + 3;
                continue;
            }
            // need to win
            if(key[line[2]] == 3)
            {
                int theirPlay = key[line[0]];
                score += key[loseDrawWin.ElementAt(theirPlay - 1).ElementAt(2)] + 6;
                continue;
            }
        }
        Console.WriteLine(score);
        // 11998 correct
    }
}