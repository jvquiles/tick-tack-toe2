namespace TickTackToe2.Console;

public class Game
{
    private readonly Token[,] _board;
    private Token _currentToken;

    public Game()
    {
        _board = new [,]
        {
            {Token.Empty, Token.Empty, Token.Empty},
            {Token.Empty, Token.Empty, Token.Empty},
            {Token.Empty, Token.Empty, Token.Empty}
        };
        _currentToken = Token.X;
    }

    public string PrintBoard()
    {
        return $"[{FormatToken(_board[0,0])}][{FormatToken(_board[0,1])}][{FormatToken(_board[0,2])}]\n" +
               $"[{FormatToken(_board[1,0])}][{FormatToken(_board[1,1])}][{FormatToken(_board[1,2])}]\n" +
               $"[{FormatToken(_board[2,0])}][{FormatToken(_board[2,1])}][{FormatToken(_board[2,2])}]";
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
        if (_board[coordinates.X, coordinates.Y] != Token.Empty)
        {
            throw new InvalidOperationException();
        }

        _board[coordinates.X, coordinates.Y] = _currentToken;
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
        
        return Status.NotFinised;
    }

    private bool HasWon(Token token)
    {
        return IsRowCompleted(token, 0) || IsRowCompleted(token, 1) || IsRowCompleted(token, 2) 
               || IsColumnCompleted(token, 0) || IsColumnCompleted(token, 1) || IsColumnCompleted(token, 2)
               || IsFirstDiagonalCompleted(token) || IsSecondDiagonalCompleted(token);
    }

    private bool IsSecondDiagonalCompleted(Token token)
    {
        return _board[0, 2] == token && _board[1, 1] == token && _board[2, 0] == token;
    }

    private bool IsFirstDiagonalCompleted(Token token)
    {
        return _board[0, 0] == token && _board[1, 1] == token && _board[2, 2] == token;
    }

    private bool IsColumnCompleted(Token token, int column)
    {
        return _board[0, column] == token && _board[1, column] == token && _board[2, column] == token;
    }

    private bool IsRowCompleted(Token token, int row)
    {
        return _board[row, 0] == token && _board[row, 1] == token && _board[row, 2] == token;
    }
}

public enum Status
{
    PlayerXWins,
    PlayerOWins,
    NotFinised
}