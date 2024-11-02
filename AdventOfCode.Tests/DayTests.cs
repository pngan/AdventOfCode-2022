using AdventOfCode.Solutions.Common;
using AdventOfCode.Solutions.Days.Day01;

namespace AdventOfCode.Tests;

public class DayTests
{
    [Test]
    public void Tests()
    {
        ConfirmResult<Day01>("45000", "209481");
    }

    private static void ConfirmResult<T>(string? expectedPart1, string? expectedPart2) where T : BaseDay, new()
    {
        if (expectedPart1 != null)
            Assert.That(new T().Solve1(), Is.EqualTo(expectedPart1));
        if (expectedPart2 != null)
            Assert.That(new T().Solve2(), Is.EqualTo(expectedPart2));
    }
}