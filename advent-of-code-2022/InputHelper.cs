namespace advent_of_code_2022;

public static class InputHelper
{
    public static string[] Read(int day)
    {
        return File.ReadAllLines($"day{day}input.txt");
    }
}