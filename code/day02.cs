using System.IO;
using System.Linq;

namespace AdventOfCode_2022.code
{
    public class Day02
{
    public const string Day = "02";

    public static string[] Input() =>
        File.ReadLines($"input/2022_{Day}_input.txt").ToArray();

    public static object Solve1()
    {
        var input = Input();
        return input.Sum(Score);
    }

    public static object Solve2()
    {
        var input = Input();
        return input.Sum(inputLine => Score(Transform(inputLine)));
    }

    static int Score(string input) => input switch
    {
        "A X" => 4,
        "A Y" => 8,
        "A Z" => 3,
        "B X" => 1,
        "B Y" => 5,
        "B Z" => 9,
        "C X" => 7,
        "C Y" => 2,
        "C Z" => 6,
        _ => 0
    };

    static string Transform(string input) => input switch
    {
        "A X" => "A Z",
        "A Y" => "A X",
        "A Z" => "A Y",
        "B X" => "B X",
        "B Y" => "B Y",
        "B Z" => "B Z",
        "C X" => "C Y",
        "C Y" => "C Z",
        "C Z" => "C X",
        _ => ""
    };
}
}