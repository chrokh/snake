using System.Collections.Generic;

namespace Snake;

public class Snake
{

    public bool Dead { get; set; }
    public Point Direction;
    public Point Head => parts.First();
    public int Score => parts.Count;
    public ICollisionBehavior CrashEffectOnSelf { get; set; } = new DieBehavior();
    public ICollisionBehavior CrashEffectOnOther { get; set; } = new NoBehavior();

    private string symbol;
    public string Symbol
    {
        get => !Dead ? symbol : "X ";
        set => symbol = value;
    }

    private List<Point> parts;
    private Dictionary<ConsoleKey, Point> keyMap = new Dictionary<ConsoleKey, Point>();

    public Snake(
        string symbol,
        int initialLength,
        Point initialLocation,
        Point initialDirection,
        Dictionary<ConsoleKey, Point> keyMap)
    {
        this.symbol = symbol;
        this.keyMap = keyMap;
        parts = new List<Point>();
        for (int i = 0; i < initialLength; i++)
            parts.Add(initialLocation);
        Direction = initialDirection;
    }

    public void Turn(ConsoleKey key)
    {
        if (keyMap.ContainsKey(key))
            Direction = keyMap[key];
    }

    public void Move(Point gridSize)
    {
        if (Dead) return; // Don't move if dead.

        Point nextPosition = parts.First() + Direction;

        // Wrap around the grid
        nextPosition.X = (nextPosition.X + gridSize.X) % gridSize.X;
        nextPosition.Y = (nextPosition.Y + gridSize.Y) % gridSize.Y;

        parts.Insert(0, nextPosition); // Add new segment at the next position
        parts.RemoveAt(parts.Count - 1); // Remove last segment
    }

    public void CheckCollisions(IEnumerable<Snake> snakes)
    {
        foreach (Snake other in snakes)
        {
            if (other == this)
            {
                for (int i = 1; i < parts.Count; i++)
                    if (parts[i] == Head)
                        CrashEffectOnSelf.Execute(this);

            }
            else if (!other.Dead && other.Occupies(Head))
            {
                CrashEffectOnSelf.Execute(this);
                CrashEffectOnOther.Execute(other);
            }
        }
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
