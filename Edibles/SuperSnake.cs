namespace Snake;

public class SuperSnake : IEdible
{
    public string Symbol { get; private set; } = "⭐️";
    public void Eat (Snake eater, List<Snake> others, Grid grid)
    {
        eater.Grow();
        throw new NotImplementedException();
        //eater.SetState(new TimedSnakeState(100, )
        //eater.Symbol = "🔥";
        //eater.CrashEffectOnOther = new DieBehavior();
        //eater.CrashEffectOnSelf = new NoBehavior();
    }
}