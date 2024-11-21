using AdventOfCode.Solutions.Common;

namespace AdventOfCode.Solutions.Days;

public class Day02 : BaseDay<string[]>
{
    protected override string[] Parse(string[] input) => input;

    protected override object Solve1(string[] input) => input.Sum(Score);

    protected override object Solve2(string[] input) => input.Sum(inputLine => Score(Transform(inputLine)));


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