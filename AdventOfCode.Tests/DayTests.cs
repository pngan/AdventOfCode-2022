using AdventOfCode.Solutions.Common;
using AdventOfCode.Solutions.Days;

namespace AdventOfCode.Tests;

public class DayTests
{
    [Test]
    public void Tests()
    {
        ConfirmResult1<Day01>("74711");
        ConfirmResult2<Day01>("209481888");
    }

    private static void ConfirmResult1<T>(string expected) where T : BaseDay, new()
    {
        Assert.That(new T().Solve1(), Is.EqualTo(expected));
    }

    private static void ConfirmResult2<T>(string expected) where T : BaseDay, new()
    {
        Assert.That(new T().Solve2(), Is.EqualTo(expected));
    }
}