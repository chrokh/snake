namespace Snake;

public class Apple : IEdible
{
    public string Symbol { get; private set; } = "🍎";
    public void Eat (Snake eater, List<Snake> others, Grid grid)
    {
        eater.Grow();
        grid.SpawnItem(new Apple());
    }
}