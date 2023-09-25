namespace Snake;

public class ScoreManager
{
    public int Score { get; private set; }

    public void IncrementScore()
    {
        Score++;
    }
}
