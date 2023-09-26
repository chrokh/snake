using System;
namespace Snake.LengthBehaviors;

public interface ILengthBehavior
{
	List<Point> Execute(IEnumerable<Point> parts, int n);
}

