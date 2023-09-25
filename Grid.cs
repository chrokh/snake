using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Snake;

public class Grid
{
    public Point Size { get; private set;}
    private List<Edible> edibles = new();

    public Grid(Point size)
    {
        Size = size;
        var factory = new EdibleFactory("🍎", new GrowEatBehavior());
        SpawnItem(factory, new List<Point>());
    }

    public void Render(IEnumerable<Snake> snakes)
    {
        string SymbolAtLocation(Point location)
        {
            string symbol = "· ";
            foreach (var snake in snakes)
                if (snake.Occupies(location))
                    symbol = snake.Symbol;
            foreach (var item in edibles)
                if (item.Location == location)
                    symbol = item.Symbol;
            return symbol;
        }

        Console.Clear();
        // print grid with snake and items
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
                Console.Write(SymbolAtLocation(new Point(x, y)));
            Console.WriteLine();
        }
    }

    public bool TryEatFood(Snake snake)
    {
        Point snakeHead = snake.Head;
        foreach (var edible in edibles)
            if (edible.Location == snakeHead)
            {
                edibles.Remove(edible);
                edible.Eat(this, snake);
                break;
            }
        return false;
    }

    public void SpawnItem(EdibleFactory factory, IEnumerable<Point> excludedPositions)
    {
        List<Point> excludes = new List<Point>();
        foreach (Point point in excludedPositions)
            excludes.Add(point);
        foreach(Edible item in edibles)
            excludes.Add(item.Location);

        
        var vacantPositions = new List<Point>();
        for (int y = 0; y < Size.Y; y++)
            for (int x = 0; x < Size.X; x++)
            {
                Point p = new Point(x, y);
                if (!excludes.Contains(p))
                    vacantPositions.Add(p);
            }

        if (vacantPositions.Count > 0)
        {
            Random rand = new Random();
            int index = rand.Next(vacantPositions.Count);
            Point location = vacantPositions[index];
            edibles.Add(factory.Make(location));
        }
    }
}
