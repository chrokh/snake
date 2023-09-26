using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Snake;

public class Grid
{
    public Point Size { get; private set; }
    private List<Item> items = new();

    public Grid(Point size)
    {
        Size = size;
        SpawnItem(new Apple());
        SpawnItem(new Bomb());
        SpawnItem(new CountingApple(3, new Tree(3)));
        SpawnItem(new Attack(2));
        SpawnItem(new SuperSnake());
    }

    public void Render(IEnumerable<Snake> snakes)
    {
        // TODO: Dead snakes should be printed first so that others can be printed on top of them.
        string SymbolAtLocation(Point location)
        {
            string symbol = "· ";
            foreach (var snake in snakes)
                if (snake.Occupies(location))
                    symbol = snake.Symbol;
            foreach (var item in items)
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

    public bool TryEatFood(Snake eater, List<Snake> others)
    {
        Point snakeHead = eater.Head;
        foreach (var item in items)
            if (item.Location == snakeHead)
            {
                items.Remove(item);
                item.Eat(eater, others, this);
                break;
            }
        return false;
    }

    public List<Point> VacantPositions(List<Snake> snakes)
    {
        List<Point> excludes = new List<Point>();
        foreach (Snake snake in snakes)
            excludes.Add(snake.Head);
        foreach (Item item in items)
            excludes.Add(item.Location);

        // All possible positions except excludes
        var vacantPositions = new List<Point>();
        for (int y = 0; y < Size.Y; y++)
            for (int x = 0; x < Size.X; x++)
            {
                Point p = new Point(x, y);
                if (!excludes.Contains(p))
                    vacantPositions.Add(p);
            }
        return vacantPositions;
    }

    // If there are vacant positions, wraps the edible in an Item and adds it to the list of items.
    public void SpawnItem(IEdible edible)
    {
        var vacantPositions = VacantPositions(new List<Snake>());
        if (vacantPositions.Count > 0)
        {
            Random rand = new Random();
            int index = rand.Next(vacantPositions.Count);
            Point location = vacantPositions[index];
            items.Add(new Item(edible, location));
        }
    }
}
