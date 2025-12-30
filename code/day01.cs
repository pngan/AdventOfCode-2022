using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode_2022.code
{
    public class Day01
{
    public const string Day = "01";

    public static IEnumerable<int>[] Input() =>
        File.ReadLines($"input/2022_{Day}_input.txt")
            .Split(x => x == string.Empty)
            .Select(x => x.Select(int.Parse)).ToArray();

    public static object Solve1()
    {
        var input = Input();
        return input.Select(x => x.Sum()).Max();
    }

    public static object Solve2()
    {
        var input = Input();
        return input.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum();
    }
}
}