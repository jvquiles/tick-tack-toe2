using FluentAssertions;
using TickTackToe2.Console;

namespace TickTackToe2.Tests
{
    public class GameShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShowInitialBoard()
        {
            var game = new Game();

            var board = game.PrintBoard();

            board.Should().Be("[ ][ ][ ]\n[ ][ ][ ]\n[ ][ ][ ]");
        }

        [Test]
        public void PlayFirstMoveOnTopLeft()
        {
            var game = new Game();
            game.Play(0, 0);

            var board = game.PrintBoard();

            board.Should().Be("[X][ ][ ]\n[ ][ ][ ]\n[ ][ ][ ]");
        }
    }
}