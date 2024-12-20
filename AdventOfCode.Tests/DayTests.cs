using AdventOfCode.Solutions.Common;
using AdventOfCode.Solutions.Days;

namespace AdventOfCode.Tests;

public class DayTests
{
    [TestCase(typeof(Day12), "449", "443")]
    [TestCase(typeof(Day04), "526", "886")]
    [TestCase(typeof(Day03), "", "2881")]
    [TestCase(typeof(Day02), "12855", "13726")]
    [TestCase(typeof(Day01), "74711", "209481")]
    public void Testing(Type dayType, string expectedPart1, string expectedPart2)
    {
        BaseDay? dayObj = Activator.CreateInstance(dayType) as BaseDay;

        if (!string.IsNullOrEmpty(expectedPart1))
        {
            Assert.That(dayObj!.Solve1(), Is.EqualTo(expectedPart1));
        }

        if (!string.IsNullOrEmpty(expectedPart2))
        {
            Assert.That(dayObj!.Solve2(), Is.EqualTo(expectedPart2));
        }
    }
}
