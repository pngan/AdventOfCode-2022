using AdventOfCode.Solutions.Common;

using Point = (int r, int c);

namespace AdventOfCode.Solutions.Days;

public readonly record struct Data12(Dictionary<Point, char> map, Point start, Point end);

// Use Dikjstra's algorithm to find shortest path
// Dijkstra's algorithm learned from https://www.youtube.com/watch?v=CerlT7tTZfY
public class Day12 : BaseDay<Data12>
{
    protected override int DayNumber => 12;

    protected override Data12 Parse(string[] input)
    {
        Dictionary<Point, char> map = new();
        Point? start = null;
        Point? end = null;
        for (int r = 0; r < input.Length; r++)
            for (int c = 0; c < input[r].Length; c++)
            {
                char v = input[r][c];
                if (v == 'S')
                {
                    start = (r, c);
                    v = (char)('a'-1);
                }
                if (v == 'E')
                {
                    end = (r, c);
                    v = (char)('z'+ 1);
                }
                map[(r, c)] = v;
            }
        if (start is null)
            throw new InvalidDataException("Did not find start point on map.");

        return new Data12(map, start.Value, end.Value);
    }

    private IEnumerable<Point> GetNeighbours(Dictionary<Point, char> map, Point point)
    {
        return (new[] { 
                (point.r - 1, point.c), 
                (point.r + 1, point.c), 
                (point.r, point.c - 1), 
                (point.r, point.c + 1) 
            })
            .Where(x => map.ContainsKey(x));
    }

    protected override object Solve1(Data12 input)
    {
        long steps = 0;
        var pq = new PriorityQueue<(Point from, Point to), long>();
        pq.Enqueue((input.start, input.start), 0); // Initialize for looping

        Dictionary<Point, (Point prev, long cost, bool visited)> tracking = new();
        foreach (var entry in input.map)
        {
            tracking[entry.Key] = (entry.Key, 0, false);
        }

        while (true)
        {
            // Catch bad case
            if (tracking.Values.All(t => t.visited))
                throw new InvalidDataException("Did not find target");

            // Stop if priority queue is empty
            if (!pq.TryDequeue(out (Point from, Point to) path, out long cost) || path.to == input.end)
                break;

            // Ignore if the inspected node has its distance already determined
            if (tracking[path.to].visited)
                continue;

            // Handle minimum item from priority queue
            tracking[path.to] = (path.from, cost, true);
            steps = cost;

            // Process edges from path.to
            var neighbours = GetNeighbours(input.map, path.to);

            foreach (var neighbor in neighbours)
            {
                // Optimisation: Edge is already part of a shortest path, so no need to reprocess it
                if (tracking[neighbor].visited || path.to == tracking[neighbor].prev)
                    continue;

                // Only enqueue if neighbour is at most one height more than current
                if (input.map[neighbor] <= input.map[path.to] + 1)
                    pq.Enqueue((path.to, neighbor), cost + 1);
            }
        }
        return steps;
    }

    // Difference from part 1:
    // Start at end
    // Termination condition is when encounter a 'a'
    // The admissible step condition is now, cannot step down more than 1 unit
    protected override object Solve2(Data12 input)
    {
        long steps = 0;
        var pq = new PriorityQueue<(Point from, Point to), long>();
        pq.Enqueue((input.end, input.end), 0); // Initialize for looping

        Dictionary<Point, (Point prev, long cost, bool visited)> tracking = new();
        foreach (var entry in input.map)
        {
            tracking[entry.Key] = (entry.Key, 0, false);
        }

        while (true)
        {
            // Catch bad case
            if (tracking.Values.All(t => t.visited))
                throw new InvalidDataException("Did not find target");

            // Stop if priority queue is empty
            if (!pq.TryDequeue(out (Point from, Point to) path, out long cost) || 'a' == input.map[path.to])
                break;

            // Ignore if the inspected node has its distance already determined
            if (tracking[path.to].visited)
                continue;

            // Handle minimum item from priority queue
            tracking[path.to] = (path.from, cost, true);
            steps = cost;

            // Process edges from path.to
            var neighbours = GetNeighbours(input.map, path.to);

            foreach (var neighbor in neighbours)
            {
                // Optimisation: Edge is already part of a shortest path, so no need to reprocess it
                if (tracking[neighbor].visited || path.to == tracking[neighbor].prev)
                    continue;

                // Only enqueue if neighbour is at most one height more than current
                if (input.map[neighbor] >= input.map[path.to] - 1)
                    pq.Enqueue((path.to, neighbor), cost + 1);
            }
        }
        return steps;
    }

}