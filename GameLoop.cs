namespace Snake;

public class GameLoop
{
    Grid grid;
    List<Snake> snakes = new();

    List<Dictionary<ConsoleKey, Point>> keyMaps = new()
    {
        new () {
            { ConsoleKey.UpArrow, new Point(0, -1) },
            { ConsoleKey.DownArrow, new Point(0, 1) },
            { ConsoleKey.LeftArrow, new Point(-1, 0) },
            { ConsoleKey.RightArrow, new Point(1, 0) }
        },
        new () {
            { ConsoleKey.W, new Point(0, -1) },
            { ConsoleKey.S, new Point(0, 1) },
            { ConsoleKey.A, new Point(-1, 0) },
            { ConsoleKey.D, new Point(1, 0) }
        },
        new () {
            { ConsoleKey.I, new Point(0, -1) },
            { ConsoleKey.K, new Point(0, 1) },
            { ConsoleKey.J, new Point(-1, 0) },
            { ConsoleKey.L, new Point(1, 0) }
        },
    };

    public void Run()
    {
        grid = new Grid(new Point(20, 20));

        snakes.Add(new Snake("🟩", 4, new Point(0, 2), new Point(1, 0), keyMaps[0]));
        snakes.Add(new Snake("🟪", 4, new Point(0, 4), new Point(1, 0), keyMaps[1]));
        // snakes.Add(new Snake("3 ", new Point(0, 6), new Point(1, 0), keyMaps[2])
        //{
        //    CrashBehavior = new ShrinkAction(3),
        //});

        while (true) // Main game loop
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                foreach (Snake snake in snakes)
                    snake.Turn(key);
            }

            int deadSnakes = 0;
            foreach (Snake snake in snakes)
            {
                snake.Move(grid.Size);
                snake.CheckCollisions(snakes);

                List<Snake> others = new();
                foreach (var other in snakes)
                    if (other != snake)
                        others.Add(other);

                grid.TryEatFood(snake, others);

                //Console.WriteLine($"Score: {_scoreManager.Score}");
                if (snake.Dead) deadSnakes++;
            }

            grid.Render(snakes);

            if (deadSnakes == snakes.Count)
            {
                Console.WriteLine("Game Over!");
                break;
            }

            int fps = 10;
            Thread.Sleep(1000 / fps);
        }
    }
}
