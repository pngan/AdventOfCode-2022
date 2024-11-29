namespace AdventOfCode.Solutions.Common;

public abstract class BaseDay
{
    public abstract string? Solve1();
    public abstract string? Solve2();
}
public abstract class BaseDay<TInput> : BaseDay
{
    const int Year = 2022;

    protected abstract int DayNumber { get; }

    protected abstract TInput Parse(string[] input);

    public override string? Solve1()
    {
        var input = File.ReadAllLines($@"Inputs\{Year}_{DayNumber:00}_input.txt");
        return Solve1(Parse(input)).ToString();
    }

    protected abstract object Solve1(TInput input);

    public override string? Solve2()
    {
        var input = File.ReadAllLines($@"Inputs\{Year}_{DayNumber:00}_input.txt");
        return Solve2(Parse(input)).ToString();
    }

    protected abstract object Solve2(TInput input);
}