using AdventOfCode.Solutions.Common;
using AdventOfCode.Solutions.Days;

namespace AdventOfCode.Tests;

public class DayTests
{
    [TestCase(typeof(Day02), "12855", "13726")]
    [TestCase(typeof(Day01), "74711", "209481")]
    public void Testing(Type dayType, string expectedPart1, string expectedPart2)
    {
        var dayObj = (BaseDay) Activator.CreateInstance(dayType) ;
        Assert.That(dayObj.Solve1(), Is.EqualTo(expectedPart1));
        Assert.That(dayObj.Solve2(), Is.EqualTo(expectedPart2));
    }
}
