using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

using MoreLinq;

namespace AdventOfCode_2022.code
{
public class Day05
{
    public const string Day = "05";
    public static string[] Input()
    {
        var input = File.ReadLines($"input/2022_{Day}_input.txt").ToArray();

        return input;
    }

    public static object Solve1()
    {
        var input = Input();

        // Set up initial stacks
        // Find blank line index
        int blankLine = 0;
        while (blankLine < input.Count())
        {
            if (input[blankLine].Length == 0) break;
            blankLine++;
        }

        // Number of Stacks
        var stackCount = (int)(input[blankLine - 1].Length + 1) / 4;

        // Initialize stacks
        List<Stack<char>> stacks1 = new();
        List<Stack<char>> stacks2 = new();
        for (int i = 0; i < stackCount; i++)
        {
            stacks1.Add(new Stack<char>());
            stacks2.Add(new Stack<char>());
        }

        for (int i = 0; i < blankLine - 1; i++)
        {
            int cratePosition = 0;
            var line = input[i];
            for (int stack = 0; stack < stackCount; stack++)
            {
                if (stack == 0)
                    cratePosition = 1; // The first crate value is second char in the line

                var crate = line[cratePosition];
                if (crate != ' ')
                {
                    stacks1[stack].Push(crate);
                    stacks2[stack].Push(crate);
                }
                cratePosition += 4;    // All subsequent crates are spaced 4 chars apart
            }
        }

        // Reverse all the stacks
        for (int i = 0; i < stacks1.Count(); i++)
        {
            stacks1[i] = new Stack<char>(stacks1[i]);
            stacks2[i] = new Stack<char>(stacks2[i]);
        }

        // Apply crate movement instructions
        for (int i = blankLine + 1; i < input.Length; i++)
        {
            var _split = input[i].Split(' ');
            if (_split is not ["move", var _count, "from", var _from, "to", var _to])
                continue;

            int count = int.Parse(_count);
            int from = int.Parse(_from) - 1;
            int to = int.Parse(_to) - 1;

            for (int j = 0; j < count; j++)
            {
                if (stacks1[from].Count() == 0) continue;
                char crate = stacks1[from].Pop();
                stacks1[to].Push(crate);
            }
            
            var tempStack = new Stack<char>();
            for (int j = 0; j < count; j++)
            {
                if (stacks2[from].Count() == 0) continue;
                char crate = stacks2[from].Pop();
                tempStack.Push(crate);
            }

            for (int j = 0; j < count; j++)
            {
                if (tempStack.Count() == 0) continue;
                char crate = tempStack.Pop();
                stacks2[to].Push(crate);
            }
        }

        // Calculate return string, by reading top of stacks
        StringBuilder sb1 = new();
        for (int s = 0; s < stackCount; s++)
        {
            var currentStack1 = stacks1[s];
            if (currentStack1.Count() != 0)
            {
                sb1.Append(currentStack1.Pop());
            }
        }
        var res1 = sb1.ToString();


        StringBuilder sb2 = new();
        for (int s = 0; s < stackCount; s++)
        {
            var currentStack = stacks2[s];
            if (currentStack.Count() != 0)
            {
                sb2.Append(currentStack.Pop());
            }
        }
        var res2 = sb2.ToString();
        return (input.Count(), res1, res2);
    }


    public static object Solve2()
    {
        var input = Input();

        return input;
    }
}
}