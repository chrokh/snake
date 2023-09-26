using Snake.MoveBehaviors;
using Snake.TurnBehaviors;
using Snake.LengthBehaviors;
using Snake.CollisionBehaviors;

namespace Snake;

public class GameLoop
{
    Grid grid;
    List<Snake> snakes = new();

    List<KeyMap> keyMaps = new()
    {
        new(ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D),
        new(ConsoleKey.UpArrow, ConsoleKey.LeftArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow),
        new(ConsoleKey.I, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L),
    };

    public void Run()
    {
        grid = new Grid(new Point(20, 20));

        // Player 1
        snakes.Add(new Snake
            ("🟥"
            , 4
            , new Point(0, 3)
            , new Point(1, 0)
            , new RegularMoveBehavior()
            , new RegularTurnBehavior(keyMaps[0])
            , new GrowLengthBehavior()
            , new ShrinkLengthBehavior()
            , new DieCollisionBehavior()
            , new NoCollisionBehavior()
            ));

        // Player 2
        snakes.Add(new Snake
            ("🟦"
            , 4
            , new Point(0, grid.Size.Y - 4)
            , new Point(-1, 0)
            , new RegularMoveBehavior()
            , new RegularTurnBehavior(keyMaps[1])
            , new GrowLengthBehavior()
            , new ShrinkLengthBehavior()
            , new DieCollisionBehavior()
            , new NoCollisionBehavior()
            ));

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

            Thread.Sleep(1000 / Config.FPS);
        }
    }
}
