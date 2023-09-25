namespace Snake;

public class SimpleApple : IEdible
{
    public string Symbol { get; private set; } = "🍎";
    public void Eat (Snake eater, List<Snake> others, Grid grid)
    {
        eater.Grow();
        grid.SpawnItem(new SimpleApple());
    }
}