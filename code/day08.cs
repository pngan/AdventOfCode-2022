using AdventOfCode_2022.utilities.image;

namespace AdventOfCode_2022.code;


public class Day08
{
    public const string Day = "08";
    public static Im2 Input()
    {
        var input = File.ReadLines($"input/2022_{Day}_input.txt").Where(s => !string.IsNullOrEmpty(s));
        return new Im2(input);
    }


    public static object Solve1()
    {
        int visible = 0;
        var im = Input();
        foreach (var p in im.Image)
        {

            bool n = IsVisibleN(p, im);
            bool s = IsVisibleS(p, im);
            bool w = IsVisibleW(p, im);
            bool e = IsVisibleE(p, im);
            if (n || s || w || e)
            {
                visible++;
            }
        }
        return visible;
    }

    public static object Solve2()
    {
        long result = 0;
        var im = Input();
        foreach (var p in im.Image)
        {
            long n = VisibleDistanceN(p, im);
            long s = VisibleDistanceS(p, im);
            long w = VisibleDistanceW(p, im);
            long e = VisibleDistanceE(p, im);
            long product = n * s * w * e;
            if (product > result)
                result = product;
        }
        return result;
    }

    private static bool IsVisibleN(KeyValuePair<(int r, int c), int> p, Im2 im)
    {
        int c = p.Key.c;
        int r = p.Key.r;
        int v = p.Value;

        while (--r >= 0)
        {
            if (v <= im[(r, c)])
                return false;
        }

        return true;
    }

    private static bool IsVisibleS(KeyValuePair<(int r, int c), int> p, Im2 im)
    {
        int c = p.Key.c;
        int r = p.Key.r;
        int v = p.Value;

        while (++r < im.ROWS)
        {
            if (v <= im[(r, c)])
                return false;
        }

        return true;
    }

    private static bool IsVisibleW(KeyValuePair<(int r, int c), int> p, Im2 im)
    {
        int c = p.Key.c;
        int r = p.Key.r;
        int v = p.Value;

        while (--c >= 0)
        {
            if (v <= im[(r, c)])
                return false;
        }

        return true;
    }


    private static bool IsVisibleE(KeyValuePair<(int r, int c), int> p, Im2 im)
    {
        int c = p.Key.c;
        int r = p.Key.r;
        int v = p.Value;

        while (++c < im.COLS)
        {
            if (v <= im[(r, c)])
                return false;
        }

        return true;
    }


    private static int
        VisibleDistanceN(KeyValuePair<(int r, int c), int> p, Im2 im)
    {
        int visible = 0;
        int c = p.Key.c;
        int r = p.Key.r;
        int v = p.Value;
        while (--r >= 0)
        {
            visible++;
            if (im[(r, c)] >= v)
                break;
        }

        return visible;
    }

    private static int
        VisibleDistanceS(KeyValuePair<(int r, int c), int> p, Im2 im)
    {
        int visible = 0;
        int c = p.Key.c;
        int r = p.Key.r;
        int v = p.Value;

        while (++r < im.ROWS)
        {
            visible++;
            if (im[(r, c)] >= v)
                break;
        }

        return visible;
    }


    private static int
        VisibleDistanceW(KeyValuePair<(int r, int c), int> p, Im2 im)
    {
        int visible = 0;
        int c = p.Key.c;
        int r = p.Key.r;
        int v = p.Value;

        while (--c >= 0)
        {
            visible++;
            if (im[(r, c)] >= v)
                break;
        }

        return visible;
    }


    private static int
        VisibleDistanceE(KeyValuePair<(int r, int c), int> p, Im2 im)
    {
        int visible = 0;
        int c = p.Key.c;
        int r = p.Key.r;
        int v = p.Value;

        while (++c < im.COLS)
        {
            visible++;
            if (im[(r, c)] >= v)
                break;
        }

        return visible;
    }

}