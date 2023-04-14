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
            game.Play(new Coordinates(0, 0));

            var board = game.PrintBoard();

            board.Should().Be("[X][ ][ ]\n[ ][ ][ ]\n[ ][ ][ ]");
        }

        [Test]
        public void PlaySecondMoveOnTopCenter()
        {
            var game = new Game();
            game.Play(new Coordinates(0, 0));
            game.Play(new Coordinates(0, 1));

            var board = game.PrintBoard();

            board.Should().Be("[X][O][ ]\n[ ][ ][ ]\n[ ][ ][ ]");
        }

        [Test]
        public void PlayThirdMoveOnTopRight()
        {
            var game = new Game();
            game.Play(new Coordinates(0, 0));
            game.Play(new Coordinates(0, 1));
            game.Play(new Coordinates(0, 2));

            var board = game.PrintBoard();

            board.Should().Be("[X][O][X]\n[ ][ ][ ]\n[ ][ ][ ]");
        }

        [Test]
        public void FailWhenPlayingOnTopLeftTwice()
        {
            var game = new Game();
            game.Play(new Coordinates(0, 0));

            var failPlay = () => game.Play(new Coordinates(0, 0));

            failPlay.Should().Throw<InvalidOperationException>();
        }
    }
}