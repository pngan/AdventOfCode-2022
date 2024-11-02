namespace AdventOfCode.Solutions.Common;

public abstract class BaseDay
{
    public abstract string? Solve1();
    public abstract string? Solve2();
}
public abstract class BaseDay<TInput> : BaseDay
{
    protected BaseDay()
    {
        _day = GetType().Name[^2..];
    }

    private static string? _day;

    protected abstract TInput Parse(IEnumerable<string> input);
    
    public override string? Solve1()
    {
        var input = File.ReadAllLines($@"Days\Day{_day}\day{_day}-1.txt");
        return Solve1(Parse(input)).ToString();
    }
    
    protected abstract object Solve1(TInput input);
    
    public override string? Solve2()
    {
        var input = File.ReadAllLines($@"Days\Day{_day}\day{_day}-2.txt");
        return Solve2(Parse(input)).ToString();
    }
    
    protected abstract object Solve2(TInput input);
}