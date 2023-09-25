namespace Snake;

public class Edible
{
    public Point Location { get; private set; }
    public string Symbol { get; private set; }
    IEatBehavior eatBehavior;

    public Edible(string symbol, Point location, IEatBehavior eatBehavior)
    {
        Symbol = symbol;
        Location = location;
        this.eatBehavior = eatBehavior;
    }

    public void Eat (Grid grid, Snake snake)
        => this.eatBehavior.Eat(grid, snake);
}

public class EdibleFactory
{
    string symbol;
    IEatBehavior behavior;
    public EdibleFactory(string symbol, IEatBehavior behavior)
    {
        this.symbol = symbol;
        this.behavior = behavior;
    }
    
    public Edible Make(Point location)
        => new Edible(symbol, location, behavior);
}