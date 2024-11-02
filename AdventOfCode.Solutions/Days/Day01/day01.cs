using System.Collections.ObjectModel;
using AdventOfCode.Solutions.Common;
using AdventOfCode.Solutions.Extensions;

namespace AdventOfCode.Solutions.Days.Day01;

public class Day01 : BaseDay<IEnumerable<IEnumerable<int>>>
{
    protected override IEnumerable<IEnumerable<int>> Parse(IEnumerable<string> input) =>
        input.Split(x => x == string.Empty)
            .Select(x => x.Select(int.Parse));

    protected override object Solve1(IEnumerable<IEnumerable<int>> input)
    {
        return input.Select(x => x.Sum())
            .Order()
            .TakeLast(3)
            .Sum();
    }

    protected override object Solve2(IEnumerable<IEnumerable<int>> input)
    {
        return input.Select(x => x.Sum())
            .Order()
            .TakeLast(3)
            .Sum();
    }
}