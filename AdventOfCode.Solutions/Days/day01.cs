using AdventOfCode.Solutions.Common;
using AdventOfCode.Solutions.Extensions;

namespace AdventOfCode.Solutions.Days;

public class Day01 : BaseDay<IEnumerable<int>[]>
{
    protected override IEnumerable<int>[] Parse(string[] input) =>
        input.Split(x => x == string.Empty)
            .Select(x => x.Select(int.Parse)).ToArray();

    protected override object Solve1(IEnumerable<int>[] input)
    {
        return input.Select(x => x.Sum())
            .Max();
    }

    protected override object Solve2(IEnumerable<int>[] input)
    {
        return input.Select(x => x.Sum())
            .Order()
            .TakeLast(3)
            .Sum();
    }
}