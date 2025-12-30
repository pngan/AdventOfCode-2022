using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode_2022.utilities.image
{
    public static class PointExtensions
{
    public static IEnumerable<(T r, T c)> Neighbours8<T>(this (T r, T c) p) where T : INumber<T>
        =>
        [
            (p.r-T.One, p.c-T.One), // nw
            (p.r-T.One, p.c), // n
            (p.r-T.One, p.c+T.One), // ne
            (p.r, p.c+T.One), // e
            (p.r+T.One, p.c+T.One), // se
            (p.r+T.One, p.c), // s
            (p.r+T.One, p.c-T.One), // sw
            (p.r, p.c-T.One), // w
        ];

    public static IEnumerable<(T r, T c)> Neighbours4<T>(this (T r, T c) p) where T : INumber<T>
        =>
        [
            (p.r-T.One, p.c), // n
            (p.r, p.c+T.One), // e
            (p.r+T.One, p.c), // s
            (p.r, p.c-T.One), // w
        ];

    public static (int dr, int dc) Rot0(this (int dr, int dc) s) => (dr: s.dr, dc: s.dc);
    public static (int dr, int dc) Rot90(this (int dr, int dc) s) => (dr: -s.dc, dc: s.dr);
    public static (int dr, int dc) Rot180(this (int dr, int dc) s) => (dr: -s.dr, dc: -s.dc);
    public static (int dr, int dc) Rot270(this (int dr, int dc) s) => (dr: s.dc, dc: -s.dr);

    public static T ManhattanDistance<T>((T r, T c) a, (T r, T c) b) where T : INumber<T> => Abs<T>(a.r - b.r) + Abs<T>(a.c - b.c);

    public static T Abs<T>(this T value) where T : INumber<T> => T.Abs(value);
}
}