namespace Snake;

public class Snake
{
    public Point Direction;
    public Point Head => parts.First();

    private List<Point> parts;

    public Snake(int x, int y)
    {
        parts = new List<Point> { new Point(x, y) };
        Direction = new Point(1, 0);
    }

    public bool Move(Point newDirection)
    {
        Direction = newDirection;
        Point nextPosition = parts.First() + Direction;

        if (parts.Contains(nextPosition))
            return false; // Collision with itself

        parts.Insert(0, nextPosition); // Add new segment at the next position
        parts.RemoveAt(parts.Count - 1); // Remove last segment
        return true;
    }

    public void Grow()
    {
        parts.Add(parts.Last()); // Add a new segment at the end
    }

    public bool Contains(Point point) => parts.Contains(point);
    public IEnumerable<Point> Body => parts; // Expose body for rendering
}
