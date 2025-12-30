using System;
using AdventOfCode_2022.code;

namespace AdventOfCode_2022
{
    static class Program
    {
        static void Main()
        {
            Timing.Run(Day01.Day, Day01.Input, Day01.Solve1, Day01.Solve2);
            Timing.Run(Day02.Day, Day02.Input, Day02.Solve1, Day02.Solve2);
            Timing.Run(Day03.Day, Day03.Input, Day03.Solve1, Day03.Solve2);
            Timing.Run(Day04.Day, Day04.Input, Day04.Solve1, Day04.Solve2);
            Timing.Run(Day05.Day, Day05.Input, Day05.Solve1, Day05.Solve2);
            Timing.Run(Day06.Day, Day06.Input, Day06.Solve1, Day06.Solve2);
            Timing.Run(Day12.Day, Day12.Input, Day12.Solve1, Day12.Solve2);
            Timing.WriteReadmeTimings("README.md");
        }
    }
}