namespace advent_of_code_2022;

public static class DayFour
{
    static string[] input() => InputHelper.Read((4));
   
    public static void SolvePartOne()
    {
        // trying this one with copilot... I find it difficult to get it to suggest the data structure I want.
        var score = 0;
        var rangePairCsv = input();

        // split on comma into pairs of ranges
        var rangePairArrays = rangePairCsv.Select(item => item.Split(','));
        // split the ranges on dash
        var arraysOfRangePairArrays = rangePairArrays.Select(item => item.Select(item2 => item2.Split('-').ToArray()));
        // convert to int
        var rangeObjects = arraysOfRangePairArrays.Select(item => item.Select(item2 => new { min = int.Parse(item2[0]), max = int.Parse(item2[1]) }).ToArray());

        var count = 0; //rangesContainedByAnotherRange.Count();

        // for each item if any range contains the other, increment the count
        // oh boo, I had to write this myself; frustrated with copilot.
        foreach (var rangePair in rangeObjects)
        {
            var secondContainedInFirst = (rangePair[0].min <= rangePair[1].min && rangePair[0].max >= rangePair[1].max) ? 1 : 0;
            count += secondContainedInFirst;
            if(secondContainedInFirst == 0)
            {
                count += (rangePair[1].min <= rangePair[0].min && rangePair[1].max >= rangePair[0].max) ? 1 : 0;
            }
        }

        Console.WriteLine($"{nameof(DayFour)} - part one: {count}");
        // copilot says 143, which is too low.
        // copilot says 942, which is too high.
        // I said 659, which is too high. I knew to stop counting if the first range contained the second, but I ran it anyway.
        // 644 is correct.

    }
    public static void SolvePartTwo()
    {
        var rangePairCsv = input();

        // split on comma into pairs of ranges
        var rangePairArrays = rangePairCsv.Select(item => item.Split(','));
        // split the ranges on dash
        var arraysOfRangePairArrays = rangePairArrays.Select(item => item.Select(item2 => item2.Split('-').ToArray()));
        // convert to int
        var rangeObjects = arraysOfRangePairArrays.Select(item => item.Select(item2 => new { min = int.Parse(item2[0]), max = int.Parse(item2[1]) }).ToArray());

        var count = 0; 

        // for each item if any range contains any part of the other, increment the count
        foreach (var rangePair in rangeObjects)
        {
            var firstOverlapsSecond = (rangePair[0].max >= rangePair[1].min) && (rangePair[0].max <= rangePair[1].max) ||
            ((rangePair[0].min >= rangePair[1].min) && (rangePair[0].min <= rangePair[1].max)) ? 1 : 0;
            count += firstOverlapsSecond;
            if(firstOverlapsSecond == 0)
            {
                count += (rangePair[1].min <= rangePair[0].max) && (rangePair[1].min >= rangePair[0].min) ||
                ((rangePair[1].max <= rangePair[0].max) && (rangePair[1].max >= rangePair[0].min)) ? 1 : 0;
            }
        }
        Console.WriteLine($"{nameof(DayFour)} - part two: {count}");
        // 961 too high
        // 781 too low
        // 926 correct

    }
}