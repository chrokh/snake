namespace Snake;

public class CountingApple : IEdible
{
    public string Symbol => counter + " ";
    private int threshold;
    private int counter;
    private IEdible uponThreshold;

    public CountingApple(int threshold, IEdible uponThreshold) : this(threshold, uponThreshold, threshold) { }
    public CountingApple(int threshold, IEdible uponThreshold, int counter)
    {
        this.threshold = threshold;
        this.uponThreshold = uponThreshold;
        this.counter = counter;
    }

    public void Eat(Snake eater, List<Snake> others, Grid grid)
    {
        eater.Grow();
        if (counter <= 1)
        {
            grid.SpawnItem(uponThreshold);
            grid.SpawnItem(new CountingApple(threshold, uponThreshold));
        }
        else
        {
            grid.SpawnItem(new CountingApple(threshold, uponThreshold, counter - 1));
        }
    }
}
