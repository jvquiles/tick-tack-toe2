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

    public string GetStatus()
    {
        if (IsRowCompletedByX(0) || IsRowCompletedByX(1) || IsRowCompletedByX(2) 
            || IsColumnCompletedByX(0) || IsColumnCompletedByX(1) || IsColumnCompletedByX(2))
        {
            return "Player X wins";
        }

        return string.Empty;
    }

    private bool IsColumnCompletedByX(int column)
    {
        return _board[0, column] == Token.X && _board[1, column] == Token.X && _board[2, column] == Token.X;
    }

    private bool IsRowCompletedByX(int row)
    {
        return _board[row, 0] == Token.X && _board[row, 1] == Token.X && _board[row, 2] == Token.X;
    }
}