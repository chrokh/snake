using System.Collections.Generic;

namespace Snake;

public class Snake
{

    public bool Dead { get; set; }
    public Point Direction;
    public Point Head => parts.First();
    public int Score => parts.Count;

    private string symbol;
    public string Symbol
    {
        get => !Dead ? symbol : "X ";
    }

    private List<Point> parts;
    private Dictionary<ConsoleKey, Point> keyMap = new Dictionary<ConsoleKey, Point>();

    public Snake(string symbol, Point initialLocation, Point initialDirection, Dictionary<ConsoleKey, Point> keyMap)
    {
        this.symbol = symbol;
        this.keyMap = keyMap;
        parts = new List<Point> { initialLocation };
        Direction = initialDirection;
    }

    public void Turn(ConsoleKey key)
    {
        if (keyMap.ContainsKey(key))
            Direction = keyMap[key];
    }

    public void Move(Point grid)
    {
        if (Dead) return; // Don't move if dead.

        Point nextPosition = parts.First() + Direction;

        // Wrap around the grid
        nextPosition.X = (nextPosition.X + grid.X) % grid.X;
        nextPosition.Y = (nextPosition.Y + grid.Y) % grid.Y;

        if (parts.Contains(nextPosition))
            Dead = true; // Collision with itself

        parts.Insert(0, nextPosition); // Add new segment at the next position
        parts.RemoveAt(parts.Count - 1); // Remove last segment
    }

    public void Grow(int n=1)
    {
        for(int i=0; i<n; i++)
            parts.Add(parts.Last()); // Add a new segment at the end
    }

    public void Shrink(int n=1)
    {
        for (int i=0; i<n; i++)
            if (parts.Count > 1)
                parts.RemoveAt(parts.Count - 1);
    }

    public bool Occupies(Point point) => parts.Contains(point);
    public IEnumerable<Point> Body => parts; // Expose body for rendering
}
