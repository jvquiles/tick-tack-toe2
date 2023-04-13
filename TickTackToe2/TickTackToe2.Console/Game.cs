namespace TickTackToe2.Console;

public class Game
{
    private readonly string[,] _board;
    private string _currentToken;

    public Game()
    {
        _board = new [,] { {" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "} };
        _currentToken = "X";
    }

    public string PrintBoard()
    {
        return $"[{_board[0,0]}][{_board[0,1]}][{_board[0,2]}]\n" +
               $"[{_board[1,0]}][{_board[1,1]}][{_board[1,2]}]\n" +
               $"[{_board[2,0]}][{_board[2,1]}][{_board[2,2]}]";
    }

    public void Play(int x, int y)
    {
        _board[x, y] = _currentToken;
        _currentToken = _currentToken == "X" ? "O" : "X";
    }
}