using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode_2022.utilities.image
{
    public class Image2<T> where T : notnull, IParsable<T>
{
    public readonly int ROWS;
    public readonly int COLS;
    private readonly T[][] _image;

    public Image2(int rows, int cols)
    {
        ROWS = rows; 
        COLS = cols;
        _image = new T[rows][];
        for (int r = 0; r < ROWS; r++)
        {
            _image[r] = new T[cols];
            for (int c = 0; c < COLS; c++)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                    this[(r, c)] = default(T);
#pragma warning restore CS8601 // Possible null reference assignment.
                }
        }
    }

    public T this[(int r, int c) p]
    {
        get => _image[p.r][p.c];
        set => _image[p.r][p.c] = value;
    }

    public bool Exists((int r, int c) p) => p.r >= 0 && p.r < ROWS && p.c >= 0 && p.c < COLS;

    public bool TryGetValue((int r, int c) p, out T value)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
            value = default;
#pragma warning restore CS8601 // Possible null reference assignment.
            if (!Exists(p)) return false;
        value = _image[p.r][p.c];
        return true;
    }

    public IEnumerable<(int r, int c)> Find(T value)
    {
        for (int r = 0; r < ROWS; r++)
            for (int c = 0; c < COLS; c++)
                if (_image[r][c].Equals(value))
                    yield return (r, c);
    }

    public void Fill(T value)
    {
        for (int r = 0; r < ROWS; r++)
            for (int c = 0; c < COLS; c++)
                _image[r][c] = value;
    }

    public static Image2<T> Parse(IEnumerable<string> lines)
    {
        var arr = lines.ToArray();
        var image = new Image2<T>(arr.Length, arr[0].Length);
        for (int r = 0; r < arr.Length; r++)
            for (int c = 0; c < arr[r].Length; c++)
                image[(r, c)] = T.Parse(arr[r][c].ToString(), null);
        return image;
    }
}
}