namespace AdventOfCode.Solutions.Extensions;

public static class EnumerableExtensions
{
    public static List<List<T>> Split<T>(this IEnumerable<T> input, Func<T, bool> splitOn)
    {
        var result = new List<List<T>>{ new() };

        input.ToList().ForEach(x =>
        {
            if (splitOn(x))
            {
                result.Add(new List<T>());
            }
            else
            {
                result.Last().Add(x);
            }
        });

        return result;
    }
}