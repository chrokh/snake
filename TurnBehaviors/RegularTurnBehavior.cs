using System;
using System.Diagnostics.CodeAnalysis;

namespace Snake.TurnBehaviors;

public class RegularTurnBehavior : ITurnBehavior
{
    private KeyMap keyMap;

    public RegularTurnBehavior(KeyMap keyMap)
    {
        this.keyMap = keyMap;
    }
    public Point Execute(Point currentDirection, ConsoleKey key)
    {
        if (key == keyMap.North)
            return new Point(0, -1);
        else if (key == keyMap.West)
            return new Point(-1, 0);
        else if (key == keyMap.South)
            return new Point(0, 1);
        else if (key == keyMap.East)
            return new Point(1, 0);
        else
            return currentDirection;
    }
}

