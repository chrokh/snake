using System;
namespace Snake.CollisionBehaviors;

public class DieCollisionBehavior : ICollisionBehavior
{
	public void Execute(Snake snake)
		=> snake.Dead = true;
}
