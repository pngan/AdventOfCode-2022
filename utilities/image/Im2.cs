using System;
using System.Collections.Generic;
using System.Text;

using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode_2022.utilities.image;

using Image = Dictionary<(int r, int c), int>;


public class Im2
{
    public Im2(IEnumerable<string> s)
    {
        ROWS = s.Count();
        COLS = s.First().Length;

        int r = 0;
        foreach (string row in s)
        {
            int c = 0;
            foreach (var p in row)
            {
                Image[(r, c)] = p - '0';
                c++;
            }
            r++;
        }
    }
    public Image Image { get; } = new Image();
    public int ROWS { get; }
    public int COLS { get; }
    public int this[(int r, int c) p]
    {
        get => Image[p];
        set => Image[p] = value;
    }
}

