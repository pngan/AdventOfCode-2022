using System.IO;
using System.Linq;

namespace AdventOfCode_2022.code
{
    public readonly record struct Data04(long a1, long a2, long b1, long b2);

    public class Day04
{
    public const string Day = "04";

    public static Data04[] Input() =>
        File.ReadLines($"input/2022_{Day}_input.txt")
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(x => x.Split(',', '-'))
            .Select(x => x.Select(int.Parse).ToArray())
            .Select(x => new Data04(x[0], x[1], x[2], x[3]))
            .ToArray();

    public static object Solve1()
    {
        var data = Input();
        return data.Count(d => (d.a1 >= d.b1 && d.a2 <= d.b2) || (d.b1 >= d.a1 && d.b2 <= d.a2));
    }

    public static object Solve2()
    {
        var data = Input();
        return data.Count(d => (d.a2 >= d.b1) && (d.b2 >= d.a1));
    }
}
}