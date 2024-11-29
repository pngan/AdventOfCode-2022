using AdventOfCode.Solutions.Common;
using AdventOfCode.Solutions.Extensions;

namespace AdventOfCode.Solutions.Days;

public readonly record struct Data(long a1, long a2, long b1, long b2);

public class Day04 : BaseDay<Data[]>
{
    protected override int DayNumber => 4;

    protected override Data[] Parse(string[] input) => input
            .SkipEmptyLines()
            .Select(x => x
                .Split(',', '-'))
                .Select(x => x.Select(int.Parse).ToArray())
                .Select(x => new Data(x[0], x[1], x[2], x[3]))
                .ToArray();

    protected override object Solve1(Data[] data) => 
        data.Count(d => (d.a1 >= d.b1 && d.a2 <= d.b2) || (d.b1 >= d.a1 && d.b2 <= d.a2));

    protected override object Solve2(Data[] data) => 
        data.Count(d => (d.a2 >= d.b1) && (d.b2 >= d.a1));
}