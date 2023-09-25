namespace Snake;

public class Grid
{
    private int size;
    private Point food;

    public Grid(int size)
    {
        this.size = size;
        SpawnFood(new List<Point>());
    }

    public void Render(Snake snake)
    {
        Console.Clear();
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Point p = new Point(x, y);
                if (snake.Contains(p)) Console.Write("■ ");
                else if (p == food) Console.Write("🍎");
                else Console.Write("· ");
            }
            Console.WriteLine();
        }
    }

    public bool TryEatFood(Point snakeHead)
    {
        if (food == snakeHead)
        {
            SpawnFood(new List<Point> { snakeHead });
            return true;
        }
        return false;
    }

    private void SpawnFood(IEnumerable<Point> excludedPositions)
    {
        var vacantPositions = new List<Point>();
        for (int y = 0; y < size; y++)
            for (int x = 0; x < size; x++)
            {
                Point p = new Point(x, y);
                if (!excludedPositions.Contains(p))
                    vacantPositions.Add(p);
            }

        if (vacantPositions.Count == 0) return; // No vacant position to spawn food

        Random rand = new Random();
        int index = rand.Next(vacantPositions.Count);
        food = vacantPositions[index];
    }
}
