using System;
namespace Snake
{
	public class DieBehavior : ICollisionBehavior
	{
		public void Execute(Snake snake)
			=> snake.Dead = true;
	}
}
