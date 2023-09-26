using System.Collections.Generic;
using Snake.MoveBehaviors;
using Snake.TurnBehaviors;
using Snake.LengthBehaviors;
using Snake.CollisionBehaviors;
using System.Collections;

namespace Snake;

public class Snake : IEnumerable<Point>
{
    public string Symbol
    {
        get => Dead ? "X " : symbol;
        set => symbol = value;
    }
    public bool Dead { get; set; } = false;
    public Point Head => parts.First();
    public bool Occupies(Point point) => parts.Contains(point);

    private string symbol;
    private Point direction;
    private List<Point> parts;

    private IMoveBehavior moveBehavior;
    private ITurnBehavior turnBehavior;
    private ILengthBehavior growBehavior;
    private ILengthBehavior shrinkBehavior;
    private ICollisionBehavior collisionEffectOnSelf;
    private ICollisionBehavior collisionEffectOnOthers;

    public Snake
        ( string symbol
        , int initialLength
        , Point initialLocation
        , Point initialDirection
        , IMoveBehavior moveBehavior
        , ITurnBehavior turnBehavior
        , ILengthBehavior growBehavior
        , ILengthBehavior shrinkBehavior
        , ICollisionBehavior collisionEffectOnSelf
        , ICollisionBehavior collisionEffectOnOthers
        )
    {
        Symbol = symbol;

        parts = new List<Point>();
        for (int i = 0; i < initialLength; i++)
            parts.Add(initialLocation);

        direction = initialDirection;

        this.moveBehavior = moveBehavior;
        this.turnBehavior = turnBehavior;
        this.growBehavior = growBehavior;
        this.shrinkBehavior = shrinkBehavior;
        this.collisionEffectOnSelf = collisionEffectOnSelf;
        this.collisionEffectOnOthers = collisionEffectOnOthers;
    }

    public void Move(Point maxCoordinate)
    {
        if (!Dead)
            parts = moveBehavior.Execute(this, direction, maxCoordinate);
    }

    public void Turn(ConsoleKey key)
    {
        if (!Dead)
            direction = turnBehavior.Execute(direction, key);
    }

    public void Grow(int n = 1)
    {
        if (!Dead)
            parts = growBehavior.Execute(this, n);
    }

    public void Shrink(int n = 1)
    {
        if (!Dead)
            parts = shrinkBehavior.Execute(this, n);
    }

    public void CheckCollisions(IEnumerable<Snake> snakes)
    {
        if (Dead) return;
        foreach (Snake other in snakes)
        {
            if (other == this)
            {
                for (int i = 1; i < parts.Count; i++)
                    if (parts[i] == Head)
                        collisionEffectOnSelf.Execute(this);

            }
            else if (!other.Dead && other.Occupies(Head))
            {
                collisionEffectOnSelf.Execute(this);
                collisionEffectOnOthers.Execute(other);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<Point> GetEnumerator() => parts.GetEnumerator();
}
