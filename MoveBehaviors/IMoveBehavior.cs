using System;
namespace Snake.MoveBehaviors;

public interface IMoveBehavior
{
	List<Point> Execute(IEnumerable<Point> snake, Point direction, Point maxCoordinate);
}