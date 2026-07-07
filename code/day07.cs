using System.Collections.Immutable;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode_2022.code;

using DirSize = Dictionary<string, long>;
public class Day07
{
    public const string Day = "07";
    public static DirSize Input()
    {
        DirSize dirSizeFilesOnly = new();
        Stack<string> cwd = new();

        var input = File.ReadLines($"input/2022_{Day}_input.txt");

        foreach ( var line in input )
        {
            if (line == "$ ls" || line.StartsWith("dir ")) // Ignore irrelevant commands 
                continue;
            var l = line.Split(' ');
            if (l is ["$", "cd", ".."])
            {
                cwd.Pop();
            }
            else if (l is ["$", "cd", var dir])
            {
                cwd.Push(dir=="/" ? "" : dir);
                dirSizeFilesOnly[CurrentPath()] = 0L;
            }
            else if (l is [var size, _])
            {
                dirSizeFilesOnly[CurrentPath()] += long.Parse(size);
            }

            string CurrentPath() => string.Join('/', cwd.Reverse());
        }

        // Calculate dirSize by summing up all files
        // in the directory and its subdirectories
        DirSize dirSize = new();
        foreach(var dir in dirSizeFilesOnly.Keys)
        {
            long size = 0;
            foreach (var kvp in dirSizeFilesOnly)
            {
                if (kvp.Key.StartsWith(dir))
                    size += kvp.Value;
            }
            dirSize[dir] = size;
        }

        return dirSize;
    }

    public static object Solve1()
    {
        var dirSize = Input();
        return dirSize.Values.Where(i => i <= 100000).Sum();
    }

    public static object Solve2()
    {
        var dirSize = Input();
        var totalSize = dirSize[""];
        var targetSize = 40000000L;
        var minToFree = totalSize - targetSize;

        // Look for dirSize just larger than minToFree
        return dirSize.Values.Where(i => i > minToFree).Min();
    }
}