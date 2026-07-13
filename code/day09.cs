namespace AdventOfCode_2022.code;
public class Day09
{
    public const string Day = "09";
    public static IEnumerable<string> Input() => File.ReadLines($"input/2022_{Day}_input.txt")
            .Where(row => !string.IsNullOrEmpty(row));

    public static object Solve1()
    {
        var knots = new List<ValueTuple<int, int>> { (0, 0), (0, 0) };
        return VisitedCount(knots);
    }

    public static object Solve2()
    {
        var knots = new List<ValueTuple<int, int>> { (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0) };
        return VisitedCount(knots);
    }

    private static object VisitedCount( List<(int, int)> knots)
    {
        var i = Input();
        var visited = new HashSet<ValueTuple<int, int>> { knots.Last() };
        foreach (string r in i)
        {
            var row = r.Split(" ");
            var dir = row[0];
            int steps = int.Parse(row[1]);
            for (int s = 0; s < steps; s++)
            {
                knots[0] = MoveKnot(dir, knots[0]);
                for (int k = 1; k < knots.Count; k++)
                    knots[k] = MoveLatterKnot(knots[k - 1], knots[k]);
                visited.Add(knots.Last());
            }
        }

        return visited.Count;
    }

    private static ValueTuple<int, int> MoveKnot(string dir, ValueTuple<int, int> x)
    {
        switch (dir)
        {
            case "L":
                return (x.Item1, x.Item2 - 1);
            case "R":
                return (x.Item1, x.Item2 + 1);
            case "U":
                return (x.Item1 + 1, x.Item2);
            case "D":
                return (x.Item1 - 1, x.Item2);
            default:
                throw new Exception($"Bad dir for move {dir}");
        }
    }

    private static ValueTuple<int, int> MoveLatterKnot(ValueTuple<int, int> x,
        ValueTuple<int, int> y)
    {
        var delta = Distances(x, y);
        if (Math.Abs(delta.dc) <= 1 && Math.Abs(delta.dr) <= 1)
            return y;
        return (y.Item1+Math.Sign(delta.dr), y.Item2+Math.Sign(delta.dc));
    }

    private static (int dr, int dc) Distances(ValueTuple<int, int> x,
        ValueTuple<int, int> y)
        => (x.Item1 - y.Item1, x.Item2 - y.Item2);
}