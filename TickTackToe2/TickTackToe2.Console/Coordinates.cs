namespace TickTackToe2.Console;

public class Coordinates
{
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
}