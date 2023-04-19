namespace TickTackToe2.Console;

public class Game
{
    private Token _currentToken;
    private readonly Board _board;

    public Game()
    {
        _currentToken = Token.X;
        _board = new Board();
    }

    public string PrintBoard()
    {
        return $"[{FormatToken(_board.Get(new Coordinates(0,0)))}][{FormatToken(_board.Get(new Coordinates(0,1)))}][{FormatToken(_board.Get(new Coordinates(0,2)))}]\n" +
               $"[{FormatToken(_board.Get(new Coordinates(1,0)))}][{FormatToken(_board.Get(new Coordinates(1,1)))}][{FormatToken(_board.Get(new Coordinates(1,2)))}]\n" +
               $"[{FormatToken(_board.Get(new Coordinates(2,0)))}][{FormatToken(_board.Get(new Coordinates(2,1)))}][{FormatToken(_board.Get(new Coordinates(2,2)))}]";
    }

    private string FormatToken(Token token)
    {
        return token switch
        {
            Token.O => "O",
            Token.X => "X",
            _ => " "
        };
    }

    public void Play(Coordinates coordinates)
    {
        if (_board.Get(coordinates) != Token.Empty)
        {
            throw new InvalidOperationException();
        }

        _board.Set(coordinates, _currentToken);
        _currentToken =_currentToken != Token.X ? Token.X : Token.O;
    }

    public Status GetStatus()
    {
        if (HasWon(Token.X))
        {
            return Status.PlayerXWins;
        }

        if (HasWon(Token.O))
        {
            return Status.PlayerOWins;
        }

        if (IsBoardFullyPlayed())
        {
            return Status.NoWinner;
        }
        
        return Status.NotFinished;
    }

    private bool IsBoardFullyPlayed()
    {
        return _board.Get(new Coordinates(0, 0)) != Token.Empty && _board.Get(new Coordinates(0, 1)) != Token.Empty && _board.Get(new Coordinates(0, 2)) != Token.Empty
               && _board.Get(new Coordinates(1, 0)) != Token.Empty && _board.Get(new Coordinates(1, 1)) != Token.Empty && _board.Get(new Coordinates(1, 2)) != Token.Empty
               && _board.Get(new Coordinates(2, 0)) != Token.Empty && _board.Get(new Coordinates(2, 1)) != Token.Empty && _board.Get(new Coordinates(2, 2)) != Token.Empty;
    }

    private bool HasWon(Token token)
    {
        return IsRowCompleted(token, 0) || IsRowCompleted(token, 1) || IsRowCompleted(token, 2) 
               || IsColumnCompleted(token, 0) || IsColumnCompleted(token, 1) || IsColumnCompleted(token, 2)
               || IsFirstDiagonalCompleted(token) || IsSecondDiagonalCompleted(token);
    }

    private bool IsSecondDiagonalCompleted(Token token)
    {
        return _board.Get(new Coordinates(0, 2)) == token && _board.Get(new Coordinates(1, 1)) == token && _board.Get(new Coordinates(2, 0)) == token;
    }

    private bool IsFirstDiagonalCompleted(Token token)
    {
        return _board.Get(new Coordinates(0, 0)) == token && _board.Get(new Coordinates(1, 1)) == token && _board.Get(new Coordinates(2, 2)) == token;
    }

    private bool IsColumnCompleted(Token token, int column)
    {
        return _board.Get(new Coordinates(0, column)) == token && _board.Get(new Coordinates(1, column)) == token && _board.Get(new Coordinates(2, column)) == token;
    }

    private bool IsRowCompleted(Token token, int row)
    {
        return _board.Get(new Coordinates(row, 0)) == token && _board.Get(new Coordinates(row, 1)) == token && _board.Get(new Coordinates(row, 2)) == token;
    }
}