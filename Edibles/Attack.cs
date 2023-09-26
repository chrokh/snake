namespace Snake;

public class Attack : IEdible
{
    public string Symbol => "🎯";

    private int pieces;

		public Attack(int pieces) => this.pieces = pieces;

    public void Eat(Snake eater, List<Snake> others, Grid grid)
    {
        eater.Grow();
        foreach (Snake other in others)
            other.Shrink(pieces);
    }
}