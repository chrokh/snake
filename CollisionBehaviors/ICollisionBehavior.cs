using System;
namespace Snake;

public interface ICollisionBehavior
{
    void Execute(Snake snake);
}

