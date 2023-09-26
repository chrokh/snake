using System;
namespace Snake;

public class ShrinkBehavior : ICollisionBehavior
{
    int size;

    public ShrinkBehavior(int size)
        => this.size = size;

    public void Execute(Snake snake)
        => snake.Shrink(size);
}