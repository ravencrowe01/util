using System.Numerics;

namespace Raven.Lib {
    /// <summary>
    /// Basicly a Vector2Int, just with a cooler name cause it's used for games. :)
    /// </summary>
    public class Coordinate {
        public readonly int X;
        public readonly int Y;

        public static readonly Coordinate North = new Coordinate(0, 1);
        public static readonly Coordinate South = new Coordinate(0, -1);
        public static readonly Coordinate East = new Coordinate(-1, 0);
        public static readonly Coordinate West = new Coordinate(1, 0);
        public static readonly Coordinate NorthEast = North + East;
        public static readonly Coordinate NorthWest = North + West;
        public static readonly Coordinate SouthEast = South + East;
        public static readonly Coordinate SouthWest = South + West;

        public Coordinate(int x, int y) {
            X = x;
            Y = y;
        }

        public Coordinate (Vector2 vec) {
            X = (int) vec.X;
            Y = (int) vec.Y;
        }

        public static Coordinate operator + (Coordinate a) => a;
        public static Coordinate operator + (Coordinate a, Coordinate b) => new Coordinate(a.X + b.Y, a.Y + b.Y);
        public static Coordinate operator - (Coordinate a) => new Coordinate(-a.X, -a.Y);
        public static Coordinate operator - (Coordinate a, Coordinate b) => new Coordinate(a.X - b.X, a.Y - b.Y);
        public static Coordinate operator * (Coordinate a, int mult) => new Coordinate(a.X * mult, a.Y * mult);
        public static Coordinate operator * (Coordinate a, Coordinate b) => new Coordinate(a.X * b.X, a.X * b.X);
        public static Coordinate operator / (Coordinate a, int div) => new Coordinate(a.X / div, a.Y / div);
        public static Coordinate operator / (Coordinate a, Coordinate b) => new Coordinate(a.X / b.X, a.X / b.X);
    }
}