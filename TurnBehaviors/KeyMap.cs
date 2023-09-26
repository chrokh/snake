using System;
namespace Snake.TurnBehaviors;

public class KeyMap
{
    public ConsoleKey North { get; init; }
    public ConsoleKey West { get; init; }
    public ConsoleKey South { get; init; }
    public ConsoleKey East { get; init; }

    public KeyMap(ConsoleKey north, ConsoleKey west, ConsoleKey south, ConsoleKey east)
    {
        North = north;
        West = west;
        South = south;
        East = east;
    }
}

