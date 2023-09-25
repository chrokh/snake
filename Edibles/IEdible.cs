namespace Snake;

public interface IEdible
{
    string Symbol { get; }
    void Eat (Snake eater, List<Snake> others, Grid grid);

}
