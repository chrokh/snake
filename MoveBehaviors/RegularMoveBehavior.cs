using System;
namespace Snake.MoveBehaviors;

public class RegularMoveBehavior : IMoveBehavior
{
    public List<Point> Execute(IEnumerable<Point> parts, Point direction, Point max)
    {
        //Point nextPosition = (parts.First() + direction + maxCoordinate) % maxCoordinate;

        Point unwrapped = parts.First() + direction;

        // Wrap around the grid
        int wrappedX = (unwrapped.X + max.X) % max.X;
        int wrappedY = (unwrapped.Y + max.Y) % max.Y;

        Point nextPosition = new Point(wrappedX, wrappedY);

        List<Point> updated = parts.ToList<Point>();
        updated.Insert(0, nextPosition); // Add new segment at the next position
        updated.RemoveAt(updated.Count - 1); // Remove last segment

        return updated;
    }
}
