namespace Snake;

public class Bomb : IEdible
{
    public string Symbol { get; private set; } = "💣";
    public void Eat (Snake eater, List<Snake> others, Grid grid)
    {
        eater.Dead = true;
        grid.SpawnItem(new Bomb());
    }
}
