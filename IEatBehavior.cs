namespace Snake;

public interface IEatBehavior
{
    void Eat(Grid grid, Snake snake);
}

public class GrowEatBehavior : IEatBehavior
{
    public void Eat(Grid grid, Snake snake)
    {
        snake.Grow();
        var factory = new EdibleFactory("🍎", new GrowEatBehavior());
        grid.SpawnItem(factory, new List<Point> { snake.Head });
    }
}

public class DieBehavior : IEatBehavior
{
    public void Eat(Grid grid, Snake snake)
    {
        snake.Dead = true;
    }
}
