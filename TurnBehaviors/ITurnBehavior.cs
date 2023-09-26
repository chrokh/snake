using System;
namespace Snake.TurnBehaviors
{
	public interface ITurnBehavior
	{
		Point Execute(Point currentDirection, ConsoleKey key);
    }
}

