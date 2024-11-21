namespace AdventOfCode.Solutions.Common;

public abstract class BaseDay
{
    public abstract string? Solve1();
    public abstract string? Solve2();
}
public abstract class BaseDay<TInput> : BaseDay
{
    const int Year = 2022;
    protected BaseDay()
    {
        string day = GetType().Name[^2..]; 
        _day = int.Parse(day);
        if (_day < 1 || _day > 24)
        {
            throw new InvalidDataException("Class Name should end in a two digit number between 1 and 24, inclusive");
        }
    }

    private static int _day;

    protected abstract TInput Parse(string[] input);

    public override string? Solve1()
    {
        var input = File.ReadAllLines($@"Inputs\{Year}_{_day:00}_input.txt");
        return Solve1(Parse(input)).ToString();
    }

    protected abstract object Solve1(TInput input);

    public override string? Solve2()
    {
        var input = File.ReadAllLines($@"Inputs\{Year}_{_day:00}_input.txt");
        return Solve2(Parse(input)).ToString();
    }

    protected abstract object Solve2(TInput input);
}