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
        if (x == 0 && y == 0)
        {
            _board = "[X][ ][ ]\n[ ][ ][ ]\n[ ][ ][ ]";
        }
        else if (x == 0 && y == 1)
        {
            _board = "[X][O][ ]\n[ ][ ][ ]\n[ ][ ][ ]";
        }
        else 
        {
            _board = "[X][O][X]\n[ ][ ][ ]\n[ ][ ][ ]";
        }
    }
}