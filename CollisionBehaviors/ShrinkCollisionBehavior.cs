using System;
namespace Snake.CollisionBehaviors;

public class ShrinkCollisionBehavior : ICollisionBehavior
{
    int size;

    public ShrinkCollisionBehavior(int size)
        => this.size = size;

    public void Execute(Snake snake)
        => snake.Shrink(size);
}