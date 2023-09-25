namespace Snake;

public class Item
{
    public Point Location { get; private set; }
    public string Symbol => edible.Symbol;
    private IEdible edible;


    public Item(IEdible edible, Point location)
    {
        this.edible = edible;
        this.Location = location;
    }

    public void Eat (Snake eater, List<Snake> others, Grid grid)
        => edible.Eat(eater, others, grid);
}
