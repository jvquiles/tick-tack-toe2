namespace TickTackToe2.Console;

public class Game
{
    private readonly Token[,] _board;
    private Token _currentToken;

    public Game()
    {
        _board = new [,] { {Token.Empty, Token.Empty, Token.Empty }, {Token.Empty, Token.Empty, Token.Empty}, {Token.Empty, Token.Empty, Token.Empty} };
        _currentToken = Token.X;
    }

    public string PrintBoard()
    {
        return $"[{FormatToken(_board[0, 0])}][{FormatToken(_board[0,1])}][{FormatToken(_board[0,2])}]\n" +
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

    public void Play(int x, int y)
    {
        _board[x, y] = _currentToken;
        _currentToken =_currentToken != Token.X ? Token.X : Token.O;
    }
}