using System;
using System.Xml.Linq;

namespace Snake.LengthBehaviors;

public class GrowLengthBehavior : ILengthBehavior
{
    public List<Point> Execute(IEnumerable<Point> parts, int n)
    {
        // Copy end of snake n times.
        List<Point> updated = parts.ToList<Point>();
        for (int i = 0; i < n; i++)
            updated.Add(parts.Last());
        return updated;
    }
}

