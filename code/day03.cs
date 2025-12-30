using System.IO;
using System.Linq;

namespace AdventOfCode_2022.code
{
    public class Day03
{
    public const string Day = "03";

    public static string[] Input() =>
        File.ReadLines($"input/2022_{Day}_input.txt").ToArray();

    public static object Solve1()
    {
        var input = Input();

        int score = 0;
        foreach (var line in input)
        {
            var half = line.Length / 2;
            var first = line[..half];
            var last = line[half..];
            foreach (var c in first)
            {
                if (last.Contains(c))
                {
                    if (c >= 'a')
                        score += (c - 'a' + 1);
                    else
                        score += (c - 'A' + 27);
                    break;
                }
                
            }
        }
        return score;
    }

    public static object Solve2()
    {
        var input = Input();
        int score = 0;
        for (int i = 0; i < input.Length - 3; i += 3)
        {
            var common = input[i].Intersect(input[i + 1].Intersect(input[i + 2])).First();

            if (common >= 'a')
                score += (common - 'a' + 1);
            else
                score += (common - 'A' + 27);
        }

        return score;
    }
}
}