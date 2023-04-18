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

        [Test]
        public void LetWinPlayerXByFirstRow()
        {
            var game = new Game();
            game.Play(new Coordinates(0, 0));
            game.Play(new Coordinates(1, 0));
            game.Play(new Coordinates(0, 1));
            game.Play(new Coordinates(1, 1));
            game.Play(new Coordinates(0, 2));

            var status = game.GetStatus();

            status.Should().Be("Player X wins");
        }

        [Test]
        public void LetWinPlayerXBySecondRow()
        {
            var game = new Game();
            game.Play(new Coordinates(1, 0));
            game.Play(new Coordinates(2, 0));
            game.Play(new Coordinates(1, 1));
            game.Play(new Coordinates(2, 1));
            game.Play(new Coordinates(1, 2));

            var status = game.GetStatus();

            status.Should().Be("Player X wins");
        }

        [Test]
        public void LetWinPlayerXByThirdRow()
        {
            var game = new Game();
            game.Play(new Coordinates(2, 0));
            game.Play(new Coordinates(0, 0));
            game.Play(new Coordinates(2, 1));
            game.Play(new Coordinates(0, 1));
            game.Play(new Coordinates(2, 2));

            var status = game.GetStatus();

            status.Should().Be("Player X wins");
        }

        [Test]
        public void LetWinPlayerXByFirstColumn()
        {
            var game = new Game();
            game.Play(new Coordinates(0, 0));
            game.Play(new Coordinates(0, 1));
            game.Play(new Coordinates(1, 0));
            game.Play(new Coordinates(1, 1));
            game.Play(new Coordinates(2, 0));

            var status = game.GetStatus();

            status.Should().Be("Player X wins");
        }

        [Test]
        public void LetWinPlayerXBySecondColumn()
        {
            var game = new Game();
            game.Play(new Coordinates(0, 1));
            game.Play(new Coordinates(0, 2));
            game.Play(new Coordinates(1, 1));
            game.Play(new Coordinates(1, 2));
            game.Play(new Coordinates(2, 1));

            var status = game.GetStatus();

            status.Should().Be("Player X wins");
        }

        [Test]
        public void LetWinPlayerXByThirdColumn()
        {
            var game = new Game();
            game.Play(new Coordinates(0, 2));
            game.Play(new Coordinates(0, 0));
            game.Play(new Coordinates(1, 2));
            game.Play(new Coordinates(1, 0));
            game.Play(new Coordinates(2, 2));

            var status = game.GetStatus();

            status.Should().Be("Player X wins");
        }
    }
}