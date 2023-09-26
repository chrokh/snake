using System;
namespace Snake.CollisionBehaviors;

public interface ICollisionBehavior
{
    void Execute(Snake snake);
}