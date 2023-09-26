namespace Snake;

public class Tree : IEdible
{
    public string Symbol { get; private set; } = "🌳";
    private int numberOfApples;
    
    public Tree(int numberOfApples)
        => this.numberOfApples = numberOfApples;

    public void Eat (Snake eater, List<Snake> others, Grid grid)
    {
        for (int i = 0; i < numberOfApples; i++)
            grid.SpawnItem(new Apple());
    }
}
