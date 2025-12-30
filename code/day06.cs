using System.Collections.Immutable;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode_2022.code;

    public class Day06
{
    
    public const string Day = "06";
    public static string Input()
    {
        var input = File.ReadLines($"input/2022_{Day}_input.txt").ToArray()[0];

        return input;
    }
    public static object Solve(int distinctCount )
    {
        var input = Input();
        int i = distinctCount-1;
        for(; i < input.Length; i++)
        {
            string quad = input.Substring(i-distinctCount+1, distinctCount);
            if (quad.Length == quad.Distinct().ToArray().Length)
                break;

        }
        return i+1;
    }
    public static object Solve1() =>  Solve(4);
    public static object Solve2()=>  Solve(14);
}