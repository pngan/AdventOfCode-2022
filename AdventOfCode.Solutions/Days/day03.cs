using AdventOfCode.Solutions.Common;
using AdventOfCode.Solutions.Extensions;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode.Solutions.Days;

public class Day03 : BaseDay<string[]>
{
    protected override string[] Parse(string[] input) => input;

    protected override object Solve1(string[] input)
    {
        return new object();
    }

    protected override object Solve2(string[] input)
    {
        int score = 0;
        for (int i = 0; i < input.Length-3; i += 3)
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