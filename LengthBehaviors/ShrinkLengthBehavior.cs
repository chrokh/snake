using System;
using System.Xml.Linq;

namespace Snake.LengthBehaviors;

public class ShrinkLengthBehavior : ILengthBehavior
{
    public List<Point> Execute(IEnumerable<Point> parts, int n)
    {
        List<Point> updated = parts.ToList<Point>();
        for (int i = 0; i < n; i++)
            if (updated.Count > 1)
                updated.RemoveAt(updated.Count - 1);
        return updated;
    }
}

