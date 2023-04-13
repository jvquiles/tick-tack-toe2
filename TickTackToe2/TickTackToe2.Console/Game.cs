namespace TickTackToe2.Console;

public class Game
{
    private string _board;

    public Game()
    {
        _board = "[ ][ ][ ]\n[ ][ ][ ]\n[ ][ ][ ]";
    }

    public string PrintBoard()
    {
        return _board;
    }

    public void Play(int x, int y)
    {
        _board = "[X][ ][ ]\n[ ][ ][ ]\n[ ][ ][ ]";
    }
}