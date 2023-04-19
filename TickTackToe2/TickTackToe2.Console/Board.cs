namespace TickTackToe2.Console;

public class Board
{
    private readonly Token[,] _board;

    public Board()
    {
        _board = new [,]
        {
            {Token.Empty, Token.Empty, Token.Empty},
            {Token.Empty, Token.Empty, Token.Empty},
            {Token.Empty, Token.Empty, Token.Empty}
        };
    }

    public Token Get(Coordinates coordinates)
    {
        return _board[coordinates.X, coordinates.Y];
    }

    public void Set(Coordinates coordinates, Token currentToken)
    {
        _board[coordinates.X, coordinates.Y] = currentToken;
    }
}