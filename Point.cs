namespace Snake;

public class Point
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Point(int x, int y) { X = x; Y = y; }
    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    public static Point operator %(Point a, Point b) => new Point(a.X % b.X, a.Y % b.Y);
    public static bool operator ==(Point a, Point b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(Point a, Point b) => !(a == b);
    public override bool Equals(object? obj) => obj is Point point && this == point;
    public override int GetHashCode() => (X, Y).GetHashCode();

}
