namespace Snake;

public class GameLoop
{
    Grid grid;
    Snake snake;
    public void Run()
    {
        snake = new Snake(5, 5);
        grid = new Grid(20);

        while (true) // Main game loop
        {
            Point direction = snake.Direction;
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                direction = key switch
                {
                    ConsoleKey.UpArrow => new Point(0, -1),
                    ConsoleKey.DownArrow => new Point(0, 1),
                    ConsoleKey.LeftArrow => new Point(-1, 0),
                    ConsoleKey.RightArrow => new Point(1, 0),
                    _ => direction
                };
            }

            if (!snake.Move(direction))
                break; // Break the loop if snake collides with itself

            if (grid.TryEatFood(snake.Head))
            {
                //_scoreManager.IncrementScore();
                snake.Grow();
            }

            grid.Render(snake);
            //Console.WriteLine($"Score: {_scoreManager.Score}");

            int fps = 10;
            Thread.Sleep(1000 / fps);
        }

        Console.WriteLine("Game Over!");
    }
}
